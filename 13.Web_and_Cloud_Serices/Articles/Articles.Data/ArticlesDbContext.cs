using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Articles.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Articles.Data
{
    public class ArticlesDbContext : IdentityDbContext<ApplicationUser>
    {
        public ArticlesDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ArticlesDbContext Create()
        {
            return new ArticlesDbContext();
        }
    }
}
