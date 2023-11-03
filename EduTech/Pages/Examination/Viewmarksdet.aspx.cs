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
    public partial class Viewmarksdet : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader rdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();
            Edu.CheckPagePermission(Session["username"].ToString(), "VIEW_MARKS");
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

        

        protected void btnview_Click1(object sender, EventArgs e)
        {
            if (chkrno.Checked == false)
            {
                if (chkmarks.Checked == true)
                    Response.Redirect("~/Pages/Printpreview.aspx?code=" + Request.QueryString["code"] + "&subject=" + ddsubjects.Text + "&rollno=-1&marks=0");
                else
                    Response.Redirect("~/Pages/Printpreview.aspx?code=" + Request.QueryString["code"] + "&subject=" + ddsubjects.Text + "&rollno=-1&marks=1");
            }
            else
            {
                if (txtrollno.Text == "")
                {
                    lblerr.Text = "Enter Roll Number..";
                }
                else
                {
                    if (chkmarks.Checked == true)
                        Response.Redirect("~/Pages/Printpreview.aspx?code=" + Request.QueryString["code"] + "&subject=" + ddsubjects.Text + "&rollno=" + txtrollno.Text + "&marks=0");
                    else
                        Response.Redirect("~/Pages/Printpreview.aspx?code=" + Request.QueryString["code"] + "&subject=" + ddsubjects.Text + "&rollno=" + txtrollno.Text + "&marks=1");
                }
            }
        }
    }
}