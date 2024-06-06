using DuckGame;

namespace ALib;

public abstract class BaseUI
{
    private bool _visible;
    private int _depth;

    private Vec2 _position;
    private Vec2 _parentPosition;

    public bool Visible
    {
        get => _visible;
        set => _visible = value;
    }
    public int Depth => _depth;

    public virtual Vec2 LocalPosition
    {
        get => _position;
        set => _position = value;
    }
    public Vec2 Position => _position + _parentPosition;

    public BaseUI(Vec2 position = default, int depth = 0, Vec2 parent = default)
    {
        LocalPosition = position;
        _parentPosition = parent;
        _depth = depth;
    }
    public BaseUI(float x, float y, int depth = 0, Vec2 parent = default)
    {
        LocalPosition = new Vec2(x, y);
        _parentPosition = parent;
        _depth = depth;
    }

    public abstract void Draw();
}
