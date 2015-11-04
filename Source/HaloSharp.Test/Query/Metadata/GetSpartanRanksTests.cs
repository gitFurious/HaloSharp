using HaloSharp.Extension;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetSpartanRanksTests : TestSessionSetup
    {
        [Test]
        public async Task GetSpartanRanks()
        {
            var query = new GetSpartanRanks()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<SpartanRank>), result);
        }
    }
}