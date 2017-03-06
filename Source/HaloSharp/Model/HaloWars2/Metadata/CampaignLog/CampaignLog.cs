using System;

namespace HaloSharp.Model.HaloWars2.Metadata.CampaignLog
{
    [Serializable]
    public class CampaignLog : IEquatable<CampaignLog>
    {
        public int Id { get; set; }

        public bool Equals(CampaignLog other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(CampaignLog))
            {
                return false;
            }

            return Equals((CampaignLog) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(CampaignLog left, CampaignLog right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignLog left, CampaignLog right)
        {
            return !Equals(left, right);
        }
    }
}