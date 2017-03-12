using System;
using HaloSharp.Extension;
using System.Threading.Tasks;

namespace HaloSharp.Console
{
    internal class Application : IApplication
    {
        private static readonly object MessageLock = new object();

        private readonly IHaloSession _haloSession;

        public Application(IHaloSession haloSession)
        {
            _haloSession = haloSession;
        }

        public void Run()
        {
            const string player = "Furiousn00b";

            var printHalo5MatchHistoryForPlayerTask = PrintHalo5MatchHistoryForPlayer(player);
            var printHalo5ForgeMatchHistoryForPlayerTask = PrintHalo5ForgeMatchHistoryForPlayer(player);
            var printHaloWars2MatchHistoryForPlayerTask = PrintHaloWars2MatchHistoryForPlayer(player);

            Task.WaitAll(printHalo5MatchHistoryForPlayerTask, printHalo5ForgeMatchHistoryForPlayerTask, printHaloWars2MatchHistoryForPlayerTask);

            System.Console.ReadLine();
        }

        private async Task PrintHalo5MatchHistoryForPlayer(string player)
        {
            var query = new Query.Halo5.Stats.GetMatchHistory(player);

            var matchSet = await _haloSession.Query(query);

            foreach (var match in matchSet.Results)
            {
                Print($"       Halo 5: {match.Id.MatchId}", ConsoleColor.Cyan);
            }
        }

        private async Task PrintHalo5ForgeMatchHistoryForPlayer(string player)
        {
            var query = new Query.Halo5Forge.Stats.GetMatchHistory(player);

            var matchSet = await _haloSession.Query(query);

            foreach (var match in matchSet.Results)
            {
                Print($"Halo 5: Forge: {match.Id.MatchId}", ConsoleColor.Magenta);
            }
        }

        private async Task PrintHaloWars2MatchHistoryForPlayer(string player)
        {
            var query = new Query.HaloWars2.Stats.GetMatchHistory(player);

            var matchSet = await _haloSession.Query(query);

            foreach (var match in matchSet.Results)
            {
                Print($"  Halo Wars 2: {match.MatchId}", ConsoleColor.Yellow);
            }
        }

        private static void Print(string message, ConsoleColor colour)
        {
            lock (MessageLock)
            {
                System.Console.ForegroundColor = colour;
                System.Console.WriteLine(message);
                System.Console.ResetColor();
            }
        }
    }
}
