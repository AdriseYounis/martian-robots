namespace MartianRobots.Commands;

public class TurnLeftCommand : ICommand
{
    private readonly MarsSurface _surface;
    
    public TurnLeftCommand(MarsSurface surface)
    {
        _surface = surface;
    }

    public void Execute()
    {
        _surface.SetDirection(_surface.GetDirection().TurnLeft());
    }
}