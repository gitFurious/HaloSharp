using System;

namespace HaloSharp.Model
{
    public class CacheSettings
    {
        public TimeSpan? MetadataCacheDuration { get; set; }
        public TimeSpan? ProfileCacheDuration { get; set; }
        public TimeSpan? StatsCacheDuration { get; set; }
    }
}
