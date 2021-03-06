using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web_Dong
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Gioi thieu",
                url: "gioi-thieu",
                defaults: new { controller = "MainPage", action = "Gioithieu", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "San pham",
                url: "san-pham",
                defaults: new { controller = "MainPage", action = "SanPham", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Tin tuc",
                url: "tin-tuc",
                defaults: new { controller = "MainPage", action = "TinTuc", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Dang nhap",
               url: "dang-nhap",
               defaults: new { controller = "Baomat", action = "Index", id = UrlParameter.Optional }
           );

            //Member
            routes.MapRoute(
              name: "He thong",
              url: "he-thong",
              defaults: new { controller = "System", action = "Index", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Sua thanh vien",
              url: "he-thong/sua-thanh-vien/{id}",
              defaults: new { controller = "System", action = "Editmem", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Xoa thanh vien",
              url: "he-thong/xoa-thanh-vien/{id}",
              defaults: new { controller = "System", action = "DeleteMem", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Them thanh vien",
              url: "he-thong/them-thanh-vien",
              defaults: new { controller = "System", action = "InsertMem", id = UrlParameter.Optional }
          );

            //Product
            routes.MapRoute(
              name: "Quan ly san pham",
              url: "he-thong/quan-ly-san-pham",
              defaults: new { controller = "System", action = "ManageProduct", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Sua san pham",
              url: "he-thong/sua-san-pham/{id}",
              defaults: new { controller = "System", action = "EditProduct", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Xoa san pham",
              url: "he-thong/xoa-san-pham/{id}",
              defaults: new { controller = "System", action = "DeleteProduct", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "Them san pham",
              url: "he-thong/them-san-pham/",
              defaults: new { controller = "System", action = "InsertProduct", id = UrlParameter.Optional }
          );

            //Info
            routes.MapRoute(
              name: "Quan ly gioi thieu",
              url: "he-thong/quan-ly-gioi-thieu",
              defaults: new { controller = "System", action = "Manageinfo", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Sua gioi thieu",
              url: "he-thong/sua-gioi-thieu",
              defaults: new { controller = "System", action = "Editinfo", id = UrlParameter.Optional }
          );

            //News
            routes.MapRoute(
              name: "Quan ly tin tuc",
              url: "he-thong/quan-ly-tin-tuc",
              defaults: new { controller = "System", action = "ManageNews", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Sua tin tuc",
              url: "he-thong/sua-tin-tuc",
              defaults: new { controller = "System", action = "EditNews", id = UrlParameter.Optional }
          );

            routes.MapRoute(
             name: "Dang xuat",
             url: "dang-xuat",
             defaults: new { controller = "System", action = "Logout", id = UrlParameter.Optional }
         );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MainPage", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
