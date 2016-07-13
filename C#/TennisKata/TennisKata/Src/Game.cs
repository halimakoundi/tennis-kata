using System.Collections.Generic;

namespace TennisKata
{
    public class Game
    {
        private readonly Dictionary<Player, string> _scores =
                    new Dictionary<Player, string>();

        public Game(Player player1, Player player2)
        {
            _scores[player1] = "0";
            _scores[player2] = "0";
        }

        public virtual string ScoreFor(Player player)
        {
            return _scores[player];
        }

        public void WinsPoint(Player player)
        {
            var point = 0;
            int.TryParse(_scores[player], out point);

            if (point < 30)
            {
                point += 15;
            }
            else
            {
                point += 10;
            }
            _scores[player] = point.ToString();
        }
    }
}