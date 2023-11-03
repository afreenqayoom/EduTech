using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace EduTech
{
    public partial class _Default : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;
        int yr;
        protected void Page_Load(object sender, EventArgs e)
        {
           
          
            
        }

        protected void cmdlogin_Click(object sender, EventArgs e)
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            
            Boolean flag;

            flag = false;

            
             
               
             


            try
            {
               
                
              
                con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select max(SESSIONNAME) from HSE_11_SESSIONS";
                yr = Convert.ToInt32(cmd.ExecuteScalar());
                Session["conyr"] = yr;
                cmd.CommandText = "select * from useraccounts where userid='" + txtuname.Text + "' and userpass='" + txtpassword.Text + "'";

                
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    flag = true;
                    Session["username"] = txtuname.Text;
                    
                }
                else
                {
                    lblmsg.Text = "Invalid Username or Password.";
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Connection problem..";
            }
            finally
            {

                cmd.Dispose();
                con.Close();
            }
            if(flag==true)
            Response.Redirect("Pages/home.aspx");
           
        }
    }
}
