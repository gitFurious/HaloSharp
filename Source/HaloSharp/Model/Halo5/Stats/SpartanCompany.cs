using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Profile;

namespace HaloSharp.Model.Halo5.Stats
{
    [Serializable]
    public class SpartanCompany :IEquatable<SpartanCompany>, IEquatable<Company>
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Creator")]
        public Creator Creator { get; set; }

        [JsonProperty(PropertyName = "peakMembershipCount")]
        public int PeakMembershipCount { get; set; }

        [JsonProperty(PropertyName = "suspendedUntilDate")]
        public ISO8601 SuspendedUntilDate { get; set; }

        [JsonProperty(PropertyName = "members")]
        public List<Member> Members { get; set; }

        [JsonProperty(PropertyName = "CreatedDate")]
        public ISO8601 CreatedDate { get; set; }

        [JsonProperty(PropertyName = "LastModifiedDate")]
        public ISO8601 LastModifiedDate{ get; set; }

        public bool Equals(SpartanCompany other)
        {
            if(ReferenceEquals(null, other))
            {
                return false;
            }

            if(ReferenceEquals(this, other))
            {
                return true;
            }

            return Id == other.Id
                && Name == other.Name
                && Creator.Equals(other.Creator)
                && PeakMembershipCount == other.PeakMembershipCount
                && SuspendedUntilDate == other.SuspendedUntilDate
                && Members.OrderBy(m => m.Identity.Gamertag).SequenceEqual(other.Members.OrderBy(m => m.Identity.Gamertag))
                && CreatedDate == other.CreatedDate
                && LastModifiedDate == other.LastModifiedDate;
        }

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

            return Id == other.Id
                && Name == other.Name;
        }

    }

    [Serializable]
    public class Creator : IEquatable<Creator>
    {
        [JsonProperty(PropertyName = "gamertag")]
        public string gamertag { get; set; }

        public bool Equals(Creator other)
        {

            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return gamertag == other.gamertag;
        }
    }

    [Serializable]
    public class Member : IEquatable<Member>
    {
        [JsonProperty(PropertyName = "Player")]
        public Identity Identity { get; set; }

        [JsonProperty(PropertyName = "role")]
        public int Role { get; set; }

        [JsonProperty(PropertyName = "joinedDate")]
        public ISO8601 JoinedDate { get; set; }

        [JsonProperty(PropertyName = "lastModifiedDate")]
        public ISO8601 LastModifiedDate { get; set; }

        public bool Equals(Member other)
        {

            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Identity.Equals(other.Identity)
                && Role == other.Role
                && JoinedDate == other.JoinedDate
                && LastModifiedDate == other.LastModifiedDate;
        }
    }




}
