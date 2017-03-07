using HaloSharp.Model.HaloWars2.Metadata;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using System;
using System.IO;

namespace HaloSharp.Test.Schema
{
    class HaloWars2SchemaTests
    {
        [Test]
        [TestCase(HaloWars2Config.CampaignLevelsJsonPath, HaloWars2Config.CampaignLevelsJsonSchemaPath)]
        [TestCase(HaloWars2Config.CampaignLogsJsonPath, HaloWars2Config.CampaignLogsJsonSchemaPath)]
        [TestCase(HaloWars2Config.CardKeywordsJsonPath, HaloWars2Config.CardKeywordsJsonSchemaPath)]
        [TestCase(HaloWars2Config.CardsJsonPath, HaloWars2Config.CardsJsonSchemaPath)]
        [TestCase(HaloWars2Config.CsrDesignationsJsonPath, HaloWars2Config.CsrDesignationsJsonSchemaPath)]
        [TestCase(HaloWars2Config.DifficultiesJsonPath, HaloWars2Config.DifficultiesJsonSchemaPath)]
        [TestCase(HaloWars2Config.GameObjectCategoriesJsonPath, HaloWars2Config.GameObjectCategoriesJsonSchemaPath)]
        [TestCase(HaloWars2Config.GameObjectsJsonPath, HaloWars2Config.GameObjectsJsonSchemaPath)]
        [TestCase(HaloWars2Config.LeaderPowersJsonPath, HaloWars2Config.LeaderPowersJsonSchemaPath)]
        [TestCase(HaloWars2Config.LeadersJsonPath, HaloWars2Config.LeadersJsonSchemaPath)]
        [TestCase(HaloWars2Config.MapsJsonPath, HaloWars2Config.MapsJsonSchemaPath)]
        [TestCase(HaloWars2Config.PacksJsonPath, HaloWars2Config.PacksJsonSchemaPath)]
        [TestCase(HaloWars2Config.PlaylistsJsonPath, HaloWars2Config.PlaylistsJsonSchemaPath)]
        [TestCase(HaloWars2Config.SeasonsJsonPath, HaloWars2Config.SeasonsJsonSchemaPath)]
        [TestCase(HaloWars2Config.SpartanRanksJsonPath, HaloWars2Config.SpartanRanksJsonSchemaPath)]
        [TestCase(HaloWars2Config.TechsJsonPath, HaloWars2Config.TechsJsonSchemaPath)]

        [TestCase(HaloWars2Config.MatchJsonPath, HaloWars2Config.MatchJsonSchemaPath)]
        [TestCase(HaloWars2Config.MatchEventsJsonPath, HaloWars2Config.MatchEventsJsonSchemaPath)]

