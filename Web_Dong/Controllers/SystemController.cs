using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Dong.Models;

namespace Web_Dong.Controllers
{
    public class SystemController : Controller
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-V79VCG5\\SQLEXPRESS01;Database=Shop_dongho;Trusted_Connection=True;");
        SqlCommand cmd = new SqlCommand();

        public ActionResult Index()
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            ViewBag.username = Session["loginsuccess"];
            return View();
        }

        public ActionResult InsertNew(Thanhvien tv)
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            if (Request.HttpMethod == "POST")
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "Insert into Thanhvien values ('" + tv.username + "','" + tv.password + "','" + tv.email + "','" + tv.hovaten + "')";
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i >= 1)
                {
                    ViewBag.Thongtin = "Thêm thành công";
                }
                else
                {
                    ViewBag.Thongtin = "Thêm không thành công";
                }
            }
            else
            {
                ViewBag.Thongtin = "";
            }
            return View();
        }
    }
}