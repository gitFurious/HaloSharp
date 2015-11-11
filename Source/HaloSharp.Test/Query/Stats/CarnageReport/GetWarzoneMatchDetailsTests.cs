using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Stats.CarnageReport;
using HaloSharp.Query.Stats;
using HaloSharp.Query.Stats.CarnageReport;
using HaloSharp.Test.Utility;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Stats.CarnageReport
{
    [TestFixture]
    public class GetWarzoneMatchDetailsTests : TestSessionSetup
    {
        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetWarzoneMatchDetails(string gamertag)
        {
            var getMatchesQuery = new GetMatches()
                .InGameMode(Enumeration.GameMode.Warzone)
                .ForPlayer(gamertag);

            var matches = await Session.Query(getMatchesQuery);

            Assert.IsTrue(matches.Results.Any());

            var getWarzoneMatchDetailsQuery = new GetWarzoneMatchDetails()
                .ForMatchId(matches.Results.First().Id.MatchId);

            var result = await Session.Query(getWarzoneMatchDetailsQuery);

            Assert.IsInstanceOf(typeof(WarzoneMatch), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetWarzoneMatchDetails_IsSerializable(string gamertag)
        {
            var getMatchesQuery = new GetMatches()
                .InGameMode(Enumeration.GameMode.Warzone)
                .ForPlayer(gamertag);

            var matches = await Session.Query(getMatchesQuery);

            Assert.IsTrue(matches.Results.Any());

            var getWarzoneMatchDetailsQuery = new GetWarzoneMatchDetails()
                .ForMatchId(matches.Results.First().Id.MatchId);

            var result = await Session.Query(getWarzoneMatchDetailsQuery);

            var serializationUtility = new SerializationUtility<WarzoneMatch>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetWarzoneMatchDetails_InvalidGuid(string guid)
        {
            var query = new GetWarzoneMatchDetails()
                .ForMatchId(new Guid(guid));

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
        public async Task GetWarzoneMatchDetails_MissingGuid()
        {
            var query = new GetWarzoneMatchDetails();

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
    }
}