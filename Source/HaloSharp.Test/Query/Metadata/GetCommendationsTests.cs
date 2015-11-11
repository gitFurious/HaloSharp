using HaloSharp.Extension;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using HaloSharp.Test.Utility;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetCommendationsTests : TestSessionSetup
    {
        [Test]
        public async Task GetCommendations()
        {
            var query = new GetCommendations()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Commendation>), result);
        }

        [Test]
        public async Task GetCommendations_IsSerializable()
        {
            var query = new GetCommendations()
                .SkipCache();

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Commendation>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}