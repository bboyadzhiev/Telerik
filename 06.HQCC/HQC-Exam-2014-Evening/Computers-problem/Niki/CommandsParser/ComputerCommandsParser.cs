namespace Computers.CommandsParser
{
    using System;

    public class ComputerCommandsParser : ICommandsParser
    {
        public ParsedCommand Parse(string commandString)
        {
            var formattedCommandText = commandString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (formattedCommandText.Length != 2)
            {
                throw new ArgumentException("Invalid command!");
            }

            var commandName = formattedCommandText[0];
            var commandArgument = int.Parse(formattedCommandText[1]);

            return new ParsedCommand(commandName, commandArgument);
        }
    }
}