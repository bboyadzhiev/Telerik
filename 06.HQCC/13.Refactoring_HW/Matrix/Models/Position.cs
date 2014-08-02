using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix.Models
{
    public class Position
    {
        private int x;
        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public Position()
        {
            this.X = 0;
            this.Y = 0;
        }

    }
}
