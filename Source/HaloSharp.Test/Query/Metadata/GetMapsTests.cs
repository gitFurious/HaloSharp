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
    public class GetMapsTests
    {
        private IHaloSession _mockSession;
        private List<Map> _maps;

        [SetUp]
        public void Setup()
        {
            _maps = JsonConvert.DeserializeObject<List<Map>>(File.ReadAllText(Config.MapJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<Map>>(It.IsAny<string>()))
                .ReturnsAsync(_maps);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetMaps();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/maps", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetMaps()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<Map>), result);
            Assert.AreEqual(_maps, result);
        }

        [Test]
        public async Task GetMaps_DoesNotThrow()
        {
            var query = new GetMaps()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<Map>), result);
        }

        [Test]
        public async Task GetMaps_SchemaIsValid()
        {
            var mapsSchema = JSchema.Parse(File.ReadAllText(Config.MapJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.MapJsonSchemaPath))
            });

            var query = new GetMaps()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(mapsSchema, jArray);
        }

        [Test]
        public async Task GetMaps_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.MapJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.MapJsonSchemaPath))
            });

            var query = new GetMaps()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetMaps_IsSerializable()
        {
            var query = new GetMaps()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<Map>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}