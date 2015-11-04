using HaloSharp.Converter;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HaloSharp.Model.Stats.Common
{
    public class BaseStat
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
    }

    public class WeaponStat
    {
        public double TotalDamageDealt { get; set; }
        public int TotalHeadshots { get; set; }
        public int TotalKills { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan TotalPossessionTime { get; set; }

        public int TotalShotsFired { get; set; }
        public int TotalShotsLanded { get; set; }
        public WeaponId WeaponId { get; set; }
    }

    public class WeaponId
    {
        public List<int> Attachments { get; set; }
        public uint StockId { get; set; }
    }

    public class MedalAward
    {
        public int Count { get; set; }
        public uint MedalId { get; set; }
    }

    public class Impulse
    {
        public int Count { get; set; }
        public uint Id { get; set; }
    }

    public class EnemySet
    {
        public Enemy Enemy { get; set; }
        public int TotalKills { get; set; }
    }

    public class Enemy
    {
        public List<uint> Attachments { get; set; }
        public uint BaseId { get; set; }
    }
}