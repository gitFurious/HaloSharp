using HaloSharp.Model.Metadata;
using HaloSharp.Model.Metadata.Common;
using HaloSharp.Model.Stats;
using HaloSharp.Model.Stats.CarnageReport;
using HaloSharp.Test.Utility;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using HaloSharp.Model.Stats.Lifetime;

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
        [TestCase(Config.GameVariantJsonPath, typeof(GameVariant))]
        [TestCase(Config.ImpulseJsonPath, typeof(List<Impulse>))]
        [TestCase(Config.MapJsonPath, typeof(List<Map>))]
        [TestCase(Config.MapVariantJsonPath, typeof(MapVariant))]
        [TestCase(Config.MedalJsonPath, typeof(List<Medal>))]
        [TestCase(Config.PlaylistJsonPath, typeof(List<Playlist>))]
        [TestCase(Config.RequisitionJsonPath, typeof(Requisition))]
        [TestCase(Config.RequisitionPackJsonPath, typeof(RequisitionPack))]
        [TestCase(Config.SkullsJsonPath, typeof(List<Skull>))]
        [TestCase(Config.SpartanRanksJsonPath, typeof(List<SpartanRank>))]
        [TestCase(Config.TeamColorsJsonPath, typeof(List<TeamColor>))]
        [TestCase(Config.VehiclesJsonPath, typeof(List<Vehicle>))]
        [TestCase(Config.WeaponsJsonPath, typeof(List<Weapon>))]

        [TestCase(Config.ArenaMatchJsonPath, typeof(ArenaMatch))]
        [TestCase(Config.CampaignMatchJsonPath, typeof(CampaignMatch))]
        [TestCase(Config.CustomMatchJsonPath, typeof(CustomMatch))]
        [TestCase(Config.WarzoneMatchJsonPath, typeof(WarzoneMatch))]

        [TestCase(Config.ArenaServiceRecordJsonPath, typeof(ArenaServiceRecord))]
        [TestCase(Config.CampaignServiceRecordJsonPath, typeof(CampaignServiceRecord))]
        [TestCase(Config.CustomServiceRecordJsonPath, typeof(CustomServiceRecord))]
        [TestCase(Config.WarzoneServiceRecordJsonPath, typeof(WarzoneServiceRecord))]

        [TestCase(Config.MatchesJsonPath, typeof(MatchSet))]
        public void IsSerializable(string jsonPath, Type type)
        {
            var o = JsonConvert.DeserializeObject(File.ReadAllText(jsonPath), type);

            var methodInfo = typeof (SerializationUtility<>).MakeGenericType(type).GetMethod("AssertRoundTripSerializationIsPossible");

            methodInfo.Invoke(this, new[] { o });
        }
    }
}
