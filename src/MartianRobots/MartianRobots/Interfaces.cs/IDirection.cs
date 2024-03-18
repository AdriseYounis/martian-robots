using MartianRobots.Models;

namespace MartianRobots.Interfaces.cs;

public interface IDirection
{
    IDirection TurnRight();
    
    IDirection TurnLeft();
    
    Coordinates Move(Coordinates coordinates);
}