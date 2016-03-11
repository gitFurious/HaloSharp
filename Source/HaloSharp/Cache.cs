using System;
using System.Runtime.Caching;

namespace HaloSharp
{
    internal static class Cache
    {
        private static readonly ObjectCache ObjectCache = MemoryCache.Default;
        private static readonly object LockObject = new object();

        public static TimeSpan CacheDuration = TimeSpan.FromMinutes(10);

        public static void Add<T>(string key, T toAdd) where T : class
        {
            lock (LockObject)
            {
                if (toAdd != null)
                {
                    ObjectCache.Add(key, toAdd, new DateTimeOffset(DateTime.Now).ToOffset(CacheDuration));
                }
            }
        }

        public static T Get<T>(string key) where T : class
        {
            lock (LockObject)
            {
                if (ObjectCache.Contains(key))
                {
                    return (T) ObjectCache[key];
                }
                return null;
            }
        }
    }
}