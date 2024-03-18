using FluentAssertions;

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
    public void TurnRight(string command, string expectedDirection)
    {
        var position = Robot.ExecuteCommand(command);

        position.Should().Be(expectedDirection);
    }
}

public class Robot
{
    public static string ExecuteCommand(string commands)
    {
        var direction = "N";

        var commandArr = commands.ToCharArray();

        foreach (var c in commandArr)
        {
            if (c.Equals('L'))
            {
                direction = direction switch
                {
                    "N" => "W",
                    "W" => "S",
                    "S" => "E",
                    "E" => "N",
                    _ => direction
                };
            }

            if (c.Equals('R'))
            {
                if (direction.Equals("N"))
                {
                    direction = "E";
                }
            }
        }
        
        
     
        
        

        return direction;
    }
}