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

            routes.MapRoute(
              name: "He thong",
              url: "he-thong",
              defaults: new { controller = "System", action = "Index", id = UrlParameter.Optional }
          );

            routes.MapRoute(
              name: "Them thanh vien",
              url: "them-thanh-vien",
              defaults: new { controller = "System", action = "InsertNew", id = UrlParameter.Optional }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MainPage", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
