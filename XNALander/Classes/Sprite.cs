using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALander.Classes
{
    public class Sprite
    {
        /*
         * 
         *  1------2
         *  |      |
         *  |      | 
         *  |      | 
         *  4------3
         * 
         * */

        public Point Vertex1
        {
            get
            {
                return new Point(this.Rectangle.Location.X, this.Rectangle.Location.Y);
            }
        }

        public Point Vertex2
        {
            get
            {
                return new Point(this.Rectangle.Location.X + this.Width, this.Rectangle.Location.Y);
            }
        }

        public Point Vertex3
        {
            get
            {
                return new Point(this.Rectangle.Location.X + this.Width, this.Rectangle.Location.Y + this.Height);
            }
        }

        public Point Vertex4
        {
            get
            {
                return new Point(this.Rectangle.Location.X, this.Rectangle.Location.Y + this.Height);
            }
        }

        private float x, y;

        public string ID;
        public Rectangle Rectangle;
        public List<Texture2D> Textures;
        public Texture2D TextureCurrent;
        public List<string> TexturesPaths;
        public Color Color;
        public int FlipVCounter;
        public int FlipHCounter;
        public bool FlipV;
        public bool FlipH;
        public bool Visible;
        public float VerticalVelocity;
        public float HorizontalVelocity;
        public float TotalVelocity;
        public int DefaultHeight;
        public int DefaultWidth;
        public float VerticalVelocityLimit;
        public float HorizontalVelocityLimit;
        public float Drag;
        public float GForce;
        public bool vBouncingZone;
        public bool hBouncingZone;
        public int FlickCount;
        public float Accel;
        public float AccelMpS;
        public Enum.Direction CurrentMovingDirection;

        public float X
        {
            get {return this.x;}
            set { this.x = value; this.Rectangle.X = (int)value; }
        }

        public float Y
        {
            get { return this.y; }
            set { this.y = value; this.Rectangle.Y = (int)value; }
        }

        public int Height
        {
            get { return this.Rectangle.Height; }
            set { this.Rectangle.Height = value; }
        }

        public int Width
        {
            get { return this.Rectangle.Width; }
            set { this.Rectangle.Width = value; }
        }

        public Sprite(int DefaultWidth, int DefaultHeight, Color Color)
        {
            this.Reset(DefaultWidth, DefaultHeight);
            this.Color = Color;
            this.TexturesPaths.Add("");
        }

        public Sprite(int DefaultWidth, int DefaultHeight, string ImagePath)
        {
            this.Reset(DefaultWidth, DefaultHeight);
            this.TexturesPaths.Add(ImagePath);
        }

        private void Reset(int DefaultWidth, int DefaultHeight)
        {
            this.Rectangle = new Rectangle(0, 0, DefaultWidth, DefaultHeight);
            this.ID = "";
            this.Color = Color.White;
            this.FlipVCounter = 0;
            this.FlipHCounter = 0;
            this.FlipV = false;
            this.FlipH = false;
            this.Visible = true;
            this.VerticalVelocity = 0;
            this.HorizontalVelocity = 0;
            this.TotalVelocity = 0;
            this.Y = Rectangle.Location.Y;
            this.X = Rectangle.Location.X;
            //this.StretchedY = 0;
            //this.StretchedX = 0;
            this.DefaultHeight = this.Height;
            this.DefaultWidth = this.Width;
            this.VerticalVelocityLimit = 50;
            this.HorizontalVelocityLimit = 50;
            this.Drag = 0;
            this.GForce = 0;
            this.vBouncingZone = false;
            this.hBouncingZone = false;
            this.FlickCount = 0;
            this.Accel = 0;
            this.AccelMpS = 0;
            this.CurrentMovingDirection = Enum.Direction.Still;
            this.Textures = new List<Texture2D>();
            this.TexturesPaths = new List<string>();
        }
    }
}
