namespace HaloSharp
{
    public class HaloClient
    {
        private readonly string _subscriptionKey;

        public HaloClient(string subscriptionKey)
        {
            _subscriptionKey = subscriptionKey;
        }

        public IHaloSession StartSession()
        {
            var session = new HaloSession(_subscriptionKey);

            return session;
        }
    }
}