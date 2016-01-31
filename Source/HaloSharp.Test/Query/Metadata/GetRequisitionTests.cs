using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
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
    public class GetRequisitionTests
    {
        private IHaloSession _mockSession;
        private Requisition _requisition;

        [SetUp]
        public void Setup()
        {
            _requisition = JsonConvert.DeserializeObject<Requisition>(File.ReadAllText(Config.RequisitionJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<Requisition>(It.IsAny<string>()))
                .ReturnsAsync(_requisition);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetRequisition();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/requisitions/", uri);
        }

        [Test]
        [TestCase("a23a896d-57e6-45c3-970b-27550f0e7184")]
        public void GetConstructedUri_ForRequisitionId_MatchesExpected(string guid)
        {
            var query = new GetRequisition()
                .ForRequisitionId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"metadata/h5/metadata/requisitions/{guid}", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetRequisition()
                .ForRequisitionId(Guid.Empty);

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(Requisition), result);
            Assert.AreEqual(_requisition, result);
        }

        [Test]
        [TestCase("a23a896d-57e6-45c3-970b-27550f0e7184")]
        public async Task GetRequisition_DoesNotThrow(string guid)
        {
            var query = new GetRequisition()
                .ForRequisitionId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(Requisition), result);
        }

        [Test]
        [TestCase("a23a896d-57e6-45c3-970b-27550f0e7184")]
        public async Task GetRequisition_SchemaIsValid(string guid)
        {
            var requisitionSchema = JSchema.Parse(File.ReadAllText(Config.RequisitionJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.RequisitionJsonSchemaPath))
            });

            var query = new GetRequisition()
                .ForRequisitionId(new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(requisitionSchema, jArray);
        }

        [Test]
        [TestCase("a23a896d-57e6-45c3-970b-27550f0e7184")]
        public async Task GetRequisition_ModelMatchesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.RequisitionJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.RequisitionJsonSchemaPath))
            });

            var query = new GetRequisition()
                .ForRequisitionId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("a23a896d-57e6-45c3-970b-27550f0e7184")]
        public async Task GetRequisition_IsSerializable(string guid)
        {
            var query = new GetRequisition()
                .ForRequisitionId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<Requisition>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetRequisition_InvalidGuid(string guid)
        {
            var query = new GetRequisition()
                .ForRequisitionId(new Guid(guid))
                .SkipCache();

            try
            {
                await Global.Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int) Enumeration.StatusCode.NotFound, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetRequisition_MissingGuid()
        {
            var query = new GetRequisition()
                .SkipCache();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}