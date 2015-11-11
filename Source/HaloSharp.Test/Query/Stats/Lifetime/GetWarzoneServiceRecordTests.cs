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
    public class GetWarzoneServiceRecordTests : TestSessionSetup
    {
        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetWarzoneServiceRecord_ForPlayer(string gamertag)
        {
            var query = new GetWarzoneServiceRecord()
                .ForPlayer(gamertag);

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (WarzoneServiceRecord), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetWarzoneServiceRecord_IsSerializable(string gamertag)
        {
            var query = new GetWarzoneServiceRecord()
                .ForPlayer(gamertag);

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<WarzoneServiceRecord>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        public async Task GetWarzoneServiceRecord_ForPlayers()
        {
            var gamertags = new List<string>
            {
                "Greenskull",
                "Furiousn00b"
            };

            var query = new GetWarzoneServiceRecord()
                .ForPlayers(gamertags);

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof(WarzoneServiceRecord), result);
            Assert.AreEqual(2, result.Results.Count);
        }

        [Test]
        public async Task GetWarzoneServiceRecord_MissingPlayer()
        {
            var query = new GetWarzoneServiceRecord();

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
        public async Task GetWarzoneServiceRecord_InvalidGamertag(string gamertag)
        {
            var query = new GetWarzoneServiceRecord()
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