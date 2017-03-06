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
using HaloSharp.Model.Common;
using HaloSharp.Test.Config;

namespace HaloSharp.Test.Serialization
{
    class Halo5SerializationTests
    {
        [Test]
        [TestCase(Halo5Config.CampaignMissionsJsonPath, typeof(List<CampaignMission>))]
        [TestCase(Halo5Config.CommendationJsonPath, typeof(List<Commendation>))]
        [TestCase(Halo5Config.CompetitiveSkillRankDesignationsJsonPath, typeof(List<CompetitiveSkillRankDesignation>))]
        [TestCase(Halo5Config.EnemyJsonPath, typeof(List<Enemy>))]
        [TestCase(Halo5Config.FlexibleStatJsonPath, typeof(List<FlexibleStat>))]
        [TestCase(Halo5Config.GameBaseVariantJsonPath, typeof(List<GameBaseVariant>))]
        [TestCase(Halo5Config.GameVariantJsonPath, typeof(Model.Halo5.Metadata.GameVariant))]
        [TestCase(Halo5Config.ImpulseJsonPath, typeof(List<Impulse>))]
        [TestCase(Halo5Config.MapJsonPath, typeof(List<Map>))]
        [TestCase(Halo5Config.MapVariantJsonPath, typeof(Model.Halo5.Metadata.MapVariant))]
        [TestCase(Halo5Config.MedalJsonPath, typeof(List<Medal>))]
        [TestCase(Halo5Config.PlaylistJsonPath, typeof(List<Playlist>))]
        [TestCase(Halo5Config.RequisitionJsonPath, typeof(Requisition))]
        [TestCase(Halo5Config.RequisitionPackJsonPath, typeof(RequisitionPack))]
        [TestCase(Halo5Config.SeasonsJsonPath, typeof(List<Season>))]
        [TestCase(Halo5Config.SkullsJsonPath, typeof(List<Skull>))]
        [TestCase(Halo5Config.SpartanRanksJsonPath, typeof(List<SpartanRank>))]
        [TestCase(Halo5Config.TeamColorsJsonPath, typeof(List<TeamColor>))]
        [TestCase(Halo5Config.VehiclesJsonPath, typeof(List<Vehicle>))]
        [TestCase(Halo5Config.WeaponsJsonPath, typeof(List<Weapon>))]

        [TestCase(Halo5Config.ArenaMatchJsonPath, typeof(ArenaMatch))]
        [TestCase(Halo5Config.CampaignMatchJsonPath, typeof(CampaignMatch))]
        [TestCase(Halo5Config.CustomMatchJsonPath, typeof(CustomMatch))]
        [TestCase(Halo5Config.WarzoneMatchJsonPath, typeof(WarzoneMatch))]
        [TestCase(Halo5Config.MatchEventsJsonPath, typeof(MatchEvents))]

        [TestCase(Halo5Config.ArenaServiceRecordJsonPath, typeof(ArenaServiceRecord))]
        [TestCase(Halo5Config.CampaignServiceRecordJsonPath, typeof(CampaignServiceRecord))]
        [TestCase(Halo5Config.CustomServiceRecordJsonPath, typeof(CustomServiceRecord))]
        [TestCase(Halo5Config.WarzoneServiceRecordJsonPath, typeof(WarzoneServiceRecord))]

        [TestCase(Halo5Config.MatchesJsonPath, typeof(MatchSet<PlayerMatch>))]
        [TestCase(Halo5Config.LeaderboardJsonPath, typeof(Leaderboard))]

        [TestCase(Halo5Config.UserGeneratedContentGameVariantsJsonPath, typeof(GameVariantResult))]
        [TestCase(Halo5Config.UserGeneratedContentMapVariantsJsonPath, typeof(MapVariantResult))]
        [TestCase(Halo5Config.UserGeneratedContentGameVariantJsonPath, typeof(Model.Halo5.UserGeneratedContent.GameVariant))]
        [TestCase(Halo5Config.UserGeneratedContentMapVariantJsonPath, typeof(Model.Halo5.UserGeneratedContent.MapVariant))]
        public void IsSerializable(string jsonPath, Type type)
        {
            var o = JsonConvert.DeserializeObject(File.ReadAllText(jsonPath), type);

            var methodInfo = typeof (SerializationUtility<>).MakeGenericType(type).GetMethod("AssertRoundTripSerializationIsPossible");

            methodInfo.Invoke(this, new[] { o });
        }
    }
}
