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
    public class GetFlexibleStatsTests
    {
        private const string BaseUri = "metadata/h5/metadata/flexible-stats";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetFlexibleStats();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        public async Task GetFlexibleStats()
        {
            var query = new GetFlexibleStats()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (List<FlexibleStat>), result);
        }

        [Test]
        public async Task GetFlexibleStats_IsSerializable()
        {
            var query = new GetFlexibleStats()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<List<FlexibleStat>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}