using FluentAssertions;
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

internal class MarsSurface
{
    public MarsSurface(Coordinates coordinates)
    {
        throw new NotImplementedException();
    }

    public bool IsRobotOutOfBounds(Coordinates coordinates)
    {
        throw new NotImplementedException();
    }

    public void AddScentedCoordinates(Coordinates coordinates)
    {
        throw new NotImplementedException();
    }

    public bool HasRobotGoneOutOfBounds(Coordinates coordinates)
    {
        throw new NotImplementedException();
    }
}