using System;

namespace HaloSharp.Model
{
    public class Product
    {
        public string SubscriptionKey { get; set; }
        public RateLimit RateLimit { get; set; }
    }

    public class RateLimit
    {
        public int RequestCount { get; set; }
        public TimeSpan TimspSpan { get; set; }
        public TimeSpan Timeout { get; set; }
    }
}
