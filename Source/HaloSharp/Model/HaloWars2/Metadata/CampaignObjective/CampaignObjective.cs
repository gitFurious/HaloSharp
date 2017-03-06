using System;

namespace HaloSharp.Model.HaloWars2.Metadata.CampaignObjective
{
    [Serializable]
    public class CampaignObjective : IEquatable<CampaignObjective>
    {
        public int Id { get; set; }

        public bool Equals(CampaignObjective other)
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

            if (obj.GetType() != typeof(CampaignObjective))
            {
                return false;
            }

            return Equals((CampaignObjective) obj);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(CampaignObjective left, CampaignObjective right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CampaignObjective left, CampaignObjective right)
        {
            return !Equals(left, right);
        }
    }
}