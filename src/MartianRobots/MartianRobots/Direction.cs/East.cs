using MartianRobots.Interfaces.cs;
using MartianRobots.Models;

namespace MartianRobots.Direction.cs;

public class East : IDirection
{
    public IDirection TurnRight()
    {
        return new South();
    }

    public IDirection TurnLeft()
    {
        return new North();
    }
    
    public Coordinates Move(Coordinates coordinates)
    {
        return new Coordinates(coordinates.GetX() + 1, coordinates.GetY());
    }
    
    public override string ToString()
    {
        return "E" ;
    }
}