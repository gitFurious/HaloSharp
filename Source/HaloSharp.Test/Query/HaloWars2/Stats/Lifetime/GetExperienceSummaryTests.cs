using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.HaloWars2.Stats.Lifetime;
using HaloSharp.Query.HaloWars2.Stats.Lifetime;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.HaloWars2.Stats.Lifetime
{
    [TestFixture]
    public class GetExperienceSummaryTests
    {
        private const string Json = HaloWars2Config.ExperienceSummaryJsonPath;
        private const string Schema = HaloWars2Config.ExperienceSummaryJsonSchemaPath;

        private IHaloSession _mockSession;
        private ExperienceSummaryResultSet _response;

        [SetUp]
        public void Setup()
        {
            _response = JsonConvert.DeserializeObject<ExperienceSummaryResultSet>(File.ReadAllText(Json));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<ExperienceSummaryResultSet>(It.IsAny<string>()))
                .ReturnsAsync(_response);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("Furiousn00b")]
        public void GetConstructedUri_MatchesExpected(string gamertag)
        {
            var query = new GetExperienceSummary(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/hw2/xp?players={gamertag}", uri);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task Query_DoesNotThrow(string gamertag)
        {
            var query = new GetExperienceSummary(gamertag)
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(ExperienceSummaryResultSet), result);
            Assert.AreEqual(_response, result);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task GetExperienceSummary_DoesNotThrow(string gamertag)
        {
            var query = new GetExperienceSummary(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(ExperienceSummaryResultSet), result);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task GetExperienceSummary_SchemaIsValid(string gamertag)
        {
            var jSchema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var query = new GetExperienceSummary(gamertag)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(jSchema, jArray);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task GetExperienceSummary_ModelMatchesSchema(string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var query = new GetExperienceSummary(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task GetExperienceSummary_IsSerializable(string gamertag)
        {
            var query = new GetExperienceSummary(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<ExperienceSummaryResultSet>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("")]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetExperienceSummary_InvalidGamertag(string gamertag)
        {
            var query = new GetExperienceSummary(gamertag)
                .SkipCache();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}