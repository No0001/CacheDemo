using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace CacheDemo
{
    public class Cache<TKey, TSource> : ICache<TKey, TSource> where TKey : struct where TSource : class
    {
        private ObjectCache cache = MemoryCache.Default;

        public TSource GetCache(TKey key)
        => (TSource)cache[key.ToString()];

        public void SetCache(TKey key, TSource source, int cacheTimeInMinutes)
        {
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(cacheTimeInMinutes)
            };

            cache.Set(key.ToString(), source, policy);
        }
    }
}