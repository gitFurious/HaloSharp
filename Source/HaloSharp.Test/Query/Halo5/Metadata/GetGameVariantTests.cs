using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Metadata;
using HaloSharp.Query.Halo5.Metadata;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Metadata
{
    [TestFixture]
    public class GetGameVariantTests
    {
        private IHaloSession _mockSession;
        private GameVariant _gameVariant;

        [SetUp]
        public void Setup()
        {
            _gameVariant = JsonConvert.DeserializeObject<GameVariant>(File.ReadAllText(Halo5Config.GameVariantJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<GameVariant>(It.IsAny<string>()))
                .ReturnsAsync(_gameVariant);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("fa7808ca-970e-4912-ba4d-92f7ae4499e8")]
        public void Uri_MatchesExpected(string guid)
        {
            var query = new GetGameVariant(new Guid(guid));

            Assert.AreEqual($"https://www.haloapi.com/metadata/h5/metadata/game-variants/{guid}", query.Uri);
        }

        [Test]
        [TestCase("fa7808ca-970e-4912-ba4d-92f7ae4499e8")]
        public async Task Query_DoesNotThrow(string guid)
        {
            var query = new GetGameVariant(new Guid(guid));

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(GameVariant), result);
            Assert.AreEqual(_gameVariant, result);
        }

        [Test]
        [TestCase("fa7808ca-970e-4912-ba4d-92f7ae4499e8")]
        public async Task GetGameVariant_DoesNotThrow(string guid)
        {
            var query = new GetGameVariant(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(GameVariant), result);
        }

        [Test]
        [TestCase("fa7808ca-970e-4912-ba4d-92f7ae4499e8")]
        public async Task GetGameVariant_SchemaIsValid(string guid)
        {
            var gameVariantSchema = JSchema.Parse(File.ReadAllText(Halo5Config.GameVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.GameVariantJsonSchemaPath))
            });

            var query = new GetGameVariant(new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(gameVariantSchema, jArray);
        }

        [Test]
        [TestCase("fa7808ca-970e-4912-ba4d-92f7ae4499e8")]
        public async Task GetGameVariant_ModelMatchesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.GameVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.GameVariantJsonSchemaPath))
            });

            var query = new GetGameVariant(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("fa7808ca-970e-4912-ba4d-92f7ae4499e8")]
        public async Task GetGameVariant_IsSerializable(string guid)
        {
            var query = new GetGameVariant(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<GameVariant>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        public async Task GetGameVariant_InvalidGuid()
        {
            var query = new GetGameVariant(Guid.NewGuid())
                .SkipCache();

            try
            {
                await Global.Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int)Enumeration.Halo5.StatusCode.NotFound, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }
    }
}