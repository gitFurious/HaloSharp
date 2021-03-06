﻿using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Halo5.Metadata;
using HaloSharp.Query.Halo5.Metadata;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Metadata
{
    [TestFixture]
    public class GetMapVariantTests
    {
        private IHaloSession _mockSession;
        private MapVariant _mapVariant;

        [SetUp]
        public void Setup()
        {
            _mapVariant = JsonConvert.DeserializeObject<MapVariant>(File.ReadAllText(Halo5Config.MapVariantJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<MapVariant>(It.IsAny<string>()))
                .ReturnsAsync(_mapVariant);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("cb914b9e-f206-11e4-b447-24be05e24f7e")]
        public void Uri_MatchesExpected(string guid)
        {
            var query = new GetMapVariant(new Guid(guid));

            Assert.AreEqual($"https://www.haloapi.com/metadata/h5/metadata/map-variants/{guid}", query.Uri);
        }

        [Test]
        [TestCase("cb914b9e-f206-11e4-b447-24be05e24f7e")]
        public async Task Query_DoesNotThrow(string guid)
        {
            var query = new GetMapVariant(new Guid(guid));

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(MapVariant), result);
            Assert.AreEqual(_mapVariant, result);
        }

        [Test]
        [TestCase("d9f9c30d-b1be-4381-a5a4-fe29026cca12")]
        public async Task GetMapVariant_DoesNotThrow(string guid)
        {
            var query = new GetMapVariant(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(MapVariant), result);
        }

        [Test]
        [TestCase("d9f9c30d-b1be-4381-a5a4-fe29026cca12")]
        public async Task GetMapVariant_SchemaIsValid(string guid)
        {
            var mapVariantSchema = JSchema.Parse(File.ReadAllText(Halo5Config.MapVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.MapVariantJsonSchemaPath))
            });

            var query = new GetMapVariant(new Guid(guid))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(mapVariantSchema, jArray);
        }

        [Test]
        [TestCase("d9f9c30d-b1be-4381-a5a4-fe29026cca12")]
        public async Task GetMapVariant_ModelMatchesSchema(string guid)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.MapVariantJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.MapVariantJsonSchemaPath))
            });

            var query = new GetMapVariant(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("d9f9c30d-b1be-4381-a5a4-fe29026cca12")]
        public async Task GetMapVariant_IsSerializable(string guid)
        {
            var query = new GetMapVariant(new Guid(guid))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<MapVariant>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        public async Task GetMapVariant_InvalidGuid()
        {
            var query = new GetMapVariant(Guid.NewGuid())
                .SkipCache();

            try
            {
                await Global.Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int)Enumeration.Halo5.StatusCode.NotFound, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }
    }
}