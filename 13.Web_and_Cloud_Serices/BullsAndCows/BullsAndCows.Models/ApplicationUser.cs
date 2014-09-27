using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BullsAndCows.Models
{
    public enum Colors
    {
         red, blue
    }

    public class ApplicationUser : IdentityUser
    {
        public int YourNumber { get; set; }
        public virtual ICollection<Guess> Guesses { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }

        public Colors YourColor { get; set; }


        public ApplicationUser()
        {
            this.Guesses = new HashSet<Guess>();
            this.Games = new HashSet<Game>();
            this.Notifications = new HashSet<Notification>();
            // TODO: set color maybe?
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
