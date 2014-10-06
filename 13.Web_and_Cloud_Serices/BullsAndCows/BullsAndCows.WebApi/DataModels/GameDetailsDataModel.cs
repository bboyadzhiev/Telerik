using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BullsAndCows.Models;

namespace BullsAndCows.WebApi.DataModels
{
    public class GameDetailsDataModel:GameDataModel
    {
        public int YourNumber { get; set; }
        public ICollection<GuessModel> YourGuesses   { get; set; }

        public ICollection<GuessModel> OpponentGuesses { get; set; }
        public Colors YourColor { get; set; }

        public GameDetailsDataModel()
        {
            this.YourGuesses = new HashSet<GuessModel>();
            this.OpponentGuesses = new HashSet<GuessModel>();
        }

        public static Expression<Func<Game, GameDetailsDataModel>> FromGame
        {
            get
            {
                return g => new GameDetailsDataModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Red = g.RedPlayer.UserName,
                    Blue = g.BluePlayer.UserName != null ? g.BluePlayer.UserName : "No blue player yet",
                    GameState = g.GameState.ToString(),
                    DateCreated = g.DateCreated
                };
            }
        }


    }
}