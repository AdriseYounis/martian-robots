using MartianRobots.Models;

namespace MartianRobots;

public class MarsSurface
{
    private readonly Coordinates _upperBound;
    private readonly List<Coordinates> _scentedCoordinates = new();
 
    public MarsSurface(Coordinates upperBound)
    {
        _upperBound = upperBound;
    }
    
    public bool IsScented(Coordinates coordinates)
    {
        return _scentedCoordinates.Contains(coordinates);
    }
    
    public void AddScentedCoordinates(Coordinates coordinates)
    {
        _scentedCoordinates.Add(coordinates);
    }

    public bool HasRobotGoneOutOfBounds(Coordinates coordinates)
    {
        return _scentedCoordinates.Any(x => x.GetX() == coordinates.GetX() && x.GetY() == coordinates.GetY());
    }
    
    public bool IsRobotOutOfBounds(Coordinates coordinates)
    {
        var x = coordinates.GetY();
        var y = coordinates.GetY();
        
        return x > _upperBound.GetX() || x < 0 || y > _upperBound.GetY() || y < 0;
    }
}