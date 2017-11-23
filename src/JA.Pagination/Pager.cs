using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using JA.Pagination.Elements;

namespace JA.Pagination
{
    public class Pager
    {
        private readonly int _currentPage;
        private readonly int _total;
        private readonly Func<int, string> _urlBuilder;
        private readonly string _currentPageClass;
        private readonly string _ulClass;
        private readonly string _liDisabledClass;
        private readonly ContentResource _resource;

        private Pager(int currentPage, int total, Func<int, string> urlBuilder, string currentPageClass, string ulClass, string liDisabledClass, ContentResource resource)
        {
            _currentPage = currentPage;
            _total = total;
            _urlBuilder = urlBuilder;
            _currentPageClass = currentPageClass;
            _ulClass = ulClass;
            _liDisabledClass = liDisabledClass;
            _resource = resource;
        }

        /// <summary>
        /// Prepare pager settiongs
        /// </summary>
        /// <param name="currentPage">Current page</param>
        /// <param name="totalPages">Total number of pages</param>
        /// <param name="urlBuilder">Callback for creating specific page URL</param>
        /// <param name="currentPageClass">Current page class</param>
        /// <param name="ulClass">Conteiner UL class</param>
        /// <param name="liDisabledClass">Disabled page LI class</param>
        /// <param name="resourceOverrides">Resource (Previous, Next, etc) overridess</param>
        /// <returns></returns>
        public static Pager Build(int currentPage,
            int totalPages,
            Func<int, string> urlBuilder,
            string currentPageClass = "active",
            string ulClass = "pagination",
            string liDisabledClass = "disabled",
            Action<ContentResource> resourceOverrides = null)
        {
            var resource = new ContentResource();

            resourceOverrides?.Invoke(resource);

            return new Pager(currentPage, totalPages, urlBuilder, currentPageClass, ulClass, liDisabledClass, resource);
        }

        /// <summary>
        /// Renders pager HTML
        /// </summary>
        /// <returns>string with HTML</returns>
        public string Render()
        {
            var min = Math.Max(1, _currentPage - 2);
            var max = Math.Min(_total, _currentPage + 2);

            var pages = GenerateHtmlElements(min, max);

            return pages
                .Select(page => page.Render())
                .Aggregate((state, current) => state + current);
        }

        private IEnumerable<IRenderable> GenerateHtmlElements(int min, int max)
        {
            yield return new BeginList(_ulClass);

            // Previous
            yield return new ListDecorator(
                new LinkDecorator(
                    new ContentItem(_resource.Previous), _currentPage > 1
                        ? _urlBuilder(_currentPage - 1)
                        : "#"));

            // 1
            if (min >= 2) yield return new ListDecorator(
                new LinkDecorator(
                    new ContentItem("1"), _urlBuilder(1)));

            // ...
            var dots = new ListDecorator(
                new SpanDecorator(
                    new ContentItem(_resource.Separator)), _liDisabledClass);

            if (min >= 3) yield return dots;

            // 4 5 [6] 7 9
            foreach (var x in Enumerable.Range(min, max - min + 1).ToList())
            {
                yield return 
                    new ListDecorator(
                        new LinkDecorator(
                            new ContentItem(x.ToString(CultureInfo.InvariantCulture)), _urlBuilder(x)), x == _currentPage ? _currentPageClass : string.Empty);
            }

            // ...
            if (max + 1 < _total) yield return dots;

            // 999
            if (max < _total) yield return new ListDecorator(
                new LinkDecorator(
                    new ContentItem(_total.ToString(CultureInfo.InvariantCulture)), _urlBuilder(_total)));

            // Next
            yield return new ListDecorator(
                new LinkDecorator(
                    new ContentItem(_resource.Next), _currentPage < _total ? _urlBuilder(_currentPage + 1) : "#"));

            yield return new EndList();
        }
    }
}
