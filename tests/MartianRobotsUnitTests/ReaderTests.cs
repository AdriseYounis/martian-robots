using FluentAssertions;
using MartianRobots.FileReader;
using MartianRobots.FileReader.Models;
using TestStack.BDDfy;

namespace MartianRobotsUnitTests;

public class ReaderTests
{
    private const string FilePath = @"C:\workspace\martian-robots\src\MartianRobots\MartianRobots\TestCases.txt";
    private readonly Reader _reader;
    private Instructions _instructions;
    
    public ReaderTests()
    {
        _reader = new Reader(FilePath);
    }
    
    [Test]
    public void GivenAFilePath_WhenCreatingRobotInstruction_ThenTheCorrectInstructionAreCreated()
    {
        this.When(_ => TheRobotInstructions())
            .Then(_ => MarsSurfaceCoordinatesAreSet())
            .And(_ => TheRobotInstructionsAreSet())
            .BDDfy();
    }

    private void TheRobotInstructionsAreSet()
    {
        _instructions.RobotInstructions.Count.Should().Be(3);
        
        _instructions.RobotInstructions[0].RobotPosition.GetX().Should().Be(1);
        _instructions.RobotInstructions[0].RobotPosition.GetY().Should().Be(1);
        _instructions.RobotInstructions[0].Direction.ToString().Should().Be("E");
        _instructions.RobotInstructions[0].Command.Should().Be("RFRFRFRF");
        
        _instructions.RobotInstructions[1].RobotPosition.GetX().Should().Be(3);
        _instructions.RobotInstructions[1].RobotPosition.GetY().Should().Be(2);
        _instructions.RobotInstructions[1].Direction.ToString().Should().Be("N");
        _instructions.RobotInstructions[1].Command.Should().Be("FRRFLLFFRRFLL");
        
        _instructions.RobotInstructions[2].RobotPosition.GetX().Should().Be(0);
        _instructions.RobotInstructions[2].RobotPosition.GetY().Should().Be(3);
        _instructions.RobotInstructions[2].Direction.ToString().Should().Be("W");
        _instructions.RobotInstructions[2].Command.Should().Be("LLFFFLFLFLF");
    }

    private void MarsSurfaceCoordinatesAreSet()
    {
        _instructions.Should().NotBeNull();
        _instructions.MarsSurfaceCoordinates.GetX().Should().Be(5);
        _instructions.MarsSurfaceCoordinates.GetY().Should().Be(3);
    }

    private void TheRobotInstructions()
    {
        _instructions = _reader.CreateRobotInstructionFromFileData();
    }
}