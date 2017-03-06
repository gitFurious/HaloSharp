using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Extension;
using HaloSharp.Query.HaloWars2.Stats.Match;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.HaloWars2.Stats.Match
{
    [TestFixture]
    public class GetMatchEventsTests
    {
        private const string Json = HaloWars2Config.MatchEventsJsonPath;
        private const string Schema = HaloWars2Config.MatchEventsJsonSchemaPath;

        private IHaloSession _mockSession;
        private Model.HaloWars2.Stats.MatchEventSummary _response;

        [SetUp]
        public void Setup()
        {
            _response = JsonConvert.DeserializeObject<Model.HaloWars2.Stats.MatchEventSummary>(File.ReadAllText(Json));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<Model.HaloWars2.Stats.MatchEventSummary>(It.IsAny<string>()))
                .ReturnsAsync(_response);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("bf03af8a-763e-44d2-b86b-631da83ab1a3")]
        public void GetConstructedUri_NoParameters_MatchEventsesExpected(string guid)
        {
            var matchId = new Guid(guid);

            var query = new GetMatchEvents(matchId);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/hw2/matches/{matchId}/events", uri);
        }

        [Test]
        [TestCase("bf03af8a-763e-44d2-b86b-631da83ab1a3")]
        public async Task Query_DoesNotThrow(string guid)
        {
            var matchId = new Guid(guid);

            var query = new GetMatchEvents(matchId)
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(Model.HaloWars2.Stats.MatchEventSummary), result);
            Assert.AreEqual(_response, result);
        }

        [Test]
        [TestCase("2767d98c-929b-4455-8b4f-92d31145fff1")]
        public async Task GetMatchEvents_DoesNotThrow(string guid)
        {
            var matchId = new Guid(guid);
            
            var query = new GetMatchEvents(matchId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(Model.HaloWars2.Stats.MatchEventSummary), result);
        }

        [Test]
        [TestCase("bf03af8a-763e-44d2-b86b-631da83ab1a3")]
        public async Task GetMatchEvents_SchemaIsValid(string guid)
        {
            var jSchema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var matchId = new Guid(guid);

            var query = new GetMatchEvents(matchId)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(jSchema, jArray);
        }

        [Test]
        [TestCase("bf03af8a-763e-44d2-b86b-631da83ab1a3")]
        public async Task GetMatchEvents_ModelMatchEventsesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var matchId = new Guid(guid);

            var query = new GetMatchEvents(matchId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("bf03af8a-763e-44d2-b86b-631da83ab1a3")]
        public async Task GetMatchEvents_IsSerializable(string guid)
        {
            var matchId = new Guid(guid);

            var query = new GetMatchEvents(matchId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<Model.HaloWars2.Stats.MatchEventSummary>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}