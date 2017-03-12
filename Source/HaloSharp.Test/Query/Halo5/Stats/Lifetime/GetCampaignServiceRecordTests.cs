using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.Halo5.Stats.Lifetime;
using HaloSharp.Query.Halo5.Stats.Lifetime;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Stats.Lifetime
{
    [TestFixture]
    public class GetCampaignServiceRecordTests
    {
        private IHaloSession _mockSession;
        private CampaignServiceRecord _campaignServiceRecord;

        [SetUp]
        public void Setup()
        {
            _campaignServiceRecord = JsonConvert.DeserializeObject<CampaignServiceRecord>(File.ReadAllText(Halo5Config.CampaignServiceRecordJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<CampaignServiceRecord>(It.IsAny<string>()))
                .ReturnsAsync(_campaignServiceRecord);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public void Uri_MatchesExpected(string gamertag)
        {
            var query = new GetCampaignServiceRecord(gamertag);

            Assert.AreEqual($"https://www.haloapi.com/stats/h5/servicerecords/campaign?players={gamertag}", query.Uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetCampaignServiceRecord(string gamertag)
        {
            var query = new GetCampaignServiceRecord(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(CampaignServiceRecord), result);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetCampaignServiceRecord("Player")
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(CampaignServiceRecord), result);
            Assert.AreEqual(_campaignServiceRecord, result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetCampaignServiceRecord_DoesNotThrow(string gamertag)
        {
            var query = new GetCampaignServiceRecord(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(CampaignServiceRecord), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetCampaignServiceRecord_SchemaIsValid(string gamertag)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.CampaignServiceRecordJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.CampaignServiceRecordJsonSchemaPath))
            });

            var query = new GetCampaignServiceRecord(gamertag)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetCampaignServiceRecord_ModelMatchesSchema(string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.CampaignServiceRecordJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.CampaignServiceRecordJsonSchemaPath))
            });

            var query = new GetCampaignServiceRecord(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetCampaignServiceRecord_IsSerializable(string gamertag)
        {
            var query = new GetCampaignServiceRecord(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<CampaignServiceRecord>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetCampaignServiceRecord_InvalidGamertag(string gamertag)
        {
            var query = new GetCampaignServiceRecord(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}