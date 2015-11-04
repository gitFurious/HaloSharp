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
    public class GetMapVariantTests : TestSessionSetup
    {
        [Test]
        [TestCase("cb914b9e-f206-11e4-b447-24be05e24f7e")]
        [TestCase("cae999f0-f206-11e4-9835-24be05e24f7e")]
        public async Task GetMapVariant(string guid)
        {
            var query = new GetMapVariant()
                .ForMapVariantId(new Guid(guid))
                .SkipCache();

            var result = await Session.Query(query);

            Assert.IsInstanceOf(typeof (MapVariant), result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetMapVariant_InvalidGuid(string guid)
        {
            var query = new GetMapVariant()
                .ForMapVariantId(new Guid(guid))
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
        public async Task GetMapVariant_MissingGuid()
        {
            var query = new GetMapVariant()
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