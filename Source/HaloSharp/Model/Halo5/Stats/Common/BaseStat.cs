using System;
using System.Collections.Generic;
using System.Linq;
using HaloSharp.Converter;
using Newtonsoft.Json;

namespace HaloSharp.Model.Halo5.Stats.Common
{
    [Serializable]
    public class BaseStat : IEquatable<BaseStat>
    {
        /// <summary>
        /// List of enemy vehicles destroyed. Vehicles are available via the Metadata API. Note: this stat measures enemy vehicles, not any vehicle destruction.
        /// </summary>
        [JsonProperty(PropertyName = "DestroyedEnemyVehicles")]
        public List<EnemySet> DestroyedEnemyVehicles { get; set; }

        /// <summary>
        /// List of enemies killed, per enemy type. Enemies are available via the Metadata API.
        /// /// </summary>
        [JsonProperty(PropertyName = "EnemyKills")]
        public List<EnemySet> EnemyKills { get; set; }

        /// <summary>
        /// TODO:
        /// </summary>
        [JsonProperty(PropertyName = "FastestMatchWin")]
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan FastestMatchWin { get; set; }

        /// <summary>
        /// The set of Impulses (invisible Medals) earned by the player.
        /// </summary>
        [JsonProperty(PropertyName = "Impulses")]
        public List<Impulse> Impulses { get; set; }

        /// <summary>
        /// The set of Medals earned by the player.
        /// </summary>
        [JsonProperty(PropertyName = "MedalAwards")]
        public List<MedalAward> MedalAwards { get; set; }

        /// <summary>
        /// Total number of assassinations by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalAssassinations")]
        public int TotalAssassinations { get; set; }

        /// <summary>
        /// Total number of assists by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalAssists")]
        public int TotalAssists { get; set; }

        /// <summary>
        /// Total number of deaths by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalDeaths")]
        public int TotalDeaths { get; set; }

        /// <summary>
        /// Not used.
        /// </summary>
        [JsonProperty(PropertyName = "TotalGamesCompleted")]
        public int TotalGamesCompleted { get; set; }

        /// <summary>
        /// Not used.
        /// </summary>
        [JsonProperty(PropertyName = "TotalGamesLost")]
        public int TotalGamesLost { get; set; }

        /// <summary>
        /// Not used.
        /// </summary>
        [JsonProperty(PropertyName = "TotalGamesTied")]
        public int TotalGamesTied { get; set; }

        /// <summary>
        /// Not used.
        /// </summary>
        [JsonProperty(PropertyName = "TotalGamesWon")]
        public int TotalGamesWon { get; set; }

        /// <summary>
        /// Total grenade damage dealt by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalGrenadeDamage")]
        public double TotalGrenadeDamage { get; set; }

        /// <summary>
        /// Total number of grenade kills by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalGrenadeKills")]
        public int TotalGrenadeKills { get; set; }

        /// <summary>
        /// Total ground pound damage dealt by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalGroundPoundDamage")]
        public double TotalGroundPoundDamage { get; set; }

        /// <summary>
        /// Total number of ground pound kills by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalGroundPoundKills")]
        public int TotalGroundPoundKills { get; set; }

        /// <summary>
        /// Total number of headshots done by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalHeadshots")]
        public int TotalHeadshots { get; set; }

        /// <summary>
        /// Total number of kills done by the player. This includes melee kills, shoulder bash kills and Spartan charge kills, all power weapons, AI kills and vehicle destructions. 
        /// </summary>
        [JsonProperty(PropertyName = "TotalKills")]
        public int TotalKills { get; set; }

        /// <summary>
        /// Total melee damage dealt by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalMeleeDamage")]
        public double TotalMeleeDamage { get; set; }

        /// <summary>
        /// Total number of melee kills by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalMeleeKills")]
        public int TotalMeleeKills { get; set; }

        /// <summary>
        /// Total power weapon damage dealt by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalPowerWeaponDamage")]
        public double TotalPowerWeaponDamage { get; set; }

        /// <summary>
        /// Total number of power weapon grabs by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalPowerWeaponGrabs")]
        public int TotalPowerWeaponGrabs { get; set; }

        /// <summary>
        /// Total number of power weapon kills by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalPowerWeaponKills")]
        public int TotalPowerWeaponKills { get; set; }

        /// <summary>
        /// Total power weapon possession by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalPowerWeaponPossessionTime")]
        [JsonConverter(typeof (TimeSpanConverter))]
        public TimeSpan TotalPowerWeaponPossessionTime { get; set; }

