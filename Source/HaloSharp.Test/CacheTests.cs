using NUnit.Framework;
using System;

namespace HaloSharp.Test.Utility
{
    [TestFixture]
    public class CacheTests
    {
        private TimeSpan PreviousCacheDuration;

        [SetUp]
        public void Setup()
        {
            this.PreviousCacheDuration = Cache.CacheDuration;
        }

        [Test]
        public void CachedValueShouldBeNullIfExpired()
        {
            // Cached items will expire as soon as they enter the cache
            Cache.CacheDuration = TimeSpan.Zero;

            Cache.Add("key", "value");
            var cachedValue = Cache.Get<string>("key");
            Assert.IsNull(cachedValue, "cached value should be expired");
        }

        [Test]
        public void CachedValueShouldBeCorrectIfNotExpired()
        {
            var value = "value";
            Cache.Add("key", value);
            var cachedValue = Cache.Get<string>("key");
            Assert.AreEqual(value, value);
        }

        [TearDown]
        public void TearDown()
        {
            Cache.CacheDuration = this.PreviousCacheDuration;
        }
    }
}
