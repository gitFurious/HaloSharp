using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace HaloSharp.Model.HaloWars2.Stats.CarnageReport.Events
{
    [Serializable]
    public class FirefightWaveSpawned : MatchEvent, IEquatable<FirefightWaveSpawned>
    {
        [JsonProperty(PropertyName = "WaveNumber")]
        public int WaveNumber { get; set; }

        [JsonProperty(PropertyName = "InstancesSpawned")]
        public List<int> InstancesSpawned { get; set; }

        public bool Equals(FirefightWaveSpawned other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return false;
            }

            return InstancesSpawned.OrderBy(i => i).SequenceEqual(other.InstancesSpawned.OrderBy(i => i))
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

            if (obj.GetType() != typeof(FirefightWaveSpawned))
            {
                return false;
            }

            return Equals((FirefightWaveSpawned)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((InstancesSpawned?.GetHashCode() ?? 0) * 397) ^ WaveNumber;
            }
        }

        public static bool operator ==(FirefightWaveSpawned left, FirefightWaveSpawned right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FirefightWaveSpawned left, FirefightWaveSpawned right)
        {
            return !Equals(left, right);
        }
    }
}