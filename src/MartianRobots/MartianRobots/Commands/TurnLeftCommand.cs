using MartianRobots.Interfaces.cs;

namespace MartianRobots.Commands;

public class TurnLeftCommand : ICommand
{
    private readonly IMarsSurface _surface;
    
    public TurnLeftCommand(IMarsSurface surface)
    {
        _surface = surface;
    }

    public void Execute()
    {
        _surface.SetDirection(_surface.GetDirection().TurnLeft());
    }
}