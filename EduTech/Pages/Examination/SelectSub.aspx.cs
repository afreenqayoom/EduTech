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
    public partial class SelectSub : System.Web.UI.Page
    {
         SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();   
            con = new SqlConnection();
            cmd = new SqlCommand();
            try
            {

                con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select SUBJECT from HSE_11_ALLSUBJECTS";
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows == true)
                {
                    while (rdr.Read())
                    {
                        ddsubjects.Items.Add(rdr["SUBJECT"].ToString());
                    }
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

        protected void btnview_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Examination/MarksEntry.aspx?subject=" + ddsubjects.Text + "&code=" + Request.QueryString["code"] + "&exam=" + Request.QueryString["exam"] + "&ex=" + Request.QueryString["ex"]);
        }
    }
}