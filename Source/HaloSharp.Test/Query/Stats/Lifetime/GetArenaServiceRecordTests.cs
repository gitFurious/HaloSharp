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
    public class GetArenaServiceRecordTests
    {
        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetArenaServiceRecord(string gamertag)
        {
            var query = new GetArenaServiceRecord()
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (ArenaServiceRecord), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetArenaServiceRecord_IsSerializable(string gamertag)
        {
            var query = new GetArenaServiceRecord()
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<ArenaServiceRecord>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        public async Task GetArenaServiceRecord_ForPlayers()
        {
            var gamertags = new List<string>
            {
                "Greenskull",
                "Furiousn00b"
            };

            var query = new GetArenaServiceRecord()
                .ForPlayers(gamertags);

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(ArenaServiceRecord), result);
            Assert.AreEqual(2, result.Results.Count);
        }

        [Test]
        public async Task GetArenaServiceRecord_MissingPlayer()
        {
            var query = new GetArenaServiceRecord();

            try
            {
                await Global.Session.Query(query);
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
        public async Task GetArenaServiceRecord_InvalidGamertag(string gamertag)
        {
            var query = new GetArenaServiceRecord()
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