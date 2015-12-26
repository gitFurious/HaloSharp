using HaloSharp.Extension;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetGameBaseVariantsTests
    {
        private IHaloSession _mockSession;
        private List<GameBaseVariant> _gameBaseVariants;

        [SetUp]
        public void Setup()
        {
            _gameBaseVariants = JsonConvert.DeserializeObject<List<GameBaseVariant>>(File.ReadAllText(Config.GameBaseVariantJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<GameBaseVariant>>(It.IsAny<string>()))
                .ReturnsAsync(_gameBaseVariants);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetGameBaseVariants();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/game-base-variants", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetGameBaseVariants()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<GameBaseVariant>), result);
            Assert.AreEqual(_gameBaseVariants, result);
        }

        [Test]
        public async Task GetGameBaseVariants_DoesNotThrow()
        {
            var query = new GetGameBaseVariants()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<GameBaseVariant>), result);
        }

        [Test]
        public async Task GetGameBaseVariants_SchemaIsValid()
        {
            var gameBaseVariantsSchema = JSchema.Parse(File.ReadAllText(Config.GameBaseVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.GameBaseVariantJsonSchemaPath))
            });

            var query = new GetGameBaseVariants()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(gameBaseVariantsSchema, jArray);
        }

        [Test]
        public async Task GetGameBaseVariants_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.GameBaseVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.GameBaseVariantJsonSchemaPath))
            });

            var query = new GetGameBaseVariants()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetGameBaseVariants_IsSerializable()
        {
            var query = new GetGameBaseVariants()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<GameBaseVariant>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}