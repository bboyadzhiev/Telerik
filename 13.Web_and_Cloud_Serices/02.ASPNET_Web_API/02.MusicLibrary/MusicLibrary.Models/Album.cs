using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        public string Producer { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }

        public Album()
        {
            this.Songs = new HashSet<Song>();
            this.Artists = new HashSet<Artist>();
        }
    }
}
