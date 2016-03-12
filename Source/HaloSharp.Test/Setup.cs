using System;
using System.Threading;
using HaloSharp.Model;
using NUnit.Framework;

namespace HaloSharp.Test
{
    [SetUpFixture]
    public class Global
    {
        public static IHaloSession Session;

        [SetUp]
        public void RunBeforeAnyTests()
        {
            var developerAccessProduct = new Product
            {
                SubscriptionKey = "00000000000000000000000000000000",
                RateLimit = new RateLimit
                {
                    RequestCount = 10,
                    TimeSpan = new TimeSpan(0, 0, 0, 10),
                    Timeout = new TimeSpan(0, 0, 0, 10)
                }
            };

            var cacheSettings = new CacheSettings
            {
                MetadataCacheDuration = new TimeSpan(0, 0, 10, 0),
                ProfileCacheDuration = new TimeSpan(0, 0, 10, 0),
                StatsCacheDuration = null //Don't cache 'Stats' endpoints.
            };

            var client = new HaloClient(developerAccessProduct, cacheSettings);
            Session = client.StartSession();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            Session.Dispose();
        }
    }
}