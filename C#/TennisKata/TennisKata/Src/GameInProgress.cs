namespace TennisKata
{
    public class GameInProgress:Game
    {

        public void RecordPoint(Player player)
        {
            _points[player] += 1;
            if (IsGameWon(player))
            {
                OnGameHasBeenWon(player);
            }
        }

        public GameInProgress(Player player1, Player player2) : base(player1, player2)
        {
        }
    }
}