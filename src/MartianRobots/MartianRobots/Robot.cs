using MartianRobots.Interfaces.cs;

namespace MartianRobots;

public class Robot
{
    private IDirection _direction;
    private int _x;
    private int _y;

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

            if (c.Equals('F'))
            {
                switch (_direction.ToString())
                {
                    case "N":
                        _y++;
                        break;
                    case "E":
                        _x++;
                        break;
                    case "S":
                        _y--;
                        break;
                    case "W":
                        _x--;
                        break;
                }
            }
        }

        return $"{_x} {_y} {_direction}";
    }
}