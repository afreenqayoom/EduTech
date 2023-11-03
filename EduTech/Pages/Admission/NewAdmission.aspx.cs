using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;




namespace EduTech.Pages.Admission
{
    public partial class NewAdmission : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();
            //btnchoose.Attributes.Add("onclick", "document.getElementById('" + FileUpload1.ClientID + "').click()");
            Edu.CheckPagePermission(Session["username"].ToString(), "NEW_ADM");
            if (!IsPostBack)
            {
                FileUpload1.Attributes.Add("onchange", "document.getElementById('" + btnchoose.ClientID + "').click()");
                ddstream_SelectedIndexChanged(sender, e);
                ddsub4_SelectedIndexChanged(sender, e);
                ddsub5_SelectedIndexChanged(sender, e);
                filldefaults();

            }
          
        }
        protected void btnchoose_Click(object sender, EventArgs e)
        {
            if (FileUpload1.PostedFile != null)
            {
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/Images/Temp/STDRNO_" + int.Parse(txtrno.Text) + ".jpg"));
                img.ImageUrl = "~/Images/Temp/STDRNO_" + int.Parse(txtrno.Text) + ".jpg";

            }

        }

        protected void ddstream_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddsub1.Items.Clear();
            ddsub2.Items.Clear();
            ddsub3.Items.Clear();
            ddsub4.Items.Clear();
            ddsub5.Items.Clear();
            ddsub6.Items.Clear();
            ddsub1.Items.Add("ENGLISH");
            ddsub1.Text = ddsub1.Items[0].Text;
            ddsub1.Enabled = false;
            if (ddstream.SelectedIndex == 0)
            {

                ddsub2.Items.Add("PHYSICS");
                ddsub2.Text = ddsub2.Items[0].Text;
                ddsub2.Enabled = false;
                ddsub3.Items.Add("CHEMISTRY");
                ddsub3.Text = ddsub3.Items[0].Text;
                ddsub3.Enabled = false;
                ddsub4.Items.Add("BIOLOGY");
                ddsub4.Items.Add("MATHEMATICS");
                ddsub4.Items.Add("STATISTICS");
                ddsub4.Items.Add("GEOLOGY");
                ddsub4_SelectedIndexChanged(sender, e);
                ddsub5_SelectedIndexChanged(sender, e);
                ddsub6_SelectedIndexChanged(sender, e);

            }
            else if (ddstream.SelectedIndex == 1)
            {
                ddsub2.Items.Add("ACCOUNTANCY");
                ddsub2.Text = ddsub2.Items[0].Text;
                ddsub2.Enabled = false;
                ddsub3.Items.Add("BUSINESS STUDIES");
                ddsub3.Text = ddsub3.Items[0].Text;
                ddsub3.Enabled = false;

                ddsub4.Items.Add("ENTREPRENEURSHIP");
                ddsub4.Items.Add("ECONOMICS");
            }

            else if (ddstream.SelectedIndex == 2)
            {


                ddsub2.Items.Add("Urdu");
                ddsub2.Items.Add("Economics");
                ddsub2.Items.Add("Mathematics");
                ddsub2.Items.Add("Education");
                ddsub2.Items.Add("History");
                ddsub2.Items.Add("Pol.Science");
                ddsub2.Items.Add("Statistics");
                ddsub2.Items.Add("Hindi");
                ddsub2.Items.Add("Arabic");
                ddsub2.Items.Add("Geography");
                ddsub2.Items.Add("Philosphy");
                ddsub2.Items.Add("Psychology");


                ddsub2.Enabled = true;
                ddsub3.Enabled = true;





            }

        }
        protected void ddsub4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddsub5.Items.Clear();
            ddsub6.Items.Clear();
            if (ddstream.SelectedIndex == 0)
            {
                             
                    ddsub5.Items.Add("MATHEMATICS");                  
                    ddsub5.Items.Add("INFORMATION PRACTICE");
                    ddsub5.Items.Add("ENVIRONMENTAL SCIENCE");
                    ddsub5.Items.Add("FUNCTIONAL ENGLISH");
                    ddsub5.Items.Add("PHYSICAL EDUCATION");
                    if (ddsub4.SelectedIndex == 0 || ddsub4.SelectedIndex==1 || ddsub4.SelectedIndex==2)
                    {
                        ddsub5.Items.Add("GEOLOGY");
                        ddsub5.Items.Add("BIOTECHNOLOGY");
                        ddsub5.Items.Add("BIOCHEMISTRY");
                    }
                    if (ddsub4.SelectedIndex == 1)
                        ddsub5.Items.RemoveAt(0);
                  
                    if (ddsub4.SelectedIndex == 3 || ddsub4.SelectedIndex==1)
                    {
                        ddsub5.Items.Add("BIOLOGY");
                        ddsub5.Items.Add("STATISTICS");
                        ddsub5.Items.Add("GEOGRAPHY");
                    }
               }
            else if (ddstream.SelectedIndex == 1)
            {

               
            ddsub5.Items.Add("STENO");
            ddsub5.Items.Add("BUSINESS MATH");
            ddsub5.Items.Add("INFORMATION PRACTICE");
            ddsub5.Items.Add("ENVIRONMENTAL SCIENCE");
            ddsub5.Items.Add("FUNCTIONAL ENGLISH");
            ddsub5.Items.Add("PHYSICAL EDUCATION");

            }
            else if (ddstream.SelectedIndex == 2)
            {
                
            ddsub5.Items.Add("IP");
            ddsub5.Items.Add("EVS");
            ddsub5.Items.Add("Func.Eng");
            ddsub5.Items.Add("Phy Edu");
            ddsub5.Items.Add("History");
            ddsub5.Items.Add("Statistics");
            }
        }

        protected void ddsub5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddsub6.Items.Clear();
            ddsub6.Items.Add("NONE");
            if (ddstream.SelectedIndex == 0)
            {
                ddsub6.Items.Add("MATHEMATICS");
                ddsub6.Items.Add("INFORMATION PRACTICE");
                ddsub6.Items.Add("ENVIRONMENTAL SCIENCE");
                ddsub6.Items.Add("FUNCTIONAL ENGLISH");
                ddsub6.Items.Add("PHYSICAL EDUCATION");
                ddsub6.Items.Add("GEOLOGY");
                ddsub6.Items.Add("BIOTECHNOLOGY");
                ddsub6.Items.Add("BIOCHEMISTRY");
                ddsub6.Items.Add("BIOLOGY");
                ddsub6.Items.Add("STATISTICS");
                ddsub6.Items.Add("GEOGRAPHY");

            }
            else if (ddstream.SelectedIndex == 1)
            {
                ddsub6.Items.Add("ENTREPRENEURSHIP");
                ddsub6.Items.Add("ECONOMICS");
                ddsub6.Items.Add("STENO");
                ddsub6.Items.Add("BUSINESS MATH");
                ddsub6.Items.Add("INFORMATION PRACTICE");
                ddsub6.Items.Add("ENVIRONMENTAL SCIENCE");
                ddsub6.Items.Add("FUNCTIONAL ENGLISH");
                ddsub6.Items.Add("PHYSICAL EDUCATION");
                
            }
            ddsub6.Items.Remove(ddsub4.Text);
            ddsub6.Items.Remove(ddsub5.Text);

            ddsub6.SelectedIndex = 0;
            
           
        }

        protected void ddsub2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddsub3.Items.Clear();
            ddsub3.Items.Add("Urdu");
            ddsub3.Items.Add("Economics");
            ddsub3.Items.Add("Mathematics");
            ddsub3.Items.Add("Education");
            ddsub3.Items.Add("History");
            ddsub3.Items.Add("Pol.Science");
            ddsub3.Items.Add("Statistics");
            ddsub3.Items.Add("Hindi");
            ddsub3.Items.Add("Arabic");
            ddsub3.Items.Add("Geography");
            ddsub3.Items.Add("Philosphy");
            ddsub3.Items.Add("Psychology");
            ddsub3.Items.Remove(ddsub2.Text);
            if(ddsub2.Text=="Hindi")
                ddsub3.Items.Remove("Urdu");
        }

        protected void ddsub3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddsub4.Items.Clear();

            ddsub4.Items.Add("Urdu");
            ddsub4.Items.Add("Economics");
            ddsub4.Items.Add("Mathematics");
            ddsub4.Items.Add("Education");
            ddsub4.Items.Add("History");
            ddsub4.Items.Add("Pol.Science");
            ddsub4.Items.Add("Statistics");
            ddsub4.Items.Add("Hindi");
            ddsub4.Items.Add("Arabic");
            ddsub4.Items.Add("Geography");
            ddsub4.Items.Add("Philosphy");
            ddsub4.Items.Add("Psychology");
            ddsub4.Items.Add("IP");
            ddsub4.Items.Remove(ddsub2.Text);
            ddsub4.Items.Remove(ddsub3.Text);
            if (ddsub2.Text == "Hindi" || ddsub3.Text=="Hindi")
                ddsub4.Items.Remove("Urdu");
        }

        protected void ddsub6_SelectedIndexChanged(object sender, EventArgs e)
        {
         

        }


         public  void filldefaults()
         {
        int year,i;
        ddsession.Items.Clear();
        for(year=Convert.ToInt32(Session["conyr"]);year>= 2010;year--)
        {
            ddsession.Items.Add("Annual Regular " + year);
            ddsession.Items.Add("Annual Private " + year);
            ddsession.Items.Add("Bi-Annual " + year);
        }

        ddoutof.Items.Add("500");
        ddresult.Items.Add("Qualified");
        ddresult.Items.Add("QBI");

        for (i = 1; i <= 20; i++)
        {
            if (i < 10)
                ddstreamno.Items.Add("0" + i);
            else
                ddstreamno.Items.Add("" + i);
        }

        ddcategory.Items.Add("GENERAL");
        ddcategory.Items.Add("SC");
        ddcategory.Items.Add("ST");
        ddcategory.Items.Add("RBA");
        ddcategory.Items.Add("PHYSICALLY HANDICAPPED");
        ddcategory.Items.Add("OTHERS");
         }

         protected void btnsave_Click(object sender, EventArgs e)
         {
             string stream,strid;
             con = new SqlConnection();
             Student std;
             std = new Student();
             int amount,rno;
             cmd = new SqlCommand();
             SqlDataReader rdr;
             if (txtrno.Text == "")
                 lblmes.Text = "Please Enter Roll Number";
             else if (ddsub1.Text == "" || ddsub2.Text == "" || ddsub3.Text == "" || ddsub4.Text == "" || ddsub5.Text == "" || ddsub6.Text == "")
             {
                 lblmes.Text = "Enter all subjects";
             }
             else
             {
                 rno = int.Parse(txtrno.Text);
                 stream = std.search(int.Parse(txtrno.Text));
                 if (stream != "")
                 {
                     update(rno);

                 }
                 else
                 {
                    try
                     {

                         con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                         con.Open();

                         stream = ddstream.Text;
                         cmd.Connection = con;
                         cmd.CommandText = "select * from HSE_11_STREAMS where STREAMNAME= '" + stream.ToUpper() + "'";
                         rdr = cmd.ExecuteReader();
                         rdr.Read();
                         strid = rdr["STREAMID"].ToString();
                         rdr.Dispose();
                         cmd.CommandText = "insert into HSE_11_PERDETAILS values('" + txtadmno.Text + "'," + rno + ",'" + txtboardrno.Text + "','" + ddstreamno.Text + "','" +
                             txtname.Text + "','" + txtfather.Text + "','" + txtmother.Text + "','" + txtdob.Text + "','" + txtperadd.Text + "','" + txtcoradd.Text + "','" + txtmobno.Text + "','" +
                             txtresno.Text + "','" + txtpno.Text + "','" + ddcategory.Text + "','" + strid + "')";
                         cmd.ExecuteNonQuery();
                         if (txtamt.Text == "")
                             amount = 0;
                         else
                             amount = int.Parse(txtamt.Text);

                         cmd.CommandText = "insert into HSE_11_FEEDETAILS values(" + int.Parse(txtrno.Text) + ",'" + txtrecieptno.Text + "','" + txtdate.Text + "'," + amount + ")";
                         cmd.ExecuteNonQuery();

                         cmd.CommandText = "insert into HSE_11_BOARDDETAILS values(" + int.Parse(txtrno.Text) + ",'" + txtboardreg.Text + "','" + txtboardrno.Text + "','" + ddsession.Text + "','" +
                             txtmarks.Text + "','" + ddoutof.Text + "','" + ddresult.Text + "','" + txtremarks.Text + "')";
                         cmd.ExecuteNonQuery();

                         cmd.CommandText = "insert into HSE_11_SUBJECTS values(" + int.Parse(txtrno.Text) + ",'" + ddsub1.Text + "','" + ddsub2.Text + "','" + ddsub3.Text + "','" + ddsub4.Text + "','" +
                             ddsub5.Text + "','" + ddsub6.Text + "')";
                         cmd.ExecuteNonQuery();
                    
                         if (img.ImageUrl != "")
                         File.Move(Server.MapPath("~/Images/Temp/STDRNO_" + int.Parse(txtrno.Text) + ".jpg"), Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + int.Parse(txtrno.Text) + ".jpg"));

                         lblmes.Text = "New Record Added..";
                     }


                     catch (Exception ex)
                     {
                         lblmes.Text = ex.Message;
                     }
                     finally
                     {
                         cmd.Dispose();
                         con.Close();
                     }
                 }
             }
         }

         protected void btnnewrec_Click(object sender, EventArgs e)
         {
              Response.Redirect("NewAdmission.aspx");
             
         }

         protected void cmdsearch_Click(object sender, EventArgs e)
         {
             Student s;
             s=new Student();
             string stream;
             int rollno,i;
             lblmes.Text = "";
             if (txtsearch.Text == "")
                 lblmes.Text = "Please Enter Roll Number.";
             else if (!int.TryParse(txtsearch.Text, out i))
             {
                 lblmes.Text = "Enter valid value for Roll Number..";
             }
             else
             {
                 rollno = int.Parse(txtsearch.Text);
                 stream = s.search(rollno);
                 if (stream == "")
                     lblmes.Text = "Invalid Rollnumber..No such student found.";
                 else
                 {
                     txtrno.Enabled = false;
                     ddstream.Text = stream;
                     ddstream_SelectedIndexChanged(sender, e);
                     ddsub4_SelectedIndexChanged(sender, e);
                     ddsub5_SelectedIndexChanged(sender, e);
                        viewdet(stream, rollno);


                 }
             }
         }

        protected void viewdet(string stream, int rollno)
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            SqlDataReader rdr;
            
           
            try
            {
                
                  con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from HSE_11_PERDETAILS where STDROLLNO =" + rollno;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        txtadmno.Text = rdr["ADMNO"].ToString();
                        txtrno.Text = rollno.ToString();
                        txtbrno.Text = rdr["11THBRNO"].ToString();
                        ddstreamno.Text = rdr["STREAMNO"].ToString();
                        txtname.Text = rdr["STDNAME"].ToString();
                        txtfather.Text = rdr["FATHER"].ToString();
                        txtmother.Text = rdr["MOTHER"].ToString();
                        txtdob.Text = rdr["DOB"].ToString();
                        txtperadd.Text = rdr["PADDR"].ToString();
                        txtcoradd.Text = rdr["CADDR"].ToString();
                        txtmobno.Text = rdr["MOBNO"].ToString();
                        txtresno.Text = rdr["RESINO"].ToString();
                        txtpno.Text = rdr["PGNO"].ToString();
                        ddcategory.Text = rdr["CATEGORY"].ToString();
                    }
                

                }
                rdr.Dispose();
                cmd.CommandText = "select * from HSE_11_FEEDETAILS where STDROLLNO =" + rollno;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        txtrecieptno.Text = rdr["BANKRECNO"].ToString();
                        txtdate.Text = rdr["DATED"].ToString();
                        txtamt.Text = rdr["AMOUNT"].ToString();

                    }
                }
                rdr.Dispose();
                cmd.CommandText = "select * from HSE_11_SUBJECTS where STDROLLNO =" + rollno;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    
                    while (rdr.Read())
                    {
                        ddsub1.Text = rdr["SUB1"].ToString();
                        ddsub2.Text = rdr["SUB2"].ToString();
                        ddsub3.Text = rdr["SUB3"].ToString();
                        ddsub4.Text = rdr["SUB4"].ToString();
                        ddsub5.Text = rdr["SUB5"].ToString();
                        ddsub6.Text = rdr["SUB6"].ToString();

                    }
                    
                }
                rdr.Dispose();
                cmd.CommandText = "select * from HSE_11_BOARDDETAILS where STDROLLNO =" + rollno;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows==true)
                {
                    while (rdr.Read())
                    {
                        txtboardreg.Text = rdr["BOARDREGNO"].ToString();
                        txtboardrno.Text = rdr["BOARDROLLNO"].ToString();
                        ddsession.Text = rdr["SES"].ToString();
                        txtmarks.Text = rdr["MARKS"].ToString();
                        ddoutof.Text = rdr["OUTOF"].ToString();
                        ddresult.Text = rdr["RESULT"].ToString();
                        txtremarks.Text = rdr["REMARKS"].ToString();
                    }
                    rdr.Dispose();
                }
               
               String strpath = Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/") + "STDRNO_" + rollno + ".jpg";
                if (File.Exists(strpath))
                {
                 
                    img.ImageUrl = "~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + rollno + ".jpg";
                   

                }
                else
                    img.ImageUrl = "";
            }
            catch(Exception ex)
            {
                lblmes.Text = ex.Message;
            }
            finally
           {
               
               cmd.Dispose();
               con.Close();
            }

        }


        void update(int rollno)
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            SqlDataReader rdr;
            String strpath,stemp;
            string strid;
            int amount;
            
            try
            {
            
                con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select STREAMID from HSE_11_STREAMS where STREAMNAME='" + ddstream.Text  + "'";
                rdr = cmd.ExecuteReader();
                rdr.Read();
                strid = rdr["STREAMID"].ToString();
                rdr.Dispose();
                cmd.CommandText = "update HSE_11_PERDETAILS set ADMNO ='" + txtadmno.Text + "', [11THBRNO] ='" + txtbrno.Text + "', STREAMNO ='" +
                   ddstreamno.Text + "', STDNAME='" + txtname.Text + "', FATHER='" + txtfather.Text + "', MOTHER='" + txtmother.Text + "', DOB='" + txtdob.Text + "',PADDR='" + txtperadd.Text + "', CADDR='" +
                   txtcoradd.Text + "', MOBNO='" + txtmobno.Text + "', RESINO='" + txtresno.Text + "', PGNO='" + txtpno.Text + "', CATEGORY='" + ddcategory.Text + "',STREAMID='" + strid + "' where STDROLLNO=" + rollno;
                cmd.ExecuteNonQuery();
                if (txtamt.Text == "")
                    amount = 0;
                else
                    amount = int.Parse(txtamt.Text);

                cmd.CommandText = "update HSE_11_FEEDETAILS set BANKRECNO='" + txtrecieptno.Text + "', DATED='" + txtdate.Text + "', AMOUNT=" + int.Parse(txtamt.Text) + " where STDROLLNO=" + rollno;
                cmd.ExecuteNonQuery();

                cmd.CommandText = "update HSE_11_BOARDDETAILS set BOARDREGNO='" + txtboardreg.Text + "', BOARDROLLNO='" + txtboardrno.Text + "',SES='" + ddsession.Text + "',MARKS='" + txtmarks.Text + "', OUTOF='" + ddoutof.Text +
                    "', RESULT='" + ddresult.Text + "', REMARKS='" + txtremarks.Text + "' where STDROLLNO=" + rollno;
                cmd.ExecuteNonQuery();


                cmd.CommandText = "update HSE_11_SUBJECTS set SUB1='" + ddsub1.Text + "', SUB2='" + ddsub2.Text + "', SUB3='" +
                    ddsub3.Text + "',SUB4='" + ddsub4.Text + "',SUB5='" + ddsub5.Text + "', SUB6='" + ddsub6.Text + "' where STDROLLNO=" + rollno;
                cmd.ExecuteNonQuery();
                
               
                    strpath = Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + rollno + ".jpg");
                    stemp = Server.MapPath("~/Images/Temp/STDRNO_" + int.Parse(txtrno.Text) + ".jpg");
                    if (img.ImageUrl != "" &&  File.Exists(stemp))
                    {
                        if (File.Exists(strpath))
                            File.Replace(Server.MapPath("~/Images/Temp/STDRNO_" + int.Parse(txtrno.Text) + ".jpg"), Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + int.Parse(txtrno.Text) + ".jpg"), null);
                        else
                            File.Move(Server.MapPath("~/Images/Temp/STDRNO_" + int.Parse(txtrno.Text) + ".jpg"), Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + int.Parse(txtrno.Text) + ".jpg"));
                    }
                
                lblmes.Text = "Record updated..";
                

          }
            catch (Exception ex)
            {
                lblmes.Text = ex.Message;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }
        

        protected void btndel_Click(object sender, EventArgs e)
        {
            string stream;
            int rno;
            Student s;
            
             s = new Student();
             if (txtrno.Text == "")
                 lblmes.Text = "Enter Rollno..";
             else
             {
                 rno = int.Parse(txtrno.Text);
                 stream = s.search(rno);
                 if (stream == "")
                     lblmes.Text = "No such student found..";
                 else
                 {
                     con = new SqlConnection();
                     cmd = new SqlCommand();
                     try
                     {
                         con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                         con.Open();
                         cmd.Connection = con;
                         cmd.CommandText = "delete from HSE_11_PERDETAILS where STDROLLNO=" + rno;
                         cmd.ExecuteNonQuery();

                         cmd.CommandText = "delete from HSE_11_BOARDDETAILS where STDROLLNO=" + rno;
                         cmd.ExecuteNonQuery();

                         cmd.CommandText = "delete from HSE_11_FEEDETAILS where STDROLLNO=" + rno;
                         cmd.ExecuteNonQuery();

                         cmd.CommandText = "delete from HSE_11_SUBJECTS where STDROLLNO=" + rno;
                         cmd.ExecuteNonQuery();
                         String strpath = Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/") + "STDRNO_" + rno+ ".jpg";
                         if (File.Exists(strpath))
                             File.Delete(Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + rno + ".jpg"));
                         lblmes.Text = "Student Record Deleted..";
                         Response.Redirect("NewAdmission.aspx");

                     }
                     catch (Exception ex)
                     {
                         lblmes.Text = ex.Message;
                     }
                     finally
                     {
                         cmd.Dispose();
                         con.Close();
                     }

                 }
             }
        }

    }


    public partial class Student : System.Web.UI.Page
    {
        SqlConnection conn;
        SqlCommand cmnd;
        SqlDataReader rder;
        public string search(int rno)
        {
            
            string st;
            st="";
           
            
           
            conn = new SqlConnection();
            cmnd = new SqlCommand();
            try
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                conn.Open();
                cmnd.Connection = conn;
               
                    cmnd.CommandText = "select * from STUDENT_STREAM where STDROLLNO=" + rno;

                    rder = cmnd.ExecuteReader();
                    if (rder.HasRows == true)
                    {
                        rder.Read();
                        st = rder["STREAMNAME"].ToString();
                        
                        
                    }
                    
                        rder.Dispose();
                                               
                         
                             
            }
            catch
            {
                
            }
            finally
            {
                
                cmnd.Dispose();
                conn.Close();
                
            }

            return st;
        }

        
    }
}