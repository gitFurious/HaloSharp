using System;

namespace HaloSharp.Model.Stats.Common
{
    [Serializable]
    public class Link
    {
        public int AcknowledgementTypeId { get; set; }
        public bool AuthenticationLifetimeExtensionSupported { get; set; }
        public string AuthorityId { get; set; }
        public string Path { get; set; }
        public object QueryString { get; set; }
        public string RetryPolicyId { get; set; }
        public string TopicName { get; set; }
    }
}