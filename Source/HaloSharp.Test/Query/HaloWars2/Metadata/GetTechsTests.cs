using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.HaloWars2.Metadata;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.HaloWars2.Metadata
{
    [TestFixture]
    public class GetTechsTests
    {
        private const string Json = HaloWars2Config.TechsJsonPath;
        private const string Schema = HaloWars2Config.TechsJsonSchemaPath;

        private IHaloSession _mockSession;
        private PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Tech.View>> _response;

        [SetUp]
        public void Setup()
        {
            _response = JsonConvert.DeserializeObject<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Tech.View>>>(File.ReadAllText(Json));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Tech.View>>>(It.IsAny<string>()))
                .ReturnsAsync(_response);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new HaloSharp.Query.HaloWars2.Metadata.GetTechs();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/hw2/techs", uri);
        }

        [Test]
        [TestCase(100)]
        [TestCase(200)]
        public void GetConstructedUri_Skip_MatchesExpected(int skip)
        {
            var query = new HaloSharp.Query.HaloWars2.Metadata.GetTechs()
                .Skip(skip);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"metadata/hw2/techs?startAt={skip}", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new HaloSharp.Query.HaloWars2.Metadata.GetTechs()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Tech.View>>), result);
            Assert.AreEqual(_response, result);
        }

        [Test]
        public async Task GetTechs_DoesNotThrow()
        {
            var query = new HaloSharp.Query.HaloWars2.Metadata.GetTechs()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Tech.View>>), result);
        }

        [Test]
        public async Task GetTechs_SchemaIsValid()
        {
            var jSchema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var query = new HaloSharp.Query.HaloWars2.Metadata.GetTechs()
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(jSchema, jArray);
        }

        [Test]
        public async Task GetTechs_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var query = new HaloSharp.Query.HaloWars2.Metadata.GetTechs()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetTechs_IsSerializable()
        {
            var query = new HaloSharp.Query.HaloWars2.Metadata.GetTechs()
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Tech.View>>>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase(10)]
        [TestCase(50)]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetConstructedUri_InvalidSkip(int skip)
        {
            var query = new HaloSharp.Query.HaloWars2.Metadata.GetTechs()
                .Skip(skip);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}