using MartianRobots.Interfaces.cs;

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
    
    public override string ToString()
    {
        return "E" ;
    }
}