using FluentAssertions;

namespace MartianRobotsUnitTests;

public class Tests
{
   
    [TestCase]
    public void TurnLeft()
    {
        var command = "L";
        var position = Robot.ExecuteCommand(command);

        position.Should().Be("W");
    }
}

public class Robot
{
    public static string ExecuteCommand(string command)
    {
        throw new NotImplementedException();
    }
}