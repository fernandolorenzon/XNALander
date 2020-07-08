using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using XNALander.StaticFunctions;
using XNALander.Classes;
using XNALander.Scenes;

namespace XNALander
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region -- Properties --

        public delegate void UpdateForLander();
        public delegate void UpdateForArea();
        public delegate void UpdateForOre();
        public delegate void UpdateForIntro();
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Classes.Sprite Sprite;

        public SpriteFont fps;

        #endregion

        #region -- Constructors --

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        #endregion

        #region -- Methods --

        protected override void Initialize()
        {
            Globals.Game1 = this;
            this.IsFixedTimeStep = true;
            //this.TargetElapsedTime = new TimeSpan((int)(Globals.TimerInterval * 10));
            //Globals.TimerInterval = (float)(this.TargetElapsedTime.Ticks / 10000);
            this.graphics.PreferredBackBufferWidth = 800;
            this.graphics.PreferredBackBufferHeight = 600;
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
            FunctionsGame.LoadGame();

            Globals.Song = Content.Load<Song>("Songs\\Intro");
            Globals.SFXCollected = Content.Load<SoundEffect>("Sounds\\collected");
            Globals.SFXCrash = Content.Load<SoundEffect>("Sounds\\crash");
            Globals.SFXExplosion = Content.Load<SoundEffect>("Sounds\\explosion");
            Globals.SFXFloat = Content.Load<SoundEffect>("Sounds\\float");
            Globals.SFXLanding = Content.Load<SoundEffect>("Sounds\\landing");
            Globals.SFXRocket = Content.Load<SoundEffect>("Sounds\\rocket");
            Globals.SFXSelected = Content.Load<SoundEffect>("Sounds\\selected");
            Globals.SFXSpecial = Content.Load<SoundEffect>("Sounds\\special");
            Globals.SFXUnlocked = Content.Load<SoundEffect>("Sounds\\unlocked");

            Globals.SFXRocketInstance = Globals.SFXRocket.CreateInstance();
            Globals.SFXFloatInstance = Globals.SFXFloat.CreateInstance();
            Globals.SFXSpecialInstance = Globals.SFXSpecial.CreateInstance();

            Globals.CurrentScene = new SceneTitle();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.fps = Content.Load<SpriteFont>("Fonts\\MenuOptions");
            
            Globals.CurrentScene.LoadScene();

            if ((Globals.CurrentScene is SceneAction) || (Globals.CurrentScene is SceneEnding))
            {
                MediaPlayer.Stop();
            }
            else if (MediaPlayer.State == MediaState.Stopped)
            {
                MediaPlayer.IsRepeating = true;
                MediaPlayer.Play(Globals.Song);
            }

            foreach (Classes.Sprite sprite in Globals.CurrentScene.SpriteList)
            {
                for (int i = 0; i < sprite.TexturesPaths.Count; i++)
                {
                    Texture2D texture;

                    if (sprite.TexturesPaths[i] != "")
                    {
                        texture = Content.Load<Texture2D>(sprite.TexturesPaths[i]);
                    }
                    else
                    {
                        Color[] colorData = new Color[sprite.Width * sprite.Height];

                        for (int j = 0; j < colorData.Length; j++)
                        {
                            colorData[j] = Color.White;
                        }

                        texture = new Texture2D(this.GraphicsDevice, sprite.Width, sprite.Height);
                        texture.SetData<Color>(colorData);
                    }

                    sprite.Textures.Add(texture);
                }

                sprite.TextureCurrent = sprite.Textures[0];
            }

            foreach (Classes.Font font in Globals.CurrentScene.FontList)
            {
                font.SpriteFont = Content.Load<SpriteFont>(font.SpriteFontPath);
            }

            Globals.MustLoadContent = false;
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            Globals.CurrentScene.Update();

            base.Update(gameTime);

            if (Globals.MustLoadContent)
            {
                this.LoadContent();
            }
            else
            {
                this.Draw(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Globals.CurrentScene.BackgroundColor);
            
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.SaveState);

            foreach (Sprite sprite in Globals.CurrentScene.SpriteList)
            {
                if (sprite.Visible)
                {
                    spriteBatch.Draw(sprite.TextureCurrent, sprite.Rectangle, sprite.Color);
                }
            }

            foreach (Font font in Globals.CurrentScene.FontList)
            {
                if (font.Visible)
                {
                    spriteBatch.DrawString(font.SpriteFont, font.Text, font.Position, font.Color);
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        #endregion
    }
}
