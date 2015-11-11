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
    public class GetCampaignMissionsTests : TestSessionSetup
    {
        [Test]
        public async Task GetCampaignMissions()
        {
            var query = new GetCampaignMissions()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<CampaignMission>), result);
        }

        [Test]
        public async Task GetCampaignMissions_IsSerializable()
        {
            var query = new GetCampaignMissions()
                .SkipCache();

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<List<CampaignMission>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}