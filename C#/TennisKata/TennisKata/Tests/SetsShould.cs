using NSubstitute;
using NUnit.Framework;

namespace TennisKata.Tests
{
    [TestFixture]
    public class SetsShould
    {
        private Player _player1;
        private Sets _sets;
        private Set _set1;

        [SetUp]
        public void SetUp()
        {
            _player1 = Substitute.For<Player>("Player 1");
            _set1 = Substitute.For<Set>(_player1);
            _sets = new Sets(_set1);
        }

        [Test]
        public void ReturnScoresForPlayer()
        {
            _set1.ScoreFor(_player1).Returns("0");

            var scoresForPlayer = _sets.ScoresFor(_player1);

            Assert.That(scoresForPlayer, Is.EqualTo(new[] { "0", "", "" }));
        }

        [Test]
        public void RegisterAWinningGameForPlayer()
        {
            _sets.WinFor(_player1);

            _set1.Received().WinGame(_player1);
        }
    }
}
