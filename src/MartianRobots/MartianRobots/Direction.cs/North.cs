using MartianRobots.Interfaces.cs;

namespace MartianRobots.Direction.cs;

public class North : IDirection
{
    public IDirection TurnRight()
    {
        return new East();
    }

    public IDirection TurnLeft()
    {
        throw new NotImplementedException();
    }
}

public class East : IDirection
{
    public IDirection TurnRight()
    {
        throw new NotImplementedException();
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