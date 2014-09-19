namespace MusicLibrary.Services.Models
{
    using System;
    using System.Linq.Expressions;
    using MusicLibrary.Models;

    public class ArtistDataModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        public static Expression<Func<Artist, ArtistDataModel>> FromArtistEFModel
        {
            get
            {
                return x => new ArtistDataModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Country = x.Country,
                    DateOfBirth = x.DateOfBirth
                };
            }
        }

        public Artist CreateArtist()
        {
            return new Artist
            {
                Id = this.Id,
                Name = this.Name,
                Country = this.Country,
                DateOfBirth = this.DateOfBirth
            };
        }

        public void UpdateArtist(Artist artist)
        {
            if (this.Name != null)
            {
                artist.Name = this.Name;
            }

            if (this.Country != null)
            {
                artist.Country = this.Country;
            }
            if (this.DateOfBirth != null)
            {
                artist.DateOfBirth = this.DateOfBirth;
            }
        }
    }
}