namespace MusicLibrary.Services.Models
{
    using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MusicLibrary.Models;

    public class AlbumDataModel
    {
        public AlbumDataModel()
        {
            this.songTitles = new List<string>();
            this.artistNames = new List<string>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime Year { get; set; }

        public string Producer { get; set; }
        public List<int> SongsIds { get; set; }
        public List<int> ArtistsIds { get; set; }
        public List<string> songTitles;
        public List<string> artistNames;

        public static Expression<Func<Album, AlbumDataModel>> FromAlbumEFModel
        {
            get
            {
                
                return x => new AlbumDataModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Year = x.Year,
                    Producer = x.Producer
                    
                };
            }
        }

        public Album CreateAlbum(List<Song> songs, List<Artist> artists)
        {
            return new Album
            {
                Id = this.Id,
                Title = this.Title,
                Year = this.Year,
                Producer = this.Producer,
                Artists = artists,
                Songs = songs
            };
        }

        public void UpdateAlbum(Album album, List<Song> songs, List<Artist> artists)
        {
            if (this.Title != null)
            {
                album.Title = this.Title;
            }

            if (this.Year != null)
            {
                album.Year = this.Year;
            }
            if (this.Producer != null)
            {
                album.Producer = this.Producer;
            }
            if (songs != null)
            {
                album.Artists = artists;
            }
            if (artists != null)
            {
                album.Songs = songs;
            }
        }
    }
}