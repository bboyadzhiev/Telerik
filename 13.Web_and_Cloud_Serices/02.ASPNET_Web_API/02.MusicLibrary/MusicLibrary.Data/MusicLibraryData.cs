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

        public Repositories.IGenericRepository<Models.Album> Albums
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Repositories.IGenericRepository<Models.Artist> Artists
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Repositories.IGenericRepository<Models.Song> Songs
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Album)))
                {
                    type = typeof(AlbumsRepository);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
