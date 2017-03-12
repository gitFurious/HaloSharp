using System;
using System.Threading;
using NUnit.Framework;

namespace HaloSharp.Test.Cache
{
    [TestFixture]
    public class CacheTests
    {
        private TimeSpan? PreviousCacheDuration { get; set; }

        [SetUp]
        public void Setup()
        {
            PreviousCacheDuration = HaloSharp.Cache.CacheDuration;
        }

        [Test]
        public void ExpiresFromCacheAfterDuration()
        {
            var cacheDuration = new TimeSpan(0, 0, 0, 3);

            HaloSharp.Cache.CacheDuration = cacheDuration;

            const string key = "ExpiresFromCacheAfterDuration";
            const string input = "HaloSharp.Cache";

            HaloSharp.Cache.Add(key, input);
            var output = HaloSharp.Cache.Get<string>(key);
            Assert.AreEqual(input, output);

            Thread.Sleep(cacheDuration);

            output = HaloSharp.Cache.Get<string>(key);
            Assert.IsNull(output);
        }

        [TearDown]
        public void TearDown()
        {
            HaloSharp.Cache.CacheDuration = PreviousCacheDuration;
        }
    }
}
