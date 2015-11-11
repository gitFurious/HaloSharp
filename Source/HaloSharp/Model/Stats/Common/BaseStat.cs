using HaloSharp.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloSharp.Model.Stats.Common
{
    [Serializable]
    public class BaseStat : IEquatable<BaseStat>
    {
        public List<EnemySet> DestroyedEnemyVehicles { get; set; }
        public List<EnemySet> EnemyKills { get; set; }
        public List<Impulse> Impulses { get; set; }
        public List<MedalAward> MedalAwards { get; set; }
        public int TotalAssassinations { get; set; }
        public int TotalAssists { get; set; }
        public int TotalDeaths { get; set; }
        public double TotalGrenadeDamage { get; set; }
        public int TotalGrenadeKills { get; set; }
        public double TotalGroundPoundDamage { get; set; }
        public int TotalGroundPoundKills { get; set; }
        public int TotalHeadshots { get; set; }
        public int TotalKills { get; set; }
        public double TotalMeleeDamage { get; set; }
        public int TotalMeleeKills { get; set; }
        public double TotalPowerWeaponDamage { get; set; }
        public int TotalPowerWeaponGrabs { get; set; }
        public int TotalPowerWeaponKills { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalPowerWeaponPossessionTime { get; set; }

        public int TotalShotsFired { get; set; }
        public int TotalShotsLanded { get; set; }
        public double TotalShoulderBashDamage { get; set; }
        public int TotalShoulderBashKills { get; set; }
        public int TotalSpartanKills { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalTimePlayed { get; set; }

        public double TotalWeaponDamage { get; set; }
        public List<WeaponStat> WeaponStats { get; set; }
        public WeaponStat WeaponWithMostKills { get; set; }

        // Not used.
        public int TotalGamesCompleted { get; set; }
        public int TotalGamesLost { get; set; }
        public int TotalGamesTied { get; set; }
        public int TotalGamesWon { get; set; }

        public bool Equals(BaseStat other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return DestroyedEnemyVehicles.OrderBy(dev => dev.Enemy.BaseId).SequenceEqual(other.DestroyedEnemyVehicles.OrderBy(dev => dev.Enemy.BaseId))
                && EnemyKills.OrderBy(dev => dev.Enemy.BaseId).SequenceEqual(other.EnemyKills.OrderBy(dev => dev.Enemy.BaseId))
                && Impulses.OrderBy(i => i.Id).SequenceEqual(other.Impulses.OrderBy(i => i.Id))
                && MedalAwards.OrderBy(ma => ma.MedalId).SequenceEqual(other.MedalAwards.OrderBy(ma => ma.MedalId))
                && TotalAssassinations == other.TotalAssassinations
                && TotalAssists == other.TotalAssists
                && TotalDeaths == other.TotalDeaths
                && TotalGamesCompleted == other.TotalGamesCompleted
                && TotalGamesLost == other.TotalGamesLost
                && TotalGamesTied == other.TotalGamesTied
                && TotalGamesWon == other.TotalGamesWon
                && TotalGrenadeDamage.Equals(other.TotalGrenadeDamage)
                && TotalGrenadeKills == other.TotalGrenadeKills
                && TotalGroundPoundDamage.Equals(other.TotalGroundPoundDamage)
                && TotalGroundPoundKills == other.TotalGroundPoundKills
                && TotalHeadshots == other.TotalHeadshots
                && TotalKills == other.TotalKills
                && TotalMeleeDamage.Equals(other.TotalMeleeDamage)
                && TotalMeleeKills == other.TotalMeleeKills
                && TotalPowerWeaponDamage.Equals(other.TotalPowerWeaponDamage)
                && TotalPowerWeaponGrabs == other.TotalPowerWeaponGrabs
                && TotalPowerWeaponKills == other.TotalPowerWeaponKills
                && TotalPowerWeaponPossessionTime.Equals(other.TotalPowerWeaponPossessionTime)
                && TotalShotsFired == other.TotalShotsFired
                && TotalShotsLanded == other.TotalShotsLanded
                && TotalShoulderBashDamage.Equals(other.TotalShoulderBashDamage)
                && TotalShoulderBashKills == other.TotalShoulderBashKills
                && TotalSpartanKills == other.TotalSpartanKills
                && TotalTimePlayed.Equals(other.TotalTimePlayed)
                && TotalWeaponDamage.Equals(other.TotalWeaponDamage)
                && WeaponStats.OrderBy(ws => ws.WeaponId.StockId).SequenceEqual(other.WeaponStats.OrderBy(ws => ws.WeaponId.StockId))
                && Equals(WeaponWithMostKills, other.WeaponWithMostKills);
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

            if (obj.GetType() != typeof (BaseStat))
            {
                return false;
            }

            return Equals((BaseStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = DestroyedEnemyVehicles?.GetHashCode() ?? 0;
                hashCode = (hashCode*397) ^ (EnemyKills?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (Impulses?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (MedalAwards?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ TotalAssassinations;
                hashCode = (hashCode*397) ^ TotalAssists;
                hashCode = (hashCode*397) ^ TotalDeaths;
                hashCode = (hashCode*397) ^ TotalGamesCompleted;
                hashCode = (hashCode*397) ^ TotalGamesLost;
                hashCode = (hashCode*397) ^ TotalGamesTied;
                hashCode = (hashCode*397) ^ TotalGamesWon;
                hashCode = (hashCode*397) ^ TotalGrenadeDamage.GetHashCode();
                hashCode = (hashCode*397) ^ TotalGrenadeKills;
                hashCode = (hashCode*397) ^ TotalGroundPoundDamage.GetHashCode();
                hashCode = (hashCode*397) ^ TotalGroundPoundKills;
                hashCode = (hashCode*397) ^ TotalHeadshots;
                hashCode = (hashCode*397) ^ TotalKills;
                hashCode = (hashCode*397) ^ TotalMeleeDamage.GetHashCode();
                hashCode = (hashCode*397) ^ TotalMeleeKills;
                hashCode = (hashCode*397) ^ TotalPowerWeaponDamage.GetHashCode();
                hashCode = (hashCode*397) ^ TotalPowerWeaponGrabs;
                hashCode = (hashCode*397) ^ TotalPowerWeaponKills;
                hashCode = (hashCode*397) ^ TotalPowerWeaponPossessionTime.GetHashCode();
                hashCode = (hashCode*397) ^ TotalShotsFired;
                hashCode = (hashCode*397) ^ TotalShotsLanded;
                hashCode = (hashCode*397) ^ TotalShoulderBashDamage.GetHashCode();
                hashCode = (hashCode*397) ^ TotalShoulderBashKills;
                hashCode = (hashCode*397) ^ TotalSpartanKills;
                hashCode = (hashCode*397) ^ TotalTimePlayed.GetHashCode();
                hashCode = (hashCode*397) ^ TotalWeaponDamage.GetHashCode();
                hashCode = (hashCode*397) ^ (WeaponStats?.GetHashCode() ?? 0);
                hashCode = (hashCode*397) ^ (WeaponWithMostKills?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(BaseStat left, BaseStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(BaseStat left, BaseStat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class WeaponStat : IEquatable<WeaponStat>
    {
        public double TotalDamageDealt { get; set; }
        public int TotalHeadshots { get; set; }
        public int TotalKills { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalPossessionTime { get; set; }

        public int TotalShotsFired { get; set; }
        public int TotalShotsLanded { get; set; }
        public WeaponId WeaponId { get; set; }

        public bool Equals(WeaponStat other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return TotalDamageDealt.Equals(other.TotalDamageDealt)
                && TotalHeadshots == other.TotalHeadshots
                && TotalKills == other.TotalKills
                && TotalPossessionTime.Equals(other.TotalPossessionTime)
                && TotalShotsFired == other.TotalShotsFired
                && TotalShotsLanded == other.TotalShotsLanded
                && Equals(WeaponId, other.WeaponId);
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

            if (obj.GetType() != typeof (WeaponStat))
            {
                return false;
            }

            return Equals((WeaponStat) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = TotalDamageDealt.GetHashCode();
                hashCode = (hashCode*397) ^ TotalHeadshots;
                hashCode = (hashCode*397) ^ TotalKills;
                hashCode = (hashCode*397) ^ TotalPossessionTime.GetHashCode();
                hashCode = (hashCode*397) ^ TotalShotsFired;
                hashCode = (hashCode*397) ^ TotalShotsLanded;
                hashCode = (hashCode*397) ^ (WeaponId?.GetHashCode() ?? 0);
                return hashCode;
            }
        }

        public static bool operator ==(WeaponStat left, WeaponStat right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WeaponStat left, WeaponStat right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class WeaponId : IEquatable<WeaponId>
    {
        public List<int> Attachments { get; set; }
        public uint StockId { get; set; }

        public bool Equals(WeaponId other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Attachments.OrderBy(a => a).SequenceEqual(other.Attachments.OrderBy(a => a))
                && StockId == other.StockId;
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

            if (obj.GetType() != typeof (WeaponId))
            {
                return false;
            }

            return Equals((WeaponId) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Attachments?.GetHashCode() ?? 0)*397) ^ (int) StockId;
            }
        }

        public static bool operator ==(WeaponId left, WeaponId right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(WeaponId left, WeaponId right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class MedalAward : IEquatable<MedalAward>
    {
        public int Count { get; set; }
        public uint MedalId { get; set; }

        public bool Equals(MedalAward other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Count == other.Count
                && MedalId == other.MedalId;
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

            if (obj.GetType() != typeof (MedalAward))
            {
                return false;
            }

            return Equals((MedalAward) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Count*397) ^ (int) MedalId;
            }
        }

        public static bool operator ==(MedalAward left, MedalAward right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(MedalAward left, MedalAward right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Impulse : IEquatable<Impulse>
    {
        public int Count { get; set; }
        public uint Id { get; set; }

        public bool Equals(Impulse other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Count == other.Count 
                && Id == other.Id;
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

            if (obj.GetType() != typeof (Impulse))
            {
                return false;
            }

            return Equals((Impulse) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Count*397) ^ (int) Id;
            }
        }

        public static bool operator ==(Impulse left, Impulse right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Impulse left, Impulse right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class EnemySet : IEquatable<EnemySet>
    {
        public Enemy Enemy { get; set; }
        public int TotalKills { get; set; }

        public bool Equals(EnemySet other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(Enemy, other.Enemy) 
                && TotalKills == other.TotalKills;
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

            if (obj.GetType() != typeof (EnemySet))
            {
                return false;
            }

            return Equals((EnemySet) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Enemy?.GetHashCode() ?? 0)*397) ^ TotalKills;
            }
        }

        public static bool operator ==(EnemySet left, EnemySet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EnemySet left, EnemySet right)
        {
            return !Equals(left, right);
        }
    }

    [Serializable]
    public class Enemy : IEquatable<Enemy>
    {
        public List<uint> Attachments { get; set; }
        public uint BaseId { get; set; }

        public bool Equals(Enemy other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Attachments.OrderBy(a => a).SequenceEqual(other.Attachments.OrderBy(a => a))
                && BaseId == other.BaseId;
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

            if (obj.GetType() != typeof (Enemy))
            {
                return false;
            }

            return Equals((Enemy) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Attachments?.GetHashCode() ?? 0)*397) ^ (int) BaseId;
            }
        }

        public static bool operator ==(Enemy left, Enemy right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Enemy left, Enemy right)
        {
            return !Equals(left, right);
        }
    }
}