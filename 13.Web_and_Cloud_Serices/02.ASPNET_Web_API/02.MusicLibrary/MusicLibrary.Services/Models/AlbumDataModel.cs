using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MusicLibrary.Models;

namespace MusicLibrary.Services.Models
{
    public class AlbumDataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public string Producer { get; set; }
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

        public Album CreateAlbum()
        {
            return new Album
            {
                Id = this.Id,
                Title = this.Title,
                Year = this.Year,
                Producer = this.Producer
            };
        }

        public void UpdateAlbum(Album album)
        {
            if (this.Title != null)
            {
                this.Title = album.Title;
            }

            if (this.Year != null)
            {
                this.Year = album.Year;
            }
            if (this.Producer != null)
            {
                this.Producer = album.Producer;
            }
        }
    }
}