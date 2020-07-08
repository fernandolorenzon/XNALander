using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNALander.StaticFunctions;
using XNALander.Classes;

namespace XNALander.Scenes
{
    public class SceneAction : Scene
    {
        public Font FontMessage1;
        public Font FontMessage2;

        public SceneAction()
        {
            this.BackgroundColor = Color.Gray;
        }

        public override void LoadScene()
        {
            if (Classes.Globals.SelectedShip == null)
            {
                Classes.Globals.SelectedShip = new XNALander.Classes.SpriteShip(Enum.Ships.Type01, 32, 32);
            }

            FunctionsStage.InitializeStage();
            
            base.LoadScene();
        }

        public override void UnloadScene()
        {
            this.FontMessage1 = null;
            this.FontMessage2 = null;
            base.UnloadScene();
        }

        public override void LoadSpriteList()
        {
            this.SpriteList = new System.Collections.Generic.List<Sprite>();

            this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteAction);
            this.SpriteList.Add(Classes.Globals.SelectedShip);
            this.SpriteList.Add(Classes.Globals.SelectedShip.SpriteLeft);
            this.SpriteList.Add(Classes.Globals.SelectedShip.SpriteRight);
            this.SpriteList.Add(Classes.Globals.SelectedShip.SpriteTop);
            this.SpriteList.Add(Classes.Globals.SelectedShip.SpriteBotton);
            this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteLZ);

