namespace Core.Application.Pipelines.Caching
{
    public interface ICacheRemoverRequest
    {
        public string CacheKey { get; }

        public bool BypassCache { get; }

        string? CacheGroupKey { get; }
    }
}
