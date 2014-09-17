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
        IGenericRepository<Album> Albums { get; set; }
        IGenericRepository<Artist> Artists { get; set; }
        IGenericRepository<Song> Songs { get; set; }
    }
}
