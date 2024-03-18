using MartianRobots.Interfaces.cs;

namespace MartianRobots;

public class Robot
{
    private IDirection _direction;

    public Robot(IDirection direction)
    {
        _direction = direction;
    }
    
    public string ExecuteCommand(string commands)
    {
        var commandArr = commands.ToCharArray();

        foreach (var c in commandArr)
        {
            if (c.Equals('L'))
            {
                _direction = _direction.TurnLeft();
            }

            if (c.Equals('R'))
            {
                _direction = _direction.TurnRight();
            }
        }

        return $"0 0 {_direction}";
    }
}