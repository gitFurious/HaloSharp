using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Profile;
using HaloSharp.Query.Halo5.Profile;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Profile
{
    [TestFixture]
    public class GetPlayerAppearanceTests
    {

        private IHaloSession _mockSession;
        private PlayerAppearance _playerAppearance;

        [SetUp]
        public void Setup()
        {
            /***Don't know where to find this schema file...***/
           // _playerAppearance = JsonConvert.DeserializeObject<PlayerAppearance>(File.ReadAllText("TODO"));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<PlayerAppearance>(It.IsAny<string>()))
                .ReturnsAsync(_playerAppearance);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("Sn1p3r C")]
        [TestCase("Furiousn00b")]
        public void Uri_MatchesExpected(string gamertag)
        {
            var query = new GetPlayerAppearance(gamertag);

            Assert.AreEqual($"https://www.haloapi.com/profile/h5/profiles/{gamertag}/appearance", query.Uri);
        }

        [Test]
        [TestCase("Furiousn00b")]
        public async Task Query_DoesNotThrow(string gamertag)
        {
            Assert.Fail();  //Fix Setup() before this can run.
            var query = new GetPlayerAppearance(gamertag)
                .SkipCache();
        
            var result = await _mockSession.Query(query);
        
            Assert.IsInstanceOf(typeof(PlayerAppearance), result);
            Assert.AreEqual(_playerAppearance, result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetPlayerAppearance_DoesNotThrow(string gamertag)
        {
            var query = new GetPlayerAppearance(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(PlayerAppearance), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetPlayerAppearance_SchemaIsValid(string gamertag)
        {
            Assert.Fail();   /***Don't know where to find this schema file...***/
            var playerAppearanceSchema = JSchema.Parse(File.ReadAllText("TODO"), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.MatchesJsonSchemaPath))
            });

            var query = new GetPlayerAppearance(gamertag)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(playerAppearanceSchema, jArray);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetPlayerAppearance_ModelMatchesSchema(string gamertag)
        {
            Assert.Fail();   /***Don't know where to find this schema file...***/
            var schema = JSchema.Parse(File.ReadAllText("TODO"), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.MatchesJsonSchemaPath))
            });

            var query = new GetPlayerAppearance(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetPlayerAppearance_IsSerializable(string gamertag)
        {
            var query = new GetPlayerAppearance(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<PlayerAppearance>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetPlayerAppearance_InvalidGamertag(string gamertag)
        {
            var query = new GetPlayerAppearance(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }


    }
}
