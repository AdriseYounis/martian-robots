using MartianRobots.Interfaces.cs;

namespace MartianRobots.Commands;

public class TurnRightCommand : ICommand
{
    private readonly IMarsSurface _surface;

    public TurnRightCommand(IMarsSurface surface)
    {
        _surface = surface;
    }
    
    public void Execute()
    {
        _surface.SetDirection(_surface.GetDirection().TurnRight());
    }
}