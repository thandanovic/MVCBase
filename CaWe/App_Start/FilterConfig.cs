﻿using MVCBase.Attributes;
using System.Web;
using System.Web.Mvc;

namespace MVCBase
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new JsonExceptionFilterAttribute());
            filters.Add(new HandleErrorAttribute());            
        }
    }
}
