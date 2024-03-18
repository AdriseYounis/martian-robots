using MartianRobots.Commands;
using MartianRobots.Interfaces.cs;
using MartianRobots.Models;

namespace MartianRobots;

public class Robot
{
    private readonly IMarsSurface _surface;
 
    public Robot(Coordinates coordinates, IMarsSurface surface, IDirection direction)
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