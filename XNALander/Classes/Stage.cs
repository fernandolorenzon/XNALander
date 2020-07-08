using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using XNALander.StaticFunctions;

namespace XNALander.Classes
{
    public class Stage
    {
        public int StageNumber;
        public float ConstHForce;
        public float ConstVForce;
        public float Drag;
        public string Name;
        public string Location;
        public string WindDirection;
        public Sprite SpriteAction;
        public Sprite SpriteHud;
        public Sprite SpriteHudLocation;
        public Sprite SpriteHudConsole;
        public Sprite SpriteLocation;
        public Sprite SpriteLZ;
        public Sprite SpriteShipLeft1;
        public Sprite SpriteShipLeft2;
        public Sprite SpriteAsteroid1;
        public Sprite SpriteAsteroid2;
        public Sprite SpriteMetroid;
        public Sprite SpriteRedOre;
        public Sprite SpriteBlueOre;
        public Sprite SpriteGreenOre;
        public Sprite SpriteCursor;
        public Sprite SpriteLED;
        public Sprite SpriteCursorDanger;

        public Bar BarFuel;
        public Bar BarSpeed;
        public Bar BarSpeedToLZ;

        public Font FontFuel;
        public Font FontSpeed;
        public Font FontSpeedToLZ;

        public Font FontCursor;
        public Font FontSpecial;
        public Font FontCursorDanger;
        public Font FontLocationName;

        public Font FontGravity;
        public Font FontWind;

        public Stage(int StageNumber)
        {
            this.StageNumber = StageNumber;
            this.InitializeSprites();
            this.InitializeFonts();
            this.LoadStageLogic();
            this.CreateLayout();
        }

        private void InitializeSprites()
        {
            this.SpriteLZ = new Sprite(32, 32, "Images\\Misc\\LZ");
            this.SpriteAction = new Sprite(0, 0, Color.Green);
            this.SpriteHud = new Sprite(0, 0, Color.Teal);
            this.SpriteHudLocation = new Sprite(0, 0, Color.Black);

            this.SpriteCursor = new Sprite(16, 16, "Images\\Misc\\OffMapCursor");
            this.SpriteCursor.Visible = false;
            this.SpriteLED = new Sprite(16, 16, "Images\\Misc\\LED_OFF");
            this.SpriteLED.TexturesPaths.Add("Images\\Misc\\LED_ON");
            this.SpriteHudConsole = new Sprite(0, 0, Color.Black);

            this.SpriteShipLeft1 = new Sprite(Globals.SelectedShip.DefaultWidth, Globals.SelectedShip.DefaultHeight, Globals.SelectedShip.TexturesPaths[0]);
            this.SpriteShipLeft2 = new Sprite(Globals.SelectedShip.DefaultWidth, Globals.SelectedShip.DefaultHeight, Globals.SelectedShip.TexturesPaths[0]);

            this.BarSpeed = new Bar(Color.LightSeaGreen, Color.Black, 0, 20);
            this.BarSpeedToLZ = new Bar(Color.LightSeaGreen, Color.Black, 0, 20);
            this.BarFuel = new Bar(Color.SpringGreen, Color.Black, 0, 20);

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre = new Sprite(16, 16, "Images\\Misc\\Red_Ore");
                this.SpriteGreenOre = new Sprite(16, 16, "Images\\Misc\\Green_Ore");
                this.SpriteBlueOre = new Sprite(16, 16, "Images\\Misc\\Blue_Ore");
            }

            this.SpriteCursorDanger = new Sprite(16, 16, "Images\\Misc\\OffMapCursor");
        }

        private void InitializeFonts()
        {
            this.FontFuel = new Font("Fonts\\MenuOptions", "Combustivel", new Vector2(0, 0), Color.Black);
            this.FontSpeed = new Font("Fonts\\MenuOptions", "Velocidade", new Vector2(0, 0), Color.Black);
            this.FontSpeedToLZ = new Font("Fonts\\MenuOptions", "Veloc. p/ LZ", new Vector2(0, 0), Color.Black);
            this.FontSpecial = new Font("Fonts\\MenuOptions", "Especial", new Vector2(0, 0), Color.Black);
            this.FontCursor = new Font("Fonts\\MenuOptions", "00", new Vector2(0, 0), Color.Red);
            this.FontCursor.Visible = false;
            this.FontGravity = new Font("Fonts\\Console", "", new Vector2(0, 0), Color.Lime);
            this.FontWind = new Font("Fonts\\Console", "", new Vector2(0, 0), Color.Lime);
            this.FontCursorDanger = new Font("Fonts\\MenuOptions", "Perigo", new Vector2(0, 0), Color.Red);
            this.FontLocationName = new Font("Fonts\\Console", "", new Vector2(0, 0), Color.WhiteSmoke);

            this.FontGravity.Text = "Gravidade: \r\n{0}m/s²";
            this.FontWind.Text = "Vento: \r\n{0}m/s {1}";
        }

