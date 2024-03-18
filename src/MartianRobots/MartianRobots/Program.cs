// See https://aka.ms/new-console-template for more information

using MartianRobots;
using MartianRobots.FileReader;

var fileReader = new Reader(@"C:\workspace\martian-robots\src\MartianRobots\MartianRobots\TestCases.txt");
var instructions = fileReader.CreateRobotInstructionFromFileData();

var marsSurface = new MarsSurface(instructions.MarsSurfaceCoordinates);

foreach (var robotInstruction in instructions.RobotInstructions)
{
    var robot = new Robot(robotInstruction.RobotPosition, marsSurface, robotInstruction.Direction);
    Console.WriteLine(robot.ExecuteCommand(robotInstruction.Command));
}