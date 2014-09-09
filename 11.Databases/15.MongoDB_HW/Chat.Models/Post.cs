using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class Post
    {
        public string Message { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
    }
}
