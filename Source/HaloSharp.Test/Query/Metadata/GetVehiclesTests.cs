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
    public class GetVehiclesTests
    {
        private const string BaseUri = "metadata/h5/metadata/vehicles";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetVehicles();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        public async Task GetVehicles()
        {
            var query = new GetVehicles()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Vehicle>), result);
        }

        [Test]
        public async Task GetVehicles_IsSerializable()
        {
            var query = new GetVehicles()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Vehicle>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}