﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Extension;
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
    public class GetEnemiesTests
    {
        private IHaloSession _mockSession;
        private List<Enemy> _enemies;

        [SetUp]
        public void Setup()
        {
            _enemies = JsonConvert.DeserializeObject<List<Enemy>>(File.ReadAllText(Halo5Config.EnemyJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<Enemy>>(It.IsAny<string>()))
                .ReturnsAsync(_enemies);

            _mockSession = mock.Object;
        }

        [Test]
        public void Uri_MatchesExpected()
        {
            var query = new GetEnemies();

            Assert.AreEqual("https://www.haloapi.com/metadata/h5/metadata/enemies", query.Uri);
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
            var enemiesSchema = JSchema.Parse(File.ReadAllText(Halo5Config.EnemyJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.EnemyJsonSchemaPath))
            });

            var query = new GetEnemies()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(enemiesSchema, jArray);
        }

        [Test]
        public async Task GetEnemies_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.EnemyJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.EnemyJsonSchemaPath))
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