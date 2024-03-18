using FluentAssertions;

namespace MartianRobotsUnitTests;

public class Tests
{
   
    [TestCase("", "N")]
    [TestCase("L", "W")]
    public void TurnLeft(string command, string expectedDirection)
    {
        var position = Robot.ExecuteCommand(command);

        position.Should().Be(expectedDirection);
    }
}

public class Robot
{
    public static string ExecuteCommand(string command)
    {
        var direction = "N";

        if (command.Equals("L") && direction.Equals("N"))
        {
            return "W";
        }

        return direction;
    }
}