namespace TennisKata
{
    public class ScoreBoard
    {
        private IConsole _console;
        private Player _player1;
        private Game _currentGame;
        private Sets _sets;

        public ScoreBoard(IConsole _console, Player player1, Game currentGame, Sets sets)
        {
            this._console = _console;
            _player1 = player1;
            _currentGame = currentGame;
            _sets = sets;
        }

        public virtual void Display()
        {
            _console.PrintLine("Player   | 1 | 2 | 3 | Game");
            _console.PrintLine("---------------------------");
            _console.PrintLine($"{_player1.Name()} | {_sets.PlayerOneScore()} | {_currentGame.PlayerOneScore()}");
        }

    }
}