namespace JA.Pagination.Elements
{
    internal class ContentItem : IRenderable
    {
        private readonly string _text;

        public ContentItem(string text)
        {
            _text = text;
        }

        public string Render() => _text;
    }
}