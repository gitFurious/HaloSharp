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
    public class GetWarzoneMatchDetailsTests
    {
        private const string BaseUri = "stats/h5/warzone/matches/";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetWarzoneMatchDetails();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("22ee16eb-cdb9-4acf-9324-4a5516f93852")]
        public void GetConstructedUri_ForMatchId_MatchesExpected(string guid)
        {
            var query = new GetWarzoneMatchDetails()
                .ForMatchId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"{BaseUri}{guid}", uri);
        }

        [Test]
        [TestCase("22ee16eb-cdb9-4acf-9324-4a5516f93852")]
        [TestCase("982eaef6-4ed4-43b3-9361-b40563122b92")]
        [TestCase("ea392dc3-5989-4fa8-b920-08e265220ffc")] // Contains MetaCommendationDeltas
        public async Task GetWarzoneMatchDetails(string guid)
        {
            var query = new GetWarzoneMatchDetails()
                .ForMatchId(new Guid(guid));

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(WarzoneMatch), result);
        }

        [Test]
        [TestCase("22ee16eb-cdb9-4acf-9324-4a5516f93852")]
        [TestCase("982eaef6-4ed4-43b3-9361-b40563122b92")]
        [TestCase("ea392dc3-5989-4fa8-b920-08e265220ffc")] // Contains MetaCommendationDeltas
        public async Task GetWarzoneMatchDetails_IsSerializable(string guid)
        {
            var query = new GetWarzoneMatchDetails()
                .ForMatchId(new Guid(guid));

            var result = await Global.Session.Query(query);

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
        public async Task GetWarzoneMatchDetails_MissingGuid()
        {
            var query = new GetWarzoneMatchDetails();

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