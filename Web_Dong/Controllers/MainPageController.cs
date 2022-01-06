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
            List<DataTable> tables = new List<DataTable>();
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Moi";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            conn.Close();
            tables.Add(table);

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "SP_Cu";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr1 = cmd.ExecuteReader();
            DataTable table1 = new DataTable();
            table1.Load(dr1);
            conn.Close();
            tables.Add(table1);
            return View(tables);
        }
        public ActionResult GioiThieu()
        {
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = "ThongTin_Gioithieu";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@INFO", SqlDbType.NVarChar).Value = "line";

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
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = "ThongTin_TinTuc";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@INFO", SqlDbType.NVarChar).Value = "line";

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            conn.Close();
            return View(table);
        }
    }
}