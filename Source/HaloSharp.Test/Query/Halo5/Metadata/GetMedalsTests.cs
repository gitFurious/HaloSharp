using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Extension;
using HaloSharp.Model.Halo5.Metadata;
using HaloSharp.Query.Halo5.Metadata;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Metadata
{
    [TestFixture]
    public class GetMedalsTests
    {
        private IHaloSession _mockSession;
        private List<Medal> _medals;

        [SetUp]
        public void Setup()
        {
            _medals = JsonConvert.DeserializeObject<List<Medal>>(File.ReadAllText(Config.MedalJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<Medal>>(It.IsAny<string>()))
                .ReturnsAsync(_medals);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetMedals();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/medals", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetMedals()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<Medal>), result);
            Assert.AreEqual(_medals, result);
        }

        [Test]
        public async Task GetMedals_DoesNotThrow()
        {
            var query = new GetMedals()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<Medal>), result);
        }

        [Test]
        public async Task GetMedals_SchemaIsValid()
        {
            var medalsSchema = JSchema.Parse(File.ReadAllText(Config.MedalJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.MedalJsonSchemaPath))
            });

            var query = new GetMedals()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(medalsSchema, jArray);
        }

        [Test]
        public async Task GetMedals_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.MedalJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.MedalJsonSchemaPath))
            });

            var query = new GetMedals()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetMedals_IsSerializable()
        {
            var query = new GetMedals()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<Medal>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}