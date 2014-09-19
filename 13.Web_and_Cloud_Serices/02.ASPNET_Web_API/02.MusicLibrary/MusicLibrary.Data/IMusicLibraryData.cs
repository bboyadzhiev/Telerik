using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Data.Repositories;
using MusicLibrary.Models;

namespace MusicLibrary.Data
{
    public interface IMusicLibraryData
    {
        IRepository<Album> Albums { get; }
        IRepository<Artist> Artists { get; }
        IRepository<Song> Songs { get; }
        int SaveChanges();
    }
}
