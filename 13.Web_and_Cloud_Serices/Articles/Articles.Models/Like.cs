using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class Like
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
