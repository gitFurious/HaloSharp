using HaloSharp.Extension;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using HaloSharp.Test.Utility;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetSkullsTests : TestSessionSetup
    {
        [Test]
        public async Task GetSkulls()
        {
            var query = new GetSkulls()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Skull>), result);
        }

        [Test]
        public async Task GetSkulls_IsSerializable()
        {
            var query = new GetSkulls()
                .SkipCache();

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Skull>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}