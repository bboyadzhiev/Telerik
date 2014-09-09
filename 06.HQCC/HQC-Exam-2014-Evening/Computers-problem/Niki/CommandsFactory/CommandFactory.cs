namespace Computers.CommandsFactory
{
    using System;
    using Computers.AbstractFactory;
    using Computers.Commands;
    using Computers.CommandsParser;

    public class CommandFactory : IComputersCommandFactory
    {
        private AbstractComputer computer;

        public CommandFactory(AbstractComputer computer)
        {
            this.computer = computer;
        }

        public ICommand CreateCommand(ParsedCommand parsedCommand)
        {
            ICommand command;
            if (parsedCommand.CommandName == "Charge")
            {
                command = new ChargeCommand(this.computer);
            }
            else if (parsedCommand.CommandName == "Process")
            {
                command = new ProcessCommand(this.computer);
            }
            else if (parsedCommand.CommandName == "Play")
            {
                command = new PlayCommand(this.computer);
            }
            else
            {
                throw new ArgumentException("Invalid command!");
            }

            return command;
        }
    }
}