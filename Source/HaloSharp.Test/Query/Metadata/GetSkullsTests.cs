using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Extension;
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
    public class GetSkullsTests
    {
        private IHaloSession _mockSession;
        private List<Skull> _skulls;

        [SetUp]
        public void Setup()
        {
            _skulls = JsonConvert.DeserializeObject<List<Skull>>(File.ReadAllText(Config.SkullsJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<Skull>>(It.IsAny<string>()))
                .ReturnsAsync(_skulls);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetSkulls();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/skulls", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetSkulls()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<Skull>), result);
            Assert.AreEqual(_skulls, result);
        }

        [Test]
        public async Task GetSkulls_DoesNotThrow()
        {
            var query = new GetSkulls()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<Skull>), result);
        }

        [Test]
        public async Task GetSkulls_SchemaIsValid()
        {
            var skullsSchema = JSchema.Parse(File.ReadAllText(Config.SkullsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.SkullsJsonSchemaPath))
            });

            var query = new GetSkulls()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(skullsSchema, jArray);
        }

        [Test]
        public async Task GetSkulls_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.SkullsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.SkullsJsonSchemaPath))
            });

            var query = new GetSkulls()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetSkulls_IsSerializable()
        {
            var query = new GetSkulls()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<Skull>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}