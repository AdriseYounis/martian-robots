using FluentAssertions;
using MartianRobots;
using MartianRobots.Direction.cs;
using MartianRobots.Interfaces.cs;
using MartianRobots.Models;
using TestStack.BDDfy;

namespace MartianRobotsUnitTests;

public class Tests
{
    private readonly MarsSurface _surface = new(new Coordinates(5, 3));
    private IDirection _direction;
    private string _expectedPosition;
    private Coordinates _robotPosition;
    
    [TestCase("", "N")]
    [TestCase("L", "W")]
    [TestCase("LL", "S")]
    [TestCase("LLL", "E")]
    [TestCase("LLLL", "N")]
    public void TurnLeft(string command, string expectedDirection)
    {
        this.Given(_ => ADirection(new North()))
            .And(_ => TheRobotPosition(new Coordinates(0, 0)))
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
            .And(_ => TheRobotPosition(new Coordinates(0, 0)))
            .When(_ => TheRobotExecutesTheCommand(command))
            .Then(_ => TheExpectedPositionIs(expectedDirection))
            .BDDfy();
    }
    
    [TestCase("", "0 0 N")]
    [TestCase("F", "0 1 N")]
    [TestCase("RF", "1 0 E")]
    [TestCase("RRF", "0 -1 S")]
    [TestCase("RRRF", "-1 0 W")]
    public void MoveForward(string command, string expectedPosition)
    {
        this.Given(_ => ADirection(new North()))
            .And(_ => TheRobotPosition(new Coordinates(0, 0)))
            .When(_ => TheRobotExecutesTheCommand(command))
            .Then(_ => TheExpectedPositionIs(expectedPosition))
            .BDDfy();
    }
    
    [Test]
    public void MoveRobot_RightAndForward()
    {
        this.Given(_ => ADirection(new East()))
            .And(_ => TheRobotPosition(new Coordinates(1,1)))
            .When(_ => TheRobotExecutesTheCommand("RFRFRFRF"))
            .Then(_ => TheExpectedPositionIs("1 1 E"))
            .BDDfy();
    }
    
    [Test]
    public void MoveRobot_OutOfBounds()
    {
        this.Given(_ => ADirection(new North()))
            .And(_ => TheRobotPosition(new Coordinates(3,2)))
            .When(_ => TheRobotExecutesTheCommand("FRRFLLFFRRFLL"))
            .Then(_ => TheExpectedPositionIs("3 3 N LOST"))
            .BDDfy();
    }
 
    private void TheRobotPosition(Coordinates coordinates)
    {
        _robotPosition = coordinates;
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
        var robot  = new Robot(_robotPosition, _surface, _direction);
        _expectedPosition = robot.ExecuteCommand(command);
    }
}