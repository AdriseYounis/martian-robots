using FluentAssertions;

namespace MartianRobotsUnitTests;

public class Tests
{
   
    [TestCase("", "N")]
    [TestCase("L", "W")]
    [TestCase("LL", "S")]
    [TestCase("LLL", "E")]
    public void TurnLeft(string command, string expectedDirection)
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
            }
        }
        
        
     
        
        

        return direction;
    }
}