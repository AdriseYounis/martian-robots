using FluentAssertions;
using MartianRobots;
using MartianRobots.Commands;
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
    
    [Test]
    public void GivenRightCommand_WhenCommandFactoryIsCreated_ThenTheRightCommandIsCreated()
    {
        this.Given(_ => ACommand(Command.Right))
            .And(_ => MarsCoordinates(new Coordinates(5, 3)))
            .And(_ => AMarsSurface())
            .And(_ => CurrentDirectionIs(new North()))
            .When(_ => ExecutingTheCommand())
            .Then(_ => TheDirectionIs("E"))
            .BDDfy();
    }
    
    [Test]
    public void GivenForwardCommand_WhenCommandFactoryIsCreated_ThenTheForwardCommandIsCreated()
    {
        this.Given(_ => ACommand(Command.Forward))
            .And(_ => MarsCoordinates(new Coordinates(5, 3)))
            .And(_ => AMarsSurface())
            .And(_ => TheRobotLocationIsSet(new Coordinates(0, 0)))
            .And(_ => CurrentDirectionIs(new North()))
            .When(_ => ExecutingTheCommand())
            .Then(_ => TheRobotMovesForward())
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
    
    private void TheRobotLocationIsSet(Coordinates coordinates)
    {
        _marsSurface.SetRobotLocation(coordinates);
    }

    private void TheRobotMovesForward()
    {
        _marsSurface.GetRobotLocation().GetY().Should().Be(1);
    }
}