using XNALander.Classes;
using Microsoft.Xna.Framework.Graphics;

namespace XNALander.StaticFunctions
{
    public static class FunctionsStage
    {
        private static short MetroidBrakeCounter;

        public static void InitializeStage()
        {
            Globals.SelectedStage = new Stage(Globals.CurrentStage);
            Globals.SelectedShip.TextureCurrent = Globals.SelectedShip.Textures[0];

            Globals.MustLoadContent = true;

            Globals.SelectedStage.SpriteShipLeft1.Visible = false;
            Globals.SelectedStage.SpriteShipLeft2.Visible = false;

            Globals.SelectedStage.SpriteLZ.X = (Globals.SelectedStage.SpriteAction.Width / 2) - (Globals.SelectedStage.SpriteLZ.Width / 2);
            Globals.SelectedStage.SpriteLZ.Y = Globals.SelectedStage.SpriteAction.Height - Globals.SelectedStage.SpriteLZ.Height;

            if (Globals.GameType == Enum.GameType.Arcade)
            {
                if (Globals.ShipsLeft > 1)
                {
                    Globals.SelectedStage.SpriteShipLeft1.Visible = true;
                    Globals.SelectedStage.SpriteShipLeft2.Visible = true;
                }
                else if (Globals.ShipsLeft == 1)
                {
                    Globals.SelectedStage.SpriteShipLeft1.Visible = true;
                    Globals.SelectedStage.SpriteShipLeft2.Visible = false;
                }
            }

            if (Globals.SelectedStage.SpriteAsteroid1 != null)
            {
            Globals.SelectedStage.SpriteAsteroid1.X = -1000;
            Globals.SelectedStage.SpriteAsteroid1.Y = -1000;
            }

            if (Globals.SelectedStage.SpriteAsteroid2 != null)
            {
                Globals.SelectedStage.SpriteAsteroid2.X = -1000;
                Globals.SelectedStage.SpriteAsteroid2.Y = -1000;
            }

            if (Globals.SelectedStage.SpriteMetroid != null)
            {
                Globals.SelectedStage.SpriteMetroid.X = -200;
                Globals.SelectedStage.SpriteMetroid.Y = -200;
            }

            Globals.Collided = false;
            Globals.CollidedGround = false;
            Globals.CollidedLZ = false;
            Globals.Landed = false;

            Globals.SelectedStage.WindDirection = "N";

            Globals.EndedIntro = false;
            
            Globals.CollidedGround = false;
            Globals.CollidedLZ = false;

            Globals.SelectedShip.X = 40;
            Globals.SelectedShip.Y = -50;
            Globals.SelectedShip.VerticalVelocity = 0;
            Globals.SelectedShip.HorizontalVelocity = 0;

            Globals.SelectedShip.Fuel = Globals.SelectedShip.MaxFuel;

            Globals.SelectedStage.BarSpeed.MaxValue = 1000;
            Globals.SelectedStage.BarSpeedToLZ.MaxValue = 1000;
            Globals.SelectedStage.BarFuel.MaxValue = (int)Globals.SelectedShip.MaxFuel;

            //Posiciona o cursor de Aceleração Perigosa
            float x = (Globals.SelectedShip.Resistance * Globals.SelectedStage.BarSpeedToLZ.Width) / (Globals.SelectedStage.BarSpeedToLZ.MaxValue / Globals.SpeedBarMultiplier);

            Globals.SelectedStage.SpriteCursorDanger.X = Globals.SelectedStage.BarSpeedToLZ.X + x - (Globals.SelectedStage.SpriteCursorDanger.Width / 2) + 1;
            Globals.SelectedStage.FontCursorDanger.Position.X = Globals.SelectedStage.SpriteCursorDanger.X;

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                Globals.UpdateOre = new Game1.UpdateForOre(FunctionsStage.UpdateForOre);
            }
            else
            {
                Globals.UpdateOre = new Game1.UpdateForOre(FunctionsGame.UpdateNull);
            }
        }

