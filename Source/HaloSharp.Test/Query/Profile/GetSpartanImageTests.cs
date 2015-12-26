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
    public class GetSpartanImageTests
    {
        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetSpartanImage();

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{null}/spartan{null}", uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetSpartanImage()
                .ForPlayer(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{gamertag}/spartan{null}", uri);
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void GetConstructedUri_Size_MatchesExpected(int size)
        {
            var query = new GetSpartanImage()
                .Size(size);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{null}/spartan?size={size}", uri);
        }

        [Test]
        [TestCase(Enumeration.CropType.Full)]
        [TestCase(Enumeration.CropType.Portrait)]
        public void GetConstructedUri_Crop_MatchesExpected(Enumeration.CropType cropType)
        {
            var query = new GetSpartanImage()
                .Crop(cropType);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"profile/h5/profiles/{null}/spartan?crop={cropType}", uri);
        }

        [Test]
        [TestCase("Greenskull", 5, Enumeration.CropType.Full)]
        [TestCase("Furiousn00b", 10, Enumeration.CropType.Portrait)]
        public void GetConstructedUri_Complex_MatchesExpected(string gamertag, int size, Enumeration.CropType cropType)
        {
            var query = new GetSpartanImage()
                .ForPlayer(gamertag)
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
            var query = new GetSpartanImage()
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
        public async Task GetSpartanImage_Size(int size)
        {
            var query = new GetSpartanImage()
                .ForPlayer("Furiousn00b")
                .Size(size);

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(GetImage), result);
        }

        [Test]
        public async Task GetSpartanImage_Crop()
        {
            var query = new GetSpartanImage()
                .ForPlayer("Furiousn00b")
                .Crop(Enumeration.CropType.Portrait);

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(GetImage), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetSpartanImage_IsSerializable(string gamertag)
        {
            var query = new GetSpartanImage()
                .ForPlayer("Furiousn00b");

            var result = await Global.Session.Query(query);

            SerializationUtility<GetImage>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase(94)]
        [TestCase(127)]
        [TestCase(189)]
        [TestCase(255)]
        [TestCase(511)]
        public async Task GetSpartanImage_InvalidSize(int size)
        {
            var query = new GetSpartanImage()
                .ForPlayer("Furiousn00b")
                .Size(size);

            try
            {
                await Global.Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int)Enumeration.StatusCode.BadRequest, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        public async Task GetSpartanImage_InvalidGamertag(string gamertag)
        {
            var query = new GetSpartanImage()
                .ForPlayer(gamertag);

            try
            {
                await Global.Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int)Enumeration.StatusCode.BadRequest, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }
    }
}