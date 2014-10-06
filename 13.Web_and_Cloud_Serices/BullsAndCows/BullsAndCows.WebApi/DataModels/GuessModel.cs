using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BullsAndCows.Models;

namespace BullsAndCows.WebApi.DataModels
{
    public class GuessModel
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public string PlayerId { get; set; }

        public int Number { get; set; }
        public int CowsCount { get; set; }
        public int BullsCount { get; set; }
        public DateTime DateMade { get; set; }

        public static Expression<Func<Guess, GuessModel>> FromGuess
        {
            get
            {
                return g => new GuessModel
                {
                    Id = g.Id,
                    GameId = g.GameId,
                    PlayerId = g.PlayerId,
                    Number = g.Number,
                    CowsCount = g.CowsCount,
                    BullsCount = g.BullsCount,
                    DateMade = g.DateMade
                };
            }
        }
    }
}