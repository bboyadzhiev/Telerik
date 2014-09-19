using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MusicLibrary.Models;

namespace MusicLibrary.Services.Models
{
    public class SongDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public Genre Genre { get; set; }
        public int ArtistId { get; set; }

        public static Expression<Func<Song, SongDataModel>> FromSongEFModel
        {
            get
            {
                return x => new SongDataModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Year = x.Year,
                    Genre = x.Genre,
                    ArtistId = x.Artist.Id
                };
            }
        }

        public Song CreateSong()
        {
            return new Song
            {
                Id = this.Id,
                Title = this.Title,
                Year = this.Year,
                Genre = this.Genre,
                ArtistId = this.ArtistId
            };
        }

        public void UpdateSong(Song song)
        {
            if (this.Title != null)
            {
                this.Title = song.Title;
            }

            if (this.Year != null)
            {
                this.Year = song.Year;
            }
            if (this.Genre != null)
            {
                this.Genre = song.Genre;
            }
            if (this.ArtistId != null)
            {
                this.ArtistId = song.ArtistId;
            }
        }
    }
}