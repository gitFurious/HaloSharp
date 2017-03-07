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
    public class GetArenaServiceRecordTests
    {
        private IHaloSession _mockSession;
        private ArenaServiceRecord _arenaServiceRecord;

        [SetUp]
        public void Setup()
        {
            _arenaServiceRecord = JsonConvert.DeserializeObject<ArenaServiceRecord>(File.ReadAllText(Halo5Config.ArenaServiceRecordJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<ArenaServiceRecord>(It.IsAny<string>()))
                .ReturnsAsync(_arenaServiceRecord);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator ")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetArenaServiceRecord(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/servicerecords/arena?players={gamertag}", uri);
        }

        [Test]
        [TestCase("Greenskull", "Furiousn00b")]
        public void GetConstructedUri_ForPlayers_MatchesExpected(string gamertag, string gamertag2)
        {
            var query = new GetArenaServiceRecord(new List<string> {gamertag, gamertag2});

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/servicerecords/arena?players={gamertag},{gamertag2}", uri);
        }

        [Test]
        [TestCase("Furiousn00b", "2041d318-dd22-47c2-a487-2818ecf14e41")]
        [TestCase("Greenskull", "2fcc20a0-53ff-4ffb-8f72-eebb2e419273")]
        [TestCase("moussanator", "b46c2095-4ca6-4f4b-a565-4702d7cfe586")]
        public void GetConstructedUri_Complex_MatchesExpected(string gamertag, string guid)
        {
            var query = new GetArenaServiceRecord(gamertag)
                .ForSeasonId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/servicerecords/arena?players={gamertag}&seasonId={guid}", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetArenaServiceRecord(string gamertag)
        {
            var query = new GetArenaServiceRecord(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (ArenaServiceRecord), result);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetArenaServiceRecord("Player")
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(ArenaServiceRecord), result);
            Assert.AreEqual(_arenaServiceRecord, result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetArenaServiceRecord_DoesNotThrow(string gamertag)
        {
            var query = new GetArenaServiceRecord(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(ArenaServiceRecord), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetArenaServiceRecord_SchemaIsValid(string gamertag)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.ArenaServiceRecordJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.ArenaServiceRecordJsonSchemaPath))
            });

            var query = new GetArenaServiceRecord(gamertag)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetArenaServiceRecord_ModelMatchesSchema(string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.ArenaServiceRecordJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.ArenaServiceRecordJsonSchemaPath))
            });

            var query = new GetArenaServiceRecord(gamertag)
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
        public async Task GetArenaServiceRecord_IsSerializable(string gamertag)
        {
            var query = new GetArenaServiceRecord(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<ArenaServiceRecord>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetArenaServiceRecord_InvalidGamertag(string gamertag)
        {
            var query = new GetArenaServiceRecord(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}