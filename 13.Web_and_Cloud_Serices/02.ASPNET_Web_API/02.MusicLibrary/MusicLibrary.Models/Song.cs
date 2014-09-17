using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Models
{
    public enum Genre
    {
        Pop, Rock, Jazz, Techno, House, HipHop
    }
    public class Song
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Title { get; set; }
        [Required]
        public DateTime Year { get; set; }
        [Required]
        public Genre Genre { get; set; }
        
        public Artist Artist { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public Song()
        {
           this. Albums = new HashSet<Album>();
        }
    }
}
