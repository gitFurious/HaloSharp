using System;
using System.Collections.Generic;
using System.IO;
using HaloSharp.Model.Common;
using HaloSharp.Model.Halo5.Metadata;
using HaloSharp.Model.Halo5.Metadata.Common;
using HaloSharp.Model.Halo5.Stats;
using HaloSharp.Model.Halo5.Stats.CarnageReport;
using HaloSharp.Model.Halo5.Stats.Lifetime;
using HaloSharp.Model.Halo5.UserGeneratedContent;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Schema
{
    class Halo5SchemaTests
    {
        [Test]
        [TestCase(Halo5Config.CampaignMissionsJsonPath, Halo5Config.CampaignMissionsJsonSchemaPath)]
        [TestCase(Halo5Config.CommendationJsonPath, Halo5Config.CommendationJsonSchemaPath)]
        [TestCase(Halo5Config.CompetitiveSkillRankDesignationsJsonPath, Halo5Config.CompetitiveSkillRankDesignationsJsonSchemaPath)]
        [TestCase(Halo5Config.EnemyJsonPath, Halo5Config.EnemyJsonSchemaPath)]
        [TestCase(Halo5Config.FlexibleStatJsonPath, Halo5Config.FlexibleStatJsonSchemaPath)]
        [TestCase(Halo5Config.GameBaseVariantJsonPath, Halo5Config.GameBaseVariantJsonSchemaPath)]
        [TestCase(Halo5Config.GameVariantJsonPath, Halo5Config.GameVariantJsonSchemaPath)]
        [TestCase(Halo5Config.ImpulseJsonPath, Halo5Config.ImpulseJsonSchemaPath)]
        [TestCase(Halo5Config.MapJsonPath, Halo5Config.MapJsonSchemaPath)]
        [TestCase(Halo5Config.MapVariantJsonPath, Halo5Config.MapVariantJsonSchemaPath)]
        [TestCase(Halo5Config.MedalJsonPath, Halo5Config.MedalJsonSchemaPath)]
        [TestCase(Halo5Config.PlaylistJsonPath, Halo5Config.PlaylistJsonSchemaPath)]
        [TestCase(Halo5Config.RequisitionJsonPath, Halo5Config.RequisitionJsonSchemaPath)]
        [TestCase(Halo5Config.RequisitionPackJsonPath, Halo5Config.RequisitionPackJsonSchemaPath)]
        [TestCase(Halo5Config.SeasonsJsonPath, Halo5Config.SeasonsJsonSchemaPath)]
        [TestCase(Halo5Config.SkullsJsonPath, Halo5Config.SkullsJsonSchemaPath)]
        [TestCase(Halo5Config.SpartanRanksJsonPath, Halo5Config.SpartanRanksJsonSchemaPath)]
        [TestCase(Halo5Config.TeamColorsJsonPath, Halo5Config.TeamColorsJsonSchemaPath)]
        [TestCase(Halo5Config.VehiclesJsonPath, Halo5Config.VehiclesJsonSchemaPath)]
        [TestCase(Halo5Config.WeaponsJsonPath, Halo5Config.WeaponsJsonSchemaPath)]

        [TestCase(Halo5Config.ArenaMatchJsonPath, Halo5Config.ArenaMatchJsonSchemaPath)]
        [TestCase(Halo5Config.CampaignMatchJsonPath, Halo5Config.CampaignMatchJsonSchemaPath)]
        [TestCase(Halo5Config.CustomMatchJsonPath, Halo5Config.CustomMatchJsonSchemaPath)]
        [TestCase(Halo5Config.WarzoneMatchJsonPath, Halo5Config.WarzoneMatchJsonSchemaPath)]
        [TestCase(Halo5Config.MatchEventsJsonPath, Halo5Config.MatchEventsJsonSchemaPath)]

        [TestCase(Halo5Config.ArenaServiceRecordJsonPath, Halo5Config.ArenaServiceRecordJsonSchemaPath)]
        [TestCase(Halo5Config.CampaignServiceRecordJsonPath, Halo5Config.CampaignServiceRecordJsonSchemaPath)]
        [TestCase(Halo5Config.CustomServiceRecordJsonPath, Halo5Config.CustomServiceRecordJsonSchemaPath)]
        [TestCase(Halo5Config.WarzoneServiceRecordJsonPath, Halo5Config.WarzoneServiceRecordJsonSchemaPath)]

        [TestCase(Halo5Config.MatchesJsonPath, Halo5Config.MatchesJsonSchemaPath)]
        [TestCase(Halo5Config.LeaderboardJsonPath, Halo5Config.LeaderboardJsonSchemaPath)]

        [TestCase(Halo5Config.UserGeneratedContentGameVariantsJsonPath, Halo5Config.UserGeneratedContentGameVariantsJsonSchemaPath)]
        [TestCase(Halo5Config.UserGeneratedContentMapVariantsJsonPath, Halo5Config.UserGeneratedContentMapVariantsJsonSchemaPath)]
        [TestCase(Halo5Config.UserGeneratedContentGameVariantJsonPath, Halo5Config.UserGeneratedContentGameVariantJsonSchemaPath)]
        [TestCase(Halo5Config.UserGeneratedContentMapVariantJsonPath, Halo5Config.UserGeneratedContentMapVariantJsonSchemaPath)]
        public void SchemaIsValid(string jsonPath, string schemaPath)
        {
            var schema = JSchema.Parse(File.ReadAllText(schemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(schemaPath))
            });

            var jContainer = JsonConvert.DeserializeObject<JContainer>(File.ReadAllText(jsonPath));

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase(Halo5Config.CampaignMissionsJsonPath, Halo5Config.CampaignMissionsJsonSchemaPath, typeof(List<CampaignMission>))]
        [TestCase(Halo5Config.CommendationJsonPath, Halo5Config.CommendationJsonSchemaPath, typeof(List<Commendation>))]
        [TestCase(Halo5Config.CompetitiveSkillRankDesignationsJsonPath, Halo5Config.CompetitiveSkillRankDesignationsJsonSchemaPath, typeof(List<CompetitiveSkillRankDesignation>))]
        [TestCase(Halo5Config.EnemyJsonPath, Halo5Config.EnemyJsonSchemaPath, typeof(List<Enemy>))]
        [TestCase(Halo5Config.FlexibleStatJsonPath, Halo5Config.FlexibleStatJsonSchemaPath, typeof(List<FlexibleStat>))]
        [TestCase(Halo5Config.GameBaseVariantJsonPath, Halo5Config.GameBaseVariantJsonSchemaPath, typeof(List<GameBaseVariant>))]
        [TestCase(Halo5Config.GameVariantJsonPath, Halo5Config.GameVariantJsonSchemaPath, typeof(Model.Halo5.Metadata.GameVariant))]
        [TestCase(Halo5Config.ImpulseJsonPath, Halo5Config.ImpulseJsonSchemaPath, typeof(List<Impulse>))]
        [TestCase(Halo5Config.MapJsonPath, Halo5Config.MapJsonSchemaPath, typeof(List<Map>))]
        [TestCase(Halo5Config.MapVariantJsonPath, Halo5Config.MapVariantJsonSchemaPath, typeof(Model.Halo5.Metadata.MapVariant))]
        [TestCase(Halo5Config.MedalJsonPath, Halo5Config.MedalJsonSchemaPath, typeof(List<Medal>))]
        [TestCase(Halo5Config.PlaylistJsonPath, Halo5Config.PlaylistJsonSchemaPath, typeof(List<Playlist>))]
        [TestCase(Halo5Config.RequisitionJsonPath, Halo5Config.RequisitionJsonSchemaPath, typeof(Requisition))]
        [TestCase(Halo5Config.RequisitionPackJsonPath, Halo5Config.RequisitionPackJsonSchemaPath, typeof(RequisitionPack))]
        [TestCase(Halo5Config.SeasonsJsonPath, Halo5Config.SeasonsJsonSchemaPath, typeof(List<Season>))]
        [TestCase(Halo5Config.SkullsJsonPath, Halo5Config.SkullsJsonSchemaPath, typeof(List<Skull>))]
        [TestCase(Halo5Config.SpartanRanksJsonPath, Halo5Config.SpartanRanksJsonSchemaPath, typeof(List<SpartanRank>))]
        [TestCase(Halo5Config.TeamColorsJsonPath, Halo5Config.TeamColorsJsonSchemaPath, typeof(List<TeamColor>))]
        [TestCase(Halo5Config.VehiclesJsonPath, Halo5Config.VehiclesJsonSchemaPath, typeof(List<Vehicle>))]
        [TestCase(Halo5Config.WeaponsJsonPath, Halo5Config.WeaponsJsonSchemaPath, typeof(List<Weapon>))]

        [TestCase(Halo5Config.ArenaMatchJsonPath, Halo5Config.ArenaMatchJsonSchemaPath, typeof(ArenaMatch))]
        [TestCase(Halo5Config.CampaignMatchJsonPath, Halo5Config.CampaignMatchJsonSchemaPath, typeof(CampaignMatch))]
        [TestCase(Halo5Config.CustomMatchJsonPath, Halo5Config.CustomMatchJsonSchemaPath, typeof(CustomMatch))]
        [TestCase(Halo5Config.WarzoneMatchJsonPath, Halo5Config.WarzoneMatchJsonSchemaPath, typeof(WarzoneMatch))]
        [TestCase(Halo5Config.MatchEventsJsonPath, Halo5Config.MatchEventsModelJsonSchemaPath, typeof(MatchEvents))]

        [TestCase(Halo5Config.ArenaServiceRecordJsonPath, Halo5Config.ArenaServiceRecordJsonSchemaPath, typeof(ArenaServiceRecord))]
        [TestCase(Halo5Config.CampaignServiceRecordJsonPath, Halo5Config.CampaignServiceRecordJsonSchemaPath, typeof(CampaignServiceRecord))]
        [TestCase(Halo5Config.CustomServiceRecordJsonPath, Halo5Config.CustomServiceRecordJsonSchemaPath, typeof(CustomServiceRecord))]
        [TestCase(Halo5Config.WarzoneServiceRecordJsonPath, Halo5Config.WarzoneServiceRecordJsonSchemaPath, typeof(WarzoneServiceRecord))]

        [TestCase(Halo5Config.MatchesJsonPath, Halo5Config.MatchesJsonSchemaPath, typeof(MatchSet<PlayerMatch>))]
        [TestCase(Halo5Config.LeaderboardJsonPath, Halo5Config.LeaderboardJsonSchemaPath, typeof(Leaderboard))]

        [TestCase(Halo5Config.UserGeneratedContentGameVariantsJsonPath, Halo5Config.UserGeneratedContentGameVariantsJsonSchemaPath, typeof(GameVariantResult))]
        [TestCase(Halo5Config.UserGeneratedContentMapVariantsJsonPath, Halo5Config.UserGeneratedContentMapVariantsJsonSchemaPath, typeof(MapVariantResult))]
        [TestCase(Halo5Config.UserGeneratedContentGameVariantJsonPath, Halo5Config.UserGeneratedContentGameVariantJsonSchemaPath, typeof(Model.Halo5.UserGeneratedContent.GameVariant))]
        [TestCase(Halo5Config.UserGeneratedContentMapVariantJsonPath, Halo5Config.UserGeneratedContentMapVariantJsonSchemaPath, typeof(Model.Halo5.UserGeneratedContent.MapVariant))]
        public void ModelMatchesSchema(string jsonPath, string schemaPath, Type type)
        {
            var schema = JSchema.Parse(File.ReadAllText(schemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(schemaPath))
            });

            var requisitionPack = JsonConvert.DeserializeObject(File.ReadAllText(jsonPath), type);
            var json = JsonConvert.SerializeObject(requisitionPack);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }
    }
}
