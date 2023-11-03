using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
namespace EduTech.Pages.Sessions
{
    public partial class ChangeSession : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();
            Edu.CheckPagePermission(Session["username"].ToString(), "CHANGE_SESSION");
            
            try
            {
                con = new SqlConnection();
                cmd = new SqlCommand();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from HSE_11_SESSIONS order by SESSIONNAME desc";
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ddsession.Items.Add(rdr["SESSIONNAME"].ToString());
                }
                rdr.Dispose();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                cmd.Dispose();
                con.Close();
            }
        }

        protected void btnok_Click(object sender, EventArgs e)
        {
            Session["conyr"] = Convert.ToInt32(ddsession.Text);
            lblerr.Text = "Session changed to " + Session["conyr"];
            
        }
    }
}