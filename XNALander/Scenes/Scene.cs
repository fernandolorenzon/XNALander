using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNALander.Classes;

namespace XNALander.Scenes
{
    public abstract class Scene
    {
        public List<Classes.Sprite> SpriteList;
        public List<Classes.Font> FontList;
        public Color BackgroundColor;

        public Scene()
        {
            Classes.Globals.MustLoadContent = true;
            this.BackgroundColor = Color.Black;
            this.SpriteList = new List<Sprite>();
            this.FontList = new List<Font>();
            Globals.FontInfo1 = new Font("Fonts\\Info", "", new Vector2(), Color.Gold);
            Globals.FontInfo1.Text = "";
            Globals.FontInfo1.Position.X = 320;
            Globals.FontInfo1.Position.Y = Globals.Game1.Window.ClientBounds.Height - 30;
        }

        public virtual void LoadScene()
        {
            this.LoadSpriteList();
            this.LoadFontList();
        }

        public virtual void UnloadScene()
        {
            this.SpriteList = null;
            this.FontList = null;
        }

        public virtual void LoadSpriteList()
        {
            
        }

        public virtual void LoadFontList()
        {
            
        }

        public virtual void Update()
        {
        }
    }
}