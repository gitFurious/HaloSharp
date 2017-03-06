using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Common;
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
    public class GetMatchHistoryTests
    {
        private const string Json = HaloWars2Config.MatchHistoryJsonPath;
        private const string Schema = HaloWars2Config.MatchHistoryJsonSchemaPath;

        private IHaloSession _mockSession;
        private MatchSet<Model.HaloWars2.Stats.PlayerMatch> _response;

        [SetUp]
        public void Setup()
        {
            _response = JsonConvert.DeserializeObject<MatchSet<Model.HaloWars2.Stats.PlayerMatch>>(File.ReadAllText(Json));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<MatchSet<Model.HaloWars2.Stats.PlayerMatch>>(It.IsAny<string>()))
                .ReturnsAsync(_response);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("Furiousn00b")]
        public void GetConstructedUri_NoParameters_MatchHistoryesExpected(string player)
        {
            var query = new GetMatchHistory(player);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/hw2/players/{player}/matches", uri);
        }

        [Test]
        [TestCase("Furiousn00b", Enumeration.HaloWars2.MatchType.Custom)]
        [TestCase("Furiousn00b", Enumeration.HaloWars2.MatchType.Matchmaking)]
        public void GetConstructedUri_ForMatchType_MatchesExpected(string player, Enumeration.HaloWars2.MatchType matchType)
        {
            var query = new GetMatchHistory(player)
                .ForMatchType(matchType);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/hw2/players/{player}/matches?matchType={matchType}", uri);
        }

        [Test]
        [TestCase("Furiousn00b", 5)]
        [TestCase("Furiousn00b", 10)]
        public void GetConstructedUri_Skip_MatchesExpected(string player, int count)
        {
            var query = new GetMatchHistory(player)
                .Skip(count);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/hw2/players/{player}/matches?start={count}", uri);
        }

        [Test]
        [TestCase("Furiousn00b", 5)]
        [TestCase("Furiousn00b", 10)]
        public void GetConstructedUri_Take_MatchesExpected(string player, int take)
        {
            var query = new GetMatchHistory(player)
                .Take(take);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/hw2/players/{player}/matches?count={take}", uri);
        }

        [Test]
        [TestCase("Furiousn00b", Enumeration.HaloWars2.MatchType.Custom, 10, 20)]
        public void GetConstructedUri_Complex_MatchesExpected(string player, Enumeration.HaloWars2.MatchType matchType, int skip, int take)
        {
            var query = new GetMatchHistory(player)
                .ForMatchType(matchType)
                .Skip(skip)
                .Take(take);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/hw2/players/{player}/matches?matchType={matchType}&start={skip}&count={take}", uri);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task Query_DoesNotThrow(string player)
        {
            var query = new GetMatchHistory(player)
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(MatchSet<Model.HaloWars2.Stats.PlayerMatch>), result);
            Assert.AreEqual(_response, result);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task GetMatchHistory_DoesNotThrow(string player)
        {
            var query = new GetMatchHistory(player)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(MatchSet<Model.HaloWars2.Stats.PlayerMatch>), result);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task GetMatchHistory_SchemaIsValid(string player)
        {
            var jSchema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var query = new GetMatchHistory(player)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(jSchema, jArray);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task GetMatchHistory_ModelMatchHistoryesSchema(string player)
        {
            var schema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var query = new GetMatchHistory(player)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task GetMatchHistory_IsSerializable(string player)
        {
            var query = new GetMatchHistory(player)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<MatchSet<Model.HaloWars2.Stats.PlayerMatch>>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("")]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetMatchHistory_InvalidGamertag(string player)
        {
            var query = new GetMatchHistory(player)
                .SkipCache();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}