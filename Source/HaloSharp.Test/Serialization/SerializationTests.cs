using HaloSharp.Model.Halo5.Metadata;
using HaloSharp.Model.Halo5.Metadata.Common;
using HaloSharp.Model.Halo5.Stats;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using HaloSharp.Model.Halo5.Stats.Lifetime;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Test.Utility;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace HaloSharp.Test.Serialization
{
    class SerializationTests
    {
        [Test]
        [TestCase(Config.CampaignMissionsJsonPath, typeof(List<CampaignMission>))]
        [TestCase(Config.CommendationJsonPath, typeof(List<Commendation>))]
        [TestCase(Config.CompetitiveSkillRankDesignationsJsonPath, typeof(List<CompetitiveSkillRankDesignation>))]
        [TestCase(Config.EnemyJsonPath, typeof(List<Enemy>))]
        [TestCase(Config.FlexibleStatJsonPath, typeof(List<FlexibleStat>))]
        [TestCase(Config.GameBaseVariantJsonPath, typeof(List<GameBaseVariant>))]
        [TestCase(Config.GameVariantJsonPath, typeof(Model.Halo5.Metadata.GameVariant))]
        [TestCase(Config.ImpulseJsonPath, typeof(List<Impulse>))]
        [TestCase(Config.MapJsonPath, typeof(List<Map>))]
        [TestCase(Config.MapVariantJsonPath, typeof(Model.Halo5.Metadata.MapVariant))]
        [TestCase(Config.MedalJsonPath, typeof(List<Medal>))]
        [TestCase(Config.PlaylistJsonPath, typeof(List<Playlist>))]
        [TestCase(Config.RequisitionJsonPath, typeof(Requisition))]
        [TestCase(Config.RequisitionPackJsonPath, typeof(RequisitionPack))]
        [TestCase(Config.SeasonsJsonPath, typeof(List<Season>))]
        [TestCase(Config.SkullsJsonPath, typeof(List<Skull>))]
        [TestCase(Config.SpartanRanksJsonPath, typeof(List<SpartanRank>))]
        [TestCase(Config.TeamColorsJsonPath, typeof(List<TeamColor>))]
        [TestCase(Config.VehiclesJsonPath, typeof(List<Vehicle>))]
        [TestCase(Config.WeaponsJsonPath, typeof(List<Weapon>))]

        [TestCase(Config.ArenaMatchJsonPath, typeof(ArenaMatch))]
        [TestCase(Config.CampaignMatchJsonPath, typeof(CampaignMatch))]
        [TestCase(Config.CustomMatchJsonPath, typeof(CustomMatch))]
        [TestCase(Config.WarzoneMatchJsonPath, typeof(WarzoneMatch))]
        [TestCase(Config.MatchEventsJsonPath, typeof(MatchEvents))]

        [TestCase(Config.ArenaServiceRecordJsonPath, typeof(ArenaServiceRecord))]
        [TestCase(Config.CampaignServiceRecordJsonPath, typeof(CampaignServiceRecord))]
        [TestCase(Config.CustomServiceRecordJsonPath, typeof(CustomServiceRecord))]
        [TestCase(Config.WarzoneServiceRecordJsonPath, typeof(WarzoneServiceRecord))]

        [TestCase(Config.MatchesJsonPath, typeof(MatchSet))]
        [TestCase(Config.LeaderboardJsonPath, typeof(Leaderboard))]

        [TestCase(Config.UserGeneratedContentGameVariantsJsonPath, typeof(GameVariantResult))]
        [TestCase(Config.UserGeneratedContentMapVariantsJsonPath, typeof(MapVariantResult))]
        [TestCase(Config.UserGeneratedContentGameVariantJsonPath, typeof(Model.Halo5.UserGeneratedContent.GameVariant))]
        [TestCase(Config.UserGeneratedContentMapVariantJsonPath, typeof(Model.Halo5.UserGeneratedContent.MapVariant))]
        public void IsSerializable(string jsonPath, Type type)
        {
            var o = JsonConvert.DeserializeObject(File.ReadAllText(jsonPath), type);

            var methodInfo = typeof (SerializationUtility<>).MakeGenericType(type).GetMethod("AssertRoundTripSerializationIsPossible");

            methodInfo.Invoke(this, new[] { o });
        }
    }
}
