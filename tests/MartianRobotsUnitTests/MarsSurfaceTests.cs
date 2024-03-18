using FluentAssertions;
using MartianRobots;
using MartianRobots.Models;
using TestStack.BDDfy;

namespace MartianRobotsUnitTests;

public class MarsSurfaceTests
{
    private Coordinates _coordinates;
    private MarsSurface _marsSurface;
    private bool _hasGoneOutOfBounds;
    
    [Test]
    public void GivenAddScentedIsInvoked_WhenCheckingHasRobotGoneOutOfBounds_ThenCoordinatesAreOutOfBounds()
    {
        this.Given(_ => ASetOfCoordinates(new Coordinates(6,4)))
            .And(_ => MarsSurfaceIsCreated(new Coordinates(5, 3)))
            .When(_ => AddScentedIsInvoked(_coordinates))
            .And(_ => CheckingIfRobotIsOutOfBound())
            .Then(_ => RobotIsOutOfBounds(true))
            .BDDfy();
    }
    
    [Test]
    public void GivenCoordinatesOutOfBound_WhenInvokingIsRobotOutOfBounds_ThenCoordinatesAreOutOfBounds()
    {
        this.Given(_ => ASetOfCoordinates(new Coordinates(6,4)))
            .And(_ => MarsSurfaceIsCreated(new Coordinates(5, 3)))
            .When(_ => IsRobotOutOfBoundsIsInvoked(_coordinates))
            .Then(_ => RobotIsOutOfBounds(true))
            .BDDfy();
    }
    
    private void IsRobotOutOfBoundsIsInvoked(Coordinates coordinates)
    {
        _hasGoneOutOfBounds =_marsSurface.IsRobotOutOfBounds(coordinates);
    }

    private void AddScentedIsInvoked(Coordinates coordinates)
    {
        _marsSurface.AddScentedCoordinates(coordinates);
    }

    private void RobotIsOutOfBounds(bool isOutOfBounds)
    {
        _hasGoneOutOfBounds.Should().Be(isOutOfBounds);
    }

    private void CheckingIfRobotIsOutOfBound()
    {
        _hasGoneOutOfBounds = _marsSurface.HasRobotGoneOutOfBounds(_coordinates);
    }

    private void MarsSurfaceIsCreated(Coordinates coordinates)
    {
        _marsSurface = new MarsSurface(coordinates);
    }

    private void ASetOfCoordinates(Coordinates coordinates)
    {
        _coordinates = coordinates;
    }
}