using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Dong.Controllers
{
    public class MainPageController : Controller
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-8JVMMQJ\\SQLEXPRESS;Database=Shop_dongho;Trusted_Connection=True;");
        SqlCommand cmd = new SqlCommand();
        readonly SqlDataAdapter dt = new SqlDataAdapter();
        public ActionResult Index()
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Sanpham";
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            conn.Close();
            return View(table);
        }
        public ActionResult GioiThieu()
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Gioithieu where info = 'line'";
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            conn.Close();
            return View(table);
        }
        public ActionResult SanPham()
        {
            return View();
        }
        public ActionResult TinTuc()
        {
            return View();
        }
    }
}