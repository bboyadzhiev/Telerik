using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BullsAndCows.Models
{
    public enum NotificationStates
    {
        Read, Unread
    }

    public enum NotificationTypes
    {
        GameWon, GameLost, YourTurn, GameJoined, 
    }

    public class Notification
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public string PlayerId { get; set; }
        public virtual ApplicationUser Player { get; set; }

        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public NotificationStates State { get; set; }
        public NotificationTypes Type { get; set; }

    }
}
