using System;
using System.Collections.Generic;
using System.IO;
using HaloSharp.Model.Metadata;
using HaloSharp.Model.Metadata.Common;
using HaloSharp.Model.Stats;
using HaloSharp.Model.Stats.CarnageReport;
using HaloSharp.Model.Stats.Lifetime;
using HaloSharp.Test.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Schema
{
    class SchemaTests
    {
        [Test]
        [TestCase(Config.CampaignMissionsJsonPath, Config.CampaignMissionsJsonSchemaPath)]
        [TestCase(Config.CommendationJsonPath, Config.CommendationJsonSchemaPath)]
        [TestCase(Config.CompetitiveSkillRankDesignationsJsonPath, Config.CompetitiveSkillRankDesignationsJsonSchemaPath)]
        [TestCase(Config.EnemyJsonPath, Config.EnemyJsonSchemaPath)]
        [TestCase(Config.FlexibleStatJsonPath, Config.FlexibleStatJsonSchemaPath)]
        [TestCase(Config.GameBaseVariantJsonPath, Config.GameBaseVariantJsonSchemaPath)]
        [TestCase(Config.GameVariantJsonPath, Config.GameVariantJsonSchemaPath)]
        [TestCase(Config.ImpulseJsonPath, Config.ImpulseJsonSchemaPath)]
        [TestCase(Config.MapJsonPath, Config.MapJsonSchemaPath)]
        [TestCase(Config.MapVariantJsonPath, Config.MapVariantJsonSchemaPath)]
        [TestCase(Config.MedalJsonPath, Config.MedalJsonSchemaPath)]
        [TestCase(Config.PlaylistJsonPath, Config.PlaylistJsonSchemaPath)]
        [TestCase(Config.RequisitionJsonPath, Config.RequisitionJsonSchemaPath)]
        [TestCase(Config.RequisitionPackJsonPath, Config.RequisitionPackJsonSchemaPath)]
        [TestCase(Config.SeasonsJsonPath, Config.SeasonsJsonSchemaPath)]
        [TestCase(Config.SkullsJsonPath, Config.SkullsJsonSchemaPath)]
        [TestCase(Config.SpartanRanksJsonPath, Config.SpartanRanksJsonSchemaPath)]
        [TestCase(Config.TeamColorsJsonPath, Config.TeamColorsJsonSchemaPath)]
        [TestCase(Config.VehiclesJsonPath, Config.VehiclesJsonSchemaPath)]
        [TestCase(Config.WeaponsJsonPath, Config.WeaponsJsonSchemaPath)]

        [TestCase(Config.ArenaMatchJsonPath, Config.ArenaMatchJsonSchemaPath)]
        [TestCase(Config.CampaignMatchJsonPath, Config.CampaignMatchJsonSchemaPath)]
        [TestCase(Config.CustomMatchJsonPath, Config.CustomMatchJsonSchemaPath)]
        [TestCase(Config.WarzoneMatchJsonPath, Config.WarzoneMatchJsonSchemaPath)]
        [TestCase(Config.MatchEventsJsonPath, Config.MatchEventsJsonSchemaPath)]

        [TestCase(Config.ArenaServiceRecordJsonPath, Config.ArenaServiceRecordJsonSchemaPath)]
        [TestCase(Config.CampaignServiceRecordJsonPath, Config.CampaignServiceRecordJsonSchemaPath)]
        [TestCase(Config.CustomServiceRecordJsonPath, Config.CustomServiceRecordJsonSchemaPath)]
        [TestCase(Config.WarzoneServiceRecordJsonPath, Config.WarzoneServiceRecordJsonSchemaPath)]

        [TestCase(Config.MatchesJsonPath, Config.MatchesJsonSchemaPath)]
        [TestCase(Config.LeaderboardJsonPath, Config.LeaderboardJsonSchemaPath)]

        [TestCase(Config.UserGeneratedContentGameVariantsJsonPath, Config.UserGeneratedContentGameVariantsJsonSchemaPath)]
        [TestCase(Config.UserGeneratedContentMapVariantsJsonPath, Config.UserGeneratedContentMapVariantsJsonSchemaPath)]
        [TestCase(Config.UserGeneratedContentGameVariantJsonPath, Config.UserGeneratedContentGameVariantJsonSchemaPath)]
        [TestCase(Config.UserGeneratedContentMapVariantJsonPath, Config.UserGeneratedContentMapVariantJsonSchemaPath)]
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
        [TestCase(Config.CampaignMissionsJsonPath, Config.CampaignMissionsJsonSchemaPath, typeof(List<CampaignMission>))]
        [TestCase(Config.CommendationJsonPath, Config.CommendationJsonSchemaPath, typeof(List<Commendation>))]
        [TestCase(Config.CompetitiveSkillRankDesignationsJsonPath, Config.CompetitiveSkillRankDesignationsJsonSchemaPath, typeof(List<CompetitiveSkillRankDesignation>))]
        [TestCase(Config.EnemyJsonPath, Config.EnemyJsonSchemaPath, typeof(List<Enemy>))]
        [TestCase(Config.FlexibleStatJsonPath, Config.FlexibleStatJsonSchemaPath, typeof(List<FlexibleStat>))]
        [TestCase(Config.GameBaseVariantJsonPath, Config.GameBaseVariantJsonSchemaPath, typeof(List<GameBaseVariant>))]
        [TestCase(Config.GameVariantJsonPath, Config.GameVariantJsonSchemaPath, typeof(GameVariant))]
        [TestCase(Config.ImpulseJsonPath, Config.ImpulseJsonSchemaPath, typeof(List<Impulse>))]
        [TestCase(Config.MapJsonPath, Config.MapJsonSchemaPath, typeof(List<Map>))]
        [TestCase(Config.MapVariantJsonPath, Config.MapVariantJsonSchemaPath, typeof(MapVariant))]
        [TestCase(Config.MedalJsonPath, Config.MedalJsonSchemaPath, typeof(List<Medal>))]
        [TestCase(Config.PlaylistJsonPath, Config.PlaylistJsonSchemaPath, typeof(List<Playlist>))]
        [TestCase(Config.RequisitionJsonPath, Config.RequisitionJsonSchemaPath, typeof(Requisition))]
        [TestCase(Config.RequisitionPackJsonPath, Config.RequisitionPackJsonSchemaPath, typeof(RequisitionPack))]
        [TestCase(Config.SeasonsJsonPath, Config.SeasonsJsonSchemaPath, typeof(List<Season>))]
        [TestCase(Config.SkullsJsonPath, Config.SkullsJsonSchemaPath, typeof(List<Skull>))]
        [TestCase(Config.SpartanRanksJsonPath, Config.SpartanRanksJsonSchemaPath, typeof(List<SpartanRank>))]
        [TestCase(Config.TeamColorsJsonPath, Config.TeamColorsJsonSchemaPath, typeof(List<TeamColor>))]
        [TestCase(Config.VehiclesJsonPath, Config.VehiclesJsonSchemaPath, typeof(List<Vehicle>))]
        [TestCase(Config.WeaponsJsonPath, Config.WeaponsJsonSchemaPath, typeof(List<Weapon>))]

        [TestCase(Config.ArenaMatchJsonPath, Config.ArenaMatchJsonSchemaPath, typeof(ArenaMatch))]
        [TestCase(Config.CampaignMatchJsonPath, Config.CampaignMatchJsonSchemaPath, typeof(CampaignMatch))]
        [TestCase(Config.CustomMatchJsonPath, Config.CustomMatchJsonSchemaPath, typeof(CustomMatch))]
        [TestCase(Config.WarzoneMatchJsonPath, Config.WarzoneMatchJsonSchemaPath, typeof(WarzoneMatch))]
        [TestCase(Config.MatchEventsJsonPath, Config.MatchEventsModelJsonSchemaPath, typeof(MatchEvents))]

        [TestCase(Config.ArenaServiceRecordJsonPath, Config.ArenaServiceRecordJsonSchemaPath, typeof(ArenaServiceRecord))]
        [TestCase(Config.CampaignServiceRecordJsonPath, Config.CampaignServiceRecordJsonSchemaPath, typeof(CampaignServiceRecord))]
        [TestCase(Config.CustomServiceRecordJsonPath, Config.CustomServiceRecordJsonSchemaPath, typeof(CustomServiceRecord))]
        [TestCase(Config.WarzoneServiceRecordJsonPath, Config.WarzoneServiceRecordJsonSchemaPath, typeof(WarzoneServiceRecord))]

        [TestCase(Config.MatchesJsonPath, Config.MatchesJsonSchemaPath, typeof(MatchSet))]
        [TestCase(Config.LeaderboardJsonPath, Config.LeaderboardJsonSchemaPath, typeof(Leaderboard))]

        [TestCase(Config.UserGeneratedContentGameVariantsJsonPath, Config.UserGeneratedContentGameVariantsJsonSchemaPath, typeof(Model.UserGeneratedContent.GameVariantResult))]
        [TestCase(Config.UserGeneratedContentMapVariantsJsonPath, Config.UserGeneratedContentMapVariantsJsonSchemaPath, typeof(Model.UserGeneratedContent.MapVariantResult))]
        [TestCase(Config.UserGeneratedContentGameVariantJsonPath, Config.UserGeneratedContentGameVariantJsonSchemaPath, typeof(Model.UserGeneratedContent.GameVariant))]
        [TestCase(Config.UserGeneratedContentMapVariantJsonPath, Config.UserGeneratedContentMapVariantJsonSchemaPath, typeof(Model.UserGeneratedContent.MapVariant))]
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
