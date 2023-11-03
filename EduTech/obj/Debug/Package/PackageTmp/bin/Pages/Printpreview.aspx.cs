using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
namespace EduTech.Pages
{
    public partial class Printpreview : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        ReportDocument rpt;
        EduDataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
            Edu.CheckSession();
            con = new SqlConnection();
            cmd = new SqlCommand();
            rpt = new ReportDocument();
            ds = new EduDataSet();
            SqlDataAdapter adpt;
            DataTable dt;
            Boolean flag=false;
            
            
 
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                con.Open();
                  if (Request.QueryString["code"] == "100")
                {
                    
                      cmd.Connection = con;

                    if (Request.QueryString["Rollno"] == "-1")
                        cmd.CommandText = "Select * from Admission_Register where STREAMNAME='" + Request.QueryString["stream"].ToUpper() + "' order by STDROLLNO asc";
                    else
                        cmd.CommandText = "Select * from Admission_Register where STREAMNAME='" + Request.QueryString["stream"].ToUpper() + "' and  stdrollno=" + int.Parse(Request.QueryString["rollno"]);
                    adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(ds.Tables["AdmReg"]);
                    rpt.Load(Server.MapPath("~/Reports/Admission/EnrollmentSheet.rpt"));
                    if (ds.Tables["AdmReg"].Rows.Count > 0)
                        rpt.SetDataSource(ds.Tables["AdmReg"]);
                    else
                        flag = true;
                  
                    
                    

                    
                }
               
