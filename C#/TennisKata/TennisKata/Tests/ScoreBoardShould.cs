using NSubstitute;
using NUnit.Framework;

namespace TennisKata.Tests
{
    [TestFixture]
    public class ScoreBoardShould
    {
        private IConsole _console;
        private ScoreBoard _scoreBoard;
        private Player _player;
        private Sets _set;
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<IConsole>();
            _player = Substitute.For<Player>("Player 1");
            _set = Substitute.For<Sets>();
            _game = Substitute.For<Game>();
            _scoreBoard = new ScoreBoard(_console, _player, _game, _set);
        }

        [Test]
        public void DisplayScoreHeader()
        {
            _scoreBoard.Display();
            Received.InOrder(() =>
            {
                _console.Received().PrintLine("Player   | 1 | 2 | 3 | Game");
                _console.Received().PrintLine("---------------------------");
            });
        }

        [Test]
        public void GetPlayerSetAndGameInfo()
        {
            
            _scoreBoard.Display();

            _player.Received().Name();
            _set.Received().PlayerOneScore();
            _game.Received().PlayerOneScore();
        }
    }
}
