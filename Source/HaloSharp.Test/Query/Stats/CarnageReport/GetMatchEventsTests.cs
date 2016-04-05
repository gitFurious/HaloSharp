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
    public class GetMatchEventsTests
    {
        private IHaloSession _mockSession;
        private MatchEvents _matchEvents;

        [SetUp]
        public void Setup()
        {
            _matchEvents = JsonConvert.DeserializeObject<MatchEvents>(File.ReadAllText(Config.MatchEventsJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<MatchEvents>(It.IsAny<string>()))
                .ReturnsAsync(_matchEvents);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetMatchEvents();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("stats/h5/matches//events", uri);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public void GetConstructedUri_ForMatchId_MatchesExpected(string guid)
        {
            var query = new GetMatchEvents()
                .ForMatchId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/matches/{guid}/events", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetMatchEvents()
                .ForMatchId(Guid.Empty)
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(MatchEvents), result);
            Assert.AreEqual(_matchEvents, result);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetMatchEvents_DoesNotThrow(string guid)
        {
            var query = new GetMatchEvents()
                .ForMatchId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(MatchEvents), result);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetMatchEvents_SchemaIsValid(string guid)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Config.MatchEventsJsonPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.MatchEventsJsonSchemaPath))
            });

            var query = new GetMatchEvents()
                .ForMatchId(new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetMatchEvents_ModelMatchesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.MatchEventsJsonPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.MatchEventsJsonSchemaPath))
            });

            var query = new GetMatchEvents()
                .ForMatchId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetMatchEvents_IsSerializable(string guid)
        {
            var query = new GetMatchEvents()
                .ForMatchId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<MatchEvents>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetMatchEvents_InvalidGuid(string guid)
        {
            var query = new GetMatchEvents()
                .ForMatchId(new Guid(guid))
                .SkipCache();

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
        public async Task GetMatchEvents_MissingGuid()
        {
            var query = new GetMatchEvents();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}