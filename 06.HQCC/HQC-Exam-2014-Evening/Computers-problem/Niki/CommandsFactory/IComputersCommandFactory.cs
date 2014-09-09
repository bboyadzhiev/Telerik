namespace Computers.CommandsFactory
{
    using Computers.Commands;
    using Computers.CommandsParser;

    public interface IComputersCommandFactory
    {
        ICommand CreateCommand(ParsedCommand command);
    }
}