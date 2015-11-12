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
    public class GetWeaponsTests
    {
        private const string BaseUri = "metadata/h5/metadata/weapons";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetWeapons();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        public async Task GetWeapons()
        {
            var query = new GetWeapons()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Weapon>), result);
        }

        [Test]
        public async Task GetWeapons_IsSerializable()
        {
            var query = new GetWeapons()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Weapon>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}