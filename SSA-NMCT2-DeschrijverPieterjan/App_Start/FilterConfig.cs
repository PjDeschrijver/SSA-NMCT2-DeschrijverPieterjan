﻿using System.Web;
using System.Web.Mvc;

namespace SSA_NMCT2_DeschrijverPieterjan
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}