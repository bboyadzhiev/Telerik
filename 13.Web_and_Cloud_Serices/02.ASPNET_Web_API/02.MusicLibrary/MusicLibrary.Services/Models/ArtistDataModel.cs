using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MusicLibrary.Models;

namespace MusicLibrary.Services.Models
{
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
                  Id = x.Id, Name = x.Name, Country = x.Country, DateOfBirth = x.DateOfBirth
                };
            }
        }

        public Artist CreateArtist()
        {
            return new Artist
            {
              Id = this.Id, Name = this.Name, Country = this.Country, DateOfBirth = this.DateOfBirth
            };
        }

        public void UpdateArtist(Artist artist)
        {
            if (this.Name != null)
            {
                this.Name = artist.Name;
            }

            if (this.Country != null)
            {
                this.Country = artist.Country;
            }
            if (this.DateOfBirth != null)
            {
                this.DateOfBirth = artist.DateOfBirth;
            }

        }
    }
}