        [TestCase(HaloWars2Config.CampaignProgressJsonPath, HaloWars2Config.CampaignProgressJsonSchemaPath)]
        [TestCase(HaloWars2Config.ExperienceSummaryJsonPath, HaloWars2Config.ExperienceSummaryJsonSchemaPath)]
        [TestCase(HaloWars2Config.MatchHistoryJsonPath, HaloWars2Config.MatchHistoryJsonSchemaPath)]
        [TestCase(HaloWars2Config.PlayerSummaryJsonPath, HaloWars2Config.PlayerSummaryJsonSchemaPath)]
        [TestCase(HaloWars2Config.PlaylistRatingsJsonPath, HaloWars2Config.PlaylistRatingsJsonSchemaPath)]
        [TestCase(HaloWars2Config.SeasonSummaryJsonPath, HaloWars2Config.SeasonSummaryJsonSchemaPath)]
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
        [TestCase(HaloWars2Config.CampaignLevelsJsonPath, HaloWars2Config.CampaignLevelsJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CampaignLevel.View>>))]
        [TestCase(HaloWars2Config.CampaignLogsJsonPath, HaloWars2Config.CampaignLogsJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CampaignLog.View>>))]
        [TestCase(HaloWars2Config.CardKeywordsJsonPath, HaloWars2Config.CardKeywordsJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CardKeyword.View>>))]
        [TestCase(HaloWars2Config.CardsJsonPath, HaloWars2Config.CardsJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Card.View>>))]
        [TestCase(HaloWars2Config.CsrDesignationsJsonPath, HaloWars2Config.CsrDesignationsJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CompetitiveSkillRankDesignation.View>>))]
        [TestCase(HaloWars2Config.DifficultiesJsonPath, HaloWars2Config.DifficultiesJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Difficulty.View>>))]
        [TestCase(HaloWars2Config.GameObjectCategoriesJsonPath, HaloWars2Config.GameObjectCategoriesJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.GameObjectCategory.View>>))]
        [TestCase(HaloWars2Config.GameObjectsJsonPath, HaloWars2Config.GameObjectsJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.GameObject.View>>))]
        [TestCase(HaloWars2Config.LeaderPowersJsonPath, HaloWars2Config.LeaderPowersJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.LeaderPower.View>>))]
        [TestCase(HaloWars2Config.LeadersJsonPath, HaloWars2Config.LeadersJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Leader.View>>))]
        [TestCase(HaloWars2Config.MapsJsonPath, HaloWars2Config.MapsJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Map.View>>))]
        [TestCase(HaloWars2Config.PacksJsonPath, HaloWars2Config.PacksJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Pack.View>>))]
        [TestCase(HaloWars2Config.PlaylistsJsonPath, HaloWars2Config.PlaylistsJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Playlist.View>>))]
        [TestCase(HaloWars2Config.SeasonsJsonPath, HaloWars2Config.SeasonsJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Season.View>>))]
        [TestCase(HaloWars2Config.SpartanRanksJsonPath, HaloWars2Config.SpartanRanksJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.SpartanRank.View>>))]
        [TestCase(HaloWars2Config.TechsJsonPath, HaloWars2Config.TechsJsonSchemaPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Tech.View>>))]

        [TestCase(HaloWars2Config.MatchJsonPath, HaloWars2Config.MatchJsonSchemaPath, typeof(Model.HaloWars2.Stats.CarnageReport.Match))]
        [TestCase(HaloWars2Config.MatchEventsJsonPath, HaloWars2Config.MatchEventsJsonSchemaPath, typeof(Model.HaloWars2.Stats.CarnageReport.MatchEventSummary))]

        [TestCase(HaloWars2Config.CampaignProgressJsonPath, HaloWars2Config.CampaignProgressJsonSchemaPath, typeof(Model.HaloWars2.Stats.Lifetime.CampaignSummary))]
        [TestCase(HaloWars2Config.ExperienceSummaryJsonPath, HaloWars2Config.ExperienceSummaryJsonSchemaPath, typeof(Model.HaloWars2.Stats.Lifetime.ExperienceSummaryResultSet))]
        [TestCase(HaloWars2Config.MatchHistoryJsonPath, HaloWars2Config.MatchHistoryJsonSchemaPath, typeof(Model.Common.MatchSet<Model.HaloWars2.Stats.PlayerMatch>))]
        [TestCase(HaloWars2Config.PlayerSummaryJsonPath, HaloWars2Config.PlayerSummaryJsonSchemaPath, typeof(Model.HaloWars2.Stats.Lifetime.PlayerSummary))]
        [TestCase(HaloWars2Config.PlaylistRatingsJsonPath, HaloWars2Config.PlaylistRatingsJsonSchemaPath, typeof(Model.HaloWars2.Stats.Lifetime.PlaylistSummaryResultSet))]
        [TestCase(HaloWars2Config.SeasonSummaryJsonPath, HaloWars2Config.SeasonSummaryJsonSchemaPath, typeof(Model.HaloWars2.Stats.Lifetime.SeasonSummary))]
        public void ModelMatchesSchema(string jsonPath, string schemaPath, Type type)
        {
            var schema = JSchema.Parse(File.ReadAllText(schemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(schemaPath))
            });

            var value = JsonConvert.DeserializeObject(File.ReadAllText(jsonPath), type);
            var json = JsonConvert.SerializeObject(value);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }
    }
}
