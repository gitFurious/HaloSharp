using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Stats;
using HaloSharp.Query.Halo5Forge.Stats;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5Forge.Stats
{
    [TestFixture]
    public class GetMatchesTests
    {
        private IHaloSession _mockSession;
        private MatchSet<PlayerMatch> _matchSet;

        [SetUp]
        public void Setup()
        {
            _matchSet = JsonConvert.DeserializeObject<MatchSet<PlayerMatch>>(File.ReadAllText(Halo5Config.MatchesJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<MatchSet<PlayerMatch>>(It.IsAny<string>()))
                .ReturnsAsync(_matchSet);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("Greenskull", Enumeration.Halo5.GameMode.Warzone, 5, 10)]
        [TestCase("Furiousn00b", Enumeration.Halo5.GameMode.Arena, 15, 20)]
        public void Uri_MatchesExpected(string gamertag, Enumeration.Halo5.GameMode gameMode, int skip, int take)
        {
            var query = new GetMatchHistory(gamertag);

            Assert.AreEqual($"https://www.haloapi.com/stats/h5pc/players/{gamertag}/matches", query.Uri);

            query.InGameMode(gameMode);

            Assert.AreEqual($"https://www.haloapi.com/stats/h5pc/players/{gamertag}/matches?modes={gameMode}", query.Uri);

            query.Skip(skip);

            Assert.AreEqual($"https://www.haloapi.com/stats/h5pc/players/{gamertag}/matches?modes={gameMode}&start={skip}", query.Uri);

            query.Take(take);

            Assert.AreEqual($"https://www.haloapi.com/stats/h5pc/players/{gamertag}/matches?modes={gameMode}&start={skip}&count={take}", query.Uri);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task Query_DoesNotThrow(string gamertag)
        {
            var query = new GetMatchHistory(gamertag)
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(MatchSet<PlayerMatch>), result);
            Assert.AreEqual(_matchSet, result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetMatches_DoesNotThrow(string gamertag)
        {
            var query = new GetMatchHistory(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(MatchSet<PlayerMatch>), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetMatches_SchemaIsValid(string gamertag)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.MatchesJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.MatchesJsonSchemaPath))
            });

            var query = new GetMatchHistory(gamertag)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetMatches_ModelMatchesSchema(string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.MatchesJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.MatchesJsonSchemaPath))
            });

            var query = new GetMatchHistory(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetMatches_IsSerializable(string gamertag)
        {
            var query = new GetMatchHistory(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<MatchSet<PlayerMatch>>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetMatches_InvalidGamertag(string gamertag)
        {
            var query = new GetMatchHistory(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}