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
    public class GetCompetitiveSkillRankDesignationsTests
    {
        private IHaloSession _mockSession;
        private List<CompetitiveSkillRankDesignation> _competitiveSkillRankDesignations;

        [SetUp]
        public void Setup()
        {
            _competitiveSkillRankDesignations = JsonConvert.DeserializeObject<List<CompetitiveSkillRankDesignation>>(File.ReadAllText(Config.CompetitiveSkillRankDesignationsJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<CompetitiveSkillRankDesignation>>(It.IsAny<string>()))
                .ReturnsAsync(_competitiveSkillRankDesignations);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetCompetitiveSkillRankDesignations();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/csr-designations", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetCompetitiveSkillRankDesignations()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<CompetitiveSkillRankDesignation>), result);
            Assert.AreEqual(_competitiveSkillRankDesignations, result);
        }

        [Test]
        public async Task GetCompetitiveSkillRankDesignations_DoesNotThrow()
        {
            var query = new GetCompetitiveSkillRankDesignations()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<CompetitiveSkillRankDesignation>), result);
        }

        [Test]
        public async Task GetCompetitiveSkillRankDesignations_SchemaIsValid()
        {
            var competitiveSkillRankDesignationsSchema = JSchema.Parse(File.ReadAllText(Config.CompetitiveSkillRankDesignationsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.CompetitiveSkillRankDesignationsJsonSchemaPath))
            });

            var query = new GetCompetitiveSkillRankDesignations()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(competitiveSkillRankDesignationsSchema, jArray);
        }

        [Test]
        public async Task GetCompetitiveSkillRankDesignations_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.CompetitiveSkillRankDesignationsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.CompetitiveSkillRankDesignationsJsonSchemaPath))
            });

            var query = new GetCompetitiveSkillRankDesignations()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetCompetitiveSkillRankDesignations_IsSerializable()
        {
            var query = new GetCompetitiveSkillRankDesignations()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<CompetitiveSkillRankDesignation>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}