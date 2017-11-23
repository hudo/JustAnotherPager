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

        /// <summary>
        /// Renders pager HTML
        /// </summary>
        /// <param name="currentPage">Current page</param>
        /// <param name="totalPages">Total number of pages</param>
        /// <param name="urlBuilder">Function that creates URL or each rendered page item (by default, it appends query string "?page=X")</param>
        /// <param name="currentPageClass">CSS class of a current page item</param>
        /// <param name="ulClass">CSS class to UL element where page items (LIs) are displayed</param>
        /// <param name="liDisabledClass">CSS class used for disabled LI element (contains "...")</param>
        /// <param name="resourceOverrides">Override text content for "Previous", "Next", separator (...)</param>
        public static IHtmlContent RenderPager(this IHtmlHelper helper,
            int currentPage,
            int totalPages,
            Func<int, string> urlBuilder = null,
            string currentPageClass = "active",
            string ulClass = "pagination",
            string liDisabledClass = "disabled",
            Action<ContentResource> resourceOverrides = null)
        {
            return helper.Raw(Pager.Build(
                currentPage,
                totalPages, 
                urlBuilder ?? (page => $"?page={page}"), 
                currentPageClass, 
                ulClass, 
                liDisabledClass, 
                resourceOverrides).Render());
        }
    }
}