using System;
using System.Runtime.Serialization;

namespace HaloSharp.Model
{
    [Serializable]
    public class Enumeration
    {
        public class Common
        {
            public enum QueryResult
            {
                Success = 0,
                NotFound = 1,
                ServiceFailure = 2,
                ServiceUnavailable = 3
            }
        }

        public class HaloWars2
        {
            public enum DamageType
            {
                Basic = 0,
                LeaderPower = 1,
                LeaderPowerNonFlying = 2,
                AntiInfantry = 3,
                Fire = 4,
                AntiBuildingFire = 5,
                SmallArms = 6,
                AASmallArms = 7,
                SmallArmsScouts = 8,
                MediumArms = 9,
                ChainGun = 10,
                ArmorPiercing = 11,
                AntiVehicle = 12,
                FuelRod = 13,
                BansheeFuelRod = 14,
                AntiAir = 15,
                Explosive = 16,
                TankExplosive = 17,
                Artillery = 18,
                Missile = 19,
                Grenade = 20,
                Demolition = 21,
                Beam = 22,
                WarthogRam = 23,
                GaussCannon = 24,
                BruteShot = 25,
                Melee = 26,
                SuicideGrunt = 27,
                SuicideGruntAV = 28,
                SuperSentinel = 29,
                Hero = 30,
                CampaignHero = 31,
                ScarabBeam = 32,
                Unknown = 255
            }

            public enum GameMode
            {
                Unknown = 0,
                CampaignSolo = 1,
                CampaignCooperative = 2,
                Deathmatch = 3,
                Domination = 4,
                Strongholds = 5,
                Blitz = 6,
                Firefight = 7,
                NormalTutorial = 8,
                BlitzTutorial = 9
            }

            public enum MatchEndReason
            {
                Unknown = 0,
                Completed = 1,
                StartedNewMission = 2,
                EveryoneDisconnected = 3,
                InviteAccepted = 4
            }

            public enum MatchEventType
            {
                BuildingConstructionQueued,
                BuildingConstructionCompleted,
                BuildingRecycled,
                BuildingUpgraded,
                CardCycled,
                CardPlayed,
                Death,
                FirefightWaveCompleted,
                FirefightWaveSpawned,
                FirefightWaveStarted,
                LeaderPowerCast,
                LeaderPowerUnlocked,
                ManaOrbCollected,
                MatchEnd,
                MatchStart,
                PlayerEliminated,
                PlayerJoinedMatch,
                PlayerLeftMatch,
                PointCaptured,
                PointCreated,
                PointStatusChange,
                ResourceHeartbeat,
                ResourceTransferred,
                TechResearched,
                UnitControlTransferred,
                UnitPromoted,
                UnitTrained
            }

            public enum MatchOutcome
            {
                Unknown = 0,
                Win = 1,
                Loss = 2,
                Tie = 3
            }

            public enum MatchType
            {
                Unknown = 0,
                Campaign = 1,
                Custom = 2,
                Matchmaking = 3
            }

            public enum PlayerType
            {
                Unknown = 0,
                Human = 1,
                Computer = 2,
                NPC = 3
            }

            public enum PlaylistClassification
            {
                GeneralStats = 0,
                BlitzStats = 1,
                FirefightStats = 2
            }

            public enum PointStatus
            {
                Neutral = 0,
                Contested = 1,
                Captured = 2
            }

            public enum VictoryCondition
            {
                EndedPrematurely = 0,
                ObjectiveCompleted = 1,
                OpponentsEliminated = 2,
                Unknown = 255
            }
        }

        public class Halo5
        {
            public enum AccessControl
            {
                Listed = 0,
                Unlisted = 1,
                Unknown = 2
            }

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
                Death,
                Impulse,
                Medal,
                PlayerSpawn,
                RoundStart,
                RoundEnd,
                WeaponDrop,
                WeaponPickup,
                WeaponPickupPad
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

            public enum GiftableAcquisitionMethod
            {
                Unknown = 1
            }

            public enum MedalType
            {
                Breakout,
                CaptureTheFlag,
                KillingSpree,
                [EnumMember(Value = "Multi-kill")]
                MultiKill,
                Strongholds,
                Style,
                Vehicles,
                Warzone,
                WeaponProficiency,
                Goal,
                Ball,
                Infection
            }

            public enum OwnerType
            {
                Unknown = 0,
                UserGeneratedA = 1, //TODO: Investigate UserGeneratedA vs. UserGeneratedB
                UserGeneratedB = 2,
                Official = 3
            }

            public enum RequisitionPackType
            {
                None,
                New,
                Hot,
                [EnumMember(Value = "Leaving Soon")]
                LeavingSoon,
                [EnumMember(Value = "Maximum Value")]
                MaximumValue,
                [EnumMember(Value = "Limited Time")]
                Limitedtime,
                Featured,
                [EnumMember(Value = "Best Seller")]
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
                MapVariant = 3,
                BaseGameVariant = 8,
                BaseMapVariant = 9
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

            public enum UserGeneratedContentSort
            {
                Name,
                Description,
                Accesibility,
                Created,
                Modified,
                BookmarkCount
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
}