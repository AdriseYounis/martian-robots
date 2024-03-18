using FluentAssertions;
using MartianRobots;
using MartianRobots.Constants;
using MartianRobots.Direction.cs;
using MartianRobots.Interfaces.cs;
using MartianRobots.Models;
using TestStack.BDDfy;

namespace MartianRobotsUnitTests;

public class CommandFactoryTests
{
    private Coordinates _coordinates;
    private MarsSurface _marsSurface;
    private char _command;
    
    [Test]
    public void GivenLeftCommand_WhenCommandFactoryIsCreated_ThenTheLeftCommandIsCreated()
    {
        this.Given(_ => ACommand(Command.Left))
            .And(_ => MarsCoordinates(new Coordinates(5, 3)))
            .And(_ => AMarsSurface())
            .And(_ => CurrentDirectionIs(new North()))
            .When(_ => ExecutingTheCommand())
            .Then(_ => TheDirectionIs("W"))
            .BDDfy();
    }
    
    private void TheDirectionIs(string direction)
    {
        _marsSurface.GetDirection().ToString().Should().Be(direction);
    }

    private void ExecutingTheCommand()
    {
        CommandFactory.ExecuteCommand(_command, _marsSurface);
    }

    private void CurrentDirectionIs(IDirection direction)
    {
        _marsSurface.SetDirection(direction);
    }

    private void AMarsSurface()
    {
        _marsSurface = new MarsSurface(_coordinates);
    }

    private void MarsCoordinates(Coordinates coordinates)
    {
        _coordinates = coordinates;
    }

    private void ACommand(char command)
    {
        _command = command;
    }
}

internal class CommandFactory
{
    public static void ExecuteCommand(char command, MarsSurface surface)
    {
        if (command == Command.Left)
        {
            new TurnLeftCommand(surface).Execute();
        }
    }
}

internal class TurnLeftCommand
{
    private readonly MarsSurface _surface;
    
    public TurnLeftCommand(MarsSurface surface)
    {
        _surface = surface;
    }

    public void Execute()
    {
        _surface.SetDirection(_surface.GetDirection().TurnLeft());
    }
}