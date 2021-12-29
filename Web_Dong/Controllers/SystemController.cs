﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Dong.Models;

namespace Web_Dong.Controllers
{
    public class SystemController : Controller
    {
        readonly SqlConnection conn = new SqlConnection("Server=DESKTOP-8JVMMQJ\\SQLEXPRESS;Database=Shop_dongho;Trusted_Connection=True;");
        SqlCommand cmd = new SqlCommand();
        readonly SqlDataAdapter dt = new SqlDataAdapter();
        
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

        public ActionResult InsertMem(Thanhvien tv)
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

        public ActionResult Editmem(Thanhvien tv, int id)
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            if (Request.HttpMethod == "POST")
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "Update Thanhvien set username='" + tv.username + "', password='" + tv.password + "', email='" + tv.email + "', hovaten= '" + tv.hovaten + "' where id = " + tv.id;
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i >= 1)
                {
                    return Redirect("/he-thong");
                }
                else
                {
                    ViewBag.Thongtin = "Sửa không thành công";
                }
            }

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Thanhvien where id = " + id;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            conn.Close();
            return View(table);
        }
        public ActionResult DeleteMem(int id)
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
        //Quản lý giới thiệu
        public ActionResult ManageInfo()
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from Gioithieu where info = 'line'";
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            conn.Close();
            return View(table);
        }
        [ValidateInput(false)]
        public ActionResult EditInfo(Gioithieu info)
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            if (Request.HttpMethod == "POST")
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "update Gioithieu set text= N'" + info.text + "' where info = 'line'";
                int i = cmd.ExecuteNonQuery();
                conn.Close();
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

        //Quản lý tin tức
        public ActionResult ManageNews()
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from TinTuc where info = 'line'";
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            conn.Close();
            return View(table);
        }
        [ValidateInput(false)]
        public ActionResult EditNews(TinTuc info)
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            if (Request.HttpMethod == "POST")
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "update TinTuc set text= N'" + info.text + "' where info = 'line'";
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                {
                    return Redirect("/he-thong/quan-ly-tin-tuc");
                }
                else
                {
                    return Redirect("/he-thong/quan-ly-tin-tuc");
                }
            }
            else
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "select * from TinTuc where info = 'line'";
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(dr);
                conn.Close();
                return View(table);
            }

        }

        

        //Product
        public ActionResult ManageProduct()
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Sanpham";
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            conn.Close();
            return View(table);
        }

        public ActionResult InsertProduct(Sanpham sp, HttpPostedFileBase Hinhanh)
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            
            if (Request.HttpMethod == "POST")
            { 
                conn.Open();
                cmd.Connection = conn;
                if (Hinhanh.ContentLength > 0)
                {
                    string _Filename = Path.GetFileName(Hinhanh.FileName);
                    string _path = Path.Combine(Server.MapPath("~/Content/hinhanh"), _Filename);
                    Hinhanh.SaveAs(_path);

                    cmd.CommandText = "Insert into Sanpham values (N'" + sp.Tensp + "','" + sp.Giasp + "','" + sp.Mota + "','" + _Filename + "')";
                    int i = cmd.ExecuteNonQuery();
                    conn.Close();
                    if (i >= 1)
                    {
                        return Redirect("/he-thong/quan-ly-san-pham");
                    }
                    else
                    {
                        ViewBag.Thongtin = "Thêm không thành công";
                    }
                }               
            }
            else
            {
                ViewBag.Thongtin = "";
            }
            return View();
        }

        public ActionResult EditProduct(Sanpham sp, int id, HttpPostedFileBase Hinhanh)
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            
            if (Request.HttpMethod == "POST")
            {
                conn.Open();
                cmd.Connection = conn;
                string _Filename = Path.GetFileName(Hinhanh.FileName);
                string _path = Path.Combine(Server.MapPath("~/Content/hinhanh"), _Filename);
                Hinhanh.SaveAs(_path);

                cmd.CommandText = "Update Sanpham set tensp= N'" + sp.Tensp + "', giasp='" + sp.Giasp + "', mota='" + sp.Mota + "', hinhanh= '" + _Filename + "' where id = " + sp.Id;
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i >= 1)
                {
                    return Redirect("/he-thong/quan-ly-san-pham");
                }
                else
                {
                    ViewBag.Thongtin = "Sửa không thành công";
                }
            }

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from Sanpham where id = " + id;
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dr);
            conn.Close();
            return View(table);
        }
        public ActionResult DeleteProduct(int id)
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            conn.Open();
            cmd.Connection = conn;
            //cmd.CommandText = "Select hinhanh from Hinhanh where id = " + id;
            //SqlDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    string image = dr.GetString(0);
            //    string path = "~Content/hinhanh/" + image;
            cmd.CommandText = "Delete from Sanpham where id = " + id;
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            if (i >= 1)
            {
                    
                return Redirect("/he-thong/quan-ly-san-pham");
            }
            else
            {
                return Redirect("/he-thong/quan-ly-san-pham");
            }
            //}
            //else
            //{
            //    return Redirect("/he-thong/quan-ly-san-pham");
            //}
        }



        public ActionResult Logout()
        {
            Session["loginsuccess"] = null;
            return Redirect("/");
        }
    }
}