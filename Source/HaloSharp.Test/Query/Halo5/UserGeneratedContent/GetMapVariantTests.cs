using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Query.Halo5.UserGeneratedContent;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.UserGeneratedContent
{
    [TestFixture]
    public class GetMapVariantTests
    {
        private IHaloSession _mockSession;
        private MapVariant _mapVariant;

        [SetUp]
        public void Setup()
        {
            _mapVariant = JsonConvert.DeserializeObject<MapVariant>(File.ReadAllText(Config.UserGeneratedContentMapVariantJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<MapVariant>(It.IsAny<string>()))
                .ReturnsAsync(_mapVariant);
            
            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetMapVariant();

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{null}/mapvariants/{null}", uri);
        }

        [Test]
        [TestCase("ducain23")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetMapVariant()
                .ForPlayer(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{gamertag}/mapvariants/{null}", uri);
        }

        [Test]
        [TestCase("7f1489ad-77bb-42a5-8ffc-5990a0e83dfa")]
        public void GetConstructedUri_InGameMode_MatchesExpected(string guid)
        {
            var query = new GetMapVariant()
                .ForMapVariantId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{null}/mapvariants/{guid}", uri);
        }

        [Test]
        [TestCase("ducain23", "7f1489ad-77bb-42a5-8ffc-5990a0e83dfa")]
        public void GetConstructedUri_Complex_MatchesExpected(string gamertag, string guid)
        {
            var query = new GetMapVariant()
                .ForPlayer(gamertag)
                .ForMapVariantId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{gamertag}/mapvariants/{guid}", uri);
        }

        [Test]
        [TestCase("ducain23", "7f1489ad-77bb-42a5-8ffc-5990a0e83dfa")]
        public async Task Query_DoesNotThrow(string gamertag, string guid)
        {
            var query = new GetMapVariant()
                .ForPlayer(gamertag)
                .ForMapVariantId(new Guid(guid))
                .SkipCache();

            var result = await _mockSession.Query(query);
        
            Assert.IsInstanceOf(typeof(MapVariant), result);
            Assert.AreEqual(_mapVariant, result);
        }

        [Test]
        [TestCase("ducain23", "7f1489ad-77bb-42a5-8ffc-5990a0e83dfa")]
        public async Task GetMapVariant_DoesNotThrow(string gamertag, string guid)
        {
            var query = new GetMapVariant()
                .ForPlayer(gamertag)
                .ForMapVariantId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(MapVariant), result);
        }

        [Test]
        [TestCase("ducain23", "7f1489ad-77bb-42a5-8ffc-5990a0e83dfa")]
        public async Task GetMapVariant_SchemaIsValid(string gamertag, string guid)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Config.UserGeneratedContentMapVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.UserGeneratedContentMapVariantJsonSchemaPath))
            });

            var query = new GetMapVariant()
                .ForPlayer(gamertag)
                .ForMapVariantId(new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("ducain23", "7f1489ad-77bb-42a5-8ffc-5990a0e83dfa")]
        public async Task GetMapVariant_ModelMatchesSchema(string gamertag, string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.UserGeneratedContentMapVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.UserGeneratedContentMapVariantJsonSchemaPath))
            });

            var query = new GetMapVariant()
                .ForPlayer(gamertag)
                .ForMapVariantId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("ducain23", "7f1489ad-77bb-42a5-8ffc-5990a0e83dfa")]
        public async Task GetMapVariant_IsSerializable(string gamertag, string guid)
        {
            var query = new GetMapVariant()
                .ForPlayer(gamertag)
                .ForMapVariantId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<MapVariant>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetMapVariant_MissingPlayer()
        {
            var query = new GetMapVariant()
                .ForMapVariantId(new Guid());

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetMapVariant_InvalidGamertag(string gamertag)
        {
            var query = new GetMapVariant()
                .ForPlayer(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetMapVariant_MissingMapVariantId()
        {
            var query = new GetMapVariant()
                .ForPlayer("Player");

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}