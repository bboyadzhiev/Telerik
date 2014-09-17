namespace MusicLibrary.Data.Repositories
{
    
using System.Linq;
using MusicLibrary.Models;

    public class AlbumsRepository : GenericRepository<Album>, IGenericRepository<Album>
    {
        public AlbumsRepository(IMusicLibraryDbContext context)
            : base(context)
        {

        }

        public IQueryable<Album> AllArtists()
        {
            return this.All().Where(st => st.Artists.Count() > 0);
        }
    }
}
