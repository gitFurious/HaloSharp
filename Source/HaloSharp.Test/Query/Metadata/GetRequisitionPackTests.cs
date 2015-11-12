using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Metadata.Common;
using HaloSharp.Query.Metadata;
using HaloSharp.Test.Utility;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetRequisitionPackTests
    {
        private const string BaseUri = "metadata/h5/metadata/requisition-packs/";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetRequisitionPack();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("3a1614d9-20a4-4817-a189-88cb781e9152")]
        public void GetConstructedUri_ForRequisitionPackId_MatchesExpected(string guid)
        {
            var query = new GetRequisitionPack()
                .ForRequisitionPackId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"{BaseUri}{guid}", uri);
        }

        [Test]
        [TestCase("3a1614d9-20a4-4817-a189-88cb781e9152")]
        [TestCase("3ce05b60-a118-4ad1-9617-bc04f64ac4d8")]
        [TestCase("5f96269a-58f8-473e-9897-42a4deb1bf09")]
        public async Task GetRequisitionPack(string guid)
        {
            var query = new GetRequisitionPack()
                .ForRequisitionPackId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (RequisitionPack), result);
        }

        [Test]
        [TestCase("3a1614d9-20a4-4817-a189-88cb781e9152")]
        [TestCase("3ce05b60-a118-4ad1-9617-bc04f64ac4d8")]
        [TestCase("5f96269a-58f8-473e-9897-42a4deb1bf09")]
        public async Task GetRequisitionPack_IsSerializable(string guid)
        {
            var query = new GetRequisitionPack()
                .ForRequisitionPackId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<RequisitionPack>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetRequisitionPack_InvalidGuid(string guid)
        {
            var query = new GetRequisitionPack()
                .ForRequisitionPackId(new Guid(guid))
                .SkipCache();

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
        public async Task GetRequisitionPack_MissingGuid()
        {
            var query = new GetRequisitionPack()
                .SkipCache();

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