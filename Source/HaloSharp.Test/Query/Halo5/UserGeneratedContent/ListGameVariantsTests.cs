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
    public class ListGameVariantsTests
    {
        private IHaloSession _mockSession;
        private GameVariantResult _gameVariantResult;

        [SetUp]
        public void Setup()
        {
            _gameVariantResult = JsonConvert.DeserializeObject<GameVariantResult>(File.ReadAllText(Halo5Config.UserGeneratedContentGameVariantsJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<GameVariantResult>(It.IsAny<string>()))
                .ReturnsAsync(_gameVariantResult);
            
            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("ducain23", Enumeration.Halo5.UserGeneratedContentSort.Name, 10, 5)]
        public void Uri_MatchesExpected(string gamertag, Enumeration.Halo5.UserGeneratedContentSort sort, int skip, int take)
        {
            var query = new ListGameVariants(gamertag);

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/gamevariants", query.Uri);

            query.SortBy(sort);

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/gamevariants?sort={sort}", query.Uri);

            query.OrderByAscending();

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/gamevariants?sort={sort}&order=asc", query.Uri);

            query.OrderByDescending();

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/gamevariants?sort={sort}&order=desc", query.Uri);

            query.Skip(skip);

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/gamevariants?sort={sort}&order=desc&start={skip}", query.Uri);

            query.Take(take);

            Assert.AreEqual($"https://www.haloapi.com/ugc/h5/players/{gamertag}/gamevariants?sort={sort}&order=desc&start={skip}&count={take}", query.Uri);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task Query_DoesNotThrow(string gamertag)
        {
            var query = new ListGameVariants(gamertag)
                .SkipCache();

            var result = await _mockSession.Query(query);
        
            Assert.IsInstanceOf(typeof(GameVariantResult), result);
            Assert.AreEqual(_gameVariantResult, result);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task ListGameVariants_DoesNotThrow(string gamertag)
        {
            var query = new ListGameVariants(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(GameVariantResult), result);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task ListGameVariants_SchemaIsValid(string gamertag)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.UserGeneratedContentGameVariantsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.UserGeneratedContentGameVariantsJsonSchemaPath))
            });

            var query = new ListGameVariants(gamertag)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task ListGameVariants_ModelMatchesSchema(string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.UserGeneratedContentGameVariantsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.UserGeneratedContentGameVariantsJsonSchemaPath))
            });

            var query = new ListGameVariants(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task ListGameVariants_IsSerializable(string gamertag)
        {
            var query = new ListGameVariants(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<GameVariantResult>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task ListGameVariants_InvalidGamertag(string gamertag)
        {
            var query = new ListGameVariants(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase(0)]
        [ExpectedException(typeof(ValidationException))]
        public async Task ListGameVariants_InvalidTake(int take)
        {
            var query = new ListGameVariants("ducain23")
                .Take(take);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}