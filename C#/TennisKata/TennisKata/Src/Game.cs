using System;
using System.Collections.Generic;
using System.Linq;

namespace TennisKata
{
    public class Game
    {
        private readonly IDictionary<int, string> _pointSystem = new Dictionary<int, string>
        {
            {0, "0" },
            {1, "15" },
            {2, "30" },
            {3, "40" },
            {4, "A" }
        };

        private readonly List<Player> _players = new List<Player>();

        public Game(Player player1, Player player2)
        {
            _players.Add(player1);
            _players.Add(player2);
        }

        public virtual string ScoreFor(Player player)
        {
            return _pointSystem[_players.Find((gamePlayer => gamePlayer == player)).Points];
        }

        public void RecordPointFor(Player player)
        {
            TriggerGameIsWonIfAdvantageConfirmed(player);
            if (AdvantageIsLostBy(player))
            {
                SetGameBackToDeuce();
                return;
            }
            AddPointFor(player);
            IsGameWon(player);
        }

        private void TriggerGameIsWonIfAdvantageConfirmed(Player player)
        {
            if (IsGameAdvantage() && AdvantageFor(player))
            {
                OnGameHasBeenWon(player);
            }
        }

        private void IsGameWon(Player player)
        {
            if (player.Points > 3 && PointDifferenceReached())
            {
                OnGameHasBeenWon(player);
            }
        }

        private void AddPointFor(Player player)
        {
            if (NormalGameFor(player))
            {
                player.Points += 1;
            }
        }

        private bool AdvantageIsLostBy(Player player)
        {
            return IsGameAdvantage() && !AdvantageFor(player);
        }

        private bool PointDifferenceReached()
        {
            return Math.Abs(_players[0].Points - _players[1].Points) >1;
        }

        private void SetGameBackToDeuce()
        {
            foreach (var player in _players)
            {
                player.Points = 3;
            }
        }

        private bool NormalGameFor(Player player)
        {
            return player.Points < 4;
        }

        private bool AdvantageFor(Player player)
        {
            return player.Points == 4;
        }

        private bool IsGameAdvantage()
        {
            return _players.Any(x => x.Points == 4) && _players.Any(x => x.Points == 3);
        }

        public delegate void GameHasBeenWon(Player e);

        public event GameHasBeenWon GameIsWon;

        protected virtual void OnGameHasBeenWon(Player winner)
        {
            GameIsWon?.Invoke(winner);
        }
    }
}