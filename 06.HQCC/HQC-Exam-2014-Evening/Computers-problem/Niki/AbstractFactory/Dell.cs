namespace Computers.AbstractFactory
{
    using System.Collections.Generic;

    public class Dell : AbstractComputerManufacturer
    {
        public override PC MakePC()
        {
            var cpu = new CPU(4, 64);
            var ram = new RAM(8);
            var hardDrives = new List<HardDrive>() { new HardDrive(1000, false, 0) };
            var videoCard = new VideoCard(false);
            var motherboard = new Motherboard();
            var pc = new PC(AbstractComputer.ComputerType.PC, cpu, ram, hardDrives, videoCard, null, motherboard);
            return pc;
        }

        public override Laptop MakeLaptop()
        {
            var cpu = new CPU(4, 32);
            var ram = new RAM(8);
            var hardDrives = new List<HardDrive>() { new HardDrive(1000, false, 0) };
            var videoCard = new VideoCard(false);
            var motherboard = new Motherboard();
            var battery = new Battery();
            var laptop = new Laptop(AbstractComputer.ComputerType.PC, cpu, ram, hardDrives, videoCard, battery, motherboard);
            return laptop;
        }

        public override Server MakeServer()
        {
            var cpu = new CPU(8, 64);
            var ram = new RAM(64);
            var hardDrives = new List<HardDrive>() { new HardDrive(2000, true, 2), new HardDrive(2000, true, 2) };
            var videoCard = new VideoCard(true);
            var motherboard = new Motherboard();
            var server = new Server(AbstractComputer.ComputerType.PC, cpu, ram, hardDrives, videoCard, null, motherboard);
            return server;
        }
    }
}