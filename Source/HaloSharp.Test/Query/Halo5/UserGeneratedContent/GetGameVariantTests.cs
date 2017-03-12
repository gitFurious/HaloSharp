using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Query.Halo5.UserGeneratedContent;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.UserGeneratedContent
{
    [TestFixture]
    public class GetGameVariantTests
    {
        private IHaloSession _mockSession;
        private GameVariant _gameVariant;

        [SetUp]
        public void Setup()
        {
            _gameVariant = JsonConvert.DeserializeObject<GameVariant>(File.ReadAllText(Halo5Config.UserGeneratedContentGameVariantJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<GameVariant>(It.IsAny<string>()))
                .ReturnsAsync(_gameVariant);
            
            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("ducain23", "399c6656-c091-4433-80d1-88224a6786b6")]
        public void Uri_MatchesExpected(string gamertag, string guid)
        {
            var query = new GetGameVariant(gamertag, new Guid(guid));

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/gamevariants/{guid}", query.Uri);
        }

        [Test]
        [TestCase("ducain23", "399c6656-c091-4433-80d1-88224a6786b6")]
        public async Task Query_DoesNotThrow(string gamertag, string guid)
        {
            var query = new GetGameVariant(gamertag, new Guid(guid))
                .SkipCache();

            var result = await _mockSession.Query(query);
        
            Assert.IsInstanceOf(typeof(GameVariant), result);
            Assert.AreEqual(_gameVariant, result);
        }

        [Test]
        [TestCase("ducain23", "399c6656-c091-4433-80d1-88224a6786b6")]
        public async Task GetGameVariant_DoesNotThrow(string gamertag, string guid)
        {
            var query = new GetGameVariant(gamertag, new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(GameVariant), result);
        }

        [Test]
        [TestCase("ducain23", "399c6656-c091-4433-80d1-88224a6786b6")]
        public async Task GetGameVariant_SchemaIsValid(string gamertag, string guid)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.UserGeneratedContentGameVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.UserGeneratedContentGameVariantJsonSchemaPath))
            });

            var query = new GetGameVariant(gamertag, new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("ducain23", "399c6656-c091-4433-80d1-88224a6786b6")]
        public async Task GetGameVariant_ModelMatchesSchema(string gamertag, string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.UserGeneratedContentGameVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.UserGeneratedContentGameVariantJsonSchemaPath))
            });

            var query = new GetGameVariant(gamertag, new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("ducain23", "399c6656-c091-4433-80d1-88224a6786b6")]
        public async Task GetGameVariant_IsSerializable(string gamertag, string guid)
        {
            var query = new GetGameVariant(gamertag, new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<GameVariant>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000000000017", "399c6656-c091-4433-80d1-88224a6786b6")]
        [TestCase("!$%", "399c6656-c091-4433-80d1-88224a6786b6")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetGameVariant_InvalidGamertag(string gamertag, string guid)
        {
            var query = new GetGameVariant(gamertag, new Guid(guid));

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}