namespace MartianRobots.Models;

public class Coordinates
{
    private const int MaxCoordinateValue = 50;
    private readonly int _x;
    private readonly int _y;

    public Coordinates(int x, int y)
    {
        if (x > MaxCoordinateValue || y > MaxCoordinateValue)
        {
            throw new ArgumentException("No coordinates can be more then 50");
        }
        
        _x = x;
        _y = y;
    }

    public int GetX() => _x;
    public int GetY() => _y;
}