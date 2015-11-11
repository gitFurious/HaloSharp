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
    public class GetMapsTests : TestSessionSetup
    {
        [Test]
        public async Task GetMaps()
        {
            var query = new GetMaps()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Map>), result);
        }

        [Test]
        public async Task GetMaps_IsSerializable()
        {
            var query = new GetMaps()
                .SkipCache();

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Map>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}