using TennisKata.Tests;

namespace TennisKata
{
    public class TennisMatch
    {
        private readonly ScoreBoard _scoreBoard;

        public TennisMatch(ScoreBoard scoreBoard)
        {
            _scoreBoard = scoreBoard;
        }

        public void DisplayScore()
        {
            _scoreBoard.Display();
        }
    }
}