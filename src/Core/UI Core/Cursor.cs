using DuckGame;

namespace ALib
{
    public class Cursor : BaseUI
    {
        private Sprite _sprite;

        public Cursor(Sprite sprite)
        {
            _sprite = sprite;
        }

        public override void Draw()
        {
            if(!Visible) 
                return;

            Graphics.Draw(_sprite, Mouse.x, Mouse.y);
        }
    }
}
