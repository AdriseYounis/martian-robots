using MartianRobots.Interfaces.cs;
using MartianRobots.Models;

namespace MartianRobots.Direction.cs;

public class West : IDirection
{
    public IDirection TurnRight()
    {
        return new North();
    }

    public IDirection TurnLeft()
    {
        return new South();
    }
    
    public Coordinates Move(Coordinates coordinates)
    {
        return new Coordinates(coordinates.GetX() - 1, coordinates.GetY());
    }
    
    public override string ToString()
    {
        return "W" ;
    }
}