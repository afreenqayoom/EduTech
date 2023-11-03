using System.IO;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace EduTech
{
    public static class Edu
    {
        public static void LoadImage(DataRow drow, String filepath)
        {
            FileStream fs;
            byte[] img;



            if (File.Exists(filepath))
            {
                fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                img = new byte[fs.Length];
                fs.Read(img, 0, Convert.ToInt32(fs.Length));
                drow["STDIMG"] = img;
                fs.Close();
            }


        }
        public static void CheckPagePermission(string uname, string  pg)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader rdr;
            bool status;
             con = new SqlConnection();
            cmd = new SqlCommand();
            status = false;
            con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            try
           {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from User_form_privileges where user_name='" + uname + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                    if (rdr[pg].ToString() == "0")
                        status = true;
                }
                else
                    status = true;
                rdr.Close();
            }
            catch(Exception ex)
            { }
            finally
            {
                con.Close();
            }
            if (status == true)
                HttpContext.Current.Response.Redirect("~/Pages//Error.aspx?Err=Access denied. You don't have the permission to view this page.");
        }
        public static string UserType(string uname)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader rdr;
            string utype;
            con = new SqlConnection();
            cmd = new SqlCommand();
            utype = "";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from Useraccounts where userid='" + uname + "'";
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    rdr.Read();
                   utype  = rdr["USER_TYPE"].ToString();
                }
                rdr.Close();
            }
            catch (Exception ex)
            { }
            finally
            {
                con.Close();
            }
            return utype;
        }
        public static void CheckSubjectPagePermission(string uname, string subj,string term)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader rdr;
            bool status;
            con = new SqlConnection();
            cmd = new SqlCommand();
            status = false;
            con.ConnectionString = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "select * from User_subject_privileges where user_name='" + uname + "' and Subject='" + subj + "' and term='" + term + "'" ;
                rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                        status = true;
                }
                rdr.Close();
            }
            catch (Exception ex)
            { }
            finally
            {
                con.Close();
            }
            if (status == false)
                HttpContext.Current.Response.Redirect("~/Pages//Error.aspx?Err=Access denied. You don't have the permission to view this page.");
        }
        public static void CheckSession()
        {
            try
            {
                if(HttpContext.Current.Session["conyr"]==null)
                {
                    HttpContext.Current.Response.Redirect("~/Default.aspx");
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Redirect("~/Default.aspx");
            }
        }
    }
}