        private void CreateLayout()
        {
            this.WindDirection = "N";
            this.SpriteLZ.X = (this.SpriteAction.Width / 2) - (this.SpriteLZ.Width / 2);
            this.SpriteLZ.Y = this.SpriteAction.Height - this.SpriteLZ.Height;

            const int borderSize = 3;

            this.SpriteHudLocation.Width = 130;
            this.SpriteHudLocation.Height = 130;
            this.SpriteHudLocation.X = Globals.Game1.Window.ClientBounds.Width - this.SpriteHudLocation.Width;
            this.SpriteHudLocation.Y = Globals.Game1.Window.ClientBounds.Height - this.SpriteHudLocation.Height;

            this.SpriteHudConsole.Width = this.SpriteHudLocation.Width;
            this.SpriteHudConsole.Height = this.SpriteHudLocation.Height;
            this.SpriteHudConsole.X = this.SpriteHudLocation.X;
            this.SpriteHudConsole.Y = this.SpriteHudLocation.Y - this.SpriteHudConsole.Height - borderSize;

            this.SpriteHud.Width = this.SpriteHudLocation.Width;
            this.SpriteHud.Height = Globals.Game1.Window.ClientBounds.Height - borderSize - this.SpriteHudConsole.Height - borderSize - this.SpriteHudLocation.Height;
            this.SpriteHud.Height = (int)this.SpriteHudConsole.Y - borderSize;
            this.SpriteHud.X = this.SpriteHudLocation.X;
            this.SpriteHud.Y = 0;

            this.SpriteAction.X = 0;
            this.SpriteAction.Y = 0;

            this.SpriteAction.Width = Globals.Game1.Window.ClientBounds.Width - this.SpriteHud.Width - borderSize;
            this.SpriteAction.Height = Globals.Game1.Window.ClientBounds.Height;

            this.SpriteLocation.X = this.SpriteHudLocation.X + 40;
            this.SpriteLocation.Y = this.SpriteHudLocation.Y + 60;

            this.SpriteShipLeft1.X = this.SpriteHud.X + 5;
            this.SpriteShipLeft1.Y = this.SpriteHud.Height - 52;

            this.SpriteShipLeft2.X = this.SpriteShipLeft1.X + 40;
            this.SpriteShipLeft2.Y = this.SpriteShipLeft1.Y;

            this.BarSpeed.X = this.SpriteHud.X + 5;
            this.BarSpeed.Y = 20;
            this.BarSpeed.Width = this.SpriteHud.Width - 10;

            this.BarSpeedToLZ.X = this.SpriteHud.X + 5;
            this.BarSpeedToLZ.Y = 80;
            this.BarSpeedToLZ.Width = this.SpriteHud.Width - 10;

            this.BarFuel.X = this.SpriteHud.X + 5;
            this.BarFuel.Y = 160;
            this.BarFuel.Width = this.SpriteHud.Width - 10;

            if (Globals.GameType == Enum.GameType.Free || Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteShipLeft1.Visible = false;
                this.SpriteShipLeft2.Visible = false;
            }

            this.FontCursor.Position.Y = this.SpriteCursor.Height + 1;

            this.FontFuel.Position.X = this.BarFuel.X;
            this.FontFuel.Position.Y = this.BarFuel.Y - 15;

            this.FontSpeed.Position.X = this.BarSpeed.X;
            this.FontSpeed.Position.Y = this.BarSpeed.Y - 15;

            this.FontSpeedToLZ.Position.X = this.BarSpeedToLZ.X;
            this.FontSpeedToLZ.Position.Y = this.BarSpeedToLZ.Y - 15;

            this.FontSpecial.Position.X = this.SpriteHud.X + 5;
            this.FontSpecial.Position.Y = 200;

            this.SpriteLED.X = this.FontSpecial.Position.X + 50;
            this.SpriteLED.Y = this.FontSpecial.Position.Y;

            this.FontGravity.Position.X = this.SpriteHudConsole.X + 5;
            this.FontGravity.Position.Y = this.SpriteHudConsole.Y + 5;

            this.FontWind.Position.X = this.SpriteHudConsole.X + 5;
            this.FontWind.Position.Y = this.SpriteHudConsole.Y + 50;

            this.FontLocationName.Position.X = this.SpriteHudLocation.X + 5;
            this.FontLocationName.Position.Y = this.SpriteHudLocation.Y + 5;
            this.FontLocationName.Text = this.Name + ":\r\n" + this.Location;

            this.SpriteCursorDanger.Y = this.BarSpeedToLZ.Y + this.BarSpeedToLZ.Height + 2;
            this.FontCursorDanger.Position.Y = this.SpriteCursorDanger.Y + this.SpriteCursorDanger.Height + 2;
        }

