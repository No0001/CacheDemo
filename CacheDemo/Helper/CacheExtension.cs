using System;


namespace CacheDemo
{
    public static class CacheExtension
    {
        public static TSource GetCache<TKey, TSource>(this TKey Key, ICache<TKey, TSource> Cache, Func<TSource> ObjectSettingFunction, int CacheTimeInMinutes)
             where TKey : struct where TSource : class
        {
            TSource value = Cache.GetCache(Key);

            if (value == null)
            {
                value = ObjectSettingFunction();

                Cache.SetCache(Key, value, CacheTimeInMinutes);
            }

            return value;
        }
    }
}