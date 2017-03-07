using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Profile;
using HaloSharp.Query.Halo5.Profile;
using HaloSharp.Test.Utility;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Profile
{
    [TestFixture]
    public class GetSpartanImageTests
    {
        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetSpartanImage(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{gamertag}/spartan{null}", uri);
        }

        [Test]
        [TestCase("Furiousn00b", 5)]
        [TestCase("Furiousn00b", 10)]
        public void GetConstructedUri_Size_MatchesExpected(string gamertag, int size)
        {
            var query = new GetSpartanImage(gamertag)
                .Size(size);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{gamertag}/spartan?size={size}", uri);
        }

        [Test]
        [TestCase("Furiousn00b", Enumeration.Halo5.CropType.Full)]
        [TestCase("Furiousn00b", Enumeration.Halo5.CropType.Portrait)]
        public void GetConstructedUri_Crop_MatchesExpected(string gamertag, Enumeration.Halo5.CropType cropType)
        {
            var query = new GetSpartanImage(gamertag)
                .Crop(cropType);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{gamertag}/spartan?crop={cropType}", uri);
        }

        [Test]
        [TestCase("Greenskull", 5, Enumeration.Halo5.CropType.Full)]
        [TestCase("Furiousn00b", 10, Enumeration.Halo5.CropType.Portrait)]
        public void GetConstructedUri_Complex_MatchesExpected(string gamertag, int size, Enumeration.Halo5.CropType cropType)
        {
            var query = new GetSpartanImage(gamertag)
                .Size(size)
                .Crop(cropType);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{gamertag}/spartan?size={size}&crop={cropType}", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetSpartanImage(string gamertag)
        {
            var query = new GetSpartanImage(gamertag)
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
        public async Task GetSpartanImage_Size(string gamertag, int size)
        {
            var query = new GetSpartanImage(gamertag)
                .Size(size)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(GetImage), result);
        }

        [Test]
        [TestCase("Furiousn00b", Enumeration.Halo5.CropType.Portrait)]
        public async Task GetSpartanImage_Crop(string gamertag, Enumeration.Halo5.CropType crop)
        {
            var query = new GetSpartanImage(gamertag)
                .Crop(crop)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(GetImage), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetSpartanImage_IsSerializable(string gamertag)
        {
            var query = new GetSpartanImage(gamertag)
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
        public async Task GetSpartanImage_InvalidSize(string gamertag, int size)
        {
            var query = new GetSpartanImage(gamertag)
                .Size(size);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetSpartanImage_InvalidGamertag(string gamertag)
        {
            var query = new GetSpartanImage(gamertag);

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}