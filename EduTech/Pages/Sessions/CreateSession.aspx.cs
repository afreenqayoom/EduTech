using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using System.Xml;

namespace EduTech.Pages.Sessions
{
    public partial class CreateSession : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();
            Edu.CheckPagePermission(Session["username"].ToString(), "CREATE_SESSION");
        }

        protected void btncreate_click(object sender, EventArgs e)
        {
            SqlDataReader rdr;
            int i;
            if (txtses.Text == "")
                lblerr.Text = "Enter Session..";
            else if (!int.TryParse(txtses.Text, out i) || int.Parse(txtses.Text)<2000)
                lblerr.Text = "Enter Valid Session";
            else
            {
               try
               {
                    con = new SqlConnection();
                    cmd = new SqlCommand();
                    con.ConnectionString = con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from HSE_11_SESSIONS where SESSIONNAME=" + int.Parse(txtses.Text);
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        lblerr.Text = "Session already present..";

                        rdr.Close();
                        rdr.Dispose();
                    }
                    else
                    {
                        rdr.Close();
                        rdr.Dispose();
                        copydatabase();
                        cmd.CommandText = "insert into HSE_11_SESSIONS values(" + int.Parse(txtses.Text) + ")";
                        cmd.ExecuteNonQuery();
                        
                        System.IO.Directory.CreateDirectory(Server.MapPath("~/Images/STD_Photos/") + int.Parse(txtses.Text));
                        createconnstring();
                        lblerr.Text = "Session Created..";
                    }
                }
                catch (Exception ex)
                {
                    lblerr.Text = ex.Message;
                }
                finally
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
        }
       
        public void copydatabase()
        {
            Server server = new Server("(local)");
            server.ConnectionContext.Connect();
            Database database = server.Databases["Edutech-Template"];
            Database ddatabase = new Database(server, "EduTech-" + txtses.Text);
            ddatabase.Create();
            Transfer transfer = new Transfer(database);
            transfer.CopyAllObjects = true;
            transfer.CopyAllDefaults = true;
            
            
            //transfer.DropDestinationObjectsFirst = true;
            transfer.CopySchema = true;
            transfer.CopyData = true;
            transfer.DestinationServer = "(local)";
            transfer.CreateTargetDatabase = true;
           
            transfer.DestinationDatabase = "EduTech-" + txtses.Text;
            transfer.Options.IncludeIfNotExists = true;
            transfer.Options.ContinueScriptingOnError = true;
            transfer.TransferData();
            server = null;
            
            
        }
        public void createconnstring()
        {
            XmlNode node;
            XmlNodeList list;
            XmlAttribute attribute;
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/Web.Config"));
            list = doc.DocumentElement.SelectNodes("connectionStrings");
            node = doc.CreateNode(XmlNodeType.Element, "add", null);
            attribute = doc.CreateAttribute("name");
            attribute.Value = "dbcon" + txtses.Text;
            node.Attributes.Append(attribute);
            attribute = doc.CreateAttribute("connectionString");
            attribute.Value = "server=(local);database=EduTech-" + txtses.Text + ";uid=SPHS;password=1234;";
            node.Attributes.Append(attribute);
            doc.DocumentElement.SelectNodes("connectionStrings")[0].AppendChild(node);
            doc.Save(Server.MapPath("~/Web.Config"));
            
            
        }
        

        }
    
   
}