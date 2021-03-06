﻿using System;
using System.Web;
using System.Web.Mvc;

namespace JA.Pagination.MVC5
{
    public static class HtmlExtension
    {
        public static IHtmlString RenderPager(this HtmlHelper helper, int currentPage, int totalPages, Func<int, string> urlBuilder)
        {
            return helper.Raw(Pager.Build(currentPage, totalPages, urlBuilder).Render());
        }

        public static IHtmlString RenderPager(this HtmlHelper helper, 
            int currentPage,
            int totalPages,
            Func<int, string> urlBuilder,
            string currentPageClass = "active",
            string ulClass = "pagination",
            string liDisabledClass = "disabled",
            Action<ContentResource> resourceOverrides = null)
        {
            return helper.Raw(Pager.Build(currentPage, totalPages, urlBuilder, currentPageClass, ulClass, liDisabledClass, resourceOverrides).Render());
        }
    }
}