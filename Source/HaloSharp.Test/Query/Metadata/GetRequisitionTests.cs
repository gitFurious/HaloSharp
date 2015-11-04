using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetRequisitionTests : TestSessionSetup
    {
        [Test]
        [TestCase("e4f549b2-90af-4dab-b2bc-11a46ea44103")]
        public async Task GetRequisition(string guid)
        {
            var query = new GetRequisition()
                .ForRequisitionId(new Guid(guid))
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (Requisition), result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetRequisition_InvalidGuid(string guid)
        {
            var query = new GetRequisition()
                .ForRequisitionId(new Guid(guid))
                .SkipCache();

            try
            {
                await Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int) Enumeration.StatusCode.NotFound, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [Test]
        public async Task GetRequisition_MissingGuid()
        {
            var query = new GetRequisition()
                .SkipCache();

            try
            {
                await Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int) Enumeration.StatusCode.NotFound, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }
    }
}