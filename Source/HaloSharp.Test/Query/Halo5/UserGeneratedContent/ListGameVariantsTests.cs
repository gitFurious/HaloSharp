using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
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
    public class ListGameVariantsTests
    {
        private IHaloSession _mockSession;
        private GameVariantResult _gameVariantResult;

        [SetUp]
        public void Setup()
        {
            _gameVariantResult = JsonConvert.DeserializeObject<GameVariantResult>(File.ReadAllText(Config.UserGeneratedContentGameVariantsJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<GameVariantResult>(It.IsAny<string>()))
                .ReturnsAsync(_gameVariantResult);
            
            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new ListGameVariants();

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{null}/gamevariants", uri);
        }

        [Test]
        [TestCase("ducain23")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new ListGameVariants()
                .ForPlayer(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{gamertag}/gamevariants", uri);
        }

        [Test]
        [TestCase(Enumeration.UserGeneratedContentSort.Name)]
        public void GetConstructedUri_SortBy_MatchesExpected(Enumeration.UserGeneratedContentSort sort)
        {
            var query = new ListGameVariants()
                .SortBy(sort);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{null}/gamevariants?sort={sort}", uri);
        }

        [Test]
        public void GetConstructedUri_OrderByAscending_MatchesExpected()
        {
            var query = new ListGameVariants()
                .OrderByAscending();

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{null}/gamevariants?order=asc", uri);
        }

        [Test]
        public void GetConstructedUri_OrderByDescending_MatchesExpected()
        {
            var query = new ListGameVariants()
                .OrderByDescending();

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{null}/gamevariants?order=desc", uri);
        }

        [Test]
        [TestCase(5)]
        public void GetConstructedUri_Skip_MatchesExpected(int skip)
        {
            var query = new ListGameVariants()
                .Skip(skip);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{null}/gamevariants?start={skip}", uri);
        }

        [Test]
        [TestCase(5)]
        public void GetConstructedUri_Take_MatchesExpected(int take)
        {
            var query = new ListGameVariants()
                .Take(take);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{null}/gamevariants?count={take}", uri);
        }

        [Test]
        [TestCase("ducain23", Enumeration.UserGeneratedContentSort.Name, 10, 5)]
        public void GetConstructedUri_Complex_MatchesExpected(string gamertag, Enumeration.UserGeneratedContentSort sort, int skip, int take)
        {
            var query = new ListGameVariants()
                .ForPlayer(gamertag)
                .SortBy(sort)
                .OrderByAscending()
                .Skip(skip)
                .Take(take);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"ugc/h5/players/{gamertag}/gamevariants?sort={sort}&order=asc&start={skip}&count={take}", uri);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task Query_DoesNotThrow(string gamertag)
        {
            var query = new ListGameVariants()
                .ForPlayer(gamertag)
                .SkipCache();

            var result = await _mockSession.Query(query);
        
            Assert.IsInstanceOf(typeof(GameVariantResult), result);
            Assert.AreEqual(_gameVariantResult, result);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task ListGameVariants_DoesNotThrow(string gamertag)
        {
            var query = new ListGameVariants()
                .ForPlayer(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(GameVariantResult), result);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task ListGameVariants_SchemaIsValid(string gamertag)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Config.UserGeneratedContentGameVariantsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.UserGeneratedContentGameVariantsJsonSchemaPath))
            });

            var query = new ListGameVariants()
                .ForPlayer(gamertag)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("ducain23")]
        public async Task ListGameVariants_ModelMatchesSchema(string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.UserGeneratedContentGameVariantsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.UserGeneratedContentGameVariantsJsonSchemaPath))
            });

            var query = new ListGameVariants()
                .ForPlayer(gamertag)
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
            var query = new ListGameVariants()
                .ForPlayer(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<GameVariantResult>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task ListGameVariants_MissingPlayer()
        {
            var query = new ListGameVariants();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task ListGameVariants_InvalidGamertag(string gamertag)
        {
            var query = new ListGameVariants()
                .ForPlayer(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase(0)]
        [TestCase(101)]
        [ExpectedException(typeof(ValidationException))]
        public async Task ListGameVariants_InvalidTake(int take)
        {
            var query = new ListGameVariants()
                .ForPlayer("ducain23")
                .Take(take);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}