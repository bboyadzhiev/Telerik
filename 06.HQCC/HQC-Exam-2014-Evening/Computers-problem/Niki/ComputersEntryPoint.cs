namespace Computers
{
    using System;
    using Computers.AbstractFactory;
    using Computers.Commands;
    using Computers.CommandsFactory;
    using Computers.CommandsParser;
    
    public class ComputersClass
    {
        public static void Main()
        {
            AbstractComputer pc, laptop, server;

            var manufacturerText = Console.ReadLine();

            ICommandsParser commandParser = new ComputerCommandsParser();
            var computerDealer = new ManufacturerFactory(manufacturerText);
            pc = computerDealer.GetPC();
            laptop = computerDealer.GetLaptop();
            server = computerDealer.GetServer();

            IComputersCommandFactory personalComputerCommandsFactory = new CommandFactory(pc);
            IComputersCommandFactory serverCommandsFactory = new CommandFactory(laptop);
            IComputersCommandFactory laptopCommandsFactory = new CommandFactory(server);

            while (true)
            {
                var commandString = Console.ReadLine();
                if (commandString == "Exit" || commandString == null)
                {
                    break;
                }

                var parsedCommand = commandParser.Parse(commandString);

                ICommand command = personalComputerCommandsFactory.CreateCommand(parsedCommand);
                command.Execute(parsedCommand.CommandArgument);
                command = serverCommandsFactory.CreateCommand(parsedCommand);
                command.Execute(parsedCommand.CommandArgument);
                command = laptopCommandsFactory.CreateCommand(parsedCommand);
                command.Execute(parsedCommand.CommandArgument);
            }
        }
    }
}