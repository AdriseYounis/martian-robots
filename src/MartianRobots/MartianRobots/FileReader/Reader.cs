using MartianRobots.Direction.cs;
using MartianRobots.FileReader.Models;
using MartianRobots.Interfaces.cs;
using MartianRobots.Models;

namespace MartianRobots.FileReader;

public class Reader : IReader
{
    private readonly string _filePath;

    public Reader(string filePath)
    {
        _filePath = filePath;
    }
    
    public Instructions CreateRobotInstructionFromFileData()
    {
        var testCases = File.ReadLines(_filePath).ToList();
        
        var instruction = new Instructions();
        
        SetMarSurfaceCoordinates(testCases, instruction);

        instruction.RobotInstructions = CreateRobotPositionAndInstructions(testCases);
        return instruction;
    }

    private static List<RobotInstructions> CreateRobotPositionAndInstructions(IEnumerable<string> testCases)
    {
        var robotInstructions = new List<RobotInstructions>();
        var robotInstruction = new RobotInstructions();
        
        foreach (var line in testCases.Skip(1))
        {
            if (char.IsDigit(line[0]))
            {
                var robotPosition = line.Split(" ");
                var direction = robotPosition[2];

                robotInstruction.RobotPosition = CreateCoordinates(robotPosition);
                robotInstruction.Direction = GetDirection(direction);
            }
            else
            {
                robotInstruction.Command = line;
                robotInstructions.Add(robotInstruction);
                robotInstruction = new RobotInstructions();
            }
        }

        return robotInstructions;
    }

    private static void SetMarSurfaceCoordinates(IReadOnlyCollection<string> testCases, Instructions instruction)
    {
        if (!testCases.Any()) return;
        
        var strCoordinates = testCases.First().Split(" ");
        if (strCoordinates.Length > 0)
        {
            instruction.MarsSurfaceCoordinates = CreateCoordinates(strCoordinates);
        }
    }

    private static Coordinates CreateCoordinates(IReadOnlyList<string> fileData)
    {
        int.TryParse(fileData[0], out var x);
        int.TryParse(fileData[1], out var y);
        
        return new Coordinates(x, y);
    }

    private static IDirection? GetDirection(string direction)
    {
        return direction switch
        {
            "N" => new North(),
            "E" => new East(),
            "S" => new South(),
            "W" => new West(),
            _ => null
        };
    }
}