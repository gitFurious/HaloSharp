using System;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class FirefightWaveStarted : MatchEvent, IEquatable<FirefightWaveStarted>
    {
        [JsonProperty(PropertyName = "WaveNumber")]
        public int WaveNumber { get; set; }

        public bool Equals(FirefightWaveStarted other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return WaveNumber == other.WaveNumber;
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

            if (obj.GetType() != typeof(FirefightWaveStarted))
            {
                return false;
            }

            return Equals((FirefightWaveStarted)obj);
        }

        public override int GetHashCode()
        {
            return WaveNumber;
        }

        public static bool operator ==(FirefightWaveStarted left, FirefightWaveStarted right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FirefightWaveStarted left, FirefightWaveStarted right)
        {
            return !Equals(left, right);
        }
    }
}