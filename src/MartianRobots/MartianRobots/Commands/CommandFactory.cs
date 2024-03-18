using MartianRobots.Constants;
using MartianRobots.Interfaces.cs;

namespace MartianRobots.Commands;

public static class CommandFactory
{
    public static void ExecuteCommand(char command, IMarsSurface surface)
    {
        switch (command)
        {
            case Command.Left:
                new TurnLeftCommand(surface).Execute();
                break;
            case Command.Right:
                new TurnRightCommand(surface).Execute();
                break;
            case Command.Forward:
                new ForwardCommand(surface).Execute();
                break;
        }
    }
}