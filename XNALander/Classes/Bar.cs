using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace XNALander.Classes
{
    public class Bar
    {
        private Sprite spriteBackground;
        private Sprite spriteForeground;
        private float value;
        public float MaxValue;
        public List<Sprite> Sprites;
        private float x, y;
        public Color ForeColorDefault;
        public int FlickCount;

        public float X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
                this.spriteBackground.X = value;
                this.spriteForeground.X = value + 1;
            }
        }

        public float Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
                this.spriteBackground.Y = value;
                this.spriteForeground.Y = value + 1;
            }
        }

        public Color ForeColor
        {
            get
            {
                return this.spriteForeground.Color;
            }
            set
            {
                this.spriteForeground.Color = value;
            }
        }

        public Color BackColor
        {
            get
            {
                return this.spriteBackground.Color;
            }
            set
            {
                this.spriteBackground.Color = value;
            }
        }

        public float Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (value > this.MaxValue)
                {
                    this.value = this.MaxValue;
                }
                else
                {
                    this.value = value;
                }

                this.AjustBar();
            }
        }

        public int Width
        {
            get
            {
                return this.spriteBackground.Width;
            }

            set
            {
                this.spriteBackground.Width = value;
                this.spriteForeground.Width = value - 2;
            }
        }

        public int Height
        {
            get
            {
                return this.spriteBackground.Height;
            }

            set
            {
                this.spriteBackground.Height = value;
                this.spriteForeground.Height = value - 2;
            }
        }

        public Bar(Color ForeColor, Color BackColor, int Width, int Height)
        {
            this.spriteBackground = new Sprite(Width, Height, BackColor);
            this.spriteForeground = new Sprite(Width - 2, Height - 2, ForeColor);
            this.ForeColorDefault = ForeColor;

            this.Sprites = new List<Sprite>();
            this.Sprites.Add(this.spriteBackground);
            this.Sprites.Add(this.spriteForeground);
            this.value = 1;
            this.MaxValue = 1;
            this.X = 0;
            this.Y = 0;

            this.spriteForeground.X = this.x + 1;
            this.spriteForeground.Y = this.y + 1;
            this.spriteBackground.X = this.x;
            this.spriteBackground.Y = this.y;

            this.FlickCount = 0;
        }

        private void AjustBar()
        {
            float width = (this.value * this.spriteBackground.Width) / this.MaxValue;
            this.spriteForeground.Width = (int)width;
        }

    }
}
