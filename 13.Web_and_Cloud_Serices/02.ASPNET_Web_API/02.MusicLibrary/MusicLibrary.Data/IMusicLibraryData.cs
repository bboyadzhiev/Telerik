namespace MusicLibrary.Data
{
    using MusicLibrary.Data.Repositories;
    using MusicLibrary.Models;

    public interface IMusicLibraryData
    {
        IRepository<Album> Albums { get; }

        IRepository<Artist> Artists { get; }

        IRepository<Song> Songs { get; }

        int SaveChanges();
    }
}