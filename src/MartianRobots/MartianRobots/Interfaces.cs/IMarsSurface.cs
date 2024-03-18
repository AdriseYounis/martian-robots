using MartianRobots.Models;

namespace MartianRobots.Interfaces.cs;

public interface IMarsSurface
{
    bool IsScented(Coordinates coordinates);
    void AddScentedCoordinates(Coordinates coordinates);
    bool HasRobotGoneOutOfBounds(Coordinates coordinates);
    bool IsRobotOutOfBounds(Coordinates coordinates);

    void SetDirection(IDirection direction);
    IDirection GetDirection();
    void SetRobotLocation(Coordinates coordinates);
    Coordinates GetRobotLocation();
}