using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Stats;
using HaloSharp.Query.Stats;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HaloSharp.Test.Utility;

namespace HaloSharp.Test.Query.Stats
{
    [TestFixture]
    public class GetMatchesTests : TestSessionSetup
    {
        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetMatches(string gamertag)
        {
            var query = new GetMatches()
                .ForPlayer(gamertag);

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (MatchSet), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetMatches_IsSerializable(string gamertag)
        {
            var query = new GetMatches()
                .ForPlayer(gamertag);

            var result = await Session.Query(query);

            var serializationUtility = new SerializationUtility<MatchSet>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("Greenskull", 1)]
        [TestCase("Furiousn00b", 1)]
        [TestCase("Greenskull", 2)]
        [TestCase("Furiousn00b", 2)]
        [TestCase("Greenskull", 3)]
        [TestCase("Furiousn00b", 3)]
        [TestCase("Greenskull", 4)]
        [TestCase("Furiousn00b", 4)]
        public async Task GetMatches_InGameMode(string gamertag, int gameMode)
        {
            var query = new GetMatches()
                .InGameMode((Enumeration.GameMode)gameMode)
                .ForPlayer(gamertag);

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof(MatchSet), result);
            Assert.IsTrue(result.Results.All(r => r.Id.GameMode == (Enumeration.GameMode)gameMode));
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetMatches_InGameModes(string gamertag)
        {
            var gameModes = new List<Enumeration.GameMode>
            {
                Enumeration.GameMode.Arena,
                Enumeration.GameMode.Warzone
            };

            var query = new GetMatches()
                .InGameModes(gameModes)
                .ForPlayer(gamertag);

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof(MatchSet), result);
            Assert.IsTrue(result.Results.All(r => r.Id.GameMode == Enumeration.GameMode.Arena || r.Id.GameMode == Enumeration.GameMode.Warzone));
        }

        [Test]
        public async Task GetMatches_MissingPlayer()
        {
            var query = new GetMatches();

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
        public async Task GetMatches_InvalidGamertag(string gamertag)
        {
            var query = new GetMatches()
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