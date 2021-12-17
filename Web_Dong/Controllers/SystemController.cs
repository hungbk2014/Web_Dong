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
        SqlDataAdapter dt = new SqlDataAdapter();
        
        public ActionResult Index()
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Thanhvien";
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            conn.Close();
            return View(table);
        }

        public ActionResult ManageInfo()
        {
            //if (Session["loginsuccess"] == null)
            //{
            //    return Redirect("/");
            //}
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Gioithieu where info = 'line'";
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            conn.Close();
            return View(table);
        }

        public ActionResult EditInfo(Gioithieu info)
        {
            //if (Session["loginsuccess"] == null)
            //{
            //    return Redirect("/");
            //}
            if (Request.HttpMethod == "POST")
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "update Gioithieu set text= N'" + info.text + "' where info = 'line'";
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                {
                    return Redirect("/he-thong/quan-ly-gioi-thieu");
                }
                else
                {
                    return Redirect("/he-thong/quan-ly-gioi-thieu");
                }
            }
            else
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
                    return Redirect("/he-thong");
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

        public ActionResult DeleteMem (int id)
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Delete from Thanhvien where id = " + id;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                return Redirect("/he-thong");
            }
            else
            {
                return Redirect("/he-thong");
            }
        }

        public ActionResult Logout()
        {
            Session["loginsuccess"] = null;
            return Redirect("/");
        }
    }
}