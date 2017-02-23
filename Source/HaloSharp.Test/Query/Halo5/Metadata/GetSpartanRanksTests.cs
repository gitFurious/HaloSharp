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
    public class GetSpartanRanksTests
    {
        private IHaloSession _mockSession;
        private List<SpartanRank> _spartanRanks;

        [SetUp]
        public void Setup()
        {
            _spartanRanks = JsonConvert.DeserializeObject<List<SpartanRank>>(File.ReadAllText(Config.SpartanRanksJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<SpartanRank>>(It.IsAny<string>()))
                .ReturnsAsync(_spartanRanks);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetSpartanRanks();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/spartan-ranks", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetSpartanRanks()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<SpartanRank>), result);
            Assert.AreEqual(_spartanRanks, result);
        }

        [Test]
        public async Task GetSpartanRanks_DoesNotThrow()
        {
            var query = new GetSpartanRanks()
               .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<SpartanRank>), result);
        }

        [Test]
        public async Task GetSpartanRanks_SchemaIsValid()
        {
            var spartanRanksSchema = JSchema.Parse(File.ReadAllText(Config.SpartanRanksJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.SpartanRanksJsonSchemaPath))
            });

            var query = new GetSpartanRanks()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(spartanRanksSchema, jArray);
        }

        [Test]
        public async Task GetSpartanRanks_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.SpartanRanksJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.SpartanRanksJsonSchemaPath))
            });

            var query = new GetSpartanRanks()
               .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetSpartanRanks_IsSerializable()
        {
            var query = new GetSpartanRanks()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<SpartanRank>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}