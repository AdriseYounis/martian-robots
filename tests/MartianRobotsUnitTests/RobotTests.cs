using FluentAssertions;
using MartianRobots;

namespace MartianRobotsUnitTests;

public class Tests
{
    [TestCase("", "N")]
    [TestCase("L", "W")]
    [TestCase("LL", "S")]
    [TestCase("LLL", "E")]
    [TestCase("LLLL", "N")]
    public void TurnLeft(string command, string expectedDirection)
    {
        var position = Robot.ExecuteCommand(command);

        position.Should().Be(expectedDirection);
    }
    
    [TestCase("", "N")]
    [TestCase("R", "E")]
    [TestCase("RR", "S")]
    [TestCase("RRR", "W")]
    [TestCase("RRRR", "N")]
    public void TurnRight(string command, string expectedDirection)
    {
        var position = Robot.ExecuteCommand(command);

        position.Should().Be(expectedDirection);
    }
}