                else if (Request.QueryString["code"] == "101")
                {
                    
                    DataColumn col; 
                    cmd.Connection = con;

                    if (Request.QueryString["Rollno"] == "-1")
                        cmd.CommandText = "Select * from Adm_Card where STREAMNAME='" + Request.QueryString["stream"] + "' order by STDROLLNO asc";
                    else
                        cmd.CommandText = "Select * from Adm_Card where STREAMNAME='" + Request.QueryString["stream"] + "' and stdrollno=" + int.Parse(Request.QueryString["rollno"]);
                    adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(ds.Tables["AdmCard"]);
                  //  col = new DataColumn();
                    //col.DataType = System.Type.GetType("System.Byte[]");
                    //col.ColumnName = "STDIMG";
                   
                    // dtrow=new DataRow();
                    foreach (DataRow dtrow in ds.Tables["AdmCard"].Rows)
                    {

                        Edu.LoadImage(dtrow, Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + dtrow["STDROLLNO"] + ".jpg"));
                    }
                    rpt.Load(Server.MapPath("~/Reports/Admission/Admissioncard.rpt"));
                    if (ds.Tables["AdmCard"].Rows.Count > 0)
                        rpt.SetDataSource(ds.Tables["AdmCard"]);
                    else
                        flag = true;
 
                }
                  else if(Request.QueryString["code"]=="102")
                  {
                      SqlConnection conn;
                      SqlCommand  cmnd;
                      TextObject txtobj;
                      SqlDataReader rdr,rdrr;
                      DataColumn col;
                     // DataRow dtrow;
                      conn = new SqlConnection();
                      cmnd = new SqlCommand();
                      int i=1;
                      conn.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                      conn.Open();
                      cmd.Connection = con;
                      cmnd.Connection = conn;
                      if (Request.QueryString["Rollno"] == "-1")
                          cmd.CommandText = "select * from Admission_Register where streamname='" + Request.QueryString["stream"] + "' order by STDROLLNO asc";
                      else
                          cmd.CommandText = "select * from Admission_Register where streamname='" + Request.QueryString["stream"] + "' and stdrollno=" + int.Parse(Request.QueryString["rollno"]);
                      adpt = new SqlDataAdapter(cmd);
                      adpt.Fill(ds.Tables["IdentityCard"]);
                      rdr = cmd.ExecuteReader();
                     /* col = new DataColumn();
                      col.DataType = System.Type.GetType("System.Byte[]");
                      col.ColumnName = "STDIMG";
                      ds.Tables[0].Columns.Add(col);*/
                     // dtrow=new DataRow();
                       foreach(DataRow dtrow in ds.Tables["IdentityCard"].Rows)
                       {
                           
                           Edu.LoadImage(dtrow, Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + dtrow["STDROLLNO"] + ".jpg"));
                       }
                       rpt.Load(Server.MapPath("~/Reports/Admission/IdentityCard.rpt"));
                       if (ds.Tables["IdentityCard"].Rows.Count > 0)
                           rpt.SetDataSource(ds.Tables["IdentityCard"]);
                       else
                           flag = true;
                      while (rdr.Read())
                      {

                          i = 1;
                          while (i != 6)
                          {
                              cmnd.CommandText = "select subabbr from HSE_11_ALLSUBJECTS where subject='" + rdr["sub" + i] + "'";
                              rdrr = cmnd.ExecuteReader();
                              txtobj = rpt.ReportDefinition.Sections["Section3"].ReportObjects["txts" + i] as TextObject;
                              rdrr.Read();
                              if (rdrr.HasRows)
                                  txtobj.Text = rdrr["subabbr"].ToString();
                              else
                                  txtobj.Text = "";
                              i = i + 1;
                              rdrr.Dispose();
                              cmnd.Dispose();
                          }
                      }
                   
                     
                      
                      conn.Close();
                  }
                else if (Request.QueryString["code"] == "103")
                {

                    cmd.Connection = con;

                    if (Request.QueryString["Rollno"] == "-1")
                        cmd.CommandText = "Select * from Library_Sports where STREAMNAME='" + Request.QueryString["stream"] + "' order by STDROLLNO asc";
                    else
                        cmd.CommandText = "Select * from Library_Sports where STREAMNAME='" + Request.QueryString["stream"] + "' and stdrollno=" + int.Parse(Request.QueryString["rollno"]);
                    adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(ds.Tables["Library"]);
                    rpt.Load(Server.MapPath("~/Reports/Admission/Sports.rpt"));
                    foreach (DataRow dtrow in ds.Tables["Library"].Rows)
                    {

                        Edu.LoadImage(dtrow, Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + dtrow["STDROLLNO"] + ".jpg"));
                    }
                    if (ds.Tables["Library"].Rows.Count > 0)
                        rpt.SetDataSource(ds.Tables["Library"]);
                    else
                        flag = true;

                    
                }

                else if (Request.QueryString["code"] == "104")
                {

                    cmd.Connection = con;

                    if (Request.QueryString["Rollno"] == "-1")
                        cmd.CommandText = "Select * from Library_Sports where STREAMNAME='" + Request.QueryString["stream"] + "' order by STDROLLNO asc";
                    else
                        cmd.CommandText = "Select * from Library_Sports where STREAMNAME='" + Request.QueryString["stream"] + "' and  stdrollno=" + int.Parse(Request.QueryString["rollno"]);
                    adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(ds.Tables["Library"]);
                    foreach (DataRow dtrow in ds.Tables["Library"].Rows)
                    {

                        Edu.LoadImage(dtrow, Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + dtrow["STDROLLNO"] + ".jpg"));
                    }
                    rpt.Load(Server.MapPath("~/Reports/Admission/Library.rpt"));
                    if (ds.Tables["Library"].Rows.Count > 0)
                        rpt.SetDataSource(ds.Tables["Library"]);
                    else
                        flag = true;
                    
                    

                    
                }
                else if (Request.QueryString["code"] == "105")
                {
                    cmd.Connection = con;

                    if (Request.QueryString["Rollno"] == "-1")
                        cmd.CommandText = "Select * from Admission_Register where STREAMNAME='" + Request.QueryString["stream"].ToUpper() + "' order by STDROLLNO asc";
                    else
                        cmd.CommandText = "Select * from Admission_Register where STREAMNAME='" + Request.QueryString["stream"].ToUpper() + "' and  stdrollno=" + int.Parse(Request.QueryString["rollno"]);
                    adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(ds.Tables["AdmReg"]);
                    foreach (DataRow dtrow in ds.Tables["AdmReg"].Rows)
                    {

                        Edu.LoadImage(dtrow, Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + dtrow["STDROLLNO"] + ".jpg"));
                    }
                    rpt.Load(Server.MapPath("~/Reports/Admission/AdmissionRegister.rpt"));
                    if (ds.Tables["AdmReg"].Rows.Count > 0)
                        rpt.SetDataSource(ds.Tables["AdmReg"]);
                    else
                        flag = true;

                }
                  else if (Request.QueryString["code"] == "106")
                  {
                      TextObject txtobj;
                      
                      cmd.Connection = con;
                      string sub;
                      sub = Request.QueryString["subject"];
                      if (Request.QueryString["Rollno"] == "-1")
                          cmd.CommandText = "Select * from Subject_Det where SUB1='" + sub + "' or SUB2='" + sub + "' or SUB3='" + sub + "' or SUB4='" + sub + "' or SUB5='" + sub + "' or SUB6='" + sub + "' order by STDROLLNO asc";
                      else
                          cmd.CommandText = "Select * from Subject_Det where stdrollno=" + int.Parse(Request.QueryString["rollno"]) + " and (SUB1='" + sub + "' or SUB2='" + sub + "' or SUB3='" + sub + "' or SUB4='" + sub + "' or SUB5='" + sub + "' or SUB6='" + sub + "')";
                      adpt = new SqlDataAdapter(cmd);
                      adpt.Fill(ds.Tables["Subject_Det"]);
                      rpt.Load(Server.MapPath("~/Reports/Admission/SubjectDetails.rpt"));
                      if (ds.Tables["Subject_Det"].Rows.Count > 0)
                          rpt.SetDataSource(ds.Tables["Subject_Det"]);
                      else
                          flag = true;
                      txtobj = rpt.ReportDefinition.Sections["Section2"].ReportObjects["txtsub"] as TextObject;
                      txtobj.Text = Request.QueryString["subject"];
                  }
                  else if (Request.QueryString["code"] == "107")
                  {
                      cmd.Connection = con;

                      if (Request.QueryString["Rollno"] == "-1")
                          cmd.CommandText = "Select * from Admission_Register where STREAMNAME='" + Request.QueryString["stream"].ToUpper() + "' order by STDROLLNO asc";
                      else
                          cmd.CommandText = "Select * from Admission_Register where STREAMNAME='" + Request.QueryString["stream"].ToUpper() + "' and  stdrollno=" + int.Parse(Request.QueryString["rollno"]);
                      adpt = new SqlDataAdapter(cmd);
                      adpt.Fill(ds.Tables["AdmReg"]);
                      foreach (DataRow dtrow in ds.Tables["AdmReg"].Rows)
                      {

                          Edu.LoadImage(dtrow, Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + dtrow["STDROLLNO"] + ".jpg"));
                      }
                      rpt.Load(Server.MapPath("~/Reports/Admission/AttendanceSheet.rpt"));
                      if (ds.Tables["AdmReg"].Rows.Count > 0)
                          rpt.SetDataSource(ds.Tables["AdmReg"]);
                      else
                          flag = true;

                  }
                  else if (Request.QueryString["code"] == "108")
                  {
                      Edu.CheckPagePermission(Session["username"].ToString(), "MICROPACK");
                      int count=0,sum=0;
                      TextObject txtob;
                      SqlConnection conn;
                      SqlDataReader rdr;
                      SqlCommand cmnd;
                      conn = new SqlConnection();
                      cmnd = new SqlCommand();
                      
                      conn.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                      conn.Open();
                      cmd.Connection = con;
                      cmnd.Connection = conn;
                      dt = new DataTable();
                     
                     
        
                      cmd.CommandText = "select * from HSE_11_ALLSUBJECTS";
                      rdr = cmd.ExecuteReader();
                      
                       dt.Columns.Add("SUBJECT",typeof(String));
                     dt.Columns.Add("SUBABBR",typeof(String));
                     dt.Columns.Add("STRENGTH", count.GetType());
                      while (rdr.Read())
                      {
                     
                         
                          cmnd.CommandText = "select count(STDROLLNO) from HSE_11_SUBJECTS where sub1='" + rdr["SUBJECT"] + "' or sub2='" + rdr["SUBJECT"] + "' or sub3='" + rdr["SUBJECT"] + "' or sub4='" + rdr["SUBJECT"] + "' or sub5='" + rdr["SUBJECT"] + "' or sub6='" + rdr["SUBJECT"] + "'";
                       
                          count = Convert.ToInt32(cmnd.ExecuteScalar());
                          sum = sum + count;
                          dt.Rows.Add(rdr["SUBJECT"],rdr["SUBABBR"],count);
                          
                        cmnd.Dispose();

                      }
                     
                      ds.Tables["Micropack"].Merge(dt);
                      
                      rpt.Load(Server.MapPath("~/Reports/Admission/Micropack.rpt"));
                      if (ds.Tables["Micropack"].Rows.Count > 0)
                          rpt.SetDataSource(ds.Tables["Micropack"]);
                      txtob = rpt.ReportDefinition.Sections["Section4"].ReportObjects["txttotal"] as TextObject;
                      txtob.Text = sum.ToString();
                      conn.Close();
                  }
                  else if (Request.QueryString["code"] == "109")
                  {
                      TextObject txtobj;
                      cmd.Connection = con;

                      if (Request.QueryString["Rollno"] == "-1")
                          cmd.CommandText = "Select * from Certificate_Det where STREAMNAME='" + Request.QueryString["stream"] + "' order by STDROLLNO asc";
                      else
                          cmd.CommandText = "Select * from Certificate_Det where STREAMNAME='" + Request.QueryString["stream"] + "' where stdrollno=" + int.Parse(Request.QueryString["rollno"]);
                      adpt = new SqlDataAdapter(cmd);
                      adpt.Fill(ds.Tables["Certificate"]);
                      foreach (DataRow dtrow in ds.Tables["Certificate"].Rows)
                      {

                          Edu.LoadImage(dtrow, Server.MapPath("~/Images/STD_Photos/" + Session["conyr"] + "/STDRNO_" + dtrow["STDROLLNO"] + ".jpg"));
                      }
                      rpt.Load(Server.MapPath("~/Reports/Certificates/Bonafide.rpt"));
                      if (ds.Tables["Certificate"].Rows.Count > 0)
                          rpt.SetDataSource(ds.Tables["Certificate"]);
                      else
                          flag = true;
                      txtobj = rpt.ReportDefinition.Sections["Section3"].ReportObjects["txtdate"] as TextObject;
                      txtobj.Text = DateTime.Today.ToString();
                     
                  }
                  else if (Request.QueryString["code"] == "110")
                  {
                      TextObject txtobj;
                      cmd.Connection = con;

                      if (Request.QueryString["Rollno"] == "-1")
                          cmd.CommandText = "Select * from Certificate_Det where STREAMNAME='" + Request.QueryString["stream"] + "' order by STDROLLNO asc";
                      else
                          cmd.CommandText = "Select * from Certificate_Det where STREAMNAME='" + Request.QueryString["stream"] + "' where stdrollno=" + int.Parse(Request.QueryString["rollno"]);
                      adpt = new SqlDataAdapter(cmd);
                      adpt.Fill(ds.Tables["Certificate"]);
                     
                      rpt.Load(Server.MapPath("~/Reports/Certificates/Discharge.rpt"));
                      if (ds.Tables["Certificate"].Rows.Count > 0)
                          rpt.SetDataSource(ds.Tables["Certificate"]);
                      else
                          flag = true;
                      txtobj = rpt.ReportDefinition.Sections["Section3"].ReportObjects["txtdate"] as TextObject;
                      txtobj.Text = DateTime.Today.ToString();
                      txtobj = rpt.ReportDefinition.Sections["Section3"].ReportObjects["txtwd"] as TextObject;
                      txtobj.Text = DateTime.Today.ToString();
                  }
                  else if (Request.QueryString["code"] == "200")
                  {
                      SqlDataReader rdr;
                      String sub;
                      dt = new DataTable();
                      sub = Request.QueryString["subject"];
                      cmd.Connection = con;
                      if (Request.QueryString["marks"] == "0")
                      {
                          dt.Columns.Add("STDROLLNO", typeof(Int32));
                          dt.Columns.Add("STDNAME", typeof(String));
                          dt.Columns.Add("SUBJECT", typeof(String));

                          if (Request.QueryString["rollno"] == "-1")
                              cmd.CommandText = "select STDROLLNO,STDNAME from Subject_Det where SUB1='" + sub + "' or SUB2='" + sub + "' or SUB3='" + sub + "' or SUB4='" + sub + "' or SUB5='" + sub + "' or SUB6='" + sub + "'";
                          else
                              cmd.CommandText = "Select STDROLLNO,STDNAME from Subject_Det where STDROLLNO=" + int.Parse(Request.QueryString["rollno"]) + "and SUB1='" + sub + "' or SUB2='" + sub + "' or SUB3='" + sub + "' or SUB4='" + sub + "' or SUB5='" + sub + "' or SUB6='" + sub + "'";
                          rdr = cmd.ExecuteReader();
                          while (rdr.Read())
                          {
                              dt.Rows.Add(rdr["STDROLLNO"], rdr["STDNAME"], sub);
                             
                          }

                          rdr.Dispose();
                          ds.Tables["STD_MARKSSHEET"].Merge(dt);
                          rpt.Load(Server.MapPath("~/Reports/Examination/Std_MarksdetSheet.rpt"));
                          if (ds.Tables["STD_MARKSSHEET"].Rows.Count > 0)
                              rpt.SetDataSource(ds.Tables["STD_MARKSSHEET"]);
                          else
                              flag = true;

                      }
                      else
                      {
                         
                          int i,j,k=1,m=1,rolln=-1;
                          Char ch = 'U';
                          String subj;
                          int[] marks = new int[9];
                          SqlDataReader rdrr;
                          SqlConnection conn;
                          SqlCommand cmnd;
                          
                          conn = new SqlConnection();
                          cmnd = new SqlCommand();
                          conn.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon" + Session["conyr"]].ConnectionString;
                          cmnd.Connection = conn;
                          conn.Open();
                          dt.Columns.Add("STDROLLNO",typeof(Int32));
                          dt.Columns.Add("STDNAME", typeof(String));
                          dt.Columns.Add("SUBJECT", typeof(String));
                          dt.Columns.Add("U1T", typeof(Int32));
                          dt.Columns.Add("U1P", typeof(Int32));
                          dt.Columns.Add("U2T", typeof(Int32));
                          dt.Columns.Add("U2P", typeof(Int32));
                          dt.Columns.Add("T1T", typeof(Int32));
                          dt.Columns.Add("T1P", typeof(Int32));
                          dt.Columns.Add("T2T", typeof(Int32));
                          dt.Columns.Add("T2P", typeof(Int32));
                          dt.Columns.Add("TERM1T", typeof(Int32));
                          dt.Columns.Add("TERM1P", typeof(Int32));
                          dt.Columns.Add("TERM2T", typeof(Int32));
                          dt.Columns.Add("TERM2P", typeof(Int32));
                          dt.Columns.Add("TTOTALT", typeof(Int32));
                          dt.Columns.Add("TTOTALP", typeof(Int32));
                          dt.Columns.Add("TOTAL", typeof(Int32));
                          
                           if (Request.QueryString["rollno"] == "-1")
                              cmd.CommandText = "select * from Subject_Det where SUB1='" + sub + "' or SUB2='" + sub + "' or SUB3='" + sub + "' or SUB4='" + sub + "' or SUB5='" + sub + "' or SUB6='" + sub + "'";
                          else
                              cmd.CommandText = "Select * from Subject_Det where STDROLLNO=" + int.Parse(Request.QueryString["rollno"]) + "and SUB1='" + sub + "' or SUB2='" + sub + "' or SUB3='" + sub + "' or SUB4='" + sub + "' or SUB5='" + sub + "' or SUB6='" + sub + "'";
                          rdr = cmd.ExecuteReader();
                         
                          while (rdr.Read())
                          {
                              k = 1;
                              m = 1;
                              ch = 'U';
                              rolln = int.Parse(rdr["STDROLLNO"].ToString());
                              for (i = 1; i <= 6; i++)
                              {
                                  subj = rdr["SUB" + i].ToString();
                                  if(subj==sub)
                                      break;
                              }
                              for (j = 1; j <= 4; j++)
                              {
                                  if (j>2)
                                  {
                                      m = 1;
                                      ch = 'T';
                                  }
                                  cmnd.CommandText = "select S" + i + "TH,S" + i + "PR from HSE_11_" + ch + m + "MARKS where stdrollno=" + rolln;
                                  rdrr = cmnd.ExecuteReader();
                                  m = m + 1;
                                  rdrr.Read();
                                  if (rdrr.HasRows)
                                  {
                                     
                                      marks[k] = int.Parse(rdrr[0].ToString());
                                      marks[k+1] = int.Parse(rdrr[1].ToString());
                                     
                                  }
                                  else
                                  {
                                      marks[k]=marks[k+1]= 0;
                                  }
                                  k++;
                                  rdrr.Close();
                              }

                              dt.Rows.Add(rdr["STDROLLNO"], rdr["STDNAME"], sub, marks[1], marks[2], marks[3], marks[4], marks[5], marks[6], marks[7], marks[8], marks[1] + marks[5], marks[2] + marks[6], marks[3] + marks[7], marks[4] + marks[8], marks[1] + marks[5] + marks[3] + marks[7], marks[2] + marks[6] + marks[4] + marks[8], marks[1] + marks[5] + marks[3] + marks[7] + marks[2] + marks[6] + marks[4] + marks[8]);
                              
                              
                          }
                          rdr.Dispose();
                          ds.Tables["STD_MARKSDET"].Merge(dt);
                         rpt.Load(Server.MapPath("~/Reports/Examination/Std_Marksdet.rpt"));
                          if (ds.Tables["STD_MARKSDET"].Rows.Count > 0)
                              rpt.SetDataSource(ds.Tables["STD_MARKSDET"]);
                          else
                              flag = true;

                      }
                  }
                  if (flag == true)
                      lblmes.Text = "Invalid Rollnumber..";
                  else
                  {
                      CrystalReportViewer.ReportSource = rpt;
                      CrystalReportViewer.DataBind();
                  }

                con.Close();
            
            }
            catch(Exception ex)
            {
                lblmes.Text = ex.Message;
            }
        }

        void LoadImage(DataRow drow, String filepath)
        {
        FileStream fs;
         byte[] img;
            


        if(File.Exists(filepath))
            {
            fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
             img = new byte[fs.Length];
             fs.Read(img, 0, Convert.ToInt32(fs.Length));
            drow["STDIMG"] = img;
               fs.Close();
            }
            
        
        }

    }
}