using Microsoft.Extensions.Caching.Memory;
using Planet.Application.Services.Caching;

namespace Planet.Infrastructure.Services.Caching
{
    public sealed class InMemoryCacheManager : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        public InMemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void CacheItem(string key, object value)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(5));
        }

        public void CacheItem(string key, object value, TimeSpan expire)
        {
            _memoryCache.Set(key, value, expire);
        }

        public T RetrieveItem<T>(string key)
        {
            if (_memoryCache.TryGetValue(key, out T value))
            {
                return value;
            }

            return default;
        }
    }
}
