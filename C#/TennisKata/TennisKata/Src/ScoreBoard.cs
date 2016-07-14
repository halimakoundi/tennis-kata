using System;
using System.Linq;

namespace TennisKata
{
    public class ScoreBoard
    {
        private readonly IConsole _console;

        public ScoreBoard(IConsole console)
        {
            _console = console;
        }

        public virtual void Display(Player player1, Player player2, Sets sets, Game game)
        {
            DisplayHeader();
            DisplayPlayerScore(player1, sets, game);
            DisplayPlayerScore(player2, sets, game);
        }

        private void DisplayHeader()
        {
            _console.PrintLine("Player   | 1 | 2 | 3 | Game");
            _console.PrintLine("---------------------------");
        }

        private void DisplayPlayerScore(Player player, Sets sets, Game game)
        {
            _console.PrintLine($"{player.Name()} | {Format(sets.ScoresFor(player))} | {game.ScoreFor(player)}");
        }

        public static string Format(string[] scoresFor)
        {
            var scores = scoresFor.Select(score => string.IsNullOrEmpty(score) ? " " : score);
            return string.Join(" | ",scores);
        }
    }
}