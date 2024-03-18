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
        throw new NotImplementedException();
    }
    
    public override string ToString()
    {
        return "E" ;
    }
}