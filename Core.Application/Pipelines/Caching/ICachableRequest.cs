﻿namespace Core.Application.Pipelines.Caching
{
    public interface ICachableRequest
    {
        public string CacheKey { get; }

        public bool BypassCache { get; }

        string? CacheGroupKey { get; }

        TimeSpan? SlidingExpiration { get; }

    }
}