        private void LoadStageLogic()
        {
            this.ConstHForce = 0;
            this.ConstVForce = 0;
            this.Drag = Functions.ConvertMpSToVelocity(1F, Globals.TimerInterval, Globals.PixelToMeter);

            if (StageNumber == 0)
            {
                Globals.UpdateArea = new XNALander.Game1.UpdateForArea(FunctionsStage.UpdateForAreaFree);

                this.LoadStageFree();
            }
            else if (StageNumber < 16)
            {
                this.LoadArea1();
                Globals.UpdateArea = new XNALander.Game1.UpdateForArea(FunctionsStage.UpdateForArea1);

                if (StageNumber == 11)
                {
                    this.LoadStage1_1();
                }
                else if (StageNumber == 12)
                {
                    this.LoadStage1_2();
                }
                else if (StageNumber == 13)
                {
                    this.LoadStage1_3();
                }
                else if (StageNumber == 14)
                {
                    this.LoadStage1_4();
                }
                else if (StageNumber == 15)
                {
                    this.LoadStage1_5();
                }
            }
            else if (StageNumber < 26)
            {
                this.LoadArea2();
                Globals.UpdateArea = new XNALander.Game1.UpdateForArea(FunctionsStage.UpdateForArea2);

                if (StageNumber == 21)
                {
                    this.LoadStage2_1();
                }
                else if (StageNumber == 22)
                {
                    this.LoadStage2_2();
                }
                else if (StageNumber == 23)
                {
                    this.LoadStage2_3();
                }
                else if (StageNumber == 24)
                {
                    this.LoadStage2_4();
                }
                else if (StageNumber == 25)
                {
                    this.LoadStage2_5();
                }
            }
            else if (StageNumber < 36)
            {
                this.LoadArea3();
                Globals.UpdateArea = new XNALander.Game1.UpdateForArea(FunctionsStage.UpdateForArea3);

                if (StageNumber == 31)
                {
                    this.LoadStage3_1();
                }
                else if (StageNumber == 32)
                {
                    this.LoadStage3_2();
                }
                else if (StageNumber == 33)
                {
                    this.LoadStage3_3();
                }
                else if (StageNumber == 34)
                {
                    this.LoadStage3_4();
                }
                else if (StageNumber == 35)
                {
                    this.LoadStage3_5();
                }
            }
            else if (StageNumber < 46)
            {
                this.LoadArea4();
                Globals.UpdateArea = new XNALander.Game1.UpdateForArea(FunctionsStage.UpdateForArea4);

                if (StageNumber == 41)
                {
                    this.LoadStage4_1();
                }
                else if (StageNumber == 42)
                {
                    this.LoadStage4_2();
                }
                else if (StageNumber == 43)
                {
                    this.LoadStage4_3();
                }
                else if (StageNumber == 44)
                {
                    this.LoadStage4_4();
                }
                else if (StageNumber == 45)
                {
                    this.LoadStage4_5();
                }
            }
            else if (StageNumber < 56)
            {
                this.LoadArea5();
                Globals.UpdateArea = new XNALander.Game1.UpdateForArea(FunctionsStage.UpdateForArea5);

                if (StageNumber == 51)
                {
                    this.LoadStage5_1();
                }
                else if (StageNumber == 52)
                {
                    this.LoadStage5_2();
                }
                else if (StageNumber == 53)
                {
                    this.LoadStage5_3();
                }
                else if (StageNumber == 54)
                {
                    this.LoadStage5_4();
                }
                else if (StageNumber == 55)
                {
                    this.LoadStage5_5();
                }
            }
            else if (StageNumber < 66)
            {
                this.LoadArea6();
                Globals.UpdateArea = new XNALander.Game1.UpdateForArea(FunctionsStage.UpdateForArea6);

                if (StageNumber == 61)
                {
                    this.LoadStage6_1();
                }
                else if (StageNumber == 62)
                {
                    this.LoadStage6_2();
                }
                else if (StageNumber == 63)
                {
                    this.LoadStage6_3();
                }
                else if (StageNumber == 64)
                {
                    this.LoadStage6_4();
                }
                else if (StageNumber == 65)
                {
                    this.LoadStage6_5();
                }
            }
        }

