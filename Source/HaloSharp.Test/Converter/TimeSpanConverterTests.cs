using System;
using HaloSharp.Converter;
using Newtonsoft.Json;
using NUnit.Framework;

namespace HaloSharp.Test.Converter
{
    [TestFixture]
    public class TimeSpanConverterTests
    {
        private readonly string _iso8081 = "P1DT2H3M4S";
        private readonly TimeSpan _timespan = new TimeSpan(1, 2, 3, 4);

        private class TestClass
        {
            [JsonProperty(PropertyName = "FastestCompletionTime")]
            [JsonConverter(typeof (TimeSpanConverter))]
            public TimeSpan FastestCompletionTime { get; set; }
        }

        [Test]
        [TestCase("NonSeasonal")]
        [TestCase(null)]
        [TestCase(12345)]
        public void DeserializeObject_ReadJson_IsDefault(object value)
        {
            var source = $"{{\"FastestCompletionTime\":\"{value}\"}}";
            var target = JsonConvert.DeserializeObject<TestClass>(source);

            Assert.AreEqual(default(TimeSpan), target.FastestCompletionTime);
        }

        [Test]
        public void DeserializeObject_ReadJson_AreEqual()
        {
            string source = $"{{\"FastestCompletionTime\":\"{_iso8081}\"}}";
            var target = JsonConvert.DeserializeObject<TestClass>(source);

            Assert.AreEqual(_timespan, target.FastestCompletionTime);
        }

        [Test]
        public void SerializeObject_WriteJson_AreEqual()
        {
            var source = new TestClass {FastestCompletionTime = _timespan};
            var target = JsonConvert.SerializeObject(source);

            Assert.AreEqual($"{{\"FastestCompletionTime\":\"{_iso8081}\"}}", target);
        }
    }
}