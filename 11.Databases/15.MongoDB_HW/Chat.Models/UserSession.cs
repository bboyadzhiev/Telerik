using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class UserSession
    {
        public UserSession(User user)
        {
            this.User = user;
            this.LastActivityDate = DateTime.Now;
            this.expired = false;
        }

        public User User { get; set; }
        public DateTime LastActivityDate { get; set; }

        private bool expired;


        public bool Expired
        {
            get 
            {
                if (this.expired == true)
                {
                    return true;
                }
                // else check time passed
                var timepassed = DateTime.Now - LastActivityDate;
                if (timepassed.TotalMinutes > 10)
                {
                    this.expired = true;
                }
                else
                {
                    this.expired = false;
                }
                return this.expired;
            }
        }

        public void Invalidate()
        {
            this.expired = true;
        }
    }
}
