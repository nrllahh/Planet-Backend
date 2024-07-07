namespace Planet.Application.Services.Caching
{
    public interface ICacheService
    {
        void CacheItem(string key, object value);
        void CacheItem(string key, object value, TimeSpan expire);
        T RetrieveItem<T>(string key);
    }
}
