using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;


namespace EduTech
{
    public partial class Changepass : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();
        }

        protected void btnchange_Click(object sender, EventArgs e)
        {
            con = new SqlConnection();
            cmd = new SqlCommand();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from USERACCOUNTS where USERID='" + Session["username"] + "' and USERPASS='" + txtold.Text + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Close();
                    if (txtpass.Text == "" || txtrpass.Text == "")
                        lblerr.Text = "Enter all fields..";
                    else
                    {
                        cmd.CommandText = "update USERACCOUNTS set USERPASS='" + txtpass.Text + "' where USERID='" + Session["username"] + "'";
                        cmd.ExecuteNonQuery();
                        lblerr.Text = "Password changed sucessfully..";
                    }
                }
                else
                {
                    rdr.Close();
                    lblerr.Text = "Wrong old password..";

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
    }
}