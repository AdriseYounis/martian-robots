using MartianRobots.Interfaces.cs;

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
    
    public override string ToString()
    {
        return "W" ;
    }
}