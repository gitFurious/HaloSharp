using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetMapVariantTests
    {
        private IHaloSession _mockSession;
        private MapVariant _mapVariant;

        [SetUp]
        public void Setup()
        {
            _mapVariant = JsonConvert.DeserializeObject<MapVariant>(File.ReadAllText(Config.MapVariantJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<MapVariant>(It.IsAny<string>()))
                .ReturnsAsync(_mapVariant);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetMapVariant();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/map-variants/", uri);
        }

        [Test]
        [TestCase("cb914b9e-f206-11e4-b447-24be05e24f7e")]
        public void GetConstructedUri_ForMapVariantId_MatchesExpected(string guid)
        {
            var query = new GetMapVariant()
                .ForMapVariantId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"metadata/h5/metadata/map-variants/{guid}", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetMapVariant()
                .ForMapVariantId(Guid.Empty);

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(MapVariant), result);
            Assert.AreEqual(_mapVariant, result);
        }

        [Test]
        [TestCase("d9f9c30d-b1be-4381-a5a4-fe29026cca12")]
        public async Task GetMapVariant_DoesNotThrow(string guid)
        {
            var query = new GetMapVariant()
                .ForMapVariantId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(MapVariant), result);
        }

        [Test]
        [TestCase("d9f9c30d-b1be-4381-a5a4-fe29026cca12")]
        public async Task GetMapVariant_SchemaIsValid(string guid)
        {
            var mapVariantSchema = JSchema.Parse(File.ReadAllText(Config.MapVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.MapVariantJsonSchemaPath))
            });

            var query = new GetMapVariant()
                .ForMapVariantId(new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(mapVariantSchema, jArray);
        }

        [Test]
        [TestCase("d9f9c30d-b1be-4381-a5a4-fe29026cca12")]
        public async Task GetMapVariant_ModelMatchesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.MapVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.MapVariantJsonSchemaPath))
            });

            var query = new GetMapVariant()
                .ForMapVariantId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("d9f9c30d-b1be-4381-a5a4-fe29026cca12")]
        public async Task GetMapVariant_IsSerializable(string guid)
        {
            var query = new GetMapVariant()
                .ForMapVariantId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<MapVariant>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetMapVariant_InvalidGuid(string guid)
        {
            var query = new GetMapVariant()
                .ForMapVariantId(new Guid(guid))
                .SkipCache();

            try
            {
                await Global.Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int) Enumeration.StatusCode.NotFound, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetMapVariant_MissingGuid()
        {
            var query = new GetMapVariant()
                .SkipCache();


            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}