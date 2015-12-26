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
    public class GetCommendationsTests
    {
        private IHaloSession _mockSession;
        private List<Commendation> _commendations;

        [SetUp]
        public void Setup()
        {
            _commendations = JsonConvert.DeserializeObject<List<Commendation>>(File.ReadAllText(Config.CommendationJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<Commendation>>(It.IsAny<string>()))
                .ReturnsAsync(_commendations);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetCommendations();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/commendations", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetCommendations()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<Commendation>), result);
            Assert.AreEqual(_commendations, result);
        }

        [Test]
        public async Task GetCommendations_DoesNotThrow()
        {
            var query = new GetCommendations()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<Commendation>), result);
        }

        [Test]
        public async Task GetCommendations_SchemaIsValid()
        {
            var commendationsSchema = JSchema.Parse(File.ReadAllText(Config.CommendationJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.CommendationJsonSchemaPath))
            });

            var query = new GetCommendations()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(commendationsSchema, jArray);
        }

        [Test]
        public async Task GetCommendations_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.CommendationJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.CommendationJsonSchemaPath))
            });

            var query = new GetCommendations()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetCommendations_IsSerializable()
        {
            var query = new GetCommendations()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<Commendation>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}