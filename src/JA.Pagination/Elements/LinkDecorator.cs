namespace JA.Pagination.Elements
{
    internal class LinkDecorator : IRenderable
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

        public string Render() => $"<a href=\"{_url}\" {_additionalAtt}>{_inner.Render()}</a>";
    }
}