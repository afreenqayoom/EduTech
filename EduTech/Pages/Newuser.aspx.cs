using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace EduTech.Pages
{
    public partial class Newuser : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();
            if(Edu.UserType(Session["username"].ToString())!="Administrator")
                Response.Redirect("~/Pages//Error.aspx?Err=Access denied. You don't have the permission to view this page.");
            con = new SqlConnection();
            cmd = new SqlCommand();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
           
                try
                {
                    con.Open();
                    cmd.Connection = con;
                    if (!IsPostBack)
                    {
                        cmd.CommandText = "select * from HSE_11_ALLSUBJECTS";
                        rdr = cmd.ExecuteReader();
                        TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[0].ChildNodes.Clear();
                        TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[1].ChildNodes.Clear();
                        TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[2].ChildNodes.Clear();
                        TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[3].ChildNodes.Clear();
                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[0].ChildNodes.Add(new TreeNode(rdr["SUBJECT"].ToString()));
                                TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[1].ChildNodes.Add(new TreeNode(rdr["SUBJECT"].ToString()));
                                TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[2].ChildNodes.Add(new TreeNode(rdr["SUBJECT"].ToString()));
                                TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[3].ChildNodes.Add(new TreeNode(rdr["SUBJECT"].ToString()));
                            }

                        }
                        rdr.Close();
                    }

                }
                catch (Exception ex)
                {
                    lblerr.Text = ex.Message;
                }
                finally
                {
                   
                    con.Close();
                }
            
        }

        protected void btncreate_Click(object sender, EventArgs e)
        {
            int[] options=new int[17];
            con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            for (int x = 0; x < 10; x++)
            {
                if (TreeView1.Nodes[0].ChildNodes[0].ChildNodes[x].Checked == true)
                    options[x] = 1;
                else
                    options[x] = 0;
            }
            if (TreeView1.Nodes[0].ChildNodes[0].ChildNodes[10].ChildNodes[0].Checked  == true)
                options[10] = 1;
            if (TreeView1.Nodes[0].ChildNodes[0].ChildNodes[10].ChildNodes[1].Checked  == true)
                options[11] = 1;
            if (TreeView1.Nodes[0].ChildNodes[1].ChildNodes[0].Checked  == true)
                options[12] = 1;
            if (TreeView1.Nodes[0].ChildNodes[1].ChildNodes[2].Checked  == true)
                options[13] = 1;
            if (TreeView1.Nodes[0].ChildNodes[1].ChildNodes[3].Checked  == true)
                options[14] = 1;
            if (TreeView1.Nodes[0].ChildNodes[2].ChildNodes[0].Checked  == true)
                options[15] = 1;
            if (TreeView1.Nodes[0].ChildNodes[2].ChildNodes[1].Checked  == true)
                options[16] = 1;
            
            try
            {
                con.Open();
                cmd.CommandText = "select userid from useraccounts where userid='" + txtuname.Text + "'";
                rdr=cmd.ExecuteReader();
                    if(rdr.HasRows)
                    {
                        lblerr.Text="Username already exists....";
                        rdr.Close();
                    }
                    else
                    {
                        rdr.Close();
                        
                        cmd.CommandText="insert into useraccounts values('" + txtuname.Text + "','" + txtpass.Text + "','" + ddaccount.Text + "')";
                        cmd.ExecuteNonQuery();

                        cmd.CommandText="insert into user_form_privileges values('" + txtuname.Text + "'," + options[0] + "," + options[1] + "," 
                                    + options[2]+ "," + options[3] + "," + options[4] + "," + options[5] + "," + options[6] + ","
                                    + options[7] + "," + options[8] + "," + options[9] + "," + options[10] + "," + options[11] + "," + options[12] + "," 
                                    +options[13] +  "," + options[14] + "," + options[15] + "," + options[16]  + ")";
                        cmd.ExecuteNonQuery();

                        for (int y = 0; y < TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[0].ChildNodes.Count; y++)
                        {
                            if (TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[0].ChildNodes[y].Checked == true)
                            {
                                cmd.CommandText = "insert into user_subject_privileges values('" + txtuname.Text + "','" + TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[0].ChildNodes[y].Text + "','" + "U1')";
                                cmd.ExecuteNonQuery();
                            }
                            if (TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[1].ChildNodes[y].Checked == true)
                            {
                                cmd.CommandText = "insert into user_subject_privileges values('" + txtuname.Text + "','" + TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[1].ChildNodes[y].Text + "','" + "U2')";
                                cmd.ExecuteNonQuery();
                            }
                            if (TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[2].ChildNodes[y].Checked == true)
                            {
                                cmd.CommandText = "insert into user_subject_privileges values('" + txtuname.Text + "','" + TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[2].ChildNodes[y].Text + "','" + "T1')";
                                cmd.ExecuteNonQuery();
                            }
                            if (TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[3].ChildNodes[y].Checked == true)
                            {
                                cmd.CommandText = "insert into user_subject_privileges values('" + txtuname.Text + "','" + TreeView1.Nodes[0].ChildNodes[1].ChildNodes[1].ChildNodes[3].ChildNodes[y].Text + "','" + "T2')";
                                cmd.ExecuteNonQuery();
                            }
                        }

                        lblerr.Text="User created successfully...";
                        
                    }
            }
            catch(Exception ex)
            {
                lblerr.Text=ex.Message;
            }
            finally
            {
                     con.Close();
            }
        }
       
    }
}