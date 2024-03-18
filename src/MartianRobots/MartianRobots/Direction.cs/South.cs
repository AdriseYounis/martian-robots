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
        throw new NotImplementedException();
    }
    
    public override string ToString()
    {
        return "S" ;
    }
}