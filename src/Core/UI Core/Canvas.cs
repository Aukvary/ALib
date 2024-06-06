using DuckGame;
using System.Collections.Generic;

namespace ALib;

public class Canvas : BaseUI
{
    private List<BaseUI> _children;

    public Canvas(Vec2 position = default, int depth = 0, Vec2 parent = default) :
        base(position, depth, parent) => _children = new List<BaseUI>();

    public Canvas(float x, float y, int depth = 0, Vec2 parent = default) :
        base(x, y, depth, parent) => _children = new List<BaseUI>();

    public override void Draw()
    {
        foreach (var obj in _children)
            obj.Draw();
    }

    public void Add(BaseUI child) =>
        _children.Add(child);

    public void Add(params BaseUI[] children)
    {
        foreach (var child in children)
            _children.Add(child);
    }

    public void Add(IEnumerable<BaseUI> children)
    {
        foreach (var child in children)
            _children.Add(child);
    }
}
