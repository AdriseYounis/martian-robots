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