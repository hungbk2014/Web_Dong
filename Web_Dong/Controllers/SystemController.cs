using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Web_Dong.Helper;
using Web_Dong.Models;

namespace Web_Dong.Controllers
{
    public class SystemController : Controller
    {
        readonly SqlConnection conn = new SqlConnection("Data Source=DESKTOP-8JVMMQJ\\SQLEXPRESS;Initial Catalog=Shop_dongho;Integrated Security=True;");
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
            cmd.CommandText = "Danhsach_TV";
            cmd.CommandType = CommandType.StoredProcedure;
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
                Regex _email = new Regex(@"[a-zA-Z0-9]*@[a-zA-Z0-9]*\.[a-zA-Z0-9]*");
                if (_email.Match(tv.email).Success)
                {
                   

                    conn.Open();
                    cmd = new SqlCommand("Them_TV", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@USERNAME", SqlDbType.NVarChar).Value = tv.username;
                    cmd.Parameters.AddWithValue("@PASSWORD", SqlDbType.NVarChar).Value = tv.password;
                    cmd.Parameters.AddWithValue("@EMAIL", SqlDbType.NVarChar).Value = tv.email;
                    cmd.Parameters.AddWithValue("@HOVATEN", SqlDbType.NVarChar).Value = tv.hovaten;                   

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
                    ViewBag.Email = "Email không hợp lệ";
                }
            }
            else
            {
                ViewBag.Thongtin = "";
                ViewBag.Email = "";
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
                cmd.CommandText = "Sua_TV";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = tv.id;
                cmd.Parameters.AddWithValue("@USERNAME", SqlDbType.NVarChar).Value = tv.username;
                cmd.Parameters.AddWithValue("@PASSWORD", SqlDbType.NVarChar).Value = tv.password;
                cmd.Parameters.AddWithValue("@EMAIL", SqlDbType.NVarChar).Value = tv.email;
                cmd.Parameters.AddWithValue("@HOVATEN", SqlDbType.NVarChar).Value = tv.hovaten;

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
            cmd.CommandText = "Tim_TV";
            cmd.CommandType = CommandType.StoredProcedure;
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
            cmd.CommandText = "Xoa_TV";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id;
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
            cmd.CommandText = "ThongTin_Gioithieu";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@INFO", SqlDbType.NVarChar).Value = "line";
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
                cmd.CommandText = "Sua_Gioithieu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@INFO", SqlDbType.NVarChar).Value = "line";
                cmd.Parameters.AddWithValue("@TEXT", SqlDbType.NVarChar).Value = info.text;
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
                cmd.CommandText = "ThongTin_Gioithieu";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@INFO", SqlDbType.NVarChar).Value = "line";
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
            cmd.CommandText = "ThongTin_TinTuc";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@INFO", SqlDbType.NVarChar).Value = "line";
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
                cmd.CommandText = "Sua_TinTuc";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@INFO", SqlDbType.NVarChar).Value = "line";
                cmd.Parameters.AddWithValue("@TEXT", SqlDbType.NVarChar).Value = info.text;
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

        

        //Product
        public ActionResult ManageProduct()
        {
            if (Session["loginsuccess"] == null)
            {
                return Redirect("/");
            }
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Danhsach_SP";
            cmd.CommandType = CommandType.StoredProcedure;
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
                    string _extent = Path.GetExtension(Hinhanh.FileName);
                    ExtensionHelper ExHelper = new ExtensionHelper(_extent);
                    if (ExHelper.accept())
                    {
                        string _Filename = Path.GetFileName(Hinhanh.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/hinhanh"), _Filename);
                        Hinhanh.SaveAs(_path);

                        cmd.CommandText = "Them_SP";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TENSP", SqlDbType.NVarChar).Value = sp.Tensp;
                        cmd.Parameters.AddWithValue("@GIASP", SqlDbType.NVarChar).Value = sp.Giasp;
                        cmd.Parameters.AddWithValue("@MOTA", SqlDbType.Text).Value = sp.Mota;
                        cmd.Parameters.AddWithValue("@HINHANH", SqlDbType.NVarChar).Value = _Filename;
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
                    else
                    {
                        ViewBag.Thongtin = "Hình không hợp lệ";
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

                cmd.CommandText = "Sua_SP";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TENSP", SqlDbType.NVarChar).Value = sp.Tensp;
                cmd.Parameters.AddWithValue("@GIASP", SqlDbType.NVarChar).Value = sp.Giasp;
                cmd.Parameters.AddWithValue("@MOTA", SqlDbType.Text).Value = sp.Mota;
                cmd.Parameters.AddWithValue("@HINHANH", SqlDbType.NVarChar).Value = _Filename; 
                
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
            cmd.CommandText = "Tim_SP";
            cmd.CommandType = CommandType.StoredProcedure;

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
            cmd.CommandText = "Tim_HinhAnh";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string _image = dr.GetString(0);
                string _path = Path.Combine(Server.MapPath("~/Content/hinhanh"), _image); ;
                if (System.IO.File.Exists(_path))
                {
                    System.IO.File.Delete(_path);
                }
            }
            conn.Close();
            
            conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = "Xoa_SP";
            cmd.CommandType = CommandType.StoredProcedure;

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