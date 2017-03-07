using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.Halo5.Stats;
using HaloSharp.Query.Halo5.Stats;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.Halo5.Stats
{
    [TestFixture]
    public class GetLeaderboardTests
    {
        private IHaloSession _mockSession;
        private Leaderboard _leaderboard;

        [SetUp]
        public void Setup()
        {
            _leaderboard = JsonConvert.DeserializeObject<Leaderboard>(File.ReadAllText(Halo5Config.LeaderboardJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<Leaderboard>(It.IsAny<string>()))
                .ReturnsAsync(_leaderboard);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("2fcc20a0-53ff-4ffb-8f72-eebb2e419273", "2323b76a-db98-4e03-aa37-e171cfbdd1a4", 5)]
        [TestCase("b46c2095-4ca6-4f4b-a565-4702d7cfe586", "c98949ae-60a8-43dc-85d7-0feb0b92e719", 10)]
        public void GetConstructedUri_Complex_MatchesExpected(string seasonId, string playlistId, int take)
        {
            var query = new GetLeaderboard(new Guid(seasonId), new Guid(playlistId))
                .Take(take);

            var uri = query.GetConstructedUri();

            Assert.AreEqual($"stats/h5/player-leaderboards/csr/{seasonId}/{playlistId}?count={take}", uri);
        }

        [Test]
        [TestCase("2fcc20a0-53ff-4ffb-8f72-eebb2e419273", "2323b76a-db98-4e03-aa37-e171cfbdd1a4")]
        [TestCase("b46c2095-4ca6-4f4b-a565-4702d7cfe586", "c98949ae-60a8-43dc-85d7-0feb0b92e719")]
        public async Task Query_DoesNotThrow(string seasonId, string playlistId)
        {
            var query = new GetLeaderboard(new Guid(seasonId), new Guid(playlistId))
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(Leaderboard), result);
            Assert.AreEqual(_leaderboard, result);
        }

        [Test]
        [TestCase("2fcc20a0-53ff-4ffb-8f72-eebb2e419273", "2323b76a-db98-4e03-aa37-e171cfbdd1a4")]
        [TestCase("b46c2095-4ca6-4f4b-a565-4702d7cfe586", "c98949ae-60a8-43dc-85d7-0feb0b92e719")]
        public async Task GetLeaderboard_DoesNotThrow(string seasonId, string playlistId)
        {
            var query = new GetLeaderboard(new Guid(seasonId), new Guid(playlistId))
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(Leaderboard), result);
        }

        [Test]
        [TestCase("2fcc20a0-53ff-4ffb-8f72-eebb2e419273", "2323b76a-db98-4e03-aa37-e171cfbdd1a4")]
        [TestCase("b46c2095-4ca6-4f4b-a565-4702d7cfe586", "c98949ae-60a8-43dc-85d7-0feb0b92e719")]
        public async Task GetLeaderboard_SchemaIsValid(string seasonId, string playlistId)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.LeaderboardJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.LeaderboardJsonSchemaPath))
            });

            var query = new GetLeaderboard(new Guid(seasonId), new Guid(playlistId))
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(schema, jArray);
        }

        [Test]
        [TestCase("2fcc20a0-53ff-4ffb-8f72-eebb2e419273", "2323b76a-db98-4e03-aa37-e171cfbdd1a4")]
        [TestCase("b46c2095-4ca6-4f4b-a565-4702d7cfe586", "c98949ae-60a8-43dc-85d7-0feb0b92e719")]
        public async Task GetLeaderboard_ModelMatchesSchema(string seasonId, string playlistId)
        {
            var schema = JSchema.Parse(File.ReadAllText(Halo5Config.LeaderboardJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Halo5Config.LeaderboardJsonSchemaPath))
            });

            var query = new GetLeaderboard(new Guid(seasonId), new Guid(playlistId))
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("2fcc20a0-53ff-4ffb-8f72-eebb2e419273", "2323b76a-db98-4e03-aa37-e171cfbdd1a4")]
        [TestCase("b46c2095-4ca6-4f4b-a565-4702d7cfe586", "c98949ae-60a8-43dc-85d7-0feb0b92e719")]
        public async Task GetLeaderboard_IsSerializable(string seasonId, string playlistId)
        {
            var query = new GetLeaderboard(new Guid(seasonId), new Guid(playlistId))
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<Leaderboard>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase(300)]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetLeaderboard_MaximumTake(int take)
        {
            var query = new GetLeaderboard(Guid.Empty, Guid.Empty)
                .Take(take)
                .SkipCache();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}