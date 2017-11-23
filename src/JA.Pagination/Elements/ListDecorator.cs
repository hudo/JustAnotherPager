namespace JA.Pagination.Elements
{
    internal class ListDecorator : IRenderable
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

        public string Render() => string.Format("<li{0}>{1}</li>",
            string.IsNullOrEmpty(_cssClass)
                ? ""
                : " class=\"" + _cssClass + "\"",
            _inner.Render());
    }
}