using MartianRobots.Interfaces.cs;
using MartianRobots.Models;

namespace MartianRobots.Direction.cs;

public class North : IDirection
{
    public IDirection TurnRight()
    {
        return new East();
    }

    public IDirection TurnLeft()
    {
        return new West();
    }
    
    public Coordinates Move(Coordinates coordinates)
    {
        return new Coordinates(coordinates.GetX(), coordinates.GetY() + 1);
    }
    
    public override string ToString()
    {
        return "N" ;
    }
}