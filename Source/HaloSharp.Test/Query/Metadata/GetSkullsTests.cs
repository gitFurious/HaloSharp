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
    public class GetSkullsTests
    {
        private const string BaseUri = "metadata/h5/metadata/skulls";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetSkulls();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        public async Task GetSkulls()
        {
            var query = new GetSkulls()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Skull>), result);
        }

        [Test]
        public async Task GetSkulls_IsSerializable()
        {
            var query = new GetSkulls()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Skull>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}