using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JA.Pagination.MVC6
{
    public static class HtmlExtensions
    {
        public static IHtmlContent RenderPager(this IHtmlHelper helper, int currentPage, int totalPages, Func<int, string> urlBuilder)
        {
            return helper.Raw(Pager.Build(currentPage, totalPages, urlBuilder).Render());
        }

        public static IHtmlContent RenderPager(this IHtmlHelper helper,
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