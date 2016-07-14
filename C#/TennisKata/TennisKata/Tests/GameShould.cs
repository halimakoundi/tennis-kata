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
            var score = _game.ScoreFor(_player1);

            Assert.That(score, Is.EqualTo("0"));
        }


        [Test]
        public void increment_score_for_player_who_wins_first_point()
        {
            _game.RecordPointFor(_player1);

            var score = _game.ScoreFor(_player1);

            Assert.That(score, Is.EqualTo("15"));
        }


        [Test]
        public void return_score_30_for_player_who_scored_first_two_points()
        {
            _game.RecordPointFor(_player1);
            _game.RecordPointFor(_player1);

            var score = _game.ScoreFor(_player1);

            Assert.That(score, Is.EqualTo("30"));
        }

        [Test]
        public void return_score_40_for_player_who_scored_first_three_points()
        {
            _game.RecordPointFor(_player1);
            _game.RecordPointFor(_player1);
            _game.RecordPointFor(_player1);

            var score = _game.ScoreFor(_player1);

            Assert.That(score, Is.EqualTo("40"));
        }

        [Test]
        public void return_score_15_for_player2_who_scored_second_point()
        {
            _game.RecordPointFor(_player1);
            _game.RecordPointFor(_player2);

            var score = _game.ScoreFor(_player2);

            Assert.That(score, Is.EqualTo("15"));
        }

        [Test]
        public void return_score_A_for_when_game_is_deuce_and_player1_win_point()
        {
            _game.RecordPointFor(_player1);
            _game.RecordPointFor(_player2);
            _game.RecordPointFor(_player1);
            _game.RecordPointFor(_player2);
            _game.RecordPointFor(_player1);
            _game.RecordPointFor(_player2);
            _game.RecordPointFor(_player1);

            var score = _game.ScoreFor(_player1);

            Assert.That(score, Is.EqualTo("A"));
        }

        [Test]
        public void return_score_40_for_when_game_is_advantage_player1_and_player2_wins_point()
        {
            _game.RecordPointFor(_player1); //15-0
            _game.RecordPointFor(_player2); //15-15
            _game.RecordPointFor(_player1); //30-15
            _game.RecordPointFor(_player2); //30-30
            _game.RecordPointFor(_player1); //40-30
            _game.RecordPointFor(_player2); //40-40
            _game.RecordPointFor(_player1); //A-40
            _game.RecordPointFor(_player2); //40-40

            var score = _game.ScoreFor(_player1);

            Assert.That(score, Is.EqualTo("40"));
        }

        [Test]
        public void trigger_event__for_when_game_is_advantage_player1_and_player1_wins_point()
        {
            bool raised = false;
            _game.GameIsWon += (e) =>
            {
                Assert.That(e, Is.EqualTo(_player1));
                raised = true;
            };
            _game.RecordPointFor(_player1); //15-0
            _game.RecordPointFor(_player2); //15-15
            _game.RecordPointFor(_player1); //30-15
            _game.RecordPointFor(_player2); //30-30
            _game.RecordPointFor(_player1); //40-30
            _game.RecordPointFor(_player2); //40-40
            _game.RecordPointFor(_player1); //A-40
            _game.RecordPointFor(_player1); //player 1 wins


            Assert.AreEqual(true, raised);
        }

        [Test]
        public void trigger_win_event__for_when_player1_has_40_and_player2_less_than_40_points()
        {
            bool raised = false;
            _game.GameIsWon += (e) =>
            {
                Assert.That(e, Is.EqualTo(_player1));
                raised = true;
            };
            _game.RecordPointFor(_player1); //15-0
            _game.RecordPointFor(_player2); //15-15
            _game.RecordPointFor(_player1); //30-15
            _game.RecordPointFor(_player2); //30-30
            _game.RecordPointFor(_player1); //40-30
            _game.RecordPointFor(_player1); //player1 wins


            Assert.AreEqual(true, raised);
        }

        [Test]
        public void trigger_win_event__for_when_player2_has_40_and_player1_less_than_40_points()
        {
            bool raised = false;
            _game.GameIsWon += (e) =>
            {
                Assert.That(e, Is.EqualTo(_player2));
                raised = true;
            };
            _game.RecordPointFor(_player2); //0-15
            _game.RecordPointFor(_player1); //15-15
            _game.RecordPointFor(_player2); //15-30
            _game.RecordPointFor(_player1); //30-30
            _game.RecordPointFor(_player2); //30-40
            _game.RecordPointFor(_player2); //player2 wins


            Assert.AreEqual(true, raised);
        }
    }
}
