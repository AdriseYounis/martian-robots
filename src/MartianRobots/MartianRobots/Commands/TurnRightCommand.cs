namespace MartianRobots.Commands;

public class TurnRightCommand : ICommand
{
    private readonly MarsSurface _surface;

    public TurnRightCommand(MarsSurface surface)
    {
        _surface = surface;
    }
    
    public void Execute()
    {
        _surface.SetDirection(_surface.GetDirection().TurnRight());
    }
}