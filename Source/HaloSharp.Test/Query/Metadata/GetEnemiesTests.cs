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
    public class GetEnemiesTests
    {
        private IHaloSession _mockSession;
        private List<Enemy> _enemies;

        [SetUp]
        public void Setup()
        {
            _enemies = JsonConvert.DeserializeObject<List<Enemy>>(File.ReadAllText(Config.EnemyJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<Enemy>>(It.IsAny<string>()))
                .ReturnsAsync(_enemies);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetEnemies();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/enemies", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetEnemies()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<Enemy>), result);
            Assert.AreEqual(_enemies, result);
        }

        [Test]
        public async Task GetEnemies_DoesNotThrow()
        {
            var query = new GetEnemies()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<Enemy>), result);
        }

        [Test]
        public async Task GetEnemies_SchemaIsValid()
        {
            var enemiesSchema = JSchema.Parse(File.ReadAllText(Config.EnemyJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.EnemyJsonSchemaPath))
            });

            var query = new GetEnemies()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(enemiesSchema, jArray);
        }

        [Test]
        public async Task GetEnemies_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.EnemyJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.EnemyJsonSchemaPath))
            });

            var query = new GetEnemies()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetEnemies_IsSerializable()
        {
            var query = new GetEnemies()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<Enemy>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}