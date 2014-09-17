﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicLibrary.Data.Migrations;
using MusicLibrary.Models;

namespace MusicLibrary.Data
{
    public class MusicLibraryDbContext : DbContext, IMusicLibraryDbContext
    {
        public MusicLibraryDbContext()
            : base("MusicLibraryConnection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicLibraryDbContext, Configuration>());
        }
        public MusicLibraryDbContext(string connectionString)
            : base("MusicLibraryConnection")
        {
            this.Database.Connection.ConnectionString = connectionString;
           // Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicLibraryDbContext, Configuration>());
        }

        public IDbSet<Artist> Artists { get; set; }
        public IDbSet<Song> Songs { get; set; }
        public IDbSet<Album> Albums { get; set; }
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
