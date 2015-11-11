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
    public class GetWeaponsTests : TestSessionSetup
    {
        [Test]
        public async Task GetWeapons()
        {
            var query = new GetWeapons()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Weapon>), result);
        }

        [Test]
        public async Task GetWeapons_IsSerializable()
        {
            var query = new GetWeapons()
                .SkipCache();

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Weapon>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}