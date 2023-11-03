using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace EduTech.Pages.Examination
{
    public partial class MarksEntry : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();
            Edu.CheckSubjectPagePermission(Session["username"].ToString(), Request.QueryString["subject"].ToString(),Request.QueryString["ex"].ToString());
            SqlDataReader rdr;
            con = new SqlConnection();
            cmd = new SqlCommand();
            cmd.Connection = con;
            lblsubject.Text = Request.QueryString["subject"];
            lblexam.Text = Request.QueryString["exam"];
            con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
            txttheory.Enabled = true;
            txtprac.Enabled = true;
            try
            {
                con.Open();
                cmd.CommandText = "select * from HSE_11_ALLSUBJECTS where subject='" + Request.QueryString["subject"] + "'";
                rdr = cmd.ExecuteReader();
                if(rdr.HasRows)
                {
                    rdr.Read();
                if (Request.QueryString["code"] == "201")
                {
                    txtto.Text = rdr["TheoryU1"].ToString();
                    txtpo.Text = rdr["PracticalU1"].ToString();

                }
                else if (Request.QueryString["code"] == "202")
                {
                    txtto.Text = rdr["TheoryU2"].ToString();
                    txtpo.Text = rdr["PracticalU2"].ToString();
                }
                else if (Request.QueryString["code"] == "203")
                {
                    txtto.Text = rdr["TheoryT1"].ToString();
                    txtpo.Text = rdr["PracticalT1"].ToString();
                }
                else if (Request.QueryString["code"] == "204")
                {
                    txtto.Text = rdr["TheoryT2"].ToString();
                    txtpo.Text = rdr["PracticalT2"].ToString();
                }
                
                }
                rdr.Dispose();
                if (txtto.Text == "0")
                    txttheory.Enabled = false;
                if (txtpo.Text == "0")
                    txtprac.Enabled = false;
            }
               catch(Exception ex)
                {
                    lblmsg.Text = ex.Message;
                }
            finally
            {

                cmd.Dispose();
                con.Close();

            }
            }
            
           

     

        protected void cmdsearch_Click(object sender, EventArgs e)
        {
            int i,rolln;
            txtname.Text = "";
            txtstream.Text = "";
            txttheory.Text = "0";
            txtprac.Text = "0";
            lblmsg.Text = "";
            if (txtsearch.Text == "")
                lblmsg.Text = "Please Enter Roll Number..";
            else if (!int.TryParse(txtsearch.Text, out i))
            {
                lblmsg.Text = "Enter valid value for Roll Number..";
            }
            else
            {
                SqlConnection conn;
                SqlCommand cmnd;
                con = new SqlConnection();
                cmd = new SqlCommand();
               conn=new SqlConnection();
                cmnd=new SqlCommand();
                SqlDataReader rdr,rdrr;
                String sub,subj;
                sub= Request.QueryString["subject"];
                try
                {

                    con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                    con.Open();
                    cmd.Connection = con;
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                    conn.Open();
                    cmnd.Connection = conn;
                    cmd.CommandText = "select stdname,streamname from Subject_Det where stdrollno=" + int.Parse(txtsearch.Text) + " and (sub1='" + sub + "' or sub2='" + sub + "' or sub3='" + sub + "' or sub4='" + sub + "' or sub5='" + sub + "' or sub6='" + sub + "')";
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows == true)
                    {
                        rdr.Read();
                        txtname.Text = rdr["stdname"].ToString();
                        txtstream.Text = rdr["streamname"].ToString();
                        btnsave.Enabled = true;
                        txtsearch.Enabled = false;
                        rdr.Close();
                                                      
                          cmd.CommandText = "Select * from Subject_Det where STDROLLNO=" + int.Parse(txtsearch.Text) + "and SUB1='" + sub + "' or SUB2='" + sub + "' or SUB3='" + sub + "' or SUB4='" + sub + "' or SUB5='" + sub + "' or SUB6='" + sub + "'";
                          rdr = cmd.ExecuteReader();

                          while (rdr.Read())
                          {
                              rolln = int.Parse(rdr["STDROLLNO"].ToString());
                              for (i = 1; i <= 6; i++)
                              {
                                  subj = rdr["SUB" + i].ToString();
                                  if (subj == sub)
                                      break;
                              }



                              if (Request.QueryString["code"] == "201")
                              {
                                  cmnd.CommandText = "select S" + i + "TH,S" + i + "PR from HSE_11_U1MARKS where stdrollno=" + rolln;

                              }
                              else if (Request.QueryString["code"] == "202")
                              {
                                  cmnd.CommandText = "select S" + i + "TH,S" + i + "PR from HSE_11_U2MARKS where stdrollno=" + rolln;
                              }
                              else if (Request.QueryString["code"] == "203")
                              {
                                  cmnd.CommandText = "select S" + i + "TH,S" + i + "PR from HSE_11_T1MARKS where stdrollno=" + rolln;
                              }
                              else if (Request.QueryString["code"] == "204")
                              {
                                  cmnd.CommandText = "select S" + i + "TH,S" + i + "PR from HSE_11_T2MARKS where stdrollno=" + rolln;
                              }
                              rdrr = cmnd.ExecuteReader();

                              rdrr.Read();
                              if (rdrr.HasRows)
                              {

                                  txttheory.Text = rdrr[0].ToString();
                                  txtprac.Text = rdrr[1].ToString();

                              }
                              else
                              {
                                  txttheory.Text = "0";
                                  txtprac.Text = "0";
                              }

                              rdrr.Close();
                          }
                    }
                    else
                        lblmsg.Text = "No such student found..";
                    rdr.Dispose();

                }
                catch (Exception ex)
                {
                    lblmsg.Text = ex.Message;
                }
                finally
                {

                    cmd.Dispose();
                    con.Close();
                    
                    cmnd.Dispose();
                    conn.Close();

                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            int i;
            int [] st=new int[7];
            int [] sp=new int[7];
            int flag = 0;
            SqlDataReader rdr;
        
            if (!int.TryParse(txtprac.Text, out i) || (!int.TryParse(txttheory.Text, out i)) || int.Parse(txttheory.Text)>int.Parse(txtto.Text) || int.Parse(txtprac.Text)>int.Parse(txtpo.Text))
            {
                lblmsg.Text = "Enter valid Marks..";
            }
             else
            {
                SqlConnection conn;
                SqlCommand cmnd;
                conn = new SqlConnection();
                cmnd = new SqlCommand();
                con=new SqlConnection();
                cmd = new SqlCommand();

                try
                {
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                    conn.Open();
                    cmnd.Connection = conn;
                    con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from HSE_11_SUBJECTS where stdrollno=" + int.Parse(txtsearch.Text);
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        rdr.Read();
                        for (i = 1; i <= 6; i++)
                        {
                            if (rdr[i].ToString() == lblsubject.Text)
                            {
                                st[i] = int.Parse(txttheory.Text);
                                sp[i] = int.Parse(txtprac.Text);
                                break;
                            }
                        }
                        rdr.Close();
                        if (Request.QueryString["code"] == "201")
                        {
                            cmnd.CommandText = "select * from HSE_11_U1MARKS where stdrollno=" + int.Parse(txtsearch.Text);
                            rdr = cmnd.ExecuteReader();
                            if (rdr.HasRows)
                                cmd.CommandText = "update HSE_11_U1MARKS set S1TH=" + st[1] + ",S1PR=" + sp[1] + ",S2TH=" + st[2] + ",S2PR=" + sp[2] + ",S3TH=" + st[3] + ",S3PR=" + sp[3] + ",S4TH=" + st[4] + ",S4PR=" + sp[4] + ",S5TH=" + st[5] + ",S5PR=" + sp[5] + ",S6TH=" + st[6] + ",S6PR=" + sp[6] + " where stdrollno=" + int.Parse(txtsearch.Text);
                            else
                            {
                                flag = 1;
                                cmd.CommandText = "insert into HSE_11_U1MARKS values(" + int.Parse(txtsearch.Text) + "," + st[1] + "," + sp[1] + "," + st[2] + "," + sp[2] + "," + st[3] + "," + sp[3] + "," + st[4] + "," + sp[4] + "," + st[5] + "," + sp[5] + "," + st[6] + "," + sp[6] + ")";
                            }
                            rdr.Close();
                        }
                        else if (Request.QueryString["code"] == "202")
                        {
                            cmnd.CommandText = "select * from HSE_11_U2MARKS where stdrollno=" + int.Parse(txtsearch.Text);
                            rdr = cmnd.ExecuteReader();
                            if (rdr.HasRows)
                                cmd.CommandText = "update HSE_11_U2MARKS set S1TH=" + st[1] + ",S1PR=" + sp[1] + ",S2TH=" + st[2] + ",S2PR=" + sp[2] + ",S3TH=" + st[3] + ",S3PR=" + sp[3] + ",S4TH=" + st[4] + ",S4PR=" + sp[4] + ",S5TH=" + st[5] + ",S5PR=" + sp[5] + ",S6TH=" + st[6] + ",S6PR=" + sp[6] + " where stdrollno=" + int.Parse(txtsearch.Text);
                            else
                            {
                                flag = 1;
                                cmd.CommandText = "insert into HSE_11_U2MARKS values(" + int.Parse(txtsearch.Text) + "," + st[1] + "," + sp[1] + "," + st[2] + "," + sp[2] + "," + st[3] + "," + sp[3] + "," + st[4] + "," + sp[4] + "," + st[5] + "," + sp[5] + "," + st[6] + "," + sp[6] + ")";
                            }
                            rdr.Close();
                        }
                        else if (Request.QueryString["code"] == "203")
                        {
                            cmnd.CommandText = "select * from HSE_11_T1MARKS where stdrollno=" + int.Parse(txtsearch.Text);
                            rdr = cmnd.ExecuteReader();
                            if (rdr.HasRows)
                                cmd.CommandText = "update HSE_11_T1MARKS set S1TH=" + st[1] + ",S1PR=" + sp[1] + ",S2TH=" + st[2] + ",S2PR=" + sp[2] + ",S3TH=" + st[3] + ",S3PR=" + sp[3] + ",S4TH=" + st[4] + ",S4PR=" + sp[4] + ",S5TH=" + st[5] + ",S5PR=" + sp[5] + ",S6TH=" + st[6] + ",S6PR=" + sp[6] + " where stdrollno=" + int.Parse(txtsearch.Text);
                            else
                            {
                                flag = 1;
                                cmd.CommandText = "insert into HSE_11_T1MARKS values(" + int.Parse(txtsearch.Text) + "," + st[1] + "," + sp[1] + "," + st[2] + "," + sp[2] + "," + st[3] + "," + sp[3] + "," + st[4] + "," + sp[4] + "," + st[5] + "," + sp[5] + "," + st[6] + "," + sp[6] + ")";
                            }
                            rdr.Close();
                        }
                        else if (Request.QueryString["code"] == "204")
                        {
                            cmnd.CommandText = "select * from HSE_11_T2MARKS where stdrollno=" + int.Parse(txtsearch.Text);
                            rdr = cmnd.ExecuteReader();
                            if (rdr.HasRows)
                                cmd.CommandText = "update HSE_11_T2MARKS set S1TH=" + st[1] + ",S1PR=" + sp[1] + ",S2TH=" + st[2] + ",S2PR=" + sp[2] + ",S3TH=" + st[3] + ",S3PR=" + sp[3] + ",S4TH=" + st[4] + ",S4PR=" + sp[4] + ",S5TH=" + st[5] + ",S5PR=" + sp[5] + ",S6TH=" + st[6] + ",S6PR=" + sp[6] + " where stdrollno=" + int.Parse(txtsearch.Text);
                            else
                            {
                                flag = 1;
                                cmd.CommandText = "insert into HSE_11_T2MARKS values(" + int.Parse(txtsearch.Text) + "," + st[1] + "," + sp[1] + "," + st[2] + "," + sp[2] + "," + st[3] + "," + sp[3] + "," + st[4] + "," + sp[4] + "," + st[5] + "," + sp[5] + "," + st[6] + "," + sp[6] + ")";
                            }
                            rdr.Close();
                        }
                        cmd.ExecuteNonQuery();
                        
                        if (flag == 1)
                            lblmsg.Text = "Record Saved Successfully..";
                        else
                            lblmsg.Text = "Record Updated Successfully..";
                       
                        txtsearch.Text = "";
                        txtsearch.Enabled = true;
                        txtname.Text = "";
                        txtstream.Text = "";
                        txttheory.Text = "0";
                        txtprac.Text = "0";
                        rdr.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    lblmsg.Text = ex.Message;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                    cmnd.Dispose();
                    conn.Close();
                }
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {

            txtsearch.Text = "";
            txtsearch.Enabled = true;
            txtname.Text = "";
            txtstream.Text = "";
            txttheory.Text = "0";
            txtprac.Text = "0";
            lblmsg.Text = "";
        }

        protected void txttheory_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(txttheory.Text, out i))
            {
                if (int.Parse(txttheory.Text) < (0.36 * int.Parse(txtto.Text)))
                {
                    lblmsg.Text = "Student is failing..";
                }
                else
                    lblmsg.Text = "";
            }
        }

        protected void txtprac_TextChanged(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(txtprac.Text, out i))
            {
                if (int.Parse(txtprac.Text) < (0.36 * int.Parse(txtpo.Text)))
                {
                    lblmsg.Text = "Student is failing..";
                }
                else
                    lblmsg.Text = "";
            }
        }

       
    }
}