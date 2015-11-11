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
    public class GetVehiclesTests : TestSessionSetup
    {
        [Test]
        public async Task GetVehicles()
        {
            var query = new GetVehicles()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Vehicle>), result);
        }

        [Test]
        public async Task GetVehicles_IsSerializable()
        {
            var query = new GetVehicles()
                .SkipCache();

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Vehicle>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}