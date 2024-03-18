using MartianRobots.Interfaces.cs;
using MartianRobots.Models;

namespace MartianRobots;

public class Robot
{
    private Coordinates _coordinates;
    private readonly MarsSurface _surface;
    private IDirection _direction;

    public Robot(Coordinates coordinates, MarsSurface marsSurface, IDirection direction)
    {
        _coordinates = coordinates;
        _surface = marsSurface;
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
              
            }
        }

        return GetRobotPosition();
    }
    
    private string GetRobotPosition()
    {
        var robotPosition = $"{_coordinates.GetX()} {_coordinates.GetY()} {_direction}";

        if (_surface.HasRobotGoneOutOfBounds(_coordinates))
        {
            robotPosition += " LOST";
        }

        return robotPosition;
    }
}