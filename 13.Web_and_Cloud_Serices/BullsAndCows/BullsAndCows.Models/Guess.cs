using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Models
{
    public class Guess
    {
        [Key]
        public int Id { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public string PlayerId { get; set; }
        public virtual ApplicationUser Player { get; set; }

        public int Number { get; set; }
        public int CowsCount { get; set; }
        public int BullsCount { get; set; }
        public DateTime DateMade { get; set; }
    }
}
