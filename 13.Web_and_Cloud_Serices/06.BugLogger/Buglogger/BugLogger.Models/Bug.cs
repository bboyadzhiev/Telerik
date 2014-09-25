using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugLogger.Models
{
    public enum Status
    {
        Fixed, Assigned, ForTesting, Pending

    }
    public class Bug
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Text { get; set; }
        public DateTime LogDate { get; set; }
    }
}
