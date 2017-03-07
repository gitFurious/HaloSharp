using System;
using HaloSharp.Converter;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class FirefightWaveCompleted : MatchEvent, IEquatable<FirefightWaveCompleted>
    {
        [JsonProperty(PropertyName = "WaveNumber")]
        public int WaveNumber { get; set; }

        [JsonProperty(PropertyName = "WaveDurationMilliseconds")]
        [JsonConverter(typeof(MillisecondConverter))]
        public TimeSpan WaveDuration { get; set; }

        public bool Equals(FirefightWaveCompleted other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return WaveDuration.Equals(other.WaveDuration)
                   && WaveNumber == other.WaveNumber;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return false;
            }

            if (obj.GetType() != typeof(FirefightWaveCompleted))
            {
                return false;
            }

            return Equals((FirefightWaveCompleted)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (WaveDuration.GetHashCode() * 397) ^ WaveNumber;
            }
        }

        public static bool operator ==(FirefightWaveCompleted left, FirefightWaveCompleted right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FirefightWaveCompleted left, FirefightWaveCompleted right)
        {
            return !Equals(left, right);
        }
    }
}