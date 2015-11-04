using HaloSharp.Extension;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetTeamColorsTests : TestSessionSetup
    {
        [Test]
        public async Task GetTeamColors()
        {
            var query = new GetTeamColors()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<TeamColor>), result);
        }
    }
}