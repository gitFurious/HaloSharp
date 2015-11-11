using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Stats.Lifetime;
using HaloSharp.Query.Stats.Lifetime;
using HaloSharp.Test.Utility;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Stats.Lifetime
{
    [TestFixture]
    public class GetCustomServiceRecordTests : TestSessionSetup
    {
        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetCustomServiceRecord(string gamertag)
        {
            var query = new GetCustomServiceRecord()
                .ForPlayer(gamertag);

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (CustomServiceRecord), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetCustomServiceRecord_IsSerializable(string gamertag)
        {
            var query = new GetCustomServiceRecord()
                .ForPlayer(gamertag);

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<CustomServiceRecord>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        public async Task GetCustomServiceRecord_ForPlayers()
        {
            var gamertags = new List<string>
            {
                "Greenskull",
                "Furiousn00b"
            };

            var query = new GetCustomServiceRecord()
                .ForPlayers(gamertags);

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof(CustomServiceRecord), result);
            Assert.AreEqual(2, result.Results.Count);
        }

        [Test]
        public async Task GetCustomServiceRecord_MissingPlayer()
        {
            var query = new GetCustomServiceRecord();

            try
            {
                await Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int)Enumeration.StatusCode.NotFound, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        public async Task GetCustomServiceRecord_InvalidGamertag(string gamertag)
        {
            var query = new GetCustomServiceRecord()
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