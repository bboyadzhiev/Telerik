using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
