namespace Computers.Commands
{
    using Computers.AbstractFactory;

    internal class PlayCommand : ICommand
    {
        private AbstractComputer computer;

        public PlayCommand(AbstractComputer computer)
        {
            this.computer = computer;
        }

        public void Execute(int argument)
        {
            this.computer.Play(argument);
        }
    }
}