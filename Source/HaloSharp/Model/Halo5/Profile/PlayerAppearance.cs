using System;
using Newtonsoft.Json;
using HaloSharp.Model.Common;

namespace HaloSharp.Model.Halo5.Profile
{
    [Serializable]
    public class PlayerAppearance : IEquatable<PlayerAppearance>
    {
        [JsonProperty(PropertyName = "gamertag")]
        public string Gamertag { get; set; }

        [JsonProperty(PropertyName = "LastModifiedUtc")]
        public ISO8601 LastModifiedUtc { get; set; }

        [JsonProperty(PropertyName = "FirstModifiedUtc")]
        public ISO8601 FirstModifiedUtc { get; set; }

        [JsonProperty(PropertyName = "serviceTag")]
        public string ServiceTag { get; set; }

        [JsonProperty(PropertyName = "Company")]
        public Company Company { get; set; }

        public bool Equals(PlayerAppearance other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Company.Equals(other.Company)
                && Gamertag == other.Gamertag
                && LastModifiedUtc == other.LastModifiedUtc
                && FirstModifiedUtc == other.FirstModifiedUtc
                && ServiceTag == other.ServiceTag;
        }
    }

    [Serializable]
    public class Company : IEquatable<Company>
    {
        [JsonProperty(PropertyName = "id")]
        public Guid id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }


        public bool Equals(Company other)
        {

            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return id == other.id
                && name == other.name;
        }

    }




}
