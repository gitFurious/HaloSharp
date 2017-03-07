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
    public class GetCustomMatchDetailsTests
    {
        private IHaloSession _mockSession;
        private CustomMatch _customMatch;

        [SetUp]
        public void Setup()
        {
            _customMatch = JsonConvert.DeserializeObject<CustomMatch>(File.ReadAllText(Halo5Config.CustomMatchJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<CustomMatch>(It.IsAny<string>()))
                .ReturnsAsync(_customMatch);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public void GetConstructedUri_ForMatchId_MatchesExpected(string guid)
        {
            var query = new GetCustomMatchDetails(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/custom/matches/{guid}", uri);
        }

        [Test]
        [TestCase("afa95d12-0e0d-487f-a583-72a24dd68361")]
        public async Task Query_DoesNotThrow(string guid)
        {
            var query = new GetCustomMatchDetails(new Guid(guid))
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(CustomMatch), result);
            Assert.AreEqual(_customMatch, result);
        }

        [Test]
        [TestCase("afa95d12-0e0d-487f-a583-72a24dd68361")]
        public async Task GetCustomMatchDetails_DoesNotThrow(string guid)
        {
            var query = new GetCustomMatchDetails(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(CustomMatch), result);
        }

        [Test]
        [TestCase("afa95d12-0e0d-487f-a583-72a24dd68361")]
        public async Task GetCustomMatchDetails_SchemaIsValid(string guid)
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Halo5Config.CustomMatchJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.CustomMatchJsonSchemaPath))
            });

            var query = new GetCustomMatchDetails(new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        [TestCase("afa95d12-0e0d-487f-a583-72a24dd68361")]
        public async Task GetCustomMatchDetails_ModelMatchesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.CustomMatchJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.CustomMatchJsonSchemaPath))
            });

            var query = new GetCustomMatchDetails(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("afa95d12-0e0d-487f-a583-72a24dd68361")]
        public async Task GetCustomMatchDetails_IsSerializable(string guid)
        {
            var query = new GetCustomMatchDetails(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<CustomMatch>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        public async Task GetCustomMatchDetails_InvalidGuid()
        {
            var query = new GetCustomMatchDetails(Guid.NewGuid())
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