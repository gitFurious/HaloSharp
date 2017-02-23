using System;
using System.Runtime.Caching;

namespace HaloSharp
{
    internal static class Cache
    {
        private static readonly ObjectCache ObjectCache = MemoryCache.Default;
        private static readonly object LockObject = new object();

        internal static TimeSpan? MetadataCacheDuration { get; set; }
        internal static TimeSpan? ProfileCacheDuration { get; set; }
        internal static TimeSpan? StatsCacheDuration { get; set; }
        internal static TimeSpan? UserGeneratedContentCacheDuration { get; set; }

        public static void AddMetadata<T>(string key, T toAdd) where T : class
        {
            lock (LockObject)
            {
                if (toAdd != null && MetadataCacheDuration.HasValue)
                {
                    var absoluteExpiration = DateTime.UtcNow.Add(MetadataCacheDuration.Value);
                    ObjectCache.Add(key, toAdd, absoluteExpiration);
                }
            }
        }

        public static void AddProfile<T>(string key, T toAdd) where T : class
        {
            lock (LockObject)
            {
                if (toAdd != null && ProfileCacheDuration.HasValue)
                {
                    var absoluteExpiration = DateTime.UtcNow.Add(ProfileCacheDuration.Value);
                    ObjectCache.Add(key, toAdd, absoluteExpiration);
                }
            }
        }

        public static void AddStats<T>(string key, T toAdd) where T : class
        {
            lock (LockObject)
            {
                if (toAdd != null && StatsCacheDuration.HasValue)
                {
                    var absoluteExpiration = DateTime.UtcNow.Add(StatsCacheDuration.Value);
                    ObjectCache.Add(key, toAdd, absoluteExpiration);
                }
            }
        }

        public static void AddUserGeneratedContent<T>(string key, T toAdd) where T : class
        {
            lock (LockObject)
            {
                if (toAdd != null && UserGeneratedContentCacheDuration.HasValue)
                {
                    var absoluteExpiration = DateTime.UtcNow.Add(UserGeneratedContentCacheDuration.Value);
                    ObjectCache.Add(key, toAdd, absoluteExpiration);
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