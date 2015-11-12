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
    public class GetSpartanRanksTests
    {
        private const string BaseUri = "metadata/h5/metadata/spartan-ranks";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetSpartanRanks();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        public async Task GetSpartanRanks()
        {
            var query = new GetSpartanRanks()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (List<SpartanRank>), result);
        }

        [Test]
        public async Task GetSpartanRanks_IsSerializable()
        {
            var query = new GetSpartanRanks()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<List<SpartanRank>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}