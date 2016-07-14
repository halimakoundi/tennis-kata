using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace TennisKata
{
    public class Game
    {
        private readonly Dictionary<Player, string> _scores =
                    new Dictionary<Player, string>();

        private readonly Dictionary<Player, int> _points =
                    new Dictionary<Player, int>();
        private readonly IDictionary<int, string> _pointSystem = new Dictionary<int, string>
        {
            {0, "0" },
            {1, "15" },
            {2, "30" },
            {3, "40" },
            {4, "A" }
        };
        public Game(Player player1, Player player2)
        {
            _points[player1] = 0;
            _points[player2] = 0;
        }

        public virtual string ScoreFor(Player player)
        {
            return _pointSystem[_points[player]];
        }

        public void WinsPoint(Player player)
        {
            if(IsGameAdvantage() )
            {
                var keyCollection = new List<Player>(_points.Keys);
                foreach (var pl in keyCollection)
                {
                    _points[pl] = 3;
                }
                return;
            }
            if (_points[player] < 4)
            {
                _points[player] += 1;
            }
        }

        private bool IsGameAdvantage()
        {
            return _points.Any(x => x.Value == 4) && _points.Any(x => x.Value == 3);
        }
    }
}