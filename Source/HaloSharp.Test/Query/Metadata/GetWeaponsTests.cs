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
    public class GetWeaponsTests
    {
        private IHaloSession _mockSession;
        private List<Weapon> _weapons;

        [SetUp]
        public void Setup()
        {
            _weapons = JsonConvert.DeserializeObject<List<Weapon>>(File.ReadAllText(Config.WeaponsJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<Weapon>>(It.IsAny<string>()))
                .ReturnsAsync(_weapons);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetWeapons();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/weapons", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetWeapons()
               .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<Weapon>), result);
            Assert.AreEqual(_weapons, result);
        }

        [Test]
        public async Task GetWeapons_DoesNotThrow()
        {
            var query = new GetWeapons()
               .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<Weapon>), result);
        }

        [Test]
        public async Task GetWeapons_SchemaIsValid()
        {
            var weaponsSchema = JSchema.Parse(File.ReadAllText(Config.WeaponsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.WeaponsJsonSchemaPath))
            });

            var query = new GetWeapons()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(weaponsSchema, jArray);
        }

        [Test]
        public async Task GetVehicles_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.WeaponsJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.WeaponsJsonSchemaPath))
            });

            var query = new GetWeapons()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetWeapons_IsSerializable()
        {
            var query = new GetWeapons()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<Weapon>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}