using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugLogger.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using BugLogger.Data.Migrations;

namespace BugLogger.Data
{
    public class BugLoggerDbContext : IdentityDbContext<ApplicationUser>
    {
        public BugLoggerDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BugLoggerDbContext, Configuration>());
        }

        public static BugLoggerDbContext Create()
        {
            return new BugLoggerDbContext();
        }

        public IDbSet<Bug> Bugs { get; set; }
    }
}
