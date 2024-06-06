using DuckGame;
using System;

namespace ALib;

public class Button : Image
{
    public event Action OnClickEvent;

    public Button(Sprite sprite, Vec2 position = default, int depth = 0, Color? color = null, Vec2 parent = default) :
        base(sprite, position, depth, color, parent) { }

    public Button(Vec2 size, Vec2 position = default, int depth = 0, Color? color = null, Vec2 parent = default) :
        base(size, position, depth, color, parent) { }

    public Button(Sprite sprite, float x = 0, float y = 0, int depth = 0, Color? color = null, Vec2 parent = default) :
        base(sprite, x, y, depth, color, parent) { }

    public Button(Vec2 size, float x = 0, float y = 0, int depth = 0, Color? color = null, Vec2 parent = default) :
        base(size, x, y, depth, color, parent) { }

    public override void Draw()
    {
        if (!Visible)
            return;
        base.Draw();
        if(Rectangle.Contains(Mouse.position) && Keyboard.Pressed(Keys.MouseLeft))
            OnClickEvent?.Invoke();
    }
}
