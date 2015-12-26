using HaloSharp.Extension;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using HaloSharp.Test.Utility;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetPlaylistsTests
    {
        private IHaloSession _mockSession;
        private List<Playlist> _playlists;

        [SetUp]
        public void Setup()
        {
            _playlists = JsonConvert.DeserializeObject<List<Playlist>>(File.ReadAllText(Config.PlaylistJsonPath));

            var mock = new Mock<IHaloSession>();
            mock.Setup(m => m.Get<List<Playlist>>(It.IsAny<string>()))
                .ReturnsAsync(_playlists);

            _mockSession = mock.Object;
        }

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetPlaylists();

            var uri = query.GetConstructedUri();

            Assert.AreEqual("metadata/h5/metadata/playlists", uri);
        }

        [Test]
        public async Task Query_DoesNotThrow()
        {
            var query = new GetPlaylists()
                .SkipCache();

            var result = await _mockSession.Query(query);

            Assert.IsInstanceOf(typeof(List<Playlist>), result);
            Assert.AreEqual(_playlists, result);
        }

        [Test]
        public async Task GetPlaylists_DoesNotThrow()
        {
            var query = new GetPlaylists()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(List<Playlist>), result);
        }

        [Test]
        public async Task GetPlaylists_SchemaIsValid()
        {
            var playlistsSchema = JSchema.Parse(File.ReadAllText(Config.PlaylistJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.PlaylistJsonSchemaPath))
            });

            var query = new GetPlaylists()
               .SkipCache();

            var jArray = await Global.Session.Get<JArray>(query.GetConstructedUri());

            SchemaUtility.AssertSchemaIsValid(playlistsSchema, jArray);
        }

        [Test]
        public async Task GetPlaylists_ModelMatchesSchema()
        {
            var schema = JSchema.Parse(File.ReadAllText(Config.PlaylistJsonSchemaPath), new JSchemaReaderSettings
            {
                Resolver = new JSchemaUrlResolver(),
                BaseUri = new Uri(Path.GetFullPath(Config.PlaylistJsonSchemaPath))
            });

            var query = new GetPlaylists()
               .SkipCache();

            var result = await Global.Session.Query(query);

            var json = JsonConvert.SerializeObject(result);
            var jContainer = JsonConvert.DeserializeObject<JContainer>(json);

            SchemaUtility.AssertSchemaIsValid(schema, jContainer);
        }

        [Test]
        public async Task GetPlaylists_IsSerializable()
        {
            var query = new GetPlaylists()
               .SkipCache();

            var result = await Global.Session.Query(query);

            SerializationUtility<List<Playlist>>.AssertRoundTripSerializationIsPossible(result);
        }
    }
}