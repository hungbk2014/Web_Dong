using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Dong.Helper
{
    public class ExtensionHelper
    {
        string[] supportedTypes = new[] { "png", "jpeg" };
        string _extent;
        public ExtensionHelper(string extent)
        {
            _extent = extent;
        }

        public bool accept() => supportedTypes.Contains(_extent);
    }
}