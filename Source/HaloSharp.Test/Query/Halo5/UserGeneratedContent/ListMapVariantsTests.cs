using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
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
    public class ListMapVariantsTests
    {
        private IHaloSession _mockSession;
        private MapVariantResult _mapVariantResult;

        [SetUp]
        public void Setup()
        {
            _mapVariantResult = JsonConvert.DeserializeObject<MapVariantResult>(File.ReadAllText(Halo5Config.UserGeneratedContentMapVariantsJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<MapVariantResult>(It.IsAny<string>()))
                .ReturnsAsync(_mapVariantResult);
            
            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("ducain23", Enumeration.Halo5.UserGeneratedContentSort.Name, 10, 5)]
        public void Uri_MatchesExpected(string gamertag, Enumeration.Halo5.UserGeneratedContentSort sort, int skip, int take)
        {
            var query = new ListMapVariants(gamertag);

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/mapvariants", query.Uri);

            query.SortBy(sort);

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/mapvariants?sort={sort}", query.Uri);

            query.OrderByAscending();

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/mapvariants?sort={sort}&order=asc", query.Uri);

            query.OrderByDescending();

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/mapvariants?sort={sort}&order=desc", query.Uri);

            query.Skip(skip);

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/mapvariants?sort={sort}&order=desc&start={skip}", query.Uri);

            query.Take(take);

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/mapvariants?sort={sort}&order=desc&start={skip}&count={take}", query.Uri);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task Query_DoesNotThrow(string gamertag)
        {
            var query = new ListMapVariants(gamertag)
                .SkipCache();

            var result = await _mockSession.Query(query);
        
            Assert.IsInstanceOf(typeof(MapVariantResult), result);
            Assert.AreEqual(_mapVariantResult, result);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task ListMapVariants_DoesNotThrow(string gamertag)
        {
            var query = new ListMapVariants(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(MapVariantResult), result);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task ListMapVariants_SchemaIsValid(string gamertag)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.UserGeneratedContentMapVariantsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.UserGeneratedContentMapVariantsJsonSchemaPath))
            });

            var query = new ListMapVariants(gamertag)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task ListMapVariants_ModelMatchesSchema(string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.UserGeneratedContentMapVariantsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.UserGeneratedContentMapVariantsJsonSchemaPath))
            });

            var query = new ListMapVariants(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task ListMapVariants_IsSerializable(string gamertag)
        {
            var query = new ListMapVariants(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<MapVariantResult>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task ListMapVariants_InvalidGamertag(string gamertag)
        {
            var query = new ListMapVariants(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase(0)]
        [TestCase(101)]
        [ExpectedException(typeof(ValidationException))]
        public async Task ListMapVariants_InvalidTake(int take)
        {
            var query = new ListMapVariants("ducain23")
                .Take(take);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}