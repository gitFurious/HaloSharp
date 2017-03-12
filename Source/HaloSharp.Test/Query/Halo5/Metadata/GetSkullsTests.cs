using System;
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
    public class GetSkullsTests
    {
        private IHaloSession _mockSession;
        private List<Skull> _skulls;

        [SetUp]
        public void Setup()
        {
            _skulls = JsonConvert.DeserializeObject<List<Skull>>(File.ReadAllText(Halo5Config.SkullsJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<Skull>>(It.IsAny<string>()))
                .ReturnsAsync(_skulls);

            _mockSession = mock.Object;
        }

        [Test]
        public void Uri_MatchesExpected()
        {
            var query = new GetSkulls();

            Assert.AreEqual("https://www.haloapi.com/metadata/h5/metadata/skulls", query.Uri);
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
            var skullsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.SkullsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.SkullsJsonSchemaPath))
            });

            var query = new GetSkulls()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(skullsSchema, jArray);
        }

        [Test]
        public async Task GetSkulls_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.SkullsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.SkullsJsonSchemaPath))
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