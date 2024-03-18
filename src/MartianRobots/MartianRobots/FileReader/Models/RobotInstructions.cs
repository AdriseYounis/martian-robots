using MartianRobots.Interfaces.cs;
using MartianRobots.Models;

namespace MartianRobots.FileReader.Models;

public class RobotInstructions 
{
    public Coordinates RobotPosition { get; set; }
    public IDirection Direction { get; set; }
    public string Command { get; set; }
}
