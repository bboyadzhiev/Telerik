using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public Tag()
        {
            this.Articles = new HashSet<Article>();
        }
    }
}
