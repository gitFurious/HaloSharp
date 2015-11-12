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
            var client = new HaloClient("00000000000000000000000000000000");
            Session = client.StartSession();
        }

        [TearDown]
        public void RunAfterAnyTests()
        {
            Session.Dispose();
        }
    }
}