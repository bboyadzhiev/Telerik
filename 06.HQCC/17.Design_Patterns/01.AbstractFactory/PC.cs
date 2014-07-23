using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class PC : AbstractComputer
    {
        private string name;
        public PC(CPU cpu, MotherBoard motherBoard, string name, int ram)
            : base(cpu, motherBoard, ram)
        {
            this.name = name;
        }

       public override string GetDescription
       {
           get
           {
               return "This PC is named " + this.name + "  and has a " + this.motherBoard + " motherboard and a " + this.cpu + " CPU"; 
           }
      
       }
    }
}
