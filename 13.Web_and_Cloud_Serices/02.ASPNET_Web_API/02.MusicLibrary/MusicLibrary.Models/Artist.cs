using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Song> Songs { get; set; }

        public Artist()
        {
            this.Albums = new HashSet<Album>();
            this.Songs = new HashSet<Song>();
        }
    }
}
