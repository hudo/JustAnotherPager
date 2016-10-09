using System;
using System.Runtime;
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
    }
}