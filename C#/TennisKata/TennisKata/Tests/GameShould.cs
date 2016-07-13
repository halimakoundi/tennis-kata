using NUnit.Framework;

namespace TennisKata.Tests
{
    [TestFixture]
    class GameShould
    {
        private Player _player1;
        private Player _player2;
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _player1 = new Player("Player 1");
            _player2 = new Player("Player 2");
            _game = new Game(_player1, _player2);
        }

        [Test]
        public void return_score_for_player()
        {
            var score   = _game.ScoreFor(_player1);

            Assert.That(score, Is.EqualTo("0"));
        }


        [Test]
        public void increment_score_for_player_who_wins_first_point()
        {
            _game.WinsPoint(_player1);

            var score = _game.ScoreFor(_player1);

            Assert.That(score, Is.EqualTo("15"));
        }


        [Test]
        public void return_score_30_for_player_who_scored_first_two_points()
        {
            _game.WinsPoint(_player1);
            _game.WinsPoint(_player1);

            var score = _game.ScoreFor(_player1);

            Assert.That(score, Is.EqualTo("30"));
        }

        [Test]
        public void return_score_40_for_player_who_scored_first_three_points()
        {
            _game.WinsPoint(_player1);
            _game.WinsPoint(_player1);
            _game.WinsPoint(_player1);

            var score = _game.ScoreFor(_player1);

            Assert.That(score, Is.EqualTo("40"));
        }

        [Test]
        public void return_score_15_for_player2_who_scored_second_point()
        {
            _game.WinsPoint(_player1);
            _game.WinsPoint(_player2);

            var score = _game.ScoreFor(_player2);

            Assert.That(score, Is.EqualTo("15"));
        }
    }
}
