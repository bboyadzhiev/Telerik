namespace MusicLibrary.Services.Models
{
    using System;
    using System.Linq.Expressions;
    using MusicLibrary.Models;

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
                song.Title = this.Title;
            }

            if (this.Year != null)
            {
                song.Year = this.Year;
            }
            if (this.Genre != null)
            {
                song.Genre = this.Genre;
            }
            if (this.ArtistId != null)
            {
                song.ArtistId = this.ArtistId;
            }
        }
    }
}