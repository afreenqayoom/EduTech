using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EduTech.MasterPages
{
    
    public partial class Webmaster : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();
            lblsession.Text = "Session: " + Session["conyr"].ToString();
        }
    }
}