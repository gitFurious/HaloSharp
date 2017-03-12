using Autofac;
using HaloSharp.Model;
using System;
using System.Configuration;

namespace HaloSharp.Console.Infrastructure
{
    internal class HaloSharpModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var subscriptionKey = ConfigurationManager.AppSettings["SubscriptionKey"];

            var product = new Product
            {
                SubscriptionKey = subscriptionKey,
                RateLimit = new RateLimit
                {
                    RequestCount = 200,
                    TimeSpan = new TimeSpan(0, 0, 0, 10),
                    Timeout = new TimeSpan(0, 0, 0, 10)
                }
            };

            var cacheSettings = new CacheSettings
            {
                CacheDuration = new TimeSpan(0, 1, 0, 0)
            };

            var haloClient = new HaloClient(product, cacheSettings);
            var haloSession = haloClient.StartSession();

            builder.RegisterInstance(haloSession)
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
