using MartianRobots.Models;

namespace MartianRobots.FileReader.Models;

public class Instructions
{
    public Coordinates MarsSurfaceCoordinates { get; set; }
    public List<RobotInstructions> RobotInstructions { get; set; }
}