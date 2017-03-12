using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using HaloSharp.Query.Halo5.Stats.CarnageReport;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Stats.CarnageReport
{
    [TestFixture]
    public class GetWarzoneMatchDetailsTests
    {
        private IHaloSession _mockSession;
        private WarzoneMatch _warzoneMatch;

        [SetUp]
        public void Setup()
        {
            _warzoneMatch = JsonConvert.DeserializeObject<WarzoneMatch>(File.ReadAllText(Halo5Config.WarzoneMatchJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<WarzoneMatch>(It.IsAny<string>()))
                .ReturnsAsync(_warzoneMatch);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public void Uri_MatchesExpected(string guid)
        {
            var query = new GetWarzoneMatchDetails(new Guid(guid));

            Assert.AreEqual($"https://www.haloapi.com/stats/h5/warzone/matches/{guid}", query.Uri);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task Query_DoesNotThrow(string guid)
        {
            var query = new GetWarzoneMatchDetails(new Guid(guid))
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(WarzoneMatch), result);
            Assert.AreEqual(_warzoneMatch, result);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        [TestCase("04725707-da3f-407c-b43c-5f2b8bceb50a")]
        [TestCase("3bd3945a-3578-4726-aad2-89b2c014a2ad")]
        public async Task GetWarzoneMatchDetails_DoesNotThrow(string guid)
        {
            var query = new GetWarzoneMatchDetails(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(WarzoneMatch), result);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        [TestCase("04725707-da3f-407c-b43c-5f2b8bceb50a")]
        [TestCase("3bd3945a-3578-4726-aad2-89b2c014a2ad")]
        public async Task GetWarzoneMatchDetails_SchemaIsValid(string guid)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.WarzoneMatchJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.WarzoneMatchJsonSchemaPath))
            });

            var query = new GetWarzoneMatchDetails(new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        [TestCase("04725707-da3f-407c-b43c-5f2b8bceb50a")]
        [TestCase("3bd3945a-3578-4726-aad2-89b2c014a2ad")]
        public async Task GetWarzoneMatchDetails_ModelMatchesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.WarzoneMatchJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.WarzoneMatchJsonSchemaPath))
            });

            var query = new GetWarzoneMatchDetails(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        [TestCase("04725707-da3f-407c-b43c-5f2b8bceb50a")]
        [TestCase("3bd3945a-3578-4726-aad2-89b2c014a2ad")]
        public async Task GetWarzoneMatchDetails_IsSerializable(string guid)
        {
            var query = new GetWarzoneMatchDetails(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<WarzoneMatch>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        public async Task GetWarzoneMatchDetails_InvalidGuid()
        {
            var query = new GetWarzoneMatchDetails(Guid.NewGuid())
                .SkipCache();

            try
            {
                await Global.Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int)Enumeration.Halo5.StatusCode.NotFound, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }
    }
}