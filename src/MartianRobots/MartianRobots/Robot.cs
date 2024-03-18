using MartianRobots.Commands;
using MartianRobots.Interfaces.cs;
using MartianRobots.Models;

namespace MartianRobots;

public class Robot
{
    private Coordinates _coordinates;
    private readonly MarsSurface _surface;
    private IDirection _direction;

    public Robot(Coordinates coordinates, MarsSurface surface, IDirection direction)
    {
        _surface = surface;
        
        surface.SetRobotLocation(coordinates);
        surface.SetDirection(direction);
    }
    
    public string ExecuteCommand(string commands)
    {
        var commandArr = commands.ToCharArray();

        foreach (var command in commandArr)
        {
            CommandFactory.ExecuteCommand(command, _surface);
            
            /*if (c.Equals('L'))
            {
                _direction = _direction.TurnLeft();
            }

            if (c.Equals('R'))
            {
                _direction = _direction.TurnRight();
            }

            if (c.Equals('F'))
            {
              
            }*/
        }

        return GetRobotPosition();
    }
    
    private string GetRobotPosition()
    {
        var coordinates = _surface.GetRobotLocation();
        var robotPosition = $"{coordinates.GetX()} {coordinates.GetY()} {_surface.GetDirection()}";

        if (_surface.HasRobotGoneOutOfBounds(coordinates))
        {
            robotPosition += " LOST";
        }

        return robotPosition;
    }
}