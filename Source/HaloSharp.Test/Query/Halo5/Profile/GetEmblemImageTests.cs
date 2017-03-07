using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.Halo5.Profile;
using HaloSharp.Query.Halo5.Profile;
using HaloSharp.Test.Utility;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Profile
{
    [TestFixture]
    public class GetEmblemImageTests
    {
        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetEmblemImage(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{gamertag}/emblem{null}", uri);
        }

        [Test]
        [TestCase("Furiousn00b", 5)]
        [TestCase("Furiousn00b", 10)]
        public void GetConstructedUri_Size_MatchesExpected(string gamertag, int size)
        {
            var query = new GetEmblemImage(gamertag)
                .Size(size);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{gamertag}/emblem?size={size}", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetEmblemImage(string gamertag)
        {
            var query = new GetEmblemImage(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (GetImage), result);
        }

        [Test]
        [TestCase("Furiousn00b", 95)]
        [TestCase("Furiousn00b", 128)]
        [TestCase("Furiousn00b", 190)]
        [TestCase("Furiousn00b", 256)]
        [TestCase("Furiousn00b", 512)]
        public async Task GetEmblemImage_Size(string gamertag, int size)
        {
            var query = new GetEmblemImage(gamertag)
                .Size(size)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(GetImage), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetEmblemImage_IsSerializable(string gamertag)
        {
            var query = new GetEmblemImage(gamertag)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<GetImage>.AssertRoundTripSerializationIsPossible(result);
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

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetEmblemImage_InvalidGamertag(string gamertag)
        {
            var query = new GetEmblemImage(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}