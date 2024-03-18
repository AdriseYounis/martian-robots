using MartianRobots.Constants;

namespace MartianRobots.Commands;

public static class CommandFactory
{
    public static void ExecuteCommand(char command, MarsSurface surface)
    {
        switch (command)
        {
            case Command.Left:
                new TurnLeftCommand(surface).Execute();
                break;
        }
    }
}