using NUnit.Framework;

namespace TennisKata.Tests
{
[TestFixture]
public class SetShould
    {

        [Test]
        public void return_score_for_player()
        {
            var player  = new Player("Player 1");
            var set = new Set(player);

            var score   = set.ScoreFor(player);

            Assert.That(score, Is.EqualTo("0"));
        }


        [Test]
        public void increment_score_for_player_when_player_wins_game()
        {
            var player  = new Player("Player 1");
            var set = new Set(player);
            set.WinGame(player);

            var score   = set.ScoreFor(player);

            Assert.That(score, Is.EqualTo("1"));
        }
    }
}
