namespace MusicLibrary.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MusicLibrary.Models;

    public sealed class Configuration : DbMigrationsConfiguration<MusicLibrary.Data.MusicLibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "MusicLibrary.Data.MusicLibraryDbContext";
        }

        protected override void Seed(MusicLibrary.Data.MusicLibraryDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data. E.g.
            this.SeedArtists(context);
            context.SaveChanges();
            this.SeedSongs(context);
            context.SaveChanges();
            this.SeedAlbums(context);
        }

        private void SeedArtists(MusicLibraryDbContext context)
        {
            if (context.Artists.Any())
            {
                return;
            }

            context.Artists.Add(new Artist
            {
                Name = "Michael Jackson",
                Country = "USA",
                DateOfBirth = DateTime.Now
            });

            context.Artists.Add(new Artist
            {
                Name = "John Bon Jovie",
                Country = "USA",
                DateOfBirth = DateTime.Now
            });

            context.Artists.Add(new Artist
            {
                Name = "Amadeus Mozart",
                Country = "Austria",
                DateOfBirth = DateTime.Now
            });

            context.Artists.Add(new Artist
            {
                Name = "Bach",
                Country = "Austria",
                DateOfBirth = DateTime.Now
            });
        }

        private void SeedSongs(MusicLibraryDbContext ctx)
        {
            if (ctx.Songs.Any())
            {
                return;
            }

            ctx.Songs.Add(
                          new Song
                          {
                              Title = "Billy Jean",
                              Artist = ctx.Artists.Where(x => x.Name == "Michael Jackson").FirstOrDefault(),
                              Year = DateTime.Now,
                              Genre = Genre.Pop
                          }
                );
            ctx.Songs.Add(
                          new Song
                          {
                              Title = "Nth Symphony",
                              Artist = ctx.Artists.Where(x => x.Name == "Amadeus Mozart").FirstOrDefault(),
                              Year = DateTime.Now,
                              Genre = Genre.Classic
                          }
                );
        }

        private void SeedAlbums(MusicLibraryDbContext ctx)
        {
            if (ctx.Albums.Any())
            {
                return;
            }

            ctx.Albums.Add(
                new Album
                {
                    Title = "Classics",
                    Year = DateTime.Now,
                    Producer = "Classics Producer"
                });
        }
    }
}