namespace MusicLibrary.Services.Models
{
    using System;
    using System.Linq.Expressions;
    using MusicLibrary.Models;

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
        }
    }
}