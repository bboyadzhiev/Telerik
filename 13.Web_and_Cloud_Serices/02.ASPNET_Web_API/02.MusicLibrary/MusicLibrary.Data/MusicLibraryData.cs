using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Data.Repositories;
using MusicLibrary.Models;

namespace MusicLibrary.Data
{
    public class MusicLibraryData : IMusicLibraryData
    {
        public IMusicLibraryDbContext context;
        public IDictionary<Type, object> repositories;

        public MusicLibraryData()
            : this(new MusicLibraryDbContext())
        {

        }

        public MusicLibraryData(string connectionString)
            : this(new MusicLibraryDbContext(connectionString))
        {

        }

        public MusicLibraryData(IMusicLibraryDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Models.Album> Albums
        {
            get
            {
                return this.GetRepository<Album>();
            }
        }

        public IRepository<Models.Artist> Artists
        {
            get
            {
                return this.GetRepository<Artist>();
            }
        }

        public IRepository<Models.Song> Songs
        {
            get
            {
                return this.GetRepository<Song>();
            }
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(EFRepository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Album)))
                {
                    type = typeof(AlbumsRepository);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }


        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
