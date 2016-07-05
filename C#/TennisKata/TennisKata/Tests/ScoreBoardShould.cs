using NSubstitute;
using NUnit.Framework;

namespace TennisKata.Tests
{
    [TestFixture]
    public class ScoreBoardShould
    {
        private IConsole _console;
        private ScoreBoard _scoreBoard;
        private Player _player1;
        private Sets _sets;
        private Game _game;
        private Player _player2;
        private Set _set1;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _player1 = Substitute.For<Player>("Player 1");
            _player2 = Substitute.For<Player>("Player 2");
            _set1 = Substitute.For<Set>(_player1);
            _sets = Substitute.For<Sets>(_set1);
            _game = Substitute.For<Game>();
            _scoreBoard = new ScoreBoard(_console);
        }

        [Test]
        public void DisplayScoreHeader()
        {
            _scoreBoard.Display(_player1, _player2, _sets, _game);

            Received.InOrder(() =>
            {
                _console.Received().PrintLine("Player   | 1 | 2 | 3 | Game");
                _console.Received().PrintLine("---------------------------");
            });
        }

        [Test]
        public void DisplayStartingGameScoreBoard()
        {
            BuildOpeningMatch();

            _scoreBoard.Display(_player1, _player2, _sets, _game);

            Received.InOrder(() =>
            {
                _console.PrintLine("Player   | 1 | 2 | 3 | Game");
                _console.PrintLine("---------------------------");
                _console.PrintLine("Player 1 | 0 |   |   | 0");
                _console.PrintLine("Player 2 | 0 |   |   | 0");

            });
        }

        private void BuildOpeningMatch()
        {
            _player1.Name().Returns("Player 1");
            _player2.Name().Returns("Player 2");
            _sets.ScoresFor(_player1).Returns(new[] {"0", "", ""});
            _sets.ScoresFor(_player2).Returns(new[] {"0", "", ""});
            _game.ScoreFor(_player1).Returns("0");
            _game.ScoreFor(_player2).Returns("0");
        }
    }
}
