namespace MusicLibrary.Data.Repositories
{

    using System.Data.Entity;
    using System.Linq;
    using MusicLibrary.Models;

    public class AlbumsRepository : EFRepository<Album>, IRepository<Album>
    {
        public AlbumsRepository(DbContext context)
            : base(context)
        {

        }

        public IQueryable<Album> AllArtists()
        {
            return this.All().Where(st => st.Artists.Count() > 0);
        }
    }
}
