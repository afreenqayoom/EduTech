using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace EduTech.Pages
{
    public partial class ViewSubdet : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();
            Edu.CheckPagePermission(Session["username"].ToString(), "SUBJECT_WISE_DETAILS");
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

        protected void ddstream_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            if (chkrno.Checked == false)
            {
                Response.Redirect("~/Pages/Printpreview.aspx?code=" + Request.QueryString["code"] + "&subject=" + ddsubjects.Text + "&rollno=-1");

            }
            else
            {
                Response.Redirect("~/Pages/Printpreview.aspx?code=" + Request.QueryString["code"] + "&subject=" + ddsubjects.Text + "&rollno=" + txtrollno.Text);
            }
        }
    }
}