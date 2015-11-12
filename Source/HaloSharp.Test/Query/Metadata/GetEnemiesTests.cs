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
    public class GetEnemiesTests
    {
        private const string BaseUri = "metadata/h5/metadata/enemies";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetEnemies();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        public async Task GetEnemies()
        {
            var query = new GetEnemies()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Enemy>), result);
        }

        [Test]
        public async Task GetEnemies_IsSerializable()
        {
            var query = new GetEnemies()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Enemy>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}