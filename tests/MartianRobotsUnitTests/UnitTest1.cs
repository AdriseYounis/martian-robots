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
                if (direction.Equals("N"))
                {
                    direction = "W";       
                }

                else if (direction.Equals("W"))
                {
                    direction = "S";
                }
                
                else if (direction.Equals("S"))
                {
                    direction = "E";
                }

                else if(direction.Equals("E"))
                {
                    direction = "N";
                }
            }
        }
        
        
     
        
        

        return direction;
    }
}