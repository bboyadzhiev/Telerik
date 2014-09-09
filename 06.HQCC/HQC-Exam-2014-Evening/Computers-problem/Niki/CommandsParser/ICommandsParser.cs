namespace Computers.CommandsParser
{
    public interface ICommandsParser
    {
        ParsedCommand Parse(string commandString);
    }
}