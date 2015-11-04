using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Query.Profile;
using NUnit.Framework;
using System.Drawing;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Profile
{
    [TestFixture]
    public class GetSpartanImageTests : TestSessionSetup
    {
        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetSpartanImage(string gamertag)
        {
            var query = new GetSpartanImage()
                .ForPlayer(gamertag);

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (Image), result);
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

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof(Image), result);
        }

        [Test]
        public async Task GetSpartanImage_Crop()
        {
            var query = new GetSpartanImage()
                .ForPlayer("Furiousn00b")
                .Crop(Enumeration.CropType.Portrait);

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof(Image), result);
        }
    }
}