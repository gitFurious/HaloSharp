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
    public class GetCampaignMissionsTests
    {
        private const string BaseUri = "metadata/h5/metadata/campaign-missions";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetCampaignMissions();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        public async Task GetCampaignMissions()
        {
            var query = new GetCampaignMissions()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (List<CampaignMission>), result);
        }

        [Test]
        public async Task GetCampaignMissions_IsSerializable()
        {
            var query = new GetCampaignMissions()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<List<CampaignMission>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}