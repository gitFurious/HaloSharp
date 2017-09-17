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
    }
}
