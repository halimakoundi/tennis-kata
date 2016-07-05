using NSubstitute;
using NUnit.Framework;

namespace TennisKata.Tests
{
    [TestFixture]
    public class TennisFeature
    {
        private readonly IConsole _console = Substitute.For<IConsole>();
        private ScoreBoard _scoreBoard;
        private Player _player1;
        private Player _player2;
        private Sets _sets;
        private Game _game;
        private TennisMatch _match;

        [SetUp]
        public void SetUp()
        {
            _player1 = new Player("Player 1");
            _player2 = new Player("Player 2");
            _sets = new Sets(new Set(_player1));
            _game = new Game();
            _scoreBoard = new ScoreBoard(_console);
            _match = new TennisMatch(
                _scoreBoard, _player1, _player2, _sets, _game);
        }

        [Test]
        public void StartOfMatchShouldShowInitialBoard()
        {
            _match.DisplayScore();

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
