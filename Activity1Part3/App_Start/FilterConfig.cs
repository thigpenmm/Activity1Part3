﻿using System.Web;
using System.Web.Mvc;

namespace Activity1Part3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
