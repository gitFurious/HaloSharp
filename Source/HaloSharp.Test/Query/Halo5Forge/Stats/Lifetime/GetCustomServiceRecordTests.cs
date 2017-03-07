using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.Halo5.Stats.Lifetime;
using HaloSharp.Query.Halo5Forge.Stats.Lifetime;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5Forge.Stats.Lifetime
{
    [TestFixture]
    public class GetCustomServiceRecordTests
    {
        private IHaloSession _mockSession;
        private CustomServiceRecord _customServiceRecord;

        [SetUp]
        public void Setup()
        {
            _customServiceRecord = JsonConvert.DeserializeObject<CustomServiceRecord>(File.ReadAllText(Halo5Config.CustomServiceRecordJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<CustomServiceRecord>(It.IsAny<string>()))
                .ReturnsAsync(_customServiceRecord);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetCustomServiceRecord(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5pc/servicerecords/custom?players={gamertag}", uri);
        }

        [Test]
        [TestCase("Greenskull", "Furiousn00b")]
        public void GetConstructedUri_ForPlayers_MatchesExpected(string gamertag, string gamertag2)
        {
            var query = new GetCustomServiceRecord(new List<string> { gamertag, gamertag2 });

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5pc/servicerecords/custom?players={gamertag},{gamertag2}", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetCustomServiceRecord(string gamertag)
        {
            var query = new GetCustomServiceRecord(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(CustomServiceRecord), result);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetCustomServiceRecord("Player")
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(CustomServiceRecord), result);
            Assert.AreEqual(_customServiceRecord, result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetCustomServiceRecord_DoesNotThrow(string gamertag)
        {
            var query = new GetCustomServiceRecord(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(CustomServiceRecord), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetCustomServiceRecord_SchemaIsValid(string gamertag)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.CustomServiceRecordJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.CustomServiceRecordJsonSchemaPath))
            });

            var query = new GetCustomServiceRecord(gamertag)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        [TestCase("moussanator")]
        public async Task GetCustomServiceRecord_ModelMatchesSchema(string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.CustomServiceRecordJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.CustomServiceRecordJsonSchemaPath))
            });

            var query = new GetCustomServiceRecord(gamertag)
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
        public async Task GetCustomServiceRecord_IsSerializable(string gamertag)
        {
            var query = new GetCustomServiceRecord(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<CustomServiceRecord>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetCustomServiceRecord_InvalidGamertag(string gamertag)
        {
            var query = new GetCustomServiceRecord(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}