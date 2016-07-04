using NSubstitute;
using NUnit.Framework;

namespace TennisKata.Tests
{
    [TestFixture]
    public class TennisFeature
    {
        private readonly IConsole _console = Substitute.For<IConsole>();
        private ScoreBoard _scoreBoard;

        [Test]
        public void BeginningMatchShouldShowNoScore()
        {
            var player = new Player("Player 1");
            var sets = new Sets();
            var game = new Game();
            _scoreBoard = new ScoreBoard(_console, player, game, sets);
            var match = new TennisMatch(_scoreBoard);

            match.DisplayScore();

            Received.InOrder(() =>
            {
                _console.PrintLine("Player   | 1 | 2 | 3 | Game");
                _console.PrintLine("---------------------------");
                _console.PrintLine("Player 1 | 0 |   |   | 0");
                _console.PrintLine("Player 2 | 0 |   |   | 0");
            });
        }
    }
}
