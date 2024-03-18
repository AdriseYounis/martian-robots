namespace MartianRobots.Commands;

public class ForwardCommand : ICommand
{
    private readonly MarsSurface _surface;

    public ForwardCommand(MarsSurface marsSurface)
    {
        _surface = marsSurface;
    }
    
    public void Execute()
    {
        throw new NotImplementedException();
    }
}