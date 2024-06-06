using DuckGame;

namespace ALib;

public class Image : Canvas
{
    private Sprite _sprite;

    private Rectangle _rectangle;

    private Vec2 _size;

    private Vec2 _scale;

    private Color _color;

    public override Vec2 LocalPosition 
    { 
        get => base.LocalPosition;
        set
        {
            base.LocalPosition = value;
            _rectangle.x = value.x;
            _rectangle.y = value.y;
        }
    }

    public Sprite Sprite
    {
        get => _sprite;
        set
        {
            _sprite = value;

            Size = new Vec2(value.width, value.height);
        }
    }

    public Rectangle Rectangle => _rectangle;

    public Vec2 Size
    {
        get => _size;

        set
        {
            _size = value;
            _rectangle.width = value.x;
            _rectangle.height = value.y;
        }
    }

    public Vec2 Scale
    {
        get => _scale;
        set => _scale = value;
    }

    public Color Color
    {
        get => _color;
        set
        {
            _color = value;
            if(Sprite != null) 
                Sprite.color = _color;
        }
    }

    public Image(Sprite sprite, Vec2 position = default, int depth = 0, Color? color = null, Vec2 parent = default) :
        base(position, depth, parent)
    {
        Sprite = sprite;
        Color = color ?? Color.White;
    }

    public Image(Vec2 size, Vec2 position = default, int depth = 0, Color? color = null, Vec2 parent = default) :
        base(position, depth, parent)
    {
        Size = size;
        Color = color ?? Color.White;
    }

    public Image(Sprite sprite, float x = 0, float y = 0, int depth = 0, Color? color = null, Vec2 parent = default) :
        base(x, y, depth, parent)
    {
        Sprite = sprite;
        Color = color ?? Color.White;
    }

    public Image(Vec2 size, float x = 0, float y = 0, int depth = 0, Color? color = null, Vec2 parent = default) :
        base(x, y, depth, parent)
    {
        Size = size;
        Color = color ?? Color.White;
    }


    public override void Draw()
    {
        if (!Visible)
            return;
        base.Draw();

        if(Sprite != null)
        {
            Graphics.Draw(Sprite, Position.x, Position.y, Depth);
        }
        else
        {
            Graphics.DrawRect(_rectangle, Color, Depth);
        }
    }
}
