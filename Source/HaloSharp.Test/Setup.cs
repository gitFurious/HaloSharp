namespace HaloSharp.Test
{
    public class TestSessionSetup
    {
        private IHaloSession _session;
        public IHaloSession Session
        {
            get
            {
                if (_session == null)
                {
                    var client = new HaloClient("00000000000000000000000000000000");
                    _session = client.StartSession();
                }
                return _session;
            }
        }
    }
}