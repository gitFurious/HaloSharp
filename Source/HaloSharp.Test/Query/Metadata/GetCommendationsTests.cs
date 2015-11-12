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
    public class GetCommendationsTests
    {
        private const string BaseUri = "metadata/h5/metadata/commendations";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetCommendations();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        public async Task GetCommendations()
        {
            var query = new GetCommendations()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Commendation>), result);
        }

        [Test]
        public async Task GetCommendations_IsSerializable()
        {
            var query = new GetCommendations()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Commendation>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}