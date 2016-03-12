using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Stats.CarnageReport;
using HaloSharp.Query.Stats.CarnageReport;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Stats.CarnageReport
{
    [TestFixture]
    public class GetWarzoneMatchDetailsTests
    {
        private IHaloSession _mockSession;
        private WarzoneMatch _warzoneMatch;

        [SetUp]
        public void Setup()
        {
            _warzoneMatch = JsonConvert.DeserializeObject<WarzoneMatch>(File.ReadAllText(Config.WarzoneMatchJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<WarzoneMatch>(It.IsAny<string>()))
                .ReturnsAsync(_warzoneMatch);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetWarzoneMatchDetails();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("stats/h5/warzone/matches/", uri);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public void GetConstructedUri_ForMatchId_MatchesExpected(string guid)
        {
            var query = new GetWarzoneMatchDetails()
                .ForMatchId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/warzone/matches/{guid}", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetWarzoneMatchDetails()
                .ForMatchId(Guid.Empty);

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(WarzoneMatch), result);
            Assert.AreEqual(_warzoneMatch, result);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetWarzoneMatchDetails_DoesNotThrow(string guid)
        {
            var query = new GetWarzoneMatchDetails()
                .ForMatchId(new Guid(guid));

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(WarzoneMatch), result);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetWarzoneMatchDetails_SchemaIsValid(string guid)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Config.WarzoneMatchJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.WarzoneMatchJsonSchemaPath))
            });

            var query = new GetWarzoneMatchDetails()
                .ForMatchId(new Guid(guid));

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetWarzoneMatchDetails_ModelMatchesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.WarzoneMatchJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.WarzoneMatchJsonSchemaPath))
            });

            var query = new GetWarzoneMatchDetails()
                .ForMatchId(new Guid(guid));

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetWarzoneMatchDetails_IsSerializable(string guid)
        {
            var query = new GetWarzoneMatchDetails()
                .ForMatchId(new Guid(guid));

            var result = await Global.Session.Query(query);

            SerializationUtility<WarzoneMatch>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetWarzoneMatchDetails_InvalidGuid(string guid)
        {
            var query = new GetWarzoneMatchDetails()
                .ForMatchId(new Guid(guid));

            try
            {
                await Global.Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int)Enumeration.StatusCode.NotFound, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetWarzoneMatchDetails_MissingGuid()
        {
            var query = new GetWarzoneMatchDetails();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}