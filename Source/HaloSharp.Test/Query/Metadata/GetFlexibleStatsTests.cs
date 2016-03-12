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
    public class GetFlexibleStatsTests
    {
        private IHaloSession _mockSession;
        private List<FlexibleStat> _flexibleStats;

        [SetUp]
        public void Setup()
        {
            _flexibleStats = JsonConvert.DeserializeObject<List<FlexibleStat>>(File.ReadAllText(Config.FlexibleStatJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<FlexibleStat>>(It.IsAny<string>()))
                .ReturnsAsync(_flexibleStats);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetFlexibleStats();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/flexible-stats", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetFlexibleStats()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<FlexibleStat>), result);
            Assert.AreEqual(_flexibleStats, result);
        }

        [Test]
        public async Task GetFlexibleStats_DoesNotThrow()
        {
            var query = new GetFlexibleStats()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<FlexibleStat>), result);
        }

        [Test]
        public async Task GetFlexibleStats_SchemaIsValid()
        {
            var flexibleStatsSchema = JSchema.Parse(File.ReadAllText(Config.FlexibleStatJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.FlexibleStatJsonSchemaPath))
            });

            var query = new GetFlexibleStats()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(flexibleStatsSchema, jArray);
        }

        [Test]
        public async Task GetFlexibleStats_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.FlexibleStatJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.FlexibleStatJsonSchemaPath))
            });

            var query = new GetFlexibleStats()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetFlexibleStats_IsSerializable()
        {
            var query = new GetFlexibleStats()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<FlexibleStat>>.AssertRoundTripSerializationIsPossible(result);
        }

    }
}