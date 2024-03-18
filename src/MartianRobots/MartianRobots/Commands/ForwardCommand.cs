using MartianRobots.Models;

namespace MartianRobots.Commands;

public class ForwardCommand : ICommand
{
    private readonly MarsSurface _surface;

    public ForwardCommand(MarsSurface marsSurface)
    {
        _surface = marsSurface;
    }
    
    public void Execute()
    {
        var coordinates = _surface.GetRobotLocation();
        var previousCoordinates = new Coordinates(coordinates.GetX(), coordinates.GetY());
        
        coordinates = _surface.GetDirection().Move(coordinates);
       
        _surface.SetRobotLocation(coordinates);
                
        if (_surface.IsRobotOutOfBounds(coordinates) && !_surface.IsScented(previousCoordinates))
        {
            _surface.AddScentedCoordinates(previousCoordinates);   
        }
    }
}