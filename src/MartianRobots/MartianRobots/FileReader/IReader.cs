using MartianRobots.FileReader.Models;

namespace MartianRobots.FileReader;

public interface IReader
{
    Instructions CreateRobotInstructionFromFileData();
}