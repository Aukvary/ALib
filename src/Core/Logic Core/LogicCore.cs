namespace ALib;

public abstract class LogicCore<V, C>
    where V : IVisual, new()
    where C : IController, new()
{
    private V _visual;
    private C _controller;

    protected V Visual => _visual;
    protected C Controller => _controller;

    public LogicCore()
    {
        _visual = new V();
        _controller = new C();
    }
}
