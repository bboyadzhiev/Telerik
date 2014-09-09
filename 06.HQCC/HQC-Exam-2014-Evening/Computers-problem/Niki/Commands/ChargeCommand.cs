namespace Computers.Commands
{
    using Computers.AbstractFactory;

    internal class ChargeCommand : ICommand
    {
        private AbstractComputer computer;

        public ChargeCommand(AbstractComputer computer)
        {
            this.computer = computer;
        }

        public void Execute(int argument)
        {
            this.computer.ChargeBattery(argument);
        }
    }
}