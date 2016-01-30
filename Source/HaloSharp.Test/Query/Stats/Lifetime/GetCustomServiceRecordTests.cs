using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Stats.Lifetime;
using HaloSharp.Query.Stats.Lifetime;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Stats.Lifetime
{
    [TestFixture]
    public class GetCustomServiceRecordTests
    {
        private IHaloSession _mockSession;
        private CustomServiceRecord _customServiceRecord;

        [SetUp]
        public void Setup()
        {
            _customServiceRecord = JsonConvert.DeserializeObject<CustomServiceRecord>(File.ReadAllText(Config.CustomServiceRecordJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<CustomServiceRecord>(It.IsAny<string>()))
                .ReturnsAsync(_customServiceRecord);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetCustomServiceRecord();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("stats/h5/servicerecords/custom", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetCustomServiceRecord()
                .ForPlayer(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/servicerecords/custom?players={gamertag}", uri);
        }

        [Test]
        [TestCase("Greenskull", "Furiousn00b")]
        public void GetConstructedUri_ForPlayers_MatchesExpected(string gamertag, string gamertag2)
        {
            var query = new GetCustomServiceRecord()
                .ForPlayers(new List<string> { gamertag, gamertag2 });

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/servicerecords/custom?players={gamertag},{gamertag2}", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetCustomServiceRecord(string gamertag)
        {
            var query = new GetCustomServiceRecord()
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(CustomServiceRecord), result);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetCustomServiceRecord()
                .ForPlayer("Player");

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(CustomServiceRecord), result);
            Assert.AreEqual(_customServiceRecord, result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetCustomServiceRecord_DoesNotThrow(string gamertag)
        {
            var query = new GetCustomServiceRecord()
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(CustomServiceRecord), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetCustomServiceRecord_SchemaIsValid(string gamertag)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Config.CustomServiceRecordJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.CustomServiceRecordJsonSchemaPath))
            });

            var query = new GetCustomServiceRecord()
                .ForPlayer(gamertag);

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetCustomServiceRecord_ModelMatchesSchema(string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.CustomServiceRecordJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.CustomServiceRecordJsonSchemaPath))
            });

            var query = new GetCustomServiceRecord()
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetCustomServiceRecord_IsSerializable(string gamertag)
        {
            var query = new GetCustomServiceRecord()
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            SerializationUtility<CustomServiceRecord>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetCustomServiceRecord_MissingPlayer()
        {
            var query = new GetCustomServiceRecord();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetCustomServiceRecord_InvalidGamertag(string gamertag)
        {
            var query = new GetCustomServiceRecord()
                .ForPlayer(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}