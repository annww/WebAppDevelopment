﻿using System.Web;
using System.Web.Mvc;

namespace BaiTap4_64130758
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
