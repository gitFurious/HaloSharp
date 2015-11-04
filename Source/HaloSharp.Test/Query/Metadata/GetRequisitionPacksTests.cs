using HaloSharp.Extension;
using HaloSharp.Model.Metadata.Common;
using HaloSharp.Query.Metadata;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetRequisitionPacksTests : TestSessionSetup
    {
        [Test]
        public async Task GetRequisitionPacks()
        {
            var query = new GetRequisitionPacks()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<RequisitionPack>), result);
        }
    }
}