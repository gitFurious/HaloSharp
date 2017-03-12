using System;
using System.Runtime.Caching;

namespace HaloSharp
{
    internal static class Cache
    {
        private static readonly ObjectCache ObjectCache = MemoryCache.Default;
        private static readonly object LockObject = new object();

        internal static TimeSpan? CacheDuration { get; set; }

        public static void Add<T>(string key, T toAdd) where T : class
        {
            if (string.IsNullOrEmpty(key) || !CacheDuration.HasValue)
            {
                return;
            }

            lock (LockObject)
            {
                if (!ObjectCache.Contains(key))
                {
                    var absoluteExpiration = DateTime.UtcNow.Add(CacheDuration.Value);
                    ObjectCache.Add(key, toAdd, absoluteExpiration);
                }
            }
        }

        public static T Get<T>(string key) where T : class
        {
            lock (LockObject)
            {
                return ObjectCache.Get(key) as T;
            }
        }
    }
}