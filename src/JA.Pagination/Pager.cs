using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

            var pages = new List<IRenderable> { new BeginList(_ulClass) };

            // Previous
            pages.Add(new ListDecorator(new LinkDecorator(new ContentItem(_resource.Previous), _currentPage > 1 ? _urlBuilder(_currentPage - 1) : "#")));

            // 1
            if (min >= 2) pages.Add(new ListDecorator(new LinkDecorator(new ContentItem("1"), _urlBuilder(1))));

            // ...
            var dots = new ListDecorator(new SpanDecorator(new ContentItem(_resource.Separator)), _liDisabledClass);
            if (min >= 3) pages.Add(dots);

            // 4 5 [6] 7 9
            foreach(var x in Enumerable.Range(min, max - min + 1).ToList())
            {
                pages.Add(
                    new ListDecorator(
                        new LinkDecorator(
                            new ContentItem(x.ToString(CultureInfo.InvariantCulture)), _urlBuilder(x)), x == _currentPage ? _currentPageClass : String.Empty));
            }

            // ...
            if (max + 1 < _total) pages.Add(dots);

            // 999
            if (max < _total) pages.Add(new ListDecorator(new LinkDecorator(new ContentItem(_total.ToString(CultureInfo.InvariantCulture)), _urlBuilder(_total))));

            // Next
            pages.Add(new ListDecorator(new LinkDecorator(new ContentItem(_resource.Next), _currentPage < _total ? _urlBuilder(_currentPage + 1) : "#")));

            pages.Add(new EndList());

            return pages.Select(x => x.Render()).Aggregate((state, current) => state + current);
        }

        private interface IRenderable
        {
            string Render();
        }

        private class BeginList : IRenderable
        {
            private readonly string _cssClass;

            public BeginList(string cssClass)
            {
                _cssClass = cssClass;
            }

            public string Render()
            {
                return "<ul" + (string.IsNullOrEmpty(_cssClass) ? ">" : (" class=\"" + _cssClass + "\">"));
            }
        }

        private class EndList : IRenderable
        {
            public string Render()
            {
                return "</ul>";
            }
        }

        private class ContentItem : IRenderable
        {
            private readonly string _text;

            public ContentItem(string text)
            {
                _text = text;
            }

            public string Render()
            {
                return _text;
            }
        }

        private class LinkDecorator : IRenderable
        {
            private readonly IRenderable _inner;
            private readonly string _url;
            private readonly string _additionalAtt;

            public LinkDecorator(IRenderable inner, string url, string additionalAtt = null)
            {
                _inner = inner;
                _url = url;
                _additionalAtt = additionalAtt;
            }

            public string Render()
            {
                return string.Format("<a href=\"{0}\" {1}>{2}</a>", _url, _additionalAtt, _inner.Render());
            }
        }

        private class ListDecorator : IRenderable
        {
            private readonly IRenderable _inner;
            private readonly string _cssClass = "";

            public ListDecorator(IRenderable inner)
            {
                _inner = inner;
            }

            public ListDecorator(IRenderable inner, string cssClass) : this(inner)
            {
                _cssClass = cssClass;
            }

            public string Render()
            {
                return string.Format("<li{0}>{1}</li>",
                    (string.IsNullOrEmpty(_cssClass) ? "" : " class=\"" + _cssClass + "\""),
                    _inner.Render());
            }
        }

        private class SpanDecorator : IRenderable
        {
            private readonly IRenderable _inner;

            public SpanDecorator(IRenderable inner)
            {
                _inner = inner;
            }

            public string Render()
            {
                return string.Format("<span>{0}</span>", _inner.Render());
            }
        }
    }

    public sealed class ContentResource
    {
        public string Previous { get; set; } = "Prev";
        public string Next { get; set; } = "Next";
        public string Separator { get; set; } = "...";
    }
}
