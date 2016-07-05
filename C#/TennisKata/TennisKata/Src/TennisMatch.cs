namespace TennisKata
{
    public class TennisMatch
    {
        private readonly ScoreBoard _scoreBoard;
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly Sets _sets;
        private readonly Game _game;

        public TennisMatch(ScoreBoard scoreBoard, Player player1, Player player2, Sets sets, Game game)
        {
            _scoreBoard = scoreBoard;
            _player1 = player1;
            _player2 = player2;
            _sets = sets;
            _game = game;
        }

        public void DisplayScore()
        {
            _scoreBoard.Display(_player1, _player2, _sets, _game);
        }
    }
}