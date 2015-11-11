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
    public class GetMedalsTests : TestSessionSetup
    {
        [Test]
        public async Task GetMedals()
        {
            var query = new GetMedals()
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Medal>), result);
        }

        [Test]
        public async Task GetMedals_IsSerializable()
        {
            var query = new GetMedals()
                .SkipCache();

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Medal>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}