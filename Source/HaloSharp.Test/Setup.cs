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
            var subscriptionKey = Environment.GetEnvironmentVariable("SUBSCRIPTION_KEY");
            var requestCount = int.Parse(Environment.GetEnvironmentVariable("REQUEST_COUNT"));
            var timeSpanSeconds = int.Parse(Environment.GetEnvironmentVariable("TIME_SPAN_SECONDS"));
            var timeoutSeconds = int.Parse(Environment.GetEnvironmentVariable("TIME_OUT_SECONDS"));

            var developerAccessProduct = new Product
            {
                SubscriptionKey = subscriptionKey,
                RateLimit = new RateLimit
                {
                    RequestCount = requestCount,
                    TimspSpan = new TimeSpan(0, 0, 0, timeSpanSeconds),
                    Timeout = new TimeSpan(0, 0, 0, timeoutSeconds)
                }
            };

            var client = new HaloClient(developerAccessProduct);
            Session = client.StartSession();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            Session.Dispose();
        }
    }
}