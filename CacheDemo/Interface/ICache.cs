using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace CacheDemo
{
    public interface ICache<TKey , TSource> where TKey : struct where TSource : class
    {
        void SetCache(TKey key, TSource source, int cacheTimeInMinutes);

        TSource GetCache(TKey key);
    }
}