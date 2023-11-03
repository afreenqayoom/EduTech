using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EduTech.Pages.Admission
{
    public partial class Viewreport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();
            if(Request.QueryString["code"]=="100")
                Edu.CheckPagePermission(Session["username"].ToString(), "ENROLL_SHEET");
            else if (Request.QueryString["code"] == "101")
                Edu.CheckPagePermission(Session["username"].ToString(), "ADM_EXAM_CARD");
            else if (Request.QueryString["code"] == "102")
                Edu.CheckPagePermission(Session["username"].ToString(), "ICARD");
            else if (Request.QueryString["code"] == "103")
                Edu.CheckPagePermission(Session["username"].ToString(), "SPORTS_FORM");
            else if (Request.QueryString["code"] == "104")
                Edu.CheckPagePermission(Session["username"].ToString(), "Library_Form");
            else if (Request.QueryString["code"] == "105")
                Edu.CheckPagePermission(Session["username"].ToString(), "ADM_REGISTER");
            else if (Request.QueryString["code"] == "107")
                Edu.CheckPagePermission(Session["username"].ToString(), "ATT_SHEET");
            else if (Request.QueryString["code"] == "109")
                Edu.CheckPagePermission(Session["username"].ToString(), "BONAFIDE_CERT");
            else if (Request.QueryString["code"] == "110")
                Edu.CheckPagePermission(Session["username"].ToString(), "DISCHARGE_CERT");
        }

        protected void btnview_Click(object sender, EventArgs e)
        {
            if (chkrno.Checked == false)
            {
                Response.Redirect("~/Pages/Printpreview.aspx?code=" + Request.QueryString["code"] + "&stream=" + ddstream.Text + "&rollno=-1");

            }
            else 
            {
                if (txtrollno.Text == "")
                    lblerr.Text = "Enter Roll Number..";
                else
                Response.Redirect("~/Pages/Printpreview.aspx?code=" + Request.QueryString["code"] + "&stream=" + ddstream.Text + "&rollno=" + txtrollno.Text);
            }
        }
    }
}