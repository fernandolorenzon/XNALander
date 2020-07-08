using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace XNALander.Classes
{
    public class Font
    {
        public SpriteFont SpriteFont;
        public string SpriteFontPath;
        public string Text;
        public Vector2 Position;
        public Color Color;
        public bool Visible;
        public bool MustRender;

        public Font()
        {
            this.Visible = true;
            this.MustRender = true;
        }

        public Font(string SpriteFontPath, string Text, Vector2 Position, Color Color)
        {
            this.Visible = true;
            this.SpriteFontPath = SpriteFontPath;
            this.Text = Text;
            this.Position = Position;
            this.Color = Color;
        }
    }
}
