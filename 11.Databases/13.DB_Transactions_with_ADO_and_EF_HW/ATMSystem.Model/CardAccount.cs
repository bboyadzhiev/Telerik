using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSystem.Model
{
    public partial class CardAccount
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique=true)]
        [MaxLength(10)]
        [MinLength(10)]
        public string CardNumber { get; set; }

        [MaxLength(4)]
        [MinLength(4)]
        public string CardPIN { get; set; }


        public decimal CardCash { get; set; }
    }
}
