using System;
using System.Runtime.Serialization;

namespace HaloSharp.Model
{
    [Serializable]
    public class Enumeration
    {
        public enum Agent
        {
            None = 0,
            Player = 1,
            AI = 2
        }

        public enum CampaignMissionType
        {
            BlueTeam,
            OsirisTeam
        }

        public enum CommendationType
        {
            Progressive,
            Meta,
            Daily
        }

        public enum CompetitiveSkillRankingDesignation
        {
            Bronze = 1,
            Silver = 2,
            Gold = 3,
            Platinum = 4,
            Diamond = 5,
            Onyx = 6,
            Champion = 7
        }

        public enum CreditsEarnedResultType
        {
            CreditsDisabledInPlaylist = 0,
            PlayerDidNotFinish = 1,
            CreditsEarned = 2
        }

        public enum CropType
        {
            Full,
            Portrait
        }

        public enum Difficulty
        {
            Easy = 0,
            Normal = 1,
            Heroic = 2,
            Legendary = 3
        }

        public enum Disposition
        {
            Friendly = 0,
            Hostile = 1,
            Neutral = 2
        }

        public enum EventType
        {
            Death
        }

        public enum Faction
        {
            // ReSharper disable once InconsistentNaming
            UNSC,
            Covenant,
            Promethean
        }

        public enum FlexibleStatType
        {
            Count,
            Duration
        }

        public enum GameMode
        {
            Error = 0,
            Arena = 1,
            Campaign = 2,
            Custom = 3,
            Warzone = 4
        }

        public enum MedalType
        {
            Breakout,
            CaptureTheFlag,
            KillingSpree,
            [EnumMember(Value = "Multi-kill")] MultiKill,
            Strongholds,
            Style,
            Vehicles,
            Warzone,
            WeaponProficiency,
            Goal,
            Ball
        }

        public enum OwnerType
        {
            Unknown = 0,
            UserGeneratedA = 1, //TODO: Investigate UserGeneratedA vs. UserGeneratedB
            UserGeneratedB = 2,
            Official = 3
        }

        public enum QueryResult
        {
            Success = 0,
            NotFound = 1,
            ServiceFailure = 2,
            ServiceUnavailable = 3
        }

        public enum RequisitionPackType
        {
            None,
            New,
            Hot,
            LeavingSoon,
            [EnumMember(Value = "Maximum Value")] MaximumValue,
            [EnumMember(Value = "Limited Time")] Limitedtime,
            Featured,
            BestSeller,
            Popular
        }

        public enum RequisitionRarityType
        {
            Common,
            Uncommon,
            Rare,
            UltraRare,
            Legendary
        }

        public enum RequisitionUseType
        {
            Consumable,
            Durable,
            Boost,
            CreditGranting
        }

        public enum ResourceType
        {
            GameVariant = 2,
            MapVariant = 3
        }

        public enum ResultType
        {
            DidNotFinish = 0,
            Lost = 1,
            Tied = 2,
            Won = 3
        }

        public enum RewardSourceType
        {
            None = 0,
            MetaCommendation = 1,
            ProgressCommendation = 2,
            SpartanRank = 3
        }

        public enum StatusCode
        {
            BadRequest = 400,
            NotFound = 404,
            InternalServiceError = 500,
            AccessDenied = 401,
            RateLimitExceeded = 429
        }

        public enum WeaponType
        {
            Unknown,
            Grenade,
            Turret,
            Vehicle,
            Standard,
            Power
        }
    }
}