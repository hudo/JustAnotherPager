namespace JA.Pagination.Elements
{
    internal class SpanDecorator : IRenderable
    {
        private readonly IRenderable _inner;

        public SpanDecorator(IRenderable inner)
        {
            _inner = inner;
        }

        public string Render() => $"<span>{_inner.Render()}</span>";
    }
}