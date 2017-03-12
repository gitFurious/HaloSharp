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
    public class GetImpulsesTests
    {
        private IHaloSession _mockSession;
        private List<Impulse> _impulses;

        [SetUp]
        public void Setup()
        {
            _impulses = JsonConvert.DeserializeObject<List<Impulse>>(File.ReadAllText(Halo5Config.ImpulseJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<Impulse>>(It.IsAny<string>()))
                .ReturnsAsync(_impulses);

            _mockSession = mock.Object;
        }

        [Test]
        public void Uri_MatchesExpected()
        {
            var query = new GetImpulses();

            Assert.AreEqual("https://www.haloapi.com/metadata/h5/metadata/impulses", query.Uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetImpulses()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<Impulse>), result);
            Assert.AreEqual(_impulses, result);
        }

        [Test]
        public async Task GetImpulses_DoesNotThrow()
        {
            var query = new GetImpulses()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<Impulse>), result);
        }

        [Test]
        public async Task GetImpulses_SchemaIsValid()
        {
            var impulsesSchema = JSchema.Parse(File.ReadAllText(Halo5Config.ImpulseJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.ImpulseJsonSchemaPath))
            });

            var query = new GetImpulses()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(impulsesSchema, jArray);
        }

        [Test]
        public async Task GetImpulses_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.ImpulseJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.ImpulseJsonSchemaPath))
            });

            var query = new GetImpulses()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetImpulses_IsSerializable()
        {
            var query = new GetImpulses()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<Impulse>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}