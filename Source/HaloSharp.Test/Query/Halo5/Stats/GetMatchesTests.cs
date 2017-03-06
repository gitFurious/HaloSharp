using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Stats;
using HaloSharp.Query.Halo5.Stats;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Stats
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
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetMatches();

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/players/{null}/matches{null}", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetMatches()
                .ForPlayer(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/players/{gamertag}/matches{null}", uri);
        }

        [Test]
        [TestCase(Enumeration.Halo5.GameMode.Arena)]
        [TestCase(Enumeration.Halo5.GameMode.Warzone)]
        public void GetConstructedUri_InGameMode_MatchesExpected(Enumeration.Halo5.GameMode gameMode)
        {
            var query = new GetMatches()
                .InGameMode(gameMode);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/players/{null}/matches?modes={gameMode}", uri);
        }

        [Test]
        [TestCase(Enumeration.Halo5.GameMode.Arena, Enumeration.Halo5.GameMode.Warzone)]
        [TestCase(Enumeration.Halo5.GameMode.Campaign, Enumeration.Halo5.GameMode.Custom)]
        public void GetConstructedUri_InGameModes_MatchesExpected(Enumeration.Halo5.GameMode gameMode1, Enumeration.Halo5.GameMode gameMode2)
        {
            var query = new GetMatches()
                .InGameModes(new List<Enumeration.Halo5.GameMode> {gameMode1, gameMode2});

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/players/{null}/matches?modes={gameMode1},{gameMode2}", uri);
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void GetConstructedUri_Skip_MatchesExpected(int skip)
        {
            var query = new GetMatches()
                .Skip(skip);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/players/{null}/matches?start={skip}", uri);
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void GetConstructedUri_Take_MatchesExpected(int take)
        {
            var query = new GetMatches()
                .Take(take);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/players/{null}/matches?count={take}", uri);
        }

        [Test]
        [TestCase("Greenskull", Enumeration.Halo5.GameMode.Warzone, 5, 10)]
        [TestCase("Furiousn00b", Enumeration.Halo5.GameMode.Arena, 15, 20)]
        public void GetConstructedUri_Complex_MatchesExpected(string gamertag, Enumeration.Halo5.GameMode gameMode, int skip, int take)
        {
            var query = new GetMatches()
                .ForPlayer(gamertag)
                .InGameMode(gameMode)
                .Skip(skip)
                .Take(take)
                .SkipCache();

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/players/{gamertag}/matches?modes={gameMode}&start={skip}&count={take}", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetMatches()
                .ForPlayer("Player")
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
            var query = new GetMatches()
                .ForPlayer(gamertag)
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

            var query = new GetMatches()
                .ForPlayer(gamertag)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

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

            var query = new GetMatches()
                .ForPlayer(gamertag)
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
            var query = new GetMatches()
                .ForPlayer(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<MatchSet<PlayerMatch>>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetMatches_MissingPlayer()
        {
            var query = new GetMatches();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetMatches_InvalidGamertag(string gamertag)
        {
            var query = new GetMatches()
                .ForPlayer(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}