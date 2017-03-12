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
        [TestCase("Greenskull", 128, Enumeration.Halo5.CropType.Full)]
        [TestCase("Furiousn00b", 256, Enumeration.Halo5.CropType.Portrait)]
        public void Uri_MatchesExpected(string gamertag, int size, Enumeration.Halo5.CropType crop)
        {
            var query = new GetSpartanImage(gamertag);

            Assert.AreEqual($"https://www.haloapi.com/profile/h5/profiles/{gamertag}/spartan", query.Uri);

            query.Size(size);

            Assert.AreEqual($"https://www.haloapi.com/profile/h5/profiles/{gamertag}/spartan?size={size}", query.Uri);

            query.Crop(crop);

            Assert.AreEqual($"https://www.haloapi.com/profile/h5/profiles/{gamertag}/spartan?size={size}&crop={crop}", query.Uri);
        }

        [Test]
        [TestCase("Greenskull", 128, Enumeration.Halo5.CropType.Full)]
        [TestCase("Furiousn00b", 256, Enumeration.Halo5.CropType.Portrait)]
        public async Task GetSpartanImage(string gamertag, int size, Enumeration.Halo5.CropType crop)
        {
            var query = new GetSpartanImage(gamertag)
                .Size(size)
                .Crop(crop)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (HaloImage), result);
        }

        [Test]
        [TestCase("Greenskull", 128, Enumeration.Halo5.CropType.Full)]
        [TestCase("Furiousn00b", 256, Enumeration.Halo5.CropType.Portrait)]
        public async Task GetSpartanImage_IsSerializable(string gamertag, int size, Enumeration.Halo5.CropType crop)
        {
            var query = new GetSpartanImage(gamertag)
                .Size(size)
                .Crop(crop)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<HaloImage>.AssertRoundTripSerializationIsPossible(result);
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
    }
}