        /// <summary>
        /// Total number of shots fired by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalShotsFired")]
        public int TotalShotsFired { get; set; }

        /// <summary>
        /// Total number of shots landed by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalShotsLanded")]
        public int TotalShotsLanded { get; set; }

        /// <summary>
        /// Total shoulder bash damage dealt by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalShoulderBashDamage")]
        public double TotalShoulderBashDamage { get; set; }

        /// <summary>
        /// Total number of shoulder bash kills by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalShoulderBashKills")]
        public int TotalShoulderBashKills { get; set; }

        /// <summary>
        /// Total number of Spartan kills by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalSpartanKills")]
        public int TotalSpartanKills { get; set; }

        /// <summary>
        /// Total timed played in this match by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalTimePlayed")]
        [JsonConverter(typeof (TimeSpanConverter))]
        public TimeSpan TotalTimePlayed { get; set; }

        /// <summary>
        /// Total weapon damage dealt by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalWeaponDamage")]
        public double TotalWeaponDamage { get; set; }

        /// <summary>
        /// The set of weapons (weapons and vehicles included) used by the player.
        /// </summary>
        [JsonProperty(PropertyName = "WeaponStats")]
        public List<WeaponStat> WeaponStats { get; set; }

        /// <summary>
        /// The weapon the player used to get the most kills this match.
        /// </summary>
        [JsonProperty(PropertyName = "WeaponWithMostKills")]
        public WeaponStat WeaponWithMostKills { get; set; }

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
                && FastestMatchWin.Equals(other.FastestMatchWin)
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
                hashCode = (hashCode*397) ^ FastestMatchWin.GetHashCode();
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
        /// <summary>
        /// The total damage dealt for this weapon.
        /// </summary>
        [JsonProperty(PropertyName = "TotalDamageDealt")]
        public double TotalDamageDealt { get; set; }

        /// <summary>
        /// The number of headshots for this weapon.
        /// </summary>
        [JsonProperty(PropertyName = "TotalHeadshots")]
        public int TotalHeadshots { get; set; }

        /// <summary>
        /// The number of kills for this weapon.
        /// </summary>
        [JsonProperty(PropertyName = "TotalKills")]
        public int TotalKills { get; set; }

        /// <summary>
        /// The total possession time for this weapon.
        /// </summary>
        [JsonProperty(PropertyName = "TotalPossessionTime")]
        [JsonConverter(typeof (TimeSpanConverter))]
        public TimeSpan TotalPossessionTime { get; set; }

        /// <summary>
        /// The number of shots fired for this weapon.
        /// </summary>
        [JsonProperty(PropertyName = "TotalShotsFired")]
        public int TotalShotsFired { get; set; }

        /// <summary>
        /// The number of shots landed for this weapon.
        /// </summary>
        [JsonProperty(PropertyName = "TotalShotsLanded")]
        public int TotalShotsLanded { get; set; }

        /// <summary>
        /// //TODO
        /// </summary>
        [JsonProperty(PropertyName = "WeaponId")]
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
        /// <summary>
        /// Any attachments the weapon had.
        /// </summary>
        [JsonProperty(PropertyName = "Attachments")]
        public List<uint> Attachments { get; set; }

        /// <summary>
        /// The ID of the weapon. Weapons are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "StockId")]
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
        /// <summary>
        /// The number of times the Medal was earned.
        /// </summary>
        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }

        /// <summary>
        /// The ID of the Medal. Medals are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "MedalId")]
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
        /// <summary>
        /// The number of times the Impuse was earned.
        /// </summary>
        [JsonProperty(PropertyName = "Count")]
        public int Count { get; set; }

        /// <summary>
        /// The ID of the Impulse. Impulses are available via the Metadata API.
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
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
        /// <summary>
        /// The enemy this entry references.
        /// </summary>
        [JsonProperty(PropertyName = "Enemy")]
        public Enemy Enemy { get; set; }

        /// <summary>
        /// Total number of kills on the enemy by the player.
        /// </summary>
        [JsonProperty(PropertyName = "TotalKills")]
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
        /// <summary>
        /// The attachments (variants) for the enemy.
        /// </summary>
        [JsonProperty(PropertyName = "Attachments")]
        public List<uint> Attachments { get; set; }

        /// <summary>
        /// The Base ID for the enemy.
        /// </summary>
        [JsonProperty(PropertyName = "BaseId")]
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