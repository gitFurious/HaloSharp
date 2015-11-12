using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using HaloSharp.Test.Utility;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetGameVariantTests
    {
        private const string BaseUri = "metadata/h5/metadata/game-variants/";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetGameVariant();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        [TestCase("1e473914-46e4-408d-af26-178fb115de76")]
        public void GetConstructedUri_ForGameVariantId_MatchesExpected(string guid)
        {
            var query = new GetGameVariant()
                .ForGameVariantId(new Guid(guid));

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"{BaseUri}{guid}", uri);
        }

        [Test]
        [TestCase("00000003-0000-0010-8000-00aa00389b71")]
        [TestCase("1e473914-46e4-408d-af26-178fb115de76")]
        public async Task GetGameVariant(string guid)
        {
            var query = new GetGameVariant()
                .ForGameVariantId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (GameVariant), result);
        }

        [Test]
        [TestCase("00000003-0000-0010-8000-00aa00389b71")]
        [TestCase("1e473914-46e4-408d-af26-178fb115de76")]
        public async Task GetGameVariant_IsSerializable(string guid)
        {
            var query = new GetGameVariant()
                .ForGameVariantId(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<GameVariant>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("00000000-0000-0000-0000-000000000000")]
        public async Task GetGameVariant_InvalidGuid(string guid)
        {
            var query = new GetGameVariant()
                .ForGameVariantId(new Guid(guid))
                .SkipCache();

            try
            {
                await Global.Session.Query(query);
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
        public async Task GetGameVariant_MissingGuid()
        {
            var query = new GetGameVariant()
                .SkipCache();

            try
            {
                await Global.Session.Query(query);
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