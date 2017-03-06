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
    public class GetWarzoneServiceRecordTests
    {
        private IHaloSession _mockSession;
        private WarzoneServiceRecord _warzoneServiceRecord;

        [SetUp]
        public void Setup()
        {
            _warzoneServiceRecord = JsonConvert.DeserializeObject<WarzoneServiceRecord>(File.ReadAllText(Halo5Config.WarzoneServiceRecordJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<WarzoneServiceRecord>(It.IsAny<string>()))
                .ReturnsAsync(_warzoneServiceRecord);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetWarzoneServiceRecord();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("stats/h5/servicerecords/warzone", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetWarzoneServiceRecord()
                .ForPlayer(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/servicerecords/warzone?players={gamertag}", uri);
        }

        [Test]
        [TestCase("Greenskull", "Furiousn00b")]
        public void GetConstructedUri_ForPlayers_MatchesExpected(string gamertag, string gamertag2)
        {
            var query = new GetWarzoneServiceRecord()
                .ForPlayers(new List<string> { gamertag, gamertag2 });

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/servicerecords/warzone?players={gamertag},{gamertag2}", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetWarzoneServiceRecord(string gamertag)
        {
            var query = new GetWarzoneServiceRecord()
                .ForPlayer(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(WarzoneServiceRecord), result);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetWarzoneServiceRecord()
                .ForPlayer("Player")
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(WarzoneServiceRecord), result);
            Assert.AreEqual(_warzoneServiceRecord, result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetWarzoneServiceRecord_DoesNotThrow(string gamertag)
        {
            var query = new GetWarzoneServiceRecord()
                .ForPlayer(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(WarzoneServiceRecord), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetWarzoneServiceRecord_SchemaIsValid(string gamertag)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.WarzoneServiceRecordJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.WarzoneServiceRecordJsonSchemaPath))
            });

            var query = new GetWarzoneServiceRecord()
                .ForPlayer(gamertag)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetWarzoneServiceRecord_ModelMatchesSchema(string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.WarzoneServiceRecordJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.WarzoneServiceRecordJsonSchemaPath))
            });

            var query = new GetWarzoneServiceRecord()
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
        [TestCase("moussanator")]
        public async Task GetWarzoneServiceRecord_IsSerializable(string gamertag)
        {
            var query = new GetWarzoneServiceRecord()
                .ForPlayer(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<WarzoneServiceRecord>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetWarzoneServiceRecord_MissingPlayer()
        {
            var query = new GetWarzoneServiceRecord();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetWarzoneServiceRecord_InvalidGamertag(string gamertag)
        {
            var query = new GetWarzoneServiceRecord()
                .ForPlayer(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}