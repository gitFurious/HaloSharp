using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Stats;
using HaloSharp.Query.Halo5.Stats;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Stats
{
    [TestFixture]
    public class GetSpartanCompanyTests
    {
        private IHaloSession _mockSession;
        private SpartanCompany _spartanCompany;

        [SetUp]
        public void Setup()
        {
            _spartanCompany = JsonConvert.DeserializeObject<SpartanCompany>(File.ReadAllText(Halo5Config.SpartanCompanyPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<SpartanCompany>(It.IsAny<string>()))
                .ReturnsAsync(_spartanCompany);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("a23876ac-321e-497d-933b-65e226d01b2f")]
        [TestCase("c376dcc0-600c-498e-b656-0c18950fa8bb")]
        public void Uri_MatchesExpected(Guid companyId)
        {
            var query = new GetSpartanCompany(companyId);
            Assert.AreEqual($"https://www.haloapi.com/stats/h5/companies/{companyId}", query.Uri);    
        }

        [Test]
        [TestCase("a23876ac-321e-497d-933b-65e226d01b2f")]
        public async Task Query_DoesNotThrow(Guid companyId)
        {
            var query = new GetSpartanCompany(companyId)
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(SpartanCompany), result);
            Assert.AreEqual(_spartanCompany, result);
        }

        [Test]
        [TestCase("a23876ac-321e-497d-933b-65e226d01b2f")]
        [TestCase("c376dcc0-600c-498e-b656-0c18950fa8bb")]
        public async Task GetSpartanCompany_DoesNotThrow(Guid companyId)
        {
            var query = new GetSpartanCompany(companyId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(SpartanCompany), result);
        }

        [Test]
        [TestCase("a23876ac-321e-497d-933b-65e226d01b2f")]
        [TestCase("c376dcc0-600c-498e-b656-0c18950fa8bb")]
        public async Task GetSpartanCompany_SchemaIsValid(Guid companyId)
        {
            var spartanCompanySchema = JSchema.Parse(File.ReadAllText(Halo5Config.SpartanCompanyPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.SpartanCompanySchemaPath))
            });

            var query = new GetSpartanCompany(companyId)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(spartanCompanySchema, jArray);
        }

        [Test]
        [TestCase("a23876ac-321e-497d-933b-65e226d01b2f")]
        [TestCase("c376dcc0-600c-498e-b656-0c18950fa8bb")]
        public async Task GetSpartanCompany_ModelMatchesSchema(Guid companyId)
        {

            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.SpartanCompanyPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.SpartanCompanySchemaPath))
            });

            var query = new GetSpartanCompany(companyId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("a23876ac-321e-497d-933b-65e226d01b2f")]
        [TestCase("c376dcc0-600c-498e-b656-0c18950fa8bb")]
        public async Task GetSpartanCompany_IsSerializable(Guid companyId)
        {
            var query = new GetSpartanCompany(companyId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<SpartanCompany>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("0")]
        [TestCase("!$%@")]
        public async Task GetSpartanCompany_InvalidGuid(Guid companyId)
        {
            var query = new GetSpartanCompany(companyId);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

    }
}