        private void LoadArea1()
        {
            this.SpriteLZ.Width = 70;
            this.SpriteLZ.Height = 20;
            this.ConstHForce = 0;
        }

        private void LoadArea2()
        {
            this.SpriteLZ.Width = 70;
            this.SpriteLZ.Height = 20;

            float h = Functions.ConvertMpSToVelocity(200F, Globals.TimerInterval, Globals.PixelToMeter);

            if (Globals.Random.Next(1, 10) > 5)
            {
                h *= -1;
            }

            this.SpriteLZ.HorizontalVelocity = h;

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                h = Functions.ConvertMpSToVelocity(200F, Globals.TimerInterval, Globals.PixelToMeter);

                if (Globals.Random.Next(1, 10) > 5)
                {
                    h *= -1;
                }

                this.SpriteRedOre.HorizontalVelocity = h;
                this.SpriteGreenOre.HorizontalVelocity = h;
                this.SpriteBlueOre.HorizontalVelocity = h;
            }
        }

        private void LoadArea3()
        {
            this.SpriteLZ.Width = 70;
            this.SpriteLZ.Height = 20;

            float h = Functions.ConvertMpSToVelocity(200F, Globals.TimerInterval, Globals.PixelToMeter);

            if (Globals.Random.Next(1, 10) > 5)
            {
                h *= -1;
            }

            this.SpriteLZ.HorizontalVelocity = h;

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                h = Functions.ConvertMpSToVelocity(400F, Globals.TimerInterval, Globals.PixelToMeter);

                if (Globals.Random.Next(1, 10) > 5)
                {
                    h *= -1;
                }

                this.SpriteRedOre.HorizontalVelocity = h;
                this.SpriteGreenOre.HorizontalVelocity = h;
                this.SpriteBlueOre.HorizontalVelocity = h;
            }
        }

        private void LoadArea4()
        {
            this.SpriteAsteroid1 = new Sprite(32, 22, "Images\\Misc\\Asteroid");

            this.SpriteLZ.Width = 70;
            this.SpriteLZ.Height = 20;

            float h = Functions.ConvertMpSToVelocity(120F, Globals.TimerInterval, Globals.PixelToMeter);

            this.SpriteLZ.VerticalVelocity = h * -1;

            if (Globals.Random.Next(1, 10) > 5)
            {
                h *= -1;
            }

            this.SpriteLZ.HorizontalVelocity = h;

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                h = Functions.ConvertMpSToVelocity(250F, Globals.TimerInterval, Globals.PixelToMeter);

                if (Globals.Random.Next(1, 10) > 5)
                {
                    h *= -1;
                }
             
                this.SpriteRedOre.HorizontalVelocity = h;
                this.SpriteGreenOre.HorizontalVelocity = h;
                this.SpriteBlueOre.HorizontalVelocity = h;

                this.SpriteRedOre.VerticalVelocity = h * 0.8F;
                this.SpriteGreenOre.VerticalVelocity = h * 0.8F;
                this.SpriteBlueOre.VerticalVelocity = h * 0.8F;
            }

            this.SpriteAsteroid1.Visible = true;
            this.SpriteAsteroid1.HorizontalVelocity = 5;
        }

        private void LoadArea5()
        {
            this.SpriteAsteroid1 = new Sprite(32, 22, "Images\\Misc\\Asteroid");
            this.SpriteAsteroid2 = new Sprite(32, 22, "Images\\Misc\\Asteroid");

            this.SpriteLZ.Width = 50;
            this.SpriteLZ.Height = 22;

            float h = Functions.ConvertMpSToVelocity(400F, Globals.TimerInterval, Globals.PixelToMeter);

            if (Globals.Random.Next(1, 10) > 5)
            {
                h *= -1;
            }

            this.SpriteLZ.HorizontalVelocity = h;

            this.SpriteAsteroid1.Visible = true;
            this.SpriteAsteroid2.Visible = true;

            h = Functions.ConvertMpSToVelocity(500F, Globals.TimerInterval, Globals.PixelToMeter);

            this.SpriteAsteroid1.HorizontalVelocity = h;
            this.SpriteAsteroid2.HorizontalVelocity = h;

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                h = Functions.ConvertMpSToVelocity(400F, Globals.TimerInterval, Globals.PixelToMeter);

                if (Globals.Random.Next(1, 10) > 5)
                {
                    h *= -1;
                }
                 
                this.SpriteLZ.HorizontalVelocity = h;
                this.SpriteRedOre.HorizontalVelocity = h;
                this.SpriteGreenOre.HorizontalVelocity = h;
                this.SpriteBlueOre.HorizontalVelocity = h;

                this.SpriteRedOre.VerticalVelocity = h;
                this.SpriteGreenOre.VerticalVelocity = h;
                this.SpriteBlueOre.VerticalVelocity = h;
            }
        }

        private void LoadArea6()
        {
            this.SpriteLZ.Width = 60;
            this.SpriteLZ.Height = 22;

            this.SpriteMetroid = new Sprite(16, 16, "Images\\Misc\\Metroid");

            Globals.SelectedShip.GForce = Functions.ConvertMpSToVelocity(50F, Globals.TimerInterval, Globals.PixelToMeter);

            float h = Functions.ConvertMpSToVelocity(200F, Globals.TimerInterval, Globals.PixelToMeter);

            if (Globals.Random.Next(1, 10) > 5)
            {
                h *= -1;
            }

            this.SpriteLZ.HorizontalVelocity = h;

            this.SpriteMetroid.Visible = true;

            if ((this.SpriteMetroid.X < -150 || this.SpriteMetroid.X > this.SpriteAction.Width + 150)
            || (this.SpriteMetroid.Y < -150 || this.SpriteMetroid.Y > this.SpriteAction.Height + 150))
            {
                double y = Globals.Random.NextDouble();
                this.SpriteMetroid.Y = (float)(-20 - (y * 100));

                double x = Globals.Random.NextDouble();
                this.SpriteMetroid.X = (float)(-20 - (x * 100));

                h = Functions.ConvertMpSToVelocity(30F, Globals.TimerInterval, Globals.PixelToMeter);

                if (x > 0.5F)
                {
                    h *= -1;
                }

                this.SpriteMetroid.X *= h;
                this.SpriteMetroid.X += this.SpriteAction.Rectangle.Width;
            }
        }

        private void LoadStageFree()
        {
            this.ConstHForce = 0;
            Globals.CurrentStage = 0;
            this.Name = "Estágio 0";
            this.Location = "Livre";
            //this.SpriteLZ.GForce = Functions.ConvertMpSToVelocity(Globals.LZGForce, Globals.TimerInterval, Globals.PixelToMeter);
            this.ConstVForce = Functions.ConvertMpSToVelocity(0, Globals.TimerInterval, Globals.PixelToMeter);
            //this.FontGravity.Text = string.Format(this.FontGravity.Text, Globals.LZGForce);
            this.FontWind.Text = string.Format(this.FontWind.Text, "0.00", this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Misc\\LZ");
            this.SpriteLZ.Rectangle.Location = new Point(300, 250);
            this.SpriteLZ.X = (this.SpriteAction.Width / 2) - (this.SpriteLZ.Width / 2);
            this.SpriteLZ.Y = (this.SpriteAction.Height / 2) - (this.SpriteLZ.Height / 2);
            this.SpriteLZ.Width = 32;
        }

        private void LoadStage1_1()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 200;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 50;
                this.SpriteGreenOre.Y = 500;

                this.SpriteBlueOre.X = 500;
                this.SpriteBlueOre.Y = 300;
            }

            float gravity = 1.62F;
            Globals.CurrentStage = 11;
            this.Name = "Estágio 1-1";
            this.Location = "Lua";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, "0.00", this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area1\\Location_Moon");
        }

        private void LoadStage1_2()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 500;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 370;
                this.SpriteGreenOre.Y = 10;

                this.SpriteBlueOre.X = 290;
                this.SpriteBlueOre.Y = 150;
            }

            float gravity = 3.69F;
            float windForce = FunctionsGame.GenerateRandomWind(1, 2, this);
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 12;
            this.Name = "Estágio 1-2";
            this.Location = "Marte";
            this.SpriteAction.Color = Color.DarkGoldenrod;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area1\\Location_Mars");
        }

        private void LoadStage1_3()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 600;
                this.SpriteRedOre.Y = 10;

                this.SpriteGreenOre.X = 80;
                this.SpriteGreenOre.Y = 480;

                this.SpriteBlueOre.X = 350;
                this.SpriteBlueOre.Y = 500;
            }

            float gravity = 3.7F;
            float windForce = FunctionsGame.GenerateRandomWind(1, 2, this);
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 13;
            this.Name = "Estágio 1-3";
            this.Location = "Mercúrio";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area1\\Location_Mercury");
        }

        private void LoadStage1_4()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 550;
                this.SpriteRedOre.Y = 550;

                this.SpriteGreenOre.X = 85;
                this.SpriteGreenOre.Y = 420;

                this.SpriteBlueOre.X = 350;
                this.SpriteBlueOre.Y = 3;
            }

            float gravity = 8.87F;
            float windForce = FunctionsGame.GenerateRandomWind(6, 8, this);
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 14;
            this.Name = "Estágio 1-4";
            this.Location = "Venus";
            this.SpriteAction.Color = Color.DarkKhaki;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area1\\Location_Venus");
        }

        private void LoadStage1_5()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 500;
                this.SpriteRedOre.Y = 500;

                this.SpriteGreenOre.X = 370;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 10;
                this.SpriteBlueOre.Y = 560;
            }

            float gravity = 9.78F;
            float windForce = FunctionsGame.GenerateRandomWind(4, 5, this);
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 15;
            this.Name = "Estágio 1-5";
            this.Location = "Terra";
            this.SpriteAction.Color = Color.DarkCyan;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area1\\Location_Earth");
        }

        private void LoadStage2_1()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 150;
                this.SpriteRedOre.Y = 20;

                this.SpriteGreenOre.X = 365;
                this.SpriteGreenOre.Y = 430;

                this.SpriteBlueOre.X = 10;
                this.SpriteBlueOre.Y = 550;
            }

            float gravity = 1.79F;
            float windForce = FunctionsGame.GenerateRandomWind(1, 2, this);
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 21;
            this.Name = "Estágio 2-1";
            this.Location = "Io";
            this.SpriteAction.Color = Color.Orange;

            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area2\\Location_Io");
        }

        private void LoadStage2_2()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 100;
                this.SpriteRedOre.Y = 280;

                this.SpriteGreenOre.X = 470;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 550;
                this.SpriteBlueOre.Y = 150;
            }

            float gravity = 1.31F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 22;
            this.Name = "Estágio 2-2";
            this.Location = "Europa";
            this.SpriteAction.Color = Color.Black;

            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area2\\Location_Europa");
        }

        private void LoadStage2_3()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 550;
                this.SpriteRedOre.Y = 20;

                this.SpriteGreenOre.X = 500;
                this.SpriteGreenOre.Y = 500;

                this.SpriteBlueOre.X = 550;
                this.SpriteBlueOre.Y = 100;
            }

            float gravity = 1.42F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 23;
            this.Name = "Estágio 2-3";
            this.Location = "Ganimedes";
            this.SpriteAction.Color = Color.Black;

            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area2\\Location_Ganymede");
        }

        private void LoadStage2_4()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 300;
                this.SpriteRedOre.Y = 2;

                this.SpriteGreenOre.X = 2;
                this.SpriteGreenOre.Y = 400;

                this.SpriteBlueOre.X = 550;
                this.SpriteBlueOre.Y = 25;
            }

            float gravity = 1.23F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 24;
            this.Name = "Estágio 2-4";
            this.Location = "Calisto";
            this.SpriteAction.Color = Color.Black;

            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area2\\Location_Callisto");
        }

        private void LoadStage2_5()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 500;
                this.SpriteRedOre.Y = 64;

                this.SpriteGreenOre.X = 07;
                this.SpriteGreenOre.Y = 470;

                this.SpriteBlueOre.X = 80;
                this.SpriteBlueOre.Y = 300;
            }

            float gravity = Functions.ConvertMpSToVelocity(1F, Globals.TimerInterval, Globals.PixelToMeter);
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 25;
            this.Name = "Estágio 2-5";
            this.Location = "Amalteia";
            this.SpriteAction.Color = Color.Black;

            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area2\\Location_Amalthea");
        }

        private void LoadStage3_1()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 620;
                this.SpriteRedOre.Y = 10;

                this.SpriteGreenOre.X = 400;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 10;
                this.SpriteBlueOre.Y = 560;
            }

            float gravity = 1.35F;
            float windForce = FunctionsGame.GenerateRandomWind(2, 3, this);
            Globals.CurrentStage = 31;
            this.Name = "Estágio 3-1";
            this.Location = "Titã";
            this.SpriteAction.Color = Color.Olive;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area3\\Location_Titan");
        }

        private void LoadStage3_2()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 200;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 50;
                this.SpriteGreenOre.Y = 500;

                this.SpriteBlueOre.X = 500;
                this.SpriteBlueOre.Y = 300;
            }

            float gravity = 0.22F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 32;
            this.Name = "Estágio 3-2";
            this.Location = "Jápeto";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area3\\Location_Iapetus");
        }

        private void LoadStage3_3()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 200;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 50;
                this.SpriteGreenOre.Y = 500;

                this.SpriteBlueOre.X = 500;
                this.SpriteBlueOre.Y = 300;
            }

            float gravity = 0.07F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 33;
            this.Name = "Estágio 3-3";
            this.Location = "Miranda";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area3\\Location_Miranda");
        }

        private void LoadStage3_4()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 200;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 50;
                this.SpriteGreenOre.Y = 500;

                this.SpriteBlueOre.X = 500;
                this.SpriteBlueOre.Y = 300;
            }

            float gravity = 0.38F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 34;
            this.Name = "Estágio 3-4";
            this.Location = "Titânia";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area3\\Location_Titania");
        }

        private void LoadStage3_5()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 200;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 50;
                this.SpriteGreenOre.Y = 500;

                this.SpriteBlueOre.X = 500;
                this.SpriteBlueOre.Y = 300;

            }

            float gravity = 0.77F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 35;
            this.Name = "Estágio 3-5";
            this.Location = "Tritão";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area3\\Location_Triton");
        }

        private void LoadStage4_1()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 350;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 50;
                this.SpriteGreenOre.Y = 450;

                this.SpriteBlueOre.X = 550;
                this.SpriteBlueOre.Y = 450;
            }

            float gravity = 0.27F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 41;
            this.Name = "Estágio 4-1";
            this.Location = "Ceres";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area4\\Location_Ceres");
        }

        private void LoadStage4_2()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 100;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 270;
                this.SpriteGreenOre.Y = 200;

                this.SpriteBlueOre.X = 450;
                this.SpriteBlueOre.Y = 350;
            }

            float gravity = 0.44F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 42;
            this.Name = "Estágio 4-2";
            this.Location = "Haumeia";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area4\\Location_Haumea");
        }

        private void LoadStage4_3()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 180;
                this.SpriteRedOre.Y = 270;

                this.SpriteGreenOre.X = 50;
                this.SpriteGreenOre.Y = 270;

                this.SpriteBlueOre.X = 500;
                this.SpriteBlueOre.Y = 270;
            }

            float gravity = 0.65F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 43;
            this.Name = "Estágio 4-3";
            this.Location = "Plutão";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area4\\Location_Pluto");
        }

        private void LoadStage4_4()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 50;
                this.SpriteRedOre.Y = 550;

                this.SpriteGreenOre.X = 100;
                this.SpriteGreenOre.Y = 550;

                this.SpriteBlueOre.X = 550;
                this.SpriteBlueOre.Y = 550;
            }

            float gravity = 0.80F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 44;
            this.Name = "Estágio 4-4";
            this.Location = "Eris";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area4\\Location_Eris");
        }

        private void LoadStage4_5()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 630;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 5;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 300;
                this.SpriteBlueOre.Y = 300;
            }

            float gravity = 0.40F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 45;
            this.Name = "Estágio 4-5";
            this.Location = "Sedna";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area4\\Location_Sedna");
        }

        private void LoadStage5_1()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 100;
                this.SpriteRedOre.Y = 250;

                this.SpriteGreenOre.X = 300;
                this.SpriteGreenOre.Y = 400;

                this.SpriteBlueOre.X = 550;
                this.SpriteBlueOre.Y = 550;
            }

            float gravity = 0.18F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 51;
            this.Name = "Estágio 5-1";
            this.Location = "Palas";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area5\\Location_Pallas");
        }

        private void LoadStage5_2()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 500;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 500;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 500;
                this.SpriteBlueOre.Y = 350;
            }

            float gravity = 0.22F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 52;
            this.Name = "Estágio 5-2";
            this.Location = "Vesta";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area5\\Location_Vesta");
        }

        private void LoadStage5_3()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 100;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 270;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 550;
                this.SpriteBlueOre.Y = 350;
            }

            float gravity = 0.09F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 53;
            this.Name = "Estágio 5-3";
            this.Location = "Hígia";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area5\\Location_Hygiea");
        }

        private void LoadStage5_4()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 400;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 270;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 500;
                this.SpriteBlueOre.Y = 300;
            }

            float gravity = 0.01F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 54;
            this.Name = "Estágio 5-4";
            this.Location = "Ida";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area5\\Location_Ida");
        }

        private void LoadStage5_5()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 500;
                this.SpriteRedOre.Y = 200;

                this.SpriteGreenOre.X = 200;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 500;
                this.SpriteBlueOre.Y = 350;
            }

            float gravity = 0.15F;
            float windForce = 0;
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 55;
            this.Name = "Estágio 5-5";
            this.Location = "Varuna";
            this.SpriteAction.Color = Color.Black;
            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area5\\Location_Varuna");
        }

        private void LoadStage6_1()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 600;
                this.SpriteRedOre.Y = 500;

                this.SpriteGreenOre.X = 300;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 150;
                this.SpriteBlueOre.Y = 350;
            }

            float gravity = 8.40F;
            float windForce = FunctionsGame.GenerateRandomWind(4, 5, this);
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 61;
            this.Name = "Estágio 6-1";
            this.Location = "Zebes";
            this.SpriteAction.Color = Color.DimGray;

            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area6\\Location_Zebes");
        }

        private void LoadStage6_2()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 600;
                this.SpriteRedOre.Y = 500;

                this.SpriteGreenOre.X = 300;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 150;
                this.SpriteBlueOre.Y = 350;
            }

            float gravity = 7.60F;
            float windForce = FunctionsGame.GenerateRandomWind(4, 5, this);
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 62;
            this.Name = "Estágio 6-2";
            this.Location = "SR-388";
            this.SpriteAction.Color = Color.SeaGreen;

            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area6\\Location_SR388");
        }

        private void LoadStage6_3()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 600;
                this.SpriteRedOre.Y = 500;

                this.SpriteGreenOre.X = 300;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 150;
                this.SpriteBlueOre.Y = 350;
            }

            float gravity = 0.01F;
            float windForce = FunctionsGame.GenerateRandomWind(0, 0, this);
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 63;
            this.Name = "Estágio 6-3";
            this.Location = "Space Lab";
            this.SpriteAction.Color = Color.Black;

            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area6\\Location_BiologicSpaceLab");
        }

        private void LoadStage6_4()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 600;
                this.SpriteRedOre.Y = 500;

                this.SpriteGreenOre.X = 300;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 150;
                this.SpriteBlueOre.Y = 350;
            }

            float gravity = 10.6F;
            float windForce = FunctionsGame.GenerateRandomWind(4, 5, this);
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 64;
            this.Name = "Estágio 6-4";
            this.Location = "Tallon IV";
            this.SpriteAction.Color = Color.RosyBrown;

            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area6\\Location_TallonIV");
        }

        private void LoadStage6_5()
        {
            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.SpriteRedOre.X = 600;
                this.SpriteRedOre.Y = 500;

                this.SpriteGreenOre.X = 300;
                this.SpriteGreenOre.Y = 300;

                this.SpriteBlueOre.X = 150;
                this.SpriteBlueOre.Y = 350;
            }

            float gravity = 9.03F;
            float windForce = FunctionsGame.GenerateRandomWind(4, 5, this);
            this.ConstHForce = Functions.ConvertMpSToVelocity(windForce, Globals.TimerInterval, Globals.PixelToMeter);
            Globals.CurrentStage = 65;
            this.Name = "Estágio 6-5";
            this.Location = "Aether";
            this.SpriteAction.Color = Color.Teal;

            this.ConstVForce = Functions.ConvertMpSToVelocity(gravity, Globals.TimerInterval, Globals.PixelToMeter);
            this.FontGravity.Text = string.Format(this.FontGravity.Text, gravity.ToString());
            this.FontWind.Text = string.Format(this.FontWind.Text, Convert.ToString(windForce).Replace("-", ""), this.WindDirection);
            this.SpriteLocation = new Sprite(50, 50, "Images\\Locations\\Area6\\Location_Aether");
        }
    }
}