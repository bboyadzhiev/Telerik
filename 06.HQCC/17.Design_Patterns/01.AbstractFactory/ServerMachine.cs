using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class ServerMachine: AbstractComputer
    {
        private string name;
        public ServerMachine(CPU cpu, MotherBoard motherBoard, string name, int ram)
            : base(cpu, motherBoard, ram)
        {
            this.name = name;
        }

        public override string GetDescription
        {
            get
            {
                return "This server machine is named " + this.name + "  and has a " + this.motherBoard + " motherboard and a " + this.cpu + " CPU"; 
            }
      
        }
    }
}
