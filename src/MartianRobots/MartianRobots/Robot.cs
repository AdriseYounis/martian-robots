using MartianRobots.Interfaces.cs;
using MartianRobots.Models;

namespace MartianRobots;

public class Robot
{
    private Coordinates _coordinates;
    private IDirection _direction;

    public Robot(Coordinates coordinates, IDirection direction)
    {
        _coordinates = coordinates;
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
                        _coordinates = new Coordinates(_coordinates.GetX(), _coordinates.GetY() + 1);
                        break;
                    case "E":
                        _coordinates = new Coordinates(_coordinates.GetX() + 1, _coordinates.GetY());
                        break;
                    case "S":
                        _coordinates = new Coordinates(_coordinates.GetX(), _coordinates.GetY() - 1);
                        break;
                    case "W":
                        _coordinates = new Coordinates(_coordinates.GetX() - 1, _coordinates.GetY());
                        break;
                }
            }
        }

        return $"{_coordinates.GetX()} {_coordinates.GetY()} {_direction}";
    }
}