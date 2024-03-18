using FluentAssertions;
using MartianRobots;
using MartianRobots.Direction.cs;
using MartianRobots.Interfaces.cs;
using TestStack.BDDfy;

namespace MartianRobotsUnitTests;

public class Tests
{
    private IDirection _direction;
    private string _expectedPosition;
    
    [TestCase("", "N")]
    [TestCase("L", "W")]
    [TestCase("LL", "S")]
    [TestCase("LLL", "E")]
    [TestCase("LLLL", "N")]
    public void TurnLeft(string command, string expectedDirection)
    {
        this.Given(_ => ADirection(new North()))
            .When(_ => TheRobotExecutesTheCommand(command))
            .Then(_ => TheExpectedPositionIs(expectedDirection))
            .BDDfy();
    }
    
    [TestCase("", "N")]
    [TestCase("R", "E")]
    [TestCase("RR", "S")]
    [TestCase("RRR", "W")]
    [TestCase("RRRR", "N")]
    public void TurnRight(string command, string expectedDirection)
    {
        this.Given(_ => ADirection(new North()))
            .When(_ => TheRobotExecutesTheCommand(command))
            .Then(_ => TheExpectedPositionIs(expectedDirection))
            .BDDfy();
    }
    
    [TestCase("", "0 0 N")]
    public void MoveForward(string command, string expectedPosition)
    {
        this.Given(_ => ADirection(new North()))
            .When(_ => TheRobotExecutesTheCommand(command))
            .Then(_ => TheExpectedPositionIs(expectedPosition))
            .BDDfy();
    }
    
    private void ADirection(IDirection direction)
    {
        _direction = direction;
    }
    
    private void TheExpectedPositionIs(string output)
    {
        _expectedPosition.Should().Be(output);
    }

    private void TheRobotExecutesTheCommand(string command)
    {
        var robot  = new Robot(_direction);
        _expectedPosition = robot.ExecuteCommand(command);
    }
}