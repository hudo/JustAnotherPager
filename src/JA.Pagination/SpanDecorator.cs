using JA.Pagination.Elements;

namespace JA.Pagination
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