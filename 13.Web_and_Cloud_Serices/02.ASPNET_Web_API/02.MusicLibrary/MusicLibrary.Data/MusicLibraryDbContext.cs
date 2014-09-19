namespace MusicLibrary.Data
{
    using System.Data.Entity;
    using MusicLibrary.Data.Migrations;
    using MusicLibrary.Models;

    public class MusicLibraryDbContext : DbContext, IMusicLibraryDbContext
    {
        public MusicLibraryDbContext()
            : base("MusicLibrary")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicLibraryDbContext, Configuration>());
        }

        public MusicLibraryDbContext(string connectionString)
            : base("MusicLibrary")
        {
            this.Database.Connection.ConnectionString = connectionString;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicLibraryDbContext, Configuration>());
        }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}