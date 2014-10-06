using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BullsAndCows.Models;

namespace BullsAndCows.WebApi.DataModels
{
    public class GameDataModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public  string Red { get; set; }

        public  string Blue { get; set; }

        public string GameState { get; set; }

        public DateTime DateCreated { get; set; }


        public static Expression<Func<Game, GameDataModel>> FromGame
        {
            get
            {
                return g => new GameDataModel
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