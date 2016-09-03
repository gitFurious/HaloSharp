using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.Stats;
using HaloSharp.Query.UserGeneratedContent;
using HaloSharp.Test.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Model.UserGeneratedContent;
using Moq;

namespace HaloSharp.Test.Query.UserGeneratedContent
{
    [TestFixture]
    public class GetGameVariantTests
    {
        private IHaloSession _mockSession;
        private GameVariant _gameVariant;

        [SetUp]
        public void Setup()
        {
            _gameVariant = JsonConvert.DeserializeObject<GameVariant>(File.ReadAllText(Config.UserGeneratedContentGameVariantJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<GameVariant>(It.IsAny<string>()))
                .ReturnsAsync(_gameVariant);
            
            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetGameVariant();

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{null}/gamevariants/{null}", uri);
        }

        [Test]
        [TestCase("ducain23")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetGameVariant()
                .ForPlayer(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{gamertag}/gamevariants/{null}", uri);
        }

        [Test]
        [TestCase("05c399ca-78cd-4dca-a0bd-c143f5ecb308")]
        public void GetConstructedUri_InGameMode_MatchesExpected(string guid)
        {
            var query = new GetGameVariant()
                .ForGameVariantId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{null}/gamevariants/{guid}", uri);
        }

        [Test]
        [TestCase("ducain23", "05c399ca-78cd-4dca-a0bd-c143f5ecb308")]
        public void GetConstructedUri_Complex_MatchesExpected(string gamertag, string guid)
        {
            var query = new GetGameVariant()
                .ForPlayer(gamertag)
                .ForGameVariantId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{gamertag}/gamevariants/{guid}", uri);
        }

        [Test]
        [TestCase("ducain23", "05c399ca-78cd-4dca-a0bd-c143f5ecb308")]
        public async Task Query_DoesNotThrow(string gamertag, string guid)
        {
            var query = new GetGameVariant()
                .ForPlayer(gamertag)
                .ForGameVariantId(new Guid(guid))
                .SkipCache();

            var result = await _mockSession.Query(query);
        
            Assert.IsInstanceOf(typeof(GameVariant), result);
            Assert.AreEqual(_gameVariant, result);
        }

        [Test]
        [TestCase("ducain23", "05c399ca-78cd-4dca-a0bd-c143f5ecb308")]
        public async Task GetGameVariant_DoesNotThrow(string gamertag, string guid)
        {
            var query = new GetGameVariant()
                .ForPlayer(gamertag)
                .ForGameVariantId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(GameVariant), result);
        }

        [Test]
        [TestCase("ducain23", "05c399ca-78cd-4dca-a0bd-c143f5ecb308")]
        public async Task GetGameVariant_SchemaIsValid(string gamertag, string guid)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Config.UserGeneratedContentGameVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.UserGeneratedContentGameVariantJsonSchemaPath))
            });

            var query = new GetGameVariant()
                .ForPlayer(gamertag)
                .ForGameVariantId(new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("ducain23", "05c399ca-78cd-4dca-a0bd-c143f5ecb308")]
        public async Task GetGameVariant_ModelMatchesSchema(string gamertag, string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.UserGeneratedContentGameVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.UserGeneratedContentGameVariantJsonSchemaPath))
            });

            var query = new GetGameVariant()
                .ForPlayer(gamertag)
                .ForGameVariantId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("ducain23", "05c399ca-78cd-4dca-a0bd-c143f5ecb308")]
        public async Task GetGameVariant_IsSerializable(string gamertag, string guid)
        {
            var query = new GetGameVariant()
                .ForPlayer(gamertag)
                .ForGameVariantId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<GameVariant>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetGameVariant_MissingPlayer()
        {
            var query = new GetGameVariant()
                .ForGameVariantId(new Guid());

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetGameVariant_InvalidGamertag(string gamertag)
        {
            var query = new GetGameVariant()
                .ForPlayer(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetGameVariant_MissingGameVariantId()
        {
            var query = new GetGameVariant()
                .ForPlayer("Player");

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}