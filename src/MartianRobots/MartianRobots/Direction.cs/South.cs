using MartianRobots.Interfaces.cs;
using MartianRobots.Models;

namespace MartianRobots.Direction.cs;

public class South : IDirection
{
    public IDirection TurnRight()
    {
        return new West();
    }

    public IDirection TurnLeft()
    {
        return new East();
    }
    
    public Coordinates Move(Coordinates coordinates)
    {
        return new Coordinates(coordinates.GetX(), coordinates.GetY() - 1);
    }
    
    public override string ToString()
    {
        return "S" ;
    }
}