using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Models
{
    public enum GameScores
    {
        won, lost, undefined
    }

    public enum GameStates
    {
        WaitingForOpponent, RedInTurn, BlueInTurn
    }


    public class Game
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string RedPlayerId { get; set; }
        public virtual ApplicationUser RedPlayer { get; set; }
        public GameScores RedPlayerScore { get; set; }

        public string BluePlayerId { get; set; }
        public virtual ApplicationUser BluePlayer { get; set; }

        public string PlayerInTurnId { get; set; }
        public virtual ApplicationUser PlayerInTurn { get; set; }
        public GameScores BluePlayerScore { get; set; }

        public GameStates GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public Game()
        {
            this.GameState = GameStates.WaitingForOpponent;
            this.BluePlayerScore = GameScores.undefined;
            this.RedPlayerScore = GameScores.undefined;
        }
    }
}