            if (Classes.Globals.SelectedStage.SpriteAsteroid1 != null)
            {
                this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteAsteroid1);
            }

            if (Classes.Globals.SelectedStage.SpriteAsteroid2 != null)
            {
                this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteAsteroid2);
            }

            if (Classes.Globals.SelectedStage.SpriteMetroid != null)
            {
                this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteMetroid);
            }

            if (Classes.Globals.SelectedStage.SpriteRedOre != null)
            {
                this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteRedOre);
            }

            if (Classes.Globals.SelectedStage.SpriteGreenOre != null)
            {
                this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteGreenOre);
            }

            if (Classes.Globals.SelectedStage.SpriteBlueOre != null)
            {
                this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteBlueOre);
            }

            this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteHudLocation);
            this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteHudConsole);
            this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteHud);
            this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteLocation);
            this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteShipLeft1);
            this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteShipLeft2);
            this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteLED);
            this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteCursor);
            this.SpriteList.Add(Classes.Globals.SelectedStage.SpriteCursorDanger);
            
            this.SpriteList.AddRange(Classes.Globals.SelectedStage.BarFuel.Sprites);
            this.SpriteList.AddRange(Classes.Globals.SelectedStage.BarSpeed.Sprites);
            this.SpriteList.AddRange(Classes.Globals.SelectedStage.BarSpeedToLZ.Sprites);
        }

        public override void LoadFontList()
        {
            this.FontMessage1 = new XNALander.Classes.Font("Fonts\\Message", "", new Vector2(200, 250), Color.White);
            this.FontMessage2 = new XNALander.Classes.Font("Fonts\\Message", "", new Vector2(200, 300), Color.White);
            this.FontList = new System.Collections.Generic.List<Font>();

            this.FontList.Add(this.FontMessage1);
            this.FontList.Add(this.FontMessage2);
            this.FontList.Add(Globals.SelectedStage.FontSpecial);
            this.FontList.Add(Globals.SelectedStage.FontLocationName);
            this.FontList.Add(Globals.SelectedStage.FontCursor);

            this.FontList.Add(Globals.SelectedStage.FontFuel);
            this.FontList.Add(Globals.SelectedStage.FontSpeed);
            this.FontList.Add(Globals.SelectedStage.FontSpeedToLZ);

            this.FontList.Add(Globals.SelectedStage.FontGravity);
            this.FontList.Add(Globals.SelectedStage.FontWind);
            this.FontList.Add(Globals.SelectedStage.FontCursorDanger);
        }

        public override void Update()
        {
            Functions.KeyReading();

            if (Globals.EscKeyPressed)
            {
                if (Globals.GameType == Enum.GameType.Arcade)
                {
                    Globals.CurrentScene = new SceneChooseArea();
                }
                else
                {
                    Globals.CurrentScene = new SceneChooseStage();
                }
            }

            Functions.ApplyPause(!Globals.Collided, this.FontMessage1);
            FunctionsGame.JumpStage();

            if (Globals.Collided)
            {
                Globals.SelectedShip.SpriteTop.Visible = false;
                Globals.SelectedShip.SpriteBotton.Visible = false;
                Globals.SelectedShip.SpriteLeft.Visible = false;
                Globals.SelectedShip.SpriteRight.Visible = false;

                if (!Globals.Landed)
                {
                    Functions.ShowMessage(this.FontMessage1, Color.Red, "Colidiu!");
                    Functions.ShowMessage(this.FontMessage2, Color.Red, "Pressione Enter para continuar...");
                }
                else
                {
                    Functions.ShowMessage(this.FontMessage1, Color.LimeGreen, "Pousou!");
                    Functions.ShowMessage(this.FontMessage2, Color.LimeGreen, "Pressione Enter para continuar...");
                }

                Functions.CenterFont(this.FontMessage1, Globals.SelectedStage.SpriteAction);
                Functions.CenterFont(this.FontMessage2, Globals.SelectedStage.SpriteAction);

                FunctionsGame.ApplyPostStage();
            }
            else
            {
                if (!Globals.Paused)
                {
                    if (!Globals.EndedIntro)
                    {
                        this.UpdateIntro();
                    }
                    else
                    {
                        this.UpdateAction();

                        Globals.UpdateLander.Invoke();

                        Globals.UpdateArea.Invoke();

                        Globals.UpdateOre.Invoke();

                        FunctionsStage.UpdateStage();
                    }
                }
            }
        }


        private void UpdateIntro()
        {
            if (Globals.SelectedShip.Y < 50)
            {
                Globals.SelectedShip.X = 100;
                Globals.SelectedShip.Y += 1F;
                Functions.MoveSprite(Globals.SelectedShip, (int)Globals.SelectedShip.X, (int)Globals.SelectedShip.Y);
            }
            else
            {
                if (this.FontMessage1.Text == "")
                {
                    Functions.ShowMessage(this.FontMessage1, Color.White, "Mova para começar");
                }

                Globals.SelectedShip.VerticalVelocity = 0F;

                Functions.KeyReading();
            }

            if (Globals.UpKeyDown || Globals.DownKeyDown || Globals.LeftKeyDown || Globals.RightKeyDown)
            {
                Functions.ShowMessage(this.FontMessage1, Color.White, "");
                Globals.SelectedShip.TotalVelocity = 0;
                Globals.EndedIntro = true;
                Globals.UpdateIntro = new Game1.UpdateForIntro(FunctionsGame.UpdateNull);
            }
        }

        private void UpdateAction()
        {
            if (Globals.SelectedShip.Fuel > 0)
            {
                FunctionsShip.ApplyControls(Globals.SelectedShip);
            }

            Functions.ApplyConstantForce(Globals.SelectedShip, Globals.SelectedStage);
            Functions.ApplyDrag(Globals.SelectedShip, Globals.SelectedStage, Enum.Axis.Horizontal);
            FunctionsShip.MoveShipSprites(Globals.SelectedShip);
            Functions.ApplyStretch(Globals.SelectedShip.SpriteBotton, Enum.Direction.Down, (Globals.SelectedShip.VerticalVelocity * -1) / 6, 32, 64);
            Functions.MoveSprite(Globals.SelectedStage.SpriteLZ);
            Functions.WarpSprite(Globals.SelectedStage.SpriteLZ, Globals.SelectedStage.SpriteAction, Enum.Axis.All);

            if (Globals.CurrentStage == 0)
            {
                Functions.WarpSprite(Globals.SelectedShip, Globals.SelectedStage.SpriteAction, Enum.Axis.All);
            }
            else
            {
                Functions.WarpSprite(Globals.SelectedShip, Globals.SelectedStage.SpriteAction, Enum.Axis.Horizontal);
            }

            FunctionsGame.VerifyCollision(Globals.SelectedShip, Globals.SelectedStage.SpriteLZ, ref Globals.Landed);

            if (Globals.Landed)
            {
                Globals.SFXLanding.Play();
            }
        }
    }
}