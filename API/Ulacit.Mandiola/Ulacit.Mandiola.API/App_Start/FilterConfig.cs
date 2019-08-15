﻿using System.Web;
using System.Web.Mvc;

namespace Ulacit.Mandiola.API
{
    /// <summary>A filter configuration.</summary>
    public class FilterConfig
    {
        /// <summary>Registers the global filters described by filters.</summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}