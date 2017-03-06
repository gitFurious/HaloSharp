using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Extension;
using HaloSharp.Model.Halo5.Metadata;
using HaloSharp.Query.Halo5.Metadata;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Metadata
{
    [TestFixture]
    public class GetCampaignMissionsTests
    {
        private IHaloSession _mockSession;
        private List<CampaignMission> _campaignMissions;

        [SetUp]
        public void Setup()
        {
            _campaignMissions = JsonConvert.DeserializeObject<List<CampaignMission>>(File.ReadAllText(Halo5Config.CampaignMissionsJsonPath));
            
            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<CampaignMission>>(It.IsAny<string>()))
                .ReturnsAsync(_campaignMissions);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetCampaignMissions();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/campaign-missions", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetCampaignMissions()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof (List<CampaignMission>), result);
            Assert.AreEqual(_campaignMissions, result);
        }

        [Test]
        public async Task GetCampaignMissions_DoesNotThrow()
        {
            var query = new GetCampaignMissions()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<CampaignMission>), result);
        }

        [Test]
        public async Task GetCampaignMissions_SchemaIsValid()
        {
            var campaignMissionsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.CampaignMissionsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.CampaignMissionsJsonSchemaPath))
            });

            var query = new GetCampaignMissions()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(campaignMissionsSchema, jArray);
        }

        [Test]
        public async Task GetCampaignMissions_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.CampaignMissionsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.CampaignMatchJsonSchemaPath))
            });

            var query = new GetCampaignMissions()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetCampaignMissions_IsSerializable()
        {
            var query = new GetCampaignMissions()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<CampaignMission>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}