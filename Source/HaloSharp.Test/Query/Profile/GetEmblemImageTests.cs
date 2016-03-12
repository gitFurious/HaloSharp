using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Profile;
using HaloSharp.Query.Profile;
using HaloSharp.Test.Utility;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Profile
{
    [TestFixture]
    public class GetEmblemImageTests
    {
        [Test]
        public void GetConstructedUri_NoParameters_MatchesExpected()
        {
            var query = new GetEmblemImage();

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{null}/emblem{null}", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetEmblemImage()
                .ForPlayer(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{gamertag}/emblem{null}", uri);
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void GetConstructedUri_Size_MatchesExpected(int size)
        {
            var query = new GetEmblemImage()
                .Size(size);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{null}/emblem?size={size}", uri);
        }

        [Test]
        [TestCase("Greenskull", 5)]
        [TestCase("Furiousn00b", 10)]
        public void GetConstructedUri_Complex_MatchesExpected(string gamertag, int size)
        {
            var query = new GetEmblemImage()
                .ForPlayer(gamertag)
                .Size(size);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{gamertag}/emblem?size={size}", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetEmblemImage(string gamertag)
        {
            var query = new GetEmblemImage()
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (GetImage), result);
        }

        [Test]
        [TestCase(95)]
        [TestCase(128)]
        [TestCase(190)]
        [TestCase(256)]
        [TestCase(512)]
        public async Task GetEmblemImage_Size(int size)
        {
            var query = new GetEmblemImage()
                .ForPlayer("Furiousn00b")
                .Size(size);

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(GetImage), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetEmblemImage_IsSerializable(string gamertag)
        {
            var query = new GetEmblemImage()
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            SerializationUtility<GetImage>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase(94)]
        [TestCase(127)]
        [TestCase(189)]
        [TestCase(255)]
        [TestCase(511)]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetEmblemImage_InvalidSize(int size)
        {
            var query = new GetEmblemImage()
                .ForPlayer("Furiousn00b")
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
            var query = new GetEmblemImage()
                .ForPlayer(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetEmblemImage_MissingGamertag()
        {
            var query = new GetEmblemImage();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}