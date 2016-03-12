using System;
using System.Threading;
using NUnit.Framework;

namespace HaloSharp.Test.Cache
{
    [TestFixture]
    public class CacheTests
    {
        private TimeSpan? PreviousMetadataCacheDuration { get; set; }
        private TimeSpan? PreviousProfileCacheDuration { get; set; }
        private TimeSpan? PreviousStatsCacheDuration { get; set; }

        [SetUp]
        public void Setup()
        {
            PreviousMetadataCacheDuration = HaloSharp.Cache.MetadataCacheDuration;
            PreviousProfileCacheDuration = HaloSharp.Cache.ProfileCacheDuration;
            PreviousStatsCacheDuration = HaloSharp.Cache.StatsCacheDuration;
        }

        [Test]
        public void MetadataExpiresFromCacheAfterDuration()
        {
            var cacheDuration = new TimeSpan(0, 0, 0, 3);

            HaloSharp.Cache.MetadataCacheDuration = cacheDuration;

            const string key = "metadata";
            const string input = "HaloSharp.Metadata";

            HaloSharp.Cache.AddMetadata(key, input);
            var output = HaloSharp.Cache.Get<string>(key);
            Assert.AreEqual(input, output);

            Thread.Sleep(cacheDuration);

            output = HaloSharp.Cache.Get<string>(key);
            Assert.IsNull(output);
        }

        [Test]
        public void ProfileExpiresFromCacheAfterDuration()
        {
            var cacheDuration = new TimeSpan(0, 0, 0, 3);

            HaloSharp.Cache.ProfileCacheDuration = cacheDuration;

            const string key = "profile";
            const string input = "HaloSharp.Profile";

            HaloSharp.Cache.AddProfile(key, input);
            var output = HaloSharp.Cache.Get<string>(key);
            Assert.AreEqual(input, output);

            Thread.Sleep(cacheDuration);

            output = HaloSharp.Cache.Get<string>(key);
            Assert.IsNull(output);
        }

        [Test]
        public void StatsExpiresFromCacheAfterDuration()
        {
            var cacheDuration = new TimeSpan(0, 0, 0, 3);

            HaloSharp.Cache.StatsCacheDuration = cacheDuration;

            const string key = "stats";
            const string input = "HaloSharp.Stats";

            HaloSharp.Cache.AddStats(key, input);
            var output = HaloSharp.Cache.Get<string>(key);
            Assert.AreEqual(input, output);

            Thread.Sleep(cacheDuration);

            output = HaloSharp.Cache.Get<string>(key);
            Assert.IsNull(output);
        }
        
        [TearDown]
        public void TearDown()
        {
            HaloSharp.Cache.MetadataCacheDuration = PreviousMetadataCacheDuration;
            HaloSharp.Cache.ProfileCacheDuration = PreviousProfileCacheDuration;
            HaloSharp.Cache.StatsCacheDuration = PreviousStatsCacheDuration;
        }
    }
}
