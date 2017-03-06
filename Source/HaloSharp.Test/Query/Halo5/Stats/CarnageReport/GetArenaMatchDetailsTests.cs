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
    public class GetArenaMatchDetailsTests
    {
        private IHaloSession _mockSession;
        private ArenaMatch _arenaMatch;

        [SetUp]
        public void Setup()
        {
            _arenaMatch = JsonConvert.DeserializeObject<ArenaMatch>(File.ReadAllText(Halo5Config.ArenaMatchJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<ArenaMatch>(It.IsAny<string>()))
                .ReturnsAsync(_arenaMatch);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetArenaMatchDetails();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("stats/h5/arena/matches/", uri);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public void GetConstructedUri_ForMatchId_MatchesExpected(string guid)
        {
            var query = new GetArenaMatchDetails()
                .ForMatchId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/arena/matches/{guid}", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetArenaMatchDetails()
                .ForMatchId(Guid.Empty)
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(ArenaMatch), result);
            Assert.AreEqual(_arenaMatch, result);
        }

        [Test]
        [TestCase("d9323dc5-d1bd-4686-8e39-158cd360eca7")]
        public async Task GetArenaMatchDetails_DoesNotThrow(string guid)
        {
            var query = new GetArenaMatchDetails()
                .ForMatchId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(ArenaMatch), result);
        }

        [Test]
        [TestCase("d9323dc5-d1bd-4686-8e39-158cd360eca7")]
        public async Task GetArenaMatchDetails_SchemaIsValid(string guid)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.ArenaMatchJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.ArenaMatchJsonSchemaPath))
            });

            var query = new GetArenaMatchDetails()
                .ForMatchId(new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("d9323dc5-d1bd-4686-8e39-158cd360eca7")]
        public async Task GetArenaMatchDetails_ModelMatchesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.ArenaMatchJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.ArenaMatchJsonSchemaPath))
            });

            var query = new GetArenaMatchDetails()
                .ForMatchId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("d9323dc5-d1bd-4686-8e39-158cd360eca7")]
        public async Task GetArenaMatchDetails_IsSerializable(string guid)
        {
            var query = new GetArenaMatchDetails()
                .ForMatchId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<ArenaMatch>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetArenaMatchDetails_InvalidGuid(string guid)
        {
            var query = new GetArenaMatchDetails()
                .ForMatchId(new Guid(guid))
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

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetArenaMatchDetails_MissingGuid()
        {
            var query = new GetArenaMatchDetails();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}