using System;
using HaloSharp.Converter;
using Newtonsoft.Json;
using NUnit.Framework;

namespace HaloSharp.Test.Converter
{
    [TestFixture]
    public class GuidConverterTests
    {
        private class TestClass
        {
            [JsonProperty(PropertyName = "HighestCsrSeasonId")]
            [JsonConverter(typeof (GuidConverter))]
            public Guid? HighestCsrSeasonId { get; set; }
        }

        [Test]
        [TestCase("2041d318-dd22-47c2-a487-2818ecf14e41")]
        public void DeserializeObject_ReadJson_AreEqual(object value)
        {
            string source = $"{{\"HighestCsrSeasonId\":\"{value}\"}}";
            var target = JsonConvert.DeserializeObject<TestClass>(source);

            Assert.AreEqual(value, target.HighestCsrSeasonId.ToString());
        }

        [Test]
        [TestCase("NonSeasonal")]
        [TestCase(null)]
        [TestCase(12345)]
        public void DeserializeObject_ReadJson_IsNull(object value)
        {
            var source = $"{{\"HighestCsrSeasonId\":\"{value}\"}}";
            var target = JsonConvert.DeserializeObject<TestClass>(source);

            Assert.IsNull(target.HighestCsrSeasonId);
        }

        [Test]
        public void SerializeObject_AreEqual()
        {
            var source = new TestClass { HighestCsrSeasonId = null };
            var target = JsonConvert.SerializeObject(source);

            Assert.AreEqual($"{{\"HighestCsrSeasonId\":null}}", target);
        }

        [Test]
        [TestCase("2041d318-dd22-47c2-a487-2818ecf14e41")]
        public void SerializeObject_WriteJson_AreEqual(string value)
        {
            var source = new TestClass { HighestCsrSeasonId = new Guid(value) };
            var target = JsonConvert.SerializeObject(source);

            Assert.AreEqual($"{{\"HighestCsrSeasonId\":\"{value}\"}}", target);
        }
    }
}
