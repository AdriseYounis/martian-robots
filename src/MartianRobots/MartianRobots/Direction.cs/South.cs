using MartianRobots.Interfaces.cs;

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
    
    public override string ToString()
    {
        return "S" ;
    }
}