        public static void UpdateStage()
        {
            Globals.SelectedShip.TotalVelocity = Functions.CalculateTotalForce(Globals.SelectedShip);
            FunctionsStage.MoveSpeedBar(Globals.SelectedShip, Globals.SelectedStage.BarSpeed, Globals.SpeedBarMultiplier);
            FunctionsStage.MoveSpeedBarToLZ(Globals.SelectedShip, ref Globals.SelectedStage.BarSpeedToLZ, Globals.SpeedBarMultiplier);
            FunctionsGame.DecreaseFuel(Globals.SelectedShip, Globals.SelectedStage.BarFuel);

            if (Globals.SpaceKeyDown)
            {
                Globals.SelectedStage.SpriteLED.TextureCurrent = Globals.SelectedStage.SpriteLED.Textures[1];
            }
            else
            {
                Globals.SelectedStage.SpriteLED.TextureCurrent = Globals.SelectedStage.SpriteLED.Textures[0];
            }

            if (Globals.SelectedShip.Y < 0 - Globals.SelectedShip.Height)
            {
                Globals.SelectedStage.SpriteCursor.Visible = true;
                Globals.SelectedStage.FontCursor.Visible = true;
                FunctionsGame.MoveOffMapCursor();
            }
            else
            {
                Globals.SelectedStage.SpriteCursor.Visible = false;
                Globals.SelectedStage.FontCursor.Visible = false;
            }
        }

        public static void UpdateForOre()
        {
            if (Globals.SelectedStage.SpriteRedOre.Visible)
            {
                Functions.MoveSprite(Globals.SelectedStage.SpriteRedOre);
                Functions.WarpSprite(Globals.SelectedStage.SpriteRedOre, Globals.SelectedStage.SpriteAction, Enum.Axis.All);

                if (Functions.DetectCollision(Globals.SelectedStage.SpriteRedOre, Globals.SelectedShip))
                {
                    Globals.SelectedStage.SpriteRedOre.Visible = false;
                    Globals.SFXCollected.Play();
                }
            }

            if (Globals.SelectedStage.SpriteGreenOre.Visible)
            {
                Functions.MoveSprite(Globals.SelectedStage.SpriteGreenOre);
                Functions.WarpSprite(Globals.SelectedStage.SpriteGreenOre, Globals.SelectedStage.SpriteAction, Enum.Axis.All);

                if (Functions.DetectCollision(Globals.SelectedStage.SpriteGreenOre, Globals.SelectedShip))
                {
                    Globals.SelectedStage.SpriteGreenOre.Visible = false;
                    Globals.SFXCollected.Play();
                }
            }

            if (Globals.SelectedStage.SpriteBlueOre.Visible)
            {
                Functions.MoveSprite(Globals.SelectedStage.SpriteBlueOre);
                Functions.WarpSprite(Globals.SelectedStage.SpriteBlueOre, Globals.SelectedStage.SpriteAction, Enum.Axis.All);

                if (Functions.DetectCollision(Globals.SelectedStage.SpriteBlueOre, Globals.SelectedShip))
                {
                    Globals.SelectedStage.SpriteBlueOre.Visible = false;
                    Globals.SFXCollected.Play();
                }
            }
        }

        public static void UpdateForAreaFree()
        {
            //Functions.ApplyGravity(Globals.SelectedStage.SpriteLZ, Globals.SelectedShip);
        }

        public static void UpdateForArea1()
        {
        }

        public static void UpdateForArea2()
        {
        }

