using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Query.Profile;
using NUnit.Framework;
using System.Drawing;
using System.Threading.Tasks;
using HaloSharp.Model.Profile;
using HaloSharp.Test.Utility;

namespace HaloSharp.Test.Query.Profile
{
    [TestFixture]
    public class GetEmblemImageTests : TestSessionSetup
    {
        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetEmblemImage(string gamertag)
        {
            var query = new GetEmblemImage()
                .ForPlayer(gamertag);

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (GetImage), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetEmblemImage_IsSerializable(string gamertag)
        {
            var query = new GetEmblemImage()
                .ForPlayer(gamertag);

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<GetImage>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
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

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof(GetImage), result);
        }

        [Test]
        [TestCase(94)]
        [TestCase(127)]
        [TestCase(189)]
        [TestCase(255)]
        [TestCase(511)]
        public async Task GetEmblemImage_InvalidSize(int size)
        {
            var query = new GetEmblemImage()
                .ForPlayer("Furiousn00b")
                .Size(size);

            try
            {
                await Session.Query(query);
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
        public async Task GetEmblemImage_InvalidGamertag(string gamertag)
        {
            var query = new GetEmblemImage()
                .ForPlayer(gamertag);

            try
            {
                await Session.Query(query);
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