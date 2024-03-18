using FluentAssertions;
using MartianRobots.Direction.cs;
using MartianRobots.Interfaces.cs;
using TestStack.BDDfy;

namespace MartianRobotsUnitTests;

public class DirectionTests
{
    private IDirection _direction;
    private IDirection _expectedDirection;
    
    [Test]
    public void GivenNorthDirection_WhenTurningRight_ThenDirectionIsEast()
    {
        this.Given(_ => ADirection(new North()))
            .When(_ => TurningRight())
            .Then(_ => DirectionIs("E"))
            .BDDfy();
    }
    
    [Test]
    public void GivenEastDirection_WhenTurningRight_ThenDirectionIsSouth()
    {
        this.Given(_ => ADirection(new East()))
            .When(_ => TurningRight())
            .Then(_ => DirectionIs("S"))
            .BDDfy();
    }
    
    [Test]
    public void GivenSouthDirection_WhenTurningRight_ThenDirectionIsWest()
    {
        this.Given(_ => ADirection(new South()))
            .When(_ => TurningRight())
            .Then(_ => DirectionIs("W"))
            .BDDfy();
    }
    
    [Test]
    public void GivenWestDirection_WhenTurningRight_ThenDirectionIsNorth()
    {
        this.Given(_ => ADirection(new West()))
            .When(_ => TurningRight())
            .Then(_ => DirectionIs("N"))
            .BDDfy();
    }
    
    private void DirectionIs(string direction)
    {
        _expectedDirection.ToString().Should().Be(direction);
    }
    
    private void TurningRight()
    {
        _expectedDirection =_direction.TurnRight();
    }

    private void ADirection(IDirection direction)
    {
        _direction = direction;
    }
}