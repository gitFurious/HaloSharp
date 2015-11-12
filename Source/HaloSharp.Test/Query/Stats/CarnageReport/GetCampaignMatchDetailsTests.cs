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
    public class GetCampaignMatchDetailsTests
    {
        private const string BaseUri = "stats/h5/campaign/matches/";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetCampaignMatchDetails();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public void GetConstructedUri_ForMatchId_MatchesExpected(string guid)
        {
            var query = new GetCampaignMatchDetails()
                .ForMatchId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"{BaseUri}{guid}", uri);
        }

        [Test]
        [TestCase("9918c24b-1f5c-43dc-a4b4-a233514ec346")]
        [TestCase("40fa0309-3008-48cb-880b-e28cd67c85ac")]
        public async Task GetCampaignMatchDetails(string guid)
        {
            var query = new GetCampaignMatchDetails()
                .ForMatchId(new Guid(guid));

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(CampaignMatch), result);
        }

        [Test]
        [TestCase("9918c24b-1f5c-43dc-a4b4-a233514ec346")]
        [TestCase("40fa0309-3008-48cb-880b-e28cd67c85ac")]
        public async Task GetCampaignMatchDetails_IsSerializable(string guid)
        {
            var query = new GetCampaignMatchDetails()
                .ForMatchId(new Guid(guid));

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<CampaignMatch>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetCampaignMatchDetails_InvalidGuid(string guid)
        {
            var query = new GetCampaignMatchDetails()
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
        public async Task GetCampaignMatchDetails_MissingGuid()
        {
            var query = new GetCampaignMatchDetails();

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