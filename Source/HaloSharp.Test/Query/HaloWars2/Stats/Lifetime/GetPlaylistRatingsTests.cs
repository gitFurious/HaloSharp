using System;
using System.IO;
using System.Threading.Tasks;
using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model.HaloWars2.Stats.Lifetime;
using HaloSharp.Query.HaloWars2.Stats.Lifetime;
using HaloSharp.Test.Config;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;

namespace HaloSharp.Test.Query.HaloWars2.Stats.Lifetime
{
    [TestFixture]
    public class GetPlaylistRatingsTests
    {
        private const string Json = HaloWars2Config.PlaylistRatingsJsonPath;
        private const string Schema = HaloWars2Config.PlaylistRatingsJsonSchemaPath;

        private IHaloSession _mockSession;
        private PlaylistSummaryResultSet _response;

        [SetUp]
        public void Setup()
        {
            _response = JsonConvert.DeserializeObject<PlaylistSummaryResultSet>(File.ReadAllText(Json));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<PlaylistSummaryResultSet>(It.IsAny<string>()))
                .ReturnsAsync(_response);

            _mockSession = mock.Object;
        }

        [Test]
        [TestCase("Furiousn00b", "c80ddcda-219b-42e6-82f4-94fae8516d96")]
        public void Uri_MatchesExpected(string player, string guid)
        {
            var query = new GetPlaylistRatings(player, new Guid(guid));

            Assert.AreEqual($"https://www.haloapi.com/stats/hw2/playlist/{guid}/rating?players={player}", query.Uri);
        }

        [Test]
        [TestCase("c80ddcda-219b-42e6-82f4-94fae8516d96", "Furiousn00b")]
        public async Task Query_DoesNotThrow(string guid, string gamertag)
        {
            var playlistId = new Guid(guid);

            var query = new GetPlaylistRatings(gamertag, playlistId)
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(PlaylistSummaryResultSet), result);
            Assert.AreEqual(_response, result);
        }

        [Test]
        [TestCase("c80ddcda-219b-42e6-82f4-94fae8516d96", "Furiousn00b")]
        public async Task GetPlaylistRatings_DoesNotThrow(string guid, string gamertag)
        {
            var playlistId = new Guid(guid);

            var query = new GetPlaylistRatings(gamertag, playlistId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(PlaylistSummaryResultSet), result);
        }

        [Test]
        [TestCase("c80ddcda-219b-42e6-82f4-94fae8516d96", "Furiousn00b")]
        public async Task GetPlaylistRatings_SchemaIsValid(string guid, string gamertag)
        {
            var jSchema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var playlistId = new Guid(guid);

            var query = new GetPlaylistRatings(gamertag, playlistId)
                .SkipCache();

            var jArray = await Global.Session.Get<JObject>(query.Uri);

            SchemaUtility.AssertSchemaIsValid(jSchema, jArray);
        }

        [Test]
        [TestCase("c80ddcda-219b-42e6-82f4-94fae8516d96", "Furiousn00b")]
        public async Task GetPlaylistRatings_ModelMatchesSchema(string guid, string gamertag)
        {
            var schema = JSchema.Parse(File.ReadAllText(Schema), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Schema))
            });

            var playlistId = new Guid(guid);

            var query = new GetPlaylistRatings(gamertag, playlistId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JObject>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        [TestCase("c80ddcda-219b-42e6-82f4-94fae8516d96", "Furiousn00b")]
        public async Task GetPlaylistRatings_IsSerializable(string guid, string gamertag)
        {
            var playlistId = new Guid(guid);

            var query = new GetPlaylistRatings(gamertag, playlistId)
                .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<PlaylistSummaryResultSet>.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("c80ddcda-219b-42e6-82f4-94fae8516d96", "")]
        [TestCase("c80ddcda-219b-42e6-82f4-94fae8516d96", "00000000000000017")]
        [TestCase("c80ddcda-219b-42e6-82f4-94fae8516d96", "!$%")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetPlaylistRatings_InvalidGamertag(string guid, string gamertag)
        {
            var playlistId = new Guid(guid);

            var query = new GetPlaylistRatings(gamertag, playlistId)
                .SkipCache();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }

        [Test]
        [TestCase("Furiousn00b")]
        [ExpectedException(typeof(ValidationException))]
        public async Task GetPlaylistRatings_InvalidPlaylist(string gamertag)
        {
            var playlistId = new Guid();

            var query = new GetPlaylistRatings(gamertag, playlistId)
                .SkipCache();

            await Global.Session.Query(query);
            Assert.Fail("An exception should have been thrown");
        }
    }
}