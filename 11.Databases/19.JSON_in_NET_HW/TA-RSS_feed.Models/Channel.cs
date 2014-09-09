using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA_RSS_feed.Models
{
    public class Channel
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public ICollection<Item> Item { get; set; }
    }
}
