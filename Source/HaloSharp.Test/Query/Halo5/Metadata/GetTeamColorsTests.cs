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
    public class GetTeamColorsTests
    {
        private IHaloSession _mockSession;
        private List<TeamColor> _teamColors;

        [SetUp]
        public void Setup()
        {
            _teamColors = JsonConvert.DeserializeObject<List<TeamColor>>(File.ReadAllText(Halo5Config.TeamColorsJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<TeamColor>>(It.IsAny<string>()))
                .ReturnsAsync(_teamColors);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetTeamColors();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/team-colors", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetTeamColors()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<TeamColor>), result);
            Assert.AreEqual(_teamColors, result);
        }

        [Test]
        public async Task GetTeamColors_DoesNotThrow()
        {
            var query = new GetTeamColors()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<TeamColor>), result);
        }

        [Test]
        public async Task GetTeamColors_SchemaIsValid()
        {
            var teamColorsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.TeamColorsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.TeamColorsJsonSchemaPath))
            });

            var query = new GetTeamColors()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(teamColorsSchema, jArray);
        }

        [Test]
        public async Task GetTeamColors_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.TeamColorsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.TeamColorsJsonSchemaPath))
            });

            var query = new GetTeamColors()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetTeamColors_IsSerializable()
        {
            var query = new GetTeamColors()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<TeamColor>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}