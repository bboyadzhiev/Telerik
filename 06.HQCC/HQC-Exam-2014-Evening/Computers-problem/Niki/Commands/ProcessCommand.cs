namespace Computers.Commands
{
    using Computers.AbstractFactory;

    internal class ProcessCommand : ICommand
    {
        private AbstractComputer computer;

        public ProcessCommand(AbstractComputer computer)
        {
            this.computer = computer;
        }

        public void Execute(int argument)
        {
            this.computer.Process(argument);
        }
    }
}