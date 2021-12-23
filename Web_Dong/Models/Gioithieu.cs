using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_Dong.Models
{
    public class Gioithieu
    {
        [AllowHtml]
        public string text { get; set; }
    }
}