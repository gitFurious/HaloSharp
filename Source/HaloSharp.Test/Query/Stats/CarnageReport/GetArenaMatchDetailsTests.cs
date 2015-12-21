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
    public class GetArenaMatchDetailsTests
    {
        private const string BaseUri = "stats/h5/arena/matches/";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetArenaMatchDetails();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public void GetConstructedUri_ForMatchId_MatchesExpected(string guid)
        {
            var query = new GetArenaMatchDetails()
                .ForMatchId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"{BaseUri}{guid}", uri);
        }

        [Test]
        [TestCase("a3938034-d2d4-45db-a136-393b9e2e27d3")]
        [TestCase("06d7f2d0-d2b8-4804-b989-e60be099df09")]
        [TestCase("eaba11d8-ac94-432d-85f9-aed32d294e91")] // Contains MetaCommendationDeltas
        public async Task GetArenaMatchDetails(string guid)
        {
            var query = new GetArenaMatchDetails()
                .ForMatchId(new Guid(guid));

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(ArenaMatch), result);
        }

        [Test]
        [TestCase("a3938034-d2d4-45db-a136-393b9e2e27d3")]
        [TestCase("06d7f2d0-d2b8-4804-b989-e60be099df09")]
        [TestCase("eaba11d8-ac94-432d-85f9-aed32d294e91")] // Contains MetaCommendationDeltas
        public async Task GetArenaMatchDetails_IsSerializable(string guid)
        {
            var query = new GetArenaMatchDetails()
                .ForMatchId(new Guid(guid));

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<ArenaMatch>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetArenaMatchDetails_InvalidGuid(string guid)
        {
            var query = new GetArenaMatchDetails()
                .ForMatchId(new Guid(guid));

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
        public async Task GetArenaMatchDetails_MissingGuid()
        {
            var query = new GetArenaMatchDetails();

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
    }
}