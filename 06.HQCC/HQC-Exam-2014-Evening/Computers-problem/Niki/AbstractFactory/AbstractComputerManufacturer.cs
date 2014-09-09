namespace Computers.AbstractFactory
{
    public abstract class AbstractComputerManufacturer
    {
        public abstract PC MakePC();

        public abstract Laptop MakeLaptop();

        public abstract Server MakeServer();
    }
}