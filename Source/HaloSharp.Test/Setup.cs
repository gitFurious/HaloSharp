using HaloSharp.Model;
using NUnit.Framework;
using System;

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
                CacheDuration = null
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