using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugLogger.Data.Repositories;
using BugLogger.Models;

namespace BugLogger.Data
{
    public interface IBugLoggerData
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Bug> Bugs { get; }
        int SaveChanges();
    }
}