        public static void UpdateForArea3()
        {
            if (Globals.SelectedStage.SpriteLZ.X < 0 || Globals.SelectedStage.SpriteLZ.X > Globals.SelectedStage.SpriteAction.Width - Globals.SelectedStage.SpriteLZ.Width)
            {
                Globals.SelectedStage.SpriteLZ.HorizontalVelocity *= -1;
            }

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                Globals.SelectedStage.SpriteRedOre.FlickCount++;
                Globals.SelectedStage.SpriteGreenOre.FlickCount++;
                Globals.SelectedStage.SpriteBlueOre.FlickCount++;

                if (Globals.SelectedStage.SpriteRedOre.FlickCount > 50)
                {
                    Globals.SelectedStage.SpriteRedOre.FlickCount = 0;

                    if (Globals.Random.Next() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteRedOre.HorizontalVelocity *= -1;
                    }
                }

                if (Globals.SelectedStage.SpriteGreenOre.FlickCount > 80)
                {
                    Globals.SelectedStage.SpriteGreenOre.FlickCount = 0;

                    if (Globals.Random.Next() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteGreenOre.HorizontalVelocity *= -1;
                    }
                }

                if (Globals.SelectedStage.SpriteBlueOre.FlickCount > 25)
                {
                    Globals.SelectedStage.SpriteBlueOre.FlickCount = 0;

                    if (Globals.Random.Next() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteBlueOre.HorizontalVelocity *= -1;
                    }
                }
            }
        }

        public static void UpdateForArea4()
        {
            if (Globals.SelectedStage.SpriteLZ.Y < (Globals.SelectedStage.SpriteAction.Height * 0.66F) || Globals.SelectedStage.SpriteLZ.Y > (Globals.SelectedStage.SpriteAction.Height - Globals.SelectedStage.SpriteLZ.Height + 3))
            {
                Globals.SelectedStage.SpriteLZ.VerticalVelocity *= -1;
            }

            if ((Globals.SelectedStage.SpriteAsteroid1.X < -150 || Globals.SelectedStage.SpriteAsteroid1.X > Globals.SelectedStage.SpriteAction.Width + 150)
            || (Globals.SelectedStage.SpriteAsteroid1.Y < -150 || Globals.SelectedStage.SpriteAsteroid1.Y > Globals.SelectedStage.SpriteAction.Height + 150))
            {
                double y = Globals.Random.NextDouble();
                Globals.SelectedStage.SpriteAsteroid1.Y = (float)(-20 - (y * 100));

                double x = Globals.Random.NextDouble();
                Globals.SelectedStage.SpriteAsteroid1.X = (float)(-20 - (x * 100));

                Globals.SelectedStage.SpriteAsteroid1.VerticalVelocity = Globals.Random.Next(1, 7);
                Globals.SelectedStage.SpriteAsteroid1.HorizontalVelocity = Globals.Random.Next(1, 7);

                if (x > 0.5F)
                {
                    Globals.SelectedStage.SpriteAsteroid1.X *= -1;
                    Globals.SelectedStage.SpriteAsteroid1.X += Globals.SelectedStage.SpriteAction.Width;
                    Globals.SelectedStage.SpriteAsteroid1.HorizontalVelocity *= -1;
                }
            }
            else
            {
                if (Functions.DetectCollision(Globals.SelectedShip, Globals.SelectedStage.SpriteAsteroid1, ref Globals.CollidedUp, ref Globals.CollidedDown, ref Globals.CollidedLeft, ref Globals.CollidedRight))
                {
                    Globals.Collided = true;
                    Globals.SelectedShip.TextureCurrent = Globals.SelectedShip.Textures[1];
                    Globals.SFXExplosion.Play();
                }

                Functions.MoveSprite(Globals.SelectedStage.SpriteAsteroid1);
            }

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                Globals.SelectedStage.SpriteRedOre.FlickCount++;
                Globals.SelectedStage.SpriteGreenOre.FlickCount++;
                Globals.SelectedStage.SpriteBlueOre.FlickCount++;

                if (Globals.SelectedStage.SpriteRedOre.FlickCount > 50)
                {
                    Globals.SelectedStage.SpriteRedOre.FlickCount = 0;

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteRedOre.HorizontalVelocity *= -1;
                    }

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteRedOre.VerticalVelocity *= -1;
                    }
                }

                if (Globals.SelectedStage.SpriteGreenOre.FlickCount > 80)
                {
                    Globals.SelectedStage.SpriteGreenOre.FlickCount = 0;

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteGreenOre.HorizontalVelocity *= -1;
                    }

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteGreenOre.VerticalVelocity *= -1;
                    }
                }

                if (Globals.SelectedStage.SpriteBlueOre.FlickCount > 25)
                {
                    Globals.SelectedStage.SpriteBlueOre.FlickCount = 0;

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteBlueOre.HorizontalVelocity *= -1;
                    }

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteBlueOre.VerticalVelocity *= -1;
                    }
                }
            }
        }

        public static void UpdateForArea5()
        {
            if (Globals.SelectedStage.SpriteLZ.X < 0 || Globals.SelectedStage.SpriteLZ.X > Globals.SelectedStage.SpriteAction.Width - Globals.SelectedStage.SpriteLZ.Width)
            {
                Globals.SelectedStage.SpriteLZ.HorizontalVelocity *= -1;
            }

            if ((Globals.SelectedStage.SpriteAsteroid1.X < -250 || Globals.SelectedStage.SpriteAsteroid1.X > Globals.SelectedStage.SpriteAction.Width + 250)
                || (Globals.SelectedStage.SpriteAsteroid1.Y < -250 || Globals.SelectedStage.SpriteAsteroid1.Y > Globals.SelectedStage.SpriteAction.Height + 250))
            {
                double y = Globals.Random.NextDouble();
                Globals.SelectedStage.SpriteAsteroid1.Y = (float)(-20 - (y * 100));

                double x = Globals.Random.NextDouble();
                Globals.SelectedStage.SpriteAsteroid1.X = (float)(-20 - (x * 100));

                Globals.SelectedStage.SpriteAsteroid1.VerticalVelocity = Globals.Random.Next(1, 7);
                Globals.SelectedStage.SpriteAsteroid1.HorizontalVelocity = Globals.Random.Next(1, 7);

                if (x > 0.5F)
                {
                    Globals.SelectedStage.SpriteAsteroid1.X *= -1;
                    Globals.SelectedStage.SpriteAsteroid1.X += Globals.SelectedStage.SpriteAction.Width;
                    Globals.SelectedStage.SpriteAsteroid1.HorizontalVelocity *= -1;
                }
            }
            else
            {
                if (Functions.DetectCollision(Globals.SelectedShip, Globals.SelectedStage.SpriteAsteroid1, ref Globals.CollidedUp, ref Globals.CollidedDown, ref Globals.CollidedLeft, ref Globals.CollidedRight))
                {
                    Globals.Collided = true;
                    Globals.SelectedShip.TextureCurrent = Globals.SelectedShip.Textures[1];
                    Globals.SFXExplosion.Play();
                }

                Functions.MoveSprite(Globals.SelectedStage.SpriteAsteroid1);
            }

            if ((Globals.SelectedStage.SpriteAsteroid2.X < -250 || Globals.SelectedStage.SpriteAsteroid2.X > Globals.SelectedStage.SpriteAction.Width + 250)
            || (Globals.SelectedStage.SpriteAsteroid2.Y < -250 || Globals.SelectedStage.SpriteAsteroid2.Y > Globals.SelectedStage.SpriteAction.Height + 250))
            {
                double y = Globals.Random.NextDouble();
                Globals.SelectedStage.SpriteAsteroid2.Y = (float)(-20 - (y * 100));

                double x = Globals.Random.NextDouble();
                Globals.SelectedStage.SpriteAsteroid2.X = (float)(-20 - (x * 100));

                Globals.SelectedStage.SpriteAsteroid2.VerticalVelocity = Globals.Random.Next(1, 7);
                Globals.SelectedStage.SpriteAsteroid2.HorizontalVelocity = Globals.Random.Next(1, 7);

                if (x > 0.5F)
                {
                    Globals.SelectedStage.SpriteAsteroid2.X *= -1;
                    Globals.SelectedStage.SpriteAsteroid2.X += Globals.SelectedStage.SpriteLocation.Width;
                    Globals.SelectedStage.SpriteAsteroid2.HorizontalVelocity *= -1;
                }
            }
            else
            {
                if (Functions.DetectCollision(Globals.SelectedShip, Globals.SelectedStage.SpriteAsteroid2, ref Globals.CollidedUp, ref Globals.CollidedDown, ref Globals.CollidedLeft, ref Globals.CollidedRight))
                {
                    Globals.Collided = true;
                    Globals.SelectedShip.TextureCurrent = Globals.SelectedShip.Textures[1];
                    Globals.SFXExplosion.Play();
                }

                Functions.MoveSprite(Globals.SelectedStage.SpriteAsteroid2);
            }

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                Globals.SelectedStage.SpriteRedOre.FlickCount++;
                Globals.SelectedStage.SpriteGreenOre.FlickCount++;
                Globals.SelectedStage.SpriteBlueOre.FlickCount++;

                if (Globals.SelectedStage.SpriteRedOre.FlickCount > 50)
                {
                    Globals.SelectedStage.SpriteRedOre.FlickCount = 0;

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteRedOre.VerticalVelocity = 0;
                        Globals.SelectedStage.SpriteRedOre.HorizontalVelocity = 5;
                    }
                    else
                    {
                        Globals.SelectedStage.SpriteRedOre.VerticalVelocity = 5;
                        Globals.SelectedStage.SpriteRedOre.HorizontalVelocity = 0;
                    }

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteRedOre.VerticalVelocity *= -1;
                        Globals.SelectedStage.SpriteRedOre.HorizontalVelocity *= -1;
                    }
                }

                if (Globals.SelectedStage.SpriteGreenOre.FlickCount > 80)
                {
                    Globals.SelectedStage.SpriteGreenOre.FlickCount = 0;

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteGreenOre.HorizontalVelocity *= -1;
                    }

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteGreenOre.VerticalVelocity *= -1;
                    }
                }

                if (Globals.SelectedStage.SpriteBlueOre.FlickCount > 25)
                {
                    Globals.SelectedStage.SpriteBlueOre.FlickCount = 0;

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteBlueOre.HorizontalVelocity *= -1;
                    }

                    if (Globals.Random.NextDouble() > 0.5F)
                    {
                        Globals.SelectedStage.SpriteBlueOre.VerticalVelocity *= -1;
                    }
                }
            }
        }

        public static void UpdateForArea6()
        {
            MetroidBrakeCounter++;
            Functions.ApplyGravity(Globals.SelectedShip, Globals.SelectedStage.SpriteMetroid);
            Functions.MoveSprite(Globals.SelectedStage.SpriteMetroid);

            if (MetroidBrakeCounter == 30)
            {
                Globals.SelectedStage.SpriteMetroid.HorizontalVelocity = 0;
                Globals.SelectedStage.SpriteMetroid.VerticalVelocity = 0;
                MetroidBrakeCounter = 0;
            }

            if (Functions.DetectCollision(Globals.SelectedStage.SpriteMetroid, Globals.SelectedShip))
            {
                Globals.SelectedShip.Fuel -= Globals.SelectedShip.FuelConsumptionRate * 2;

                Globals.SelectedStage.BarFuel.ForeColor = Color.Purple;
            }
            else
            {
                Globals.SelectedStage.BarFuel.ForeColor = Globals.SelectedStage.BarFuel.ForeColorDefault;
            }

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                Globals.SelectedStage.SpriteRedOre.FlickCount++;
                Globals.SelectedStage.SpriteGreenOre.FlickCount++;
                Globals.SelectedStage.SpriteBlueOre.FlickCount++;

                if (Globals.SelectedStage.SpriteRedOre.FlickCount > 100)
                {
                    Globals.SelectedStage.SpriteRedOre.FlickCount = 0;
                    Globals.SelectedStage.SpriteRedOre.X = Globals.Random.Next(5, 630);
                    Globals.SelectedStage.SpriteRedOre.Y = Globals.Random.Next(5, 530);
                }

                if (Globals.SelectedStage.SpriteGreenOre.FlickCount > 80)
                {
                    Globals.SelectedStage.SpriteGreenOre.FlickCount = 0;
                    Globals.SelectedStage.SpriteGreenOre.X = Globals.Random.Next(5, 630);
                    Globals.SelectedStage.SpriteGreenOre.Y = Globals.Random.Next(5, 530);
                }

                if (Globals.SelectedStage.SpriteBlueOre.FlickCount > 65)
                {
                    Globals.SelectedStage.SpriteBlueOre.FlickCount = 0;
                    Globals.SelectedStage.SpriteBlueOre.X = Globals.Random.Next(5, 630);
                    Globals.SelectedStage.SpriteBlueOre.Y = Globals.Random.Next(5, 530);
                }
            }
        }


        public static void MoveSpeedBar(Sprite Ship, Bar BarSpeed, int Multiplier)
        {
            int t = (int)(Ship.TotalVelocity * Multiplier);

            if (t > BarSpeed.MaxValue)
            {
                BarSpeed.Value = BarSpeed.MaxValue;
            }
            else
            {
                BarSpeed.Value = t;
            }
        }

        public static void MoveSpeedBarToLZ(SpriteShip Ship, ref Bar BarSpeed, int Multiplier)
        {
            Globals.RelativeVelocity = Functions.CalculateRelativeVelocityToSprite(Globals.SelectedShip, Globals.SelectedStage.SpriteLZ);
            int t = (int)(Globals.RelativeVelocity * Multiplier);

            if (t > BarSpeed.MaxValue)
            {
                BarSpeed.Value = BarSpeed.MaxValue;
            }
            else
            {
                BarSpeed.Value = t;
            }

            if (Globals.RelativeVelocity > Ship.Resistance)
            {
                if ((BarSpeed.ForeColor == BarSpeed.ForeColorDefault || BarSpeed.ForeColor == Color.White) && BarSpeed.FlickCount == 4)
                {
                    BarSpeed.ForeColor = Color.Red;
                    BarSpeed.FlickCount = 0;
                }
                else if (BarSpeed.ForeColor == Color.Red && BarSpeed.FlickCount == 4)
                {
                    BarSpeed.ForeColor = Color.White;
                    BarSpeed.FlickCount = 0;
                }

                BarSpeed.FlickCount++;
            }
            else
            {
                BarSpeed.ForeColor = BarSpeed.ForeColorDefault;
            }
        }
    }
}