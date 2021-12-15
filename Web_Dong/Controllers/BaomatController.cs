using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Dong.Models;
using System.Data;
using System.Data.SqlClient;

namespace Web_Dong.Controllers
{
    public class BaomatController : Controller
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-V79VCG5\\SQLEXPRESS01;Database=Shop_dongho;Trusted_Connection=True;");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public ActionResult Index(Thanhvien tv)
        {

            if (Request.HttpMethod == "POST")
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "select * from Thanhvien where username='" + tv.username + "' and password='" + tv.password + "' ";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //ViewBag.mgs = "Đăng nhập thành công";
                    Session["loginsuccess"] = tv.username;
                    return Redirect("/he-thong");
                }
                else
                {
                    ViewBag.mgs = "Đăng nhập không thành công";
                }
            }
            else
            {
                if (Session["loginsuccess"] != null)
                {
                    return Redirect("/he-thong");
                }
                ViewBag.mgs = "";
            }

            return View();
        }
    }
}