using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.HaloWars2.Stats;
using HaloSharp.Query.HaloWars2.Stats.Player;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.HaloWars2.Stats.Player
{
    [TestFixture]
    public class GetSeasonSummaryTests
    {
        private const string Json = HaloWars2Config.SeasonSummaryJsonPath;
        private const string Schema = HaloWars2Config.SeasonSummaryJsonSchemaPath;

        private IHaloSession _mockSession;
        private SeasonSummary _response;

        [SetUp]
        public void Setup()
        {
            _response = JsonConvert.DeserializeObject<SeasonSummary>(File.ReadAllText(Json));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<SeasonSummary>(It.IsAny<string>()))
                .ReturnsAsync(_response);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("2cdf3fae-3cf9-45a5-8165-7aff644ccdbc", "Furiousn00b")]
        public void GetConstructedUri_MatchesExpected(string guid, string gamertag)
        {
            var seasonId = new Guid(guid);

            var query = new GetSeasonSummary(gamertag, seasonId);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/hw2/players/{gamertag}/stats/seasons/{seasonId}", uri);
        }

        [Test]
        [TestCase("2cdf3fae-3cf9-45a5-8165-7aff644ccdbc", "Furiousn00b")]
        public async Task Query_DoesNotThrow(string guid, string gamertag)
        {
            var seasonId = new Guid(guid);

            var query = new GetSeasonSummary(gamertag, seasonId)
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(SeasonSummary), result);
            Assert.AreEqual(_response, result);
        }

        [Test]
        [TestCase("2cdf3fae-3cf9-45a5-8165-7aff644ccdbc", "Furiousn00b")]
        public async Task GetSeasonSummary_DoesNotThrow(string guid, string gamertag)
        {
            var seasonId = new Guid(guid);

            var query = new GetSeasonSummary(gamertag, seasonId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(SeasonSummary), result);
        }

        [Test]
        [TestCase("2cdf3fae-3cf9-45a5-8165-7aff644ccdbc", "Furiousn00b")]
        public async Task GetSeasonSummary_SchemaIsValid(string guid, string gamertag)
        {
            var jSchema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var seasonId = new Guid(guid);

            var query = new GetSeasonSummary(gamertag, seasonId)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(jSchema, jArray);
        }

        [Test]
        [TestCase("2cdf3fae-3cf9-45a5-8165-7aff644ccdbc", "Furiousn00b")]
        public async Task GetSeasonSummary_ModelMatchesSchema(string guid, string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var seasonId = new Guid(guid);

            var query = new GetSeasonSummary(gamertag, seasonId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("2cdf3fae-3cf9-45a5-8165-7aff644ccdbc", "Furiousn00b")]
        public async Task GetSeasonSummary_IsSerializable(string guid, string gamertag)
        {
            var seasonId = new Guid(guid);

            var query = new GetSeasonSummary(gamertag, seasonId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<SeasonSummary>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("2cdf3fae-3cf9-45a5-8165-7aff644ccdbc", "")]
        [TestCase("2cdf3fae-3cf9-45a5-8165-7aff644ccdbc", "00000000000000017")]
        [TestCase("2cdf3fae-3cf9-45a5-8165-7aff644ccdbc", "!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetSeasonSummary_InvalidGamertag(string guid, string gamertag)
        {
            var seasonId = new Guid(guid);

            var query = new GetSeasonSummary(gamertag, seasonId)
                .SkipCache();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase("Furiousn00b")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetSeasonSummary_InvalidSeason(string gamertag)
        {
            var seasonId = new Guid();

            var query = new GetSeasonSummary(gamertag, seasonId)
                .SkipCache();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}