namespace JA.Pagination.Elements
{
    internal class BeginList : IRenderable
    {
        private readonly string _cssClass;

        public BeginList(string cssClass)
        {
            _cssClass = cssClass;
        }

        public string Render() => "<ul" + (
            string.IsNullOrEmpty(_cssClass)
                ? ">"
                : " class=\"" + _cssClass + "\">");
    }
}