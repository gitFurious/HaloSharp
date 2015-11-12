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
    public class GetMapsTests
    {
        private const string BaseUri = "metadata/h5/metadata/maps";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetMaps();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        public async Task GetMaps()
        {
            var query = new GetMaps()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Map>), result);
        }

        [Test]
        public async Task GetMaps_IsSerializable()
        {
            var query = new GetMaps()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Map>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}