using FluentAssertions;
using MartianRobots;
using MartianRobots.Direction.cs;

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
        var position = new Robot(new North()).ExecuteCommand(command);

        position.Should().Be(expectedDirection);
    }
    
    [TestCase("", "N")]
    [TestCase("R", "E")]
    [TestCase("RR", "S")]
    [TestCase("RRR", "W")]
    [TestCase("RRRR", "N")]
    public void TurnRight(string command, string expectedDirection)
    {
        var position = new Robot(new North()).ExecuteCommand(command);

        position.Should().Be(expectedDirection);
    }
}