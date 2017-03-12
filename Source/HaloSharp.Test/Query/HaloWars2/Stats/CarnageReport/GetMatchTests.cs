using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Extension;
using HaloSharp.Query.HaloWars2.Stats.CarnageReport;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using Match = HaloSharp.Model.HaloWars2.Stats.CarnageReport.Match;

namespace HaloSharp.Test.Query.HaloWars2.Stats.CarnageReport
{
    [TestFixture]
    public class GetMatchTests
    {
        private const string Json = HaloWars2Config.MatchJsonPath;
        private const string Schema = HaloWars2Config.MatchJsonSchemaPath;

        private IHaloSession _mockSession;
        private Match _response;

        [SetUp]
        public void Setup()
        {
            _response = JsonConvert.DeserializeObject<Match>(File.ReadAllText(Json));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<Match>(It.IsAny<string>()))
                .ReturnsAsync(_response);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("bf03af8a-763e-44d2-b86b-631da83ab1a3")]
        public void Uri_MatchesExpected(string guid)
        {
            var query = new GetMatchDetails(new Guid(guid));

            Assert.AreEqual($"https://www.haloapi.com/stats/hw2/matches/{guid}", query.Uri);
        }

        [Test]
        [TestCase("bf03af8a-763e-44d2-b86b-631da83ab1a3")]
        public async Task Query_DoesNotThrow(string guid)
        {
            var matchId = new Guid(guid);

            var query = new GetMatchDetails(matchId)
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(Match), result);
            Assert.AreEqual(_response, result);
        }

        [Test]
        [TestCase("bf03af8a-763e-44d2-b86b-631da83ab1a3")]
        public async Task GetMatch_DoesNotThrow(string guid)
        {
            var matchId = new Guid(guid);
            
            var query = new GetMatchDetails(matchId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(Match), result);
        }

        [Test]
        [TestCase("bf03af8a-763e-44d2-b86b-631da83ab1a3")]
        public async Task GetMatch_SchemaIsValid(string guid)
        {
            var jSchema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var matchId = new Guid(guid);

            var query = new GetMatchDetails(matchId)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(jSchema, jArray);
        }

        [Test]
        [TestCase("bf03af8a-763e-44d2-b86b-631da83ab1a3")]
        public async Task GetMatch_ModelMatchesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var matchId = new Guid(guid);

            var query = new GetMatchDetails(matchId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("bf03af8a-763e-44d2-b86b-631da83ab1a3")]
        public async Task GetMatch_IsSerializable(string guid)
        {
            var matchId = new Guid(guid);

            var query = new GetMatchDetails(matchId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<Match>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}