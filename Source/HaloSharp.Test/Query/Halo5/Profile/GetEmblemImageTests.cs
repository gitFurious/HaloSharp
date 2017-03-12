using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.Halo5.Profile;
using HaloSharp.Query.Halo5.Profile;
using HaloSharp.Test.Utility;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Halo5.Profile
{
    [TestFixture]
    public class GetEmblemImageTests
    {
        [Test]
        [TestCase("Greenskull", 128)]
        [TestCase("Furiousn00b", 256)]
        public void Uri_MatchesExpected(string gamertag, int size)
        {
            var query = new GetEmblemImage(gamertag);

            Assert.AreEqual($"https://www.haloapi.com/profile/h5/profiles/{gamertag}/emblem", query.Uri);

            query.Size(size);

            Assert.AreEqual($"https://www.haloapi.com/profile/h5/profiles/{gamertag}/emblem?size={size}", query.Uri);
        }

        [Test]
        [TestCase("Greenskull", 128)]
        [TestCase("Furiousn00b", 256)]
        public async Task GetEmblemImage(string gamertag, int size)
        {
            var query = new GetEmblemImage(gamertag)
               .Size(size)
               .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (HaloImage), result);
        }

        [Test]
        [TestCase("Greenskull", 128)]
        [TestCase("Furiousn00b", 256)]
        public async Task GetEmblemImage_IsSerializable(string gamertag, int size)
        {
            var query = new GetEmblemImage(gamertag)
               .Size(size)
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<HaloImage>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("")]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetEmblemImage_InvalidGamertag(string gamertag)
        {
            var query = new GetEmblemImage(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase("Furiousn00b", 94)]
        [TestCase("Furiousn00b", 127)]
        [TestCase("Furiousn00b", 189)]
        [TestCase("Furiousn00b", 255)]
        [TestCase("Furiousn00b", 511)]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetEmblemImage_InvalidSize(string gamertag, int size)
        {
            var query = new GetEmblemImage(gamertag)
                .Size(size);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}