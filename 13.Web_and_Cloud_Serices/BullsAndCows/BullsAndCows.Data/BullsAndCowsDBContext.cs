using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BullsAndCows.Data.Migrations;
using BullsAndCows.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BullsAndCows.Data
{

    public class BullsAndCowsDBContext : IdentityDbContext<ApplicationUser>
    {
        public BullsAndCowsDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDBContext, Configuration>());

        }

        public static BullsAndCowsDBContext Create()
        {
            return new BullsAndCowsDBContext();
        }

        public IDbSet<Game> Games { get; set; }
        public IDbSet<Guess> Guesses { get; set; }
        public IDbSet<Notification> Notifications { get; set; }

    }

}
