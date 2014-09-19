using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Models;

namespace MusicLibrary.Data
{
    public interface IMusicLibraryDbContext
    {
       IDbSet<Artist> Artists { get; set; }
       IDbSet<Song> Songs { get; set; }
       IDbSet<Album> Albums { get; set; }
       IDbSet<T> Set<T>() where T : class;
       DbEntityEntry<T> Entry<T>(T entity) where T : class;
       int SaveChanges();

    }
}
