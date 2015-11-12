using HaloSharp.Extension;
using HaloSharp.Model.Metadata;
using HaloSharp.Query.Metadata;
using HaloSharp.Test.Utility;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HaloSharp.Test.Query.Metadata
{
    [TestFixture]
    public class GetPlaylistsTests
    {
        private const string BaseUri = "metadata/h5/metadata/playlists";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetPlaylists();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(BaseUri, uri);
        }

        [Test]
        public async Task GetPlaylists()
        {
            var query = new GetPlaylists()
                .SkipCache();

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (List<Playlist>), result);
        }

        [Test]
        public async Task GetPlaylists_IsSerializable()
        {
            var query = new GetPlaylists()
                .SkipCache();

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<List<Playlist>>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }
    }
}