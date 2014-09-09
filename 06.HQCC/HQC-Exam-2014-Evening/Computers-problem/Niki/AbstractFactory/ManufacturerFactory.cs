namespace Computers.AbstractFactory
{
    using System;

    public class ManufacturerFactory
    {
        public ManufacturerFactory(string manufacturerText)
        {
            if (manufacturerText == "HP")
            {
                this.Manufacturer = new HP();
            }
            else if (manufacturerText == "Dell")
            {
                this.Manufacturer = new Dell();
            }
            else if (manufacturerText == "Lenovo")
            {
                this.Manufacturer = new Dell();
            }
            else
            {
                throw new ArgumentException("Invalid manufacturer!");
            }
        }

        public AbstractComputerManufacturer Manufacturer { get; set; }

        public PC GetPC()
        {
            return this.Manufacturer.MakePC();
        }

        public Server GetServer()
        {
            return this.Manufacturer.MakeServer();
        }

        public Laptop GetLaptop()
        {
            return this.Manufacturer.MakeLaptop();
        }
    }
}