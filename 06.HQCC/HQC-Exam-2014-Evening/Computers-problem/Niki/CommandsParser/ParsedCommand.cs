namespace Computers.CommandsParser
{
    public class ParsedCommand
    {
        public ParsedCommand(string commandName, int commandArgument)
        {
            this.CommandName = commandName;
            this.CommandArgument = commandArgument;
        }

        public string CommandName { get; set; }

        public int CommandArgument { get; set; }
    }
}