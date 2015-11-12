using HaloSharp.Exception;
using HaloSharp.Extension;
using HaloSharp.Model;
using HaloSharp.Model.Stats;
using HaloSharp.Query.Stats;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HaloSharp.Test.Utility;

namespace HaloSharp.Test.Query.Stats
{
    [TestFixture]
    public class GetMatchesTests
    {
        private const string BaseUri = "stats/h5/players/{0}/matches{1}";

        [Test]
        public void GetConstructedUri_NoParamaters_MatchesExpected()
        {
            var query = new GetMatches();

            var uri = query.GetConstructedUri();

            Assert.AreEqual(string.Format(BaseUri, null, null), uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public void GetConstructedUri_ForPlayer_MatchesExpected(string gamertag)
        {
            var query = new GetMatches()
                .ForPlayer(gamertag);

            var uri = query.GetConstructedUri();

            Assert.AreEqual(string.Format(BaseUri, gamertag, null), uri);
        }

        [Test]
        [TestCase(Enumeration.GameMode.Arena)]
        [TestCase(Enumeration.GameMode.Warzone)]
        public void GetConstructedUri_InGameMode_MatchesExpected(Enumeration.GameMode gameMode)
        {
            var query = new GetMatches()
                .InGameMode(gameMode);

            var uri = query.GetConstructedUri();

            Assert.AreEqual(string.Format(BaseUri, null, $"?modes={gameMode}" ), uri);
        }

        [Test]
        [TestCase(Enumeration.GameMode.Arena, Enumeration.GameMode.Warzone)]
        [TestCase(Enumeration.GameMode.Campaign, Enumeration.GameMode.Custom)]
        public void GetConstructedUri_InGameModes_MatchesExpected(Enumeration.GameMode gameMode1, Enumeration.GameMode gameMode2)
        {
            var query = new GetMatches()
                .InGameModes(new List<Enumeration.GameMode> {gameMode1, gameMode2});

            var uri = query.GetConstructedUri();

            Assert.AreEqual(string.Format(BaseUri, null, $"?modes={gameMode1},{gameMode2}"), uri);
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void GetConstructedUri_Skip_MatchesExpected(int skip)
        {
            var query = new GetMatches()
                .Skip(skip);

            var uri = query.GetConstructedUri();

            Assert.AreEqual(string.Format(BaseUri, null, $"?start={skip}"), uri);
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        public void GetConstructedUri_Take_MatchesExpected(int take)
        {
            var query = new GetMatches()
                .Take(take);

            var uri = query.GetConstructedUri();

            Assert.AreEqual(string.Format(BaseUri, null, $"?count={take}"), uri);
        }

        [Test]
        [TestCase("Greenskull", Enumeration.GameMode.Warzone, 5, 10)]
        [TestCase("Furiousn00b", Enumeration.GameMode.Arena, 15, 20)]
        public void GetConstructedUri_Complex_MatchesExpected(string gamertag, Enumeration.GameMode gameMode, int skip, int take)
        {
            var query = new GetMatches()
                .ForPlayer(gamertag)
                .InGameMode(gameMode)
                .Skip(skip)
                .Take(take);

            var uri = query.GetConstructedUri();

            Assert.AreEqual(string.Format(BaseUri, gamertag, $"?modes={gameMode}&start={skip}&count={take}"), uri);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetMatches(string gamertag)
        {
            var query = new GetMatches()
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof (MatchSet), result);
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetMatches_IsSerializable(string gamertag)
        {
            var query = new GetMatches()
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            var serializationUtility = new SerializationUtility<MatchSet>();
            serializationUtility.AssertRoundTripSerializationIsPossible(result);
        }

        [Test]
        [TestCase("Greenskull", 1)]
        [TestCase("Furiousn00b", 1)]
        [TestCase("Greenskull", 2)]
        [TestCase("Furiousn00b", 2)]
        [TestCase("Greenskull", 3)]
        [TestCase("Furiousn00b", 3)]
        [TestCase("Greenskull", 4)]
        [TestCase("Furiousn00b", 4)]
        public async Task GetMatches_InGameMode(string gamertag, int gameMode)
        {
            var query = new GetMatches()
                .InGameMode((Enumeration.GameMode)gameMode)
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(MatchSet), result);
            Assert.IsTrue(result.Results.All(r => r.Id.GameMode == (Enumeration.GameMode)gameMode));
        }

        [Test]
        [TestCase("Greenskull")]
        [TestCase("Furiousn00b")]
        public async Task GetMatches_InGameModes(string gamertag)
        {
            var gameModes = new List<Enumeration.GameMode>
            {
                Enumeration.GameMode.Arena,
                Enumeration.GameMode.Warzone
            };

            var query = new GetMatches()
                .InGameModes(gameModes)
                .ForPlayer(gamertag);

            var result = await Global.Session.Query(query);

            Assert.IsInstanceOf(typeof(MatchSet), result);
            Assert.IsTrue(result.Results.All(r => r.Id.GameMode == Enumeration.GameMode.Arena || r.Id.GameMode == Enumeration.GameMode.Warzone));
        }

        [Test]
        public async Task GetMatches_MissingPlayer()
        {
            var query = new GetMatches();

            try
            {
                await Global.Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int)Enumeration.StatusCode.NotFound, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }

        [Test]
        [TestCase("00000000000000017")]
        [TestCase("!$%")]
        public async Task GetMatches_InvalidGamertag(string gamertag)
        {
            var query = new GetMatches()
                .ForPlayer(gamertag);

            try
            {
                await Global.Session.Query(query);
                Assert.Fail("An exception should have been thrown");
            }
            catch (HaloApiException e)
            {
                Assert.AreEqual((int)Enumeration.StatusCode.BadRequest, e.HaloApiError.StatusCode);
            }
            catch (System.Exception e)
            {
                Assert.Fail("Unexpected exception of type {0} caught: {1}", e.GetType(), e.Message);
            }
        }
    }
}