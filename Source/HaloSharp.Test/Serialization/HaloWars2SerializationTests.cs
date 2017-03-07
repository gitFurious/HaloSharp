using HaloSharp.Model.HaloWars2.Metadata;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;

namespace HaloSharp.Test.Serialization
{
    internal class HaloWars2SerializationTests
    {
        [Test]
        [TestCase(HaloWars2Config.CampaignLevelsJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CampaignLevel.View>>))]
        [TestCase(HaloWars2Config.CampaignLogsJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CampaignLog.View>>))]
        [TestCase(HaloWars2Config.CardKeywordsJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CardKeyword.View>>))]
        [TestCase(HaloWars2Config.CardsJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Card.View>>))]
        [TestCase(HaloWars2Config.CsrDesignationsJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.CompetitiveSkillRankDesignation.View>>))]
        [TestCase(HaloWars2Config.DifficultiesJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Difficulty.View>>))]
        [TestCase(HaloWars2Config.GameObjectCategoriesJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.GameObjectCategory.View>>))]
        [TestCase(HaloWars2Config.GameObjectsJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.GameObject.View>>))]
        [TestCase(HaloWars2Config.LeaderPowersJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.LeaderPower.View>>))]
        [TestCase(HaloWars2Config.LeadersJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Leader.View>>))]
        [TestCase(HaloWars2Config.MapsJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Map.View>>))]
        [TestCase(HaloWars2Config.PacksJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Pack.View>>))]
        [TestCase(HaloWars2Config.PlaylistsJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Playlist.View>>))]
        [TestCase(HaloWars2Config.SeasonsJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Season.View>>))]
        [TestCase(HaloWars2Config.SpartanRanksJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.SpartanRank.View>>))]
        [TestCase(HaloWars2Config.TechsJsonPath, typeof(PagedResponse<ContentItemTypeA<Model.HaloWars2.Metadata.Tech.View>>))]

        [TestCase(HaloWars2Config.MatchJsonPath, typeof(Model.HaloWars2.Stats.CarnageReport.Match))]
        [TestCase(HaloWars2Config.MatchEventsJsonPath, typeof(Model.HaloWars2.Stats.CarnageReport.MatchEventSummary))]

        [TestCase(HaloWars2Config.CampaignProgressJsonPath, typeof(Model.HaloWars2.Stats.Lifetime.CampaignSummary))]
        [TestCase(HaloWars2Config.ExperienceSummaryJsonPath, typeof(Model.HaloWars2.Stats.Lifetime.ExperienceSummaryResultSet))]
        [TestCase(HaloWars2Config.MatchHistoryJsonPath, typeof(Model.Common.MatchSet<Model.HaloWars2.Stats.PlayerMatch>))]
        [TestCase(HaloWars2Config.PlayerSummaryJsonPath, typeof(Model.HaloWars2.Stats.Lifetime.PlayerSummary))]
        [TestCase(HaloWars2Config.PlaylistRatingsJsonPath, typeof(Model.HaloWars2.Stats.Lifetime.PlaylistSummaryResultSet))]
        [TestCase(HaloWars2Config.SeasonSummaryJsonPath, typeof(Model.HaloWars2.Stats.Lifetime.SeasonSummary))]
        public void IsSerializable(string jsonPath, Type type)
        {
            var o = JsonConvert.DeserializeObject(File.ReadAllText(jsonPath), type);

            var methodInfo = typeof (SerializationUtility<>).MakeGenericType(type).GetMethod("AssertRoundTripSerializationIsPossible");

            methodInfo.Invoke(this, new[] { o });
        }
    }
}
