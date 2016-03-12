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

        public static void AddMetadata<T>(string key, T toAdd) where T : class
        {
            lock (LockObject)
            {
                if (toAdd != null)
                {
                    if (MetadataCacheDuration == null)
                    {
                        ObjectCache[key] = toAdd;
                    }
                    else
                    {
                        var absoluteExpiration = DateTime.UtcNow.Add(MetadataCacheDuration.Value);
                        ObjectCache.Add(key, toAdd, absoluteExpiration);
                    }
                }
            }
        }

        public static void AddProfile<T>(string key, T toAdd) where T : class
        {
            lock (LockObject)
            {
                if (toAdd != null)
                {
                    if (ProfileCacheDuration == null)
                    {
                        ObjectCache[key] = toAdd;
                    }
                    else
                    {
                        var absoluteExpiration = DateTime.UtcNow.Add(ProfileCacheDuration.Value);
                        ObjectCache.Add(key, toAdd, absoluteExpiration);
                    }
                }
            }
        }

        public static void AddStats<T>(string key, T toAdd) where T : class
        {
            lock (LockObject)
            {
                if (toAdd != null)
                {
                    if (StatsCacheDuration == null)
                    {
                        ObjectCache[key] = toAdd;
                    }
                    else
                    {
                        var absoluteExpiration = DateTime.UtcNow.Add(StatsCacheDuration.Value);
                        ObjectCache.Add(key, toAdd, absoluteExpiration);
                    }
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