using System.Collections.Generic;

namespace TennisKata
{
    public class Set
    {
        private readonly Dictionary<Player, int> _scores =
            new Dictionary<Player, int>();

        public Set(Player player)
        {
            _scores.Add(player, 0);
        }

        public virtual string ScoreFor(Player player) => $"{_scores[player]}";

        public virtual void WinGame(Player player)
        {
            _scores[player] += 1;
        }
    }
}