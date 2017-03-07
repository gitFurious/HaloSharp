using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using HaloSharp.Model.Halo5.Stats.CarnageReport.Events;
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
    public class GetMatchEventsTests
    {
        private IHaloSession _mockSession;
        private MatchEventSummary _matchEventSummary;

        [SetUp]
        public void Setup()
        {
            _matchEventSummary = JsonConvert.DeserializeObject<MatchEventSummary>(File.ReadAllText(Halo5Config.MatchEventsJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<MatchEventSummary>(It.IsAny<string>()))
                .ReturnsAsync(_matchEventSummary);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public void GetConstructedUri_ForMatchId_MatchesExpected(string guid)
        {
            var query = new GetMatchEvents(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/matches/{guid}/events", uri);
        }

        [Test]
        [TestCase("d9323dc5-d1bd-4686-8e39-158cd360eca7")]
        public async Task Query_DoesNotThrow(string guid)
        {
            var query = new GetMatchEvents(new Guid(guid))
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(MatchEventSummary), result);
            Assert.AreEqual(_matchEventSummary, result);
        }

        [Test]
        [TestCase("d9323dc5-d1bd-4686-8e39-158cd360eca7")]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetMatchEvents_DoesNotThrow(string guid)
        {
            var query = new GetMatchEvents(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(MatchEventSummary), result);
        }

        [Test]
        [TestCase("d9323dc5-d1bd-4686-8e39-158cd360eca7")]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetMatchEvents_SchemaIsValid(string guid)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.MatchEventsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.MatchEventsJsonSchemaPath))
            });

            var query = new GetMatchEvents(new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("d9323dc5-d1bd-4686-8e39-158cd360eca7")]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetMatchEvents_ModelMatchesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.MatchEventsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.MatchEventsJsonSchemaPath))
            });

            var query = new GetMatchEvents(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("d9323dc5-d1bd-4686-8e39-158cd360eca7")]
        [TestCase("763208a1-934e-466a-bdbd-318fa4d2e1c6")]
        public async Task GetMatchEvents_IsSerializable(string guid)
        {
            var query = new GetMatchEvents(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<MatchEventSummary>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        public async Task GetMatchEvents_InvalidGuid(string guid)
        {
            var query = new GetMatchEvents(Guid.NewGuid())
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