using System.Collections.Generic;

namespace TennisKata
{
    public class Sets
    {
        private readonly List<Set> _sets =
            new List<Set>();

        public Sets(Set set)
        {
            _sets.Add(set);
        }

        public virtual string[] ScoresFor(Player player)
        {
            return new[] { _sets[0].ScoreFor(player), "", "" };
        }

        public void WinFor(Player player)
        {
            _sets[0].WinGame(player);
        }
    }
}