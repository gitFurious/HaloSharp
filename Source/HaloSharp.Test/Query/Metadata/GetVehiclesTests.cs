using HaloSharp.Extension;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetVehiclesTests
    {
        private IHaloSession _mockSession;
        private List<Vehicle> _vehicles;

        [SetUp]
        public void Setup()
        {
            _vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(File.ReadAllText(Config.VehiclesJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<Vehicle>>(It.IsAny<string>()))
                .ReturnsAsync(_vehicles);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetVehicles();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/vehicles", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetVehicles()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<Vehicle>), result);
            Assert.AreEqual(_vehicles, result);
        }

        [Test]
        public async Task GetVehicles_DoesNotThrow()
        {
            var query = new GetVehicles()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<Vehicle>), result);
        }

        [Test]
        public async Task GetVehicles_SchemaIsValid()
        {
            var vehiclesSchema = JSchema.Parse(File.ReadAllText(Config.VehiclesJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.VehiclesJsonSchemaPath))
            });

            var query = new GetVehicles()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(vehiclesSchema, jArray);
        }

        [Test]
        public async Task GetVehicles_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.VehiclesJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.VehiclesJsonSchemaPath))
            });

            var query = new GetVehicles()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetVehicles_IsSerializable()
        {
            var query = new GetVehicles()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<Vehicle>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}