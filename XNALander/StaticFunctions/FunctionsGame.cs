using System;
using XNALander.Classes;
using Microsoft.Xna.Framework.Graphics;

namespace XNALander.StaticFunctions
{
    public static class FunctionsGame
    {
        public static void ApplyPostStage()
        {
            SoundClass.Stop(Globals.SFXRocketInstance);
            SoundClass.Stop(Globals.SFXFloatInstance);

            if (Globals.EnterKeyPressed)
            {
                if (Globals.GameType == Enum.GameType.Arcade)
                {
                    if (Globals.Landed)
                    {
                        FunctionsGame.ChangeStage();
                    }
                    else if (Globals.Collided)
                    {
                        if (Globals.ShipsLeft > 0)
                        {
                            Globals.ShipsLeft--;
                            FunctionsStage.InitializeStage();
                        }
                        else
                        {
                            Globals.CurrentScene = new Scenes.SceneTitle();
                        }
                    }
                }
                else if (Globals.GameType == Enum.GameType.OreColleting)
                {
                    if (Globals.Landed)
                    {
                        if (!Globals.SelectedStage.SpriteRedOre.Visible && !Globals.SelectedStage.SpriteGreenOre.Visible && !Globals.SelectedStage.SpriteBlueOre.Visible)
                        {
                            Globals.OreCollected = true;
                            FunctionsGame.RecordFeatures(Enum.RecordType.OreCollected);
                            Globals.CurrentScene = new Scenes.SceneChooseStage();
                        }
                        else
                        {
                            FunctionsStage.InitializeStage();
                        }
                    }
                    else
                    {
                        FunctionsStage.InitializeStage();
                    }
                }
                else
                {
                    FunctionsStage.InitializeStage();
                }
            }
        }

        public static void JumpStage()
        {
            if (!Globals.JumpStageKeyDown && Globals.JumpStageKeyDownPrevious)
            {
                if (Globals.GameType == Enum.GameType.Arcade)
                {
                    if (Globals.KeyPressDelay > 0)
                    {
                        Globals.KeyPressDelay = 0;
                        FunctionsGame.ChangeStage();
                    }
                    else
                    {
                        Globals.KeyPressDelay++;
                    }
                }
                else if (Globals.GameType == Enum.GameType.OreColleting)
                {
                    if (Globals.KeyPressDelay > 0)
                    {
                        Globals.KeyPressDelay = 0;

                        Globals.Collided = true;
                        Globals.Landed = true;
                    }
                    else
                    {
                        Globals.KeyPressDelay++;
                    }
                }
            }
        }

        public static void ChangeStage()
        {
            if (Globals.CurrentStage > 10 && Globals.CurrentStage < 15)
            {
                Globals.CurrentStage++;
                FunctionsStage.InitializeStage();
            }
            else if (Globals.CurrentStage > 20 && Globals.CurrentStage < 25)
            {
                Globals.CurrentStage++;
                FunctionsStage.InitializeStage();
            }
            else if (Globals.CurrentStage > 30 && Globals.CurrentStage < 35)
            {
                Globals.CurrentStage++;
                FunctionsStage.InitializeStage();
            }
            else if (Globals.CurrentStage > 40 && Globals.CurrentStage < 45)
            {
                Globals.CurrentStage++;
                FunctionsStage.InitializeStage();
            }
            else if (Globals.CurrentStage > 50 && Globals.CurrentStage < 55)
            {
                Globals.CurrentStage++;
                FunctionsStage.InitializeStage();
            }
            else if (Globals.CurrentStage > 60 && Globals.CurrentStage < 65)
            {
                Globals.CurrentStage++;
                FunctionsStage.InitializeStage();
            }
            else
            {
                Globals.CurrentScene = new Scenes.SceneEnding();
            }
        }

        public static void LoadGame()
        {
            if (!FunctionsGame.ValidateSaveIntegrity())
            {
                CreateNewFile();
            }

            try
            {
                string file = Functions.ReadEncryptedFile(Globals.SaveFilePath);

                string[] newline = { Environment.NewLine };
                string[] comma = { ";" };

                string[] lines = file.Split(newline, 2000, StringSplitOptions.RemoveEmptyEntries);

                Globals.SaveSelectedShip = lines[0].Replace(";", "");

                //Load Cleared Areas per Ship
                for (int i = 1; i < 7; i++)
                {
                    string[] cells = lines[i].Split(comma, 2000, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < cells.Length; j++)
                    {
                        Globals.SaveShipsAreasCompleted[i - 1, j] = Convert.ToBoolean(cells[j]);
                    }
                }

                //Load Ore Colleted per Stage
                for (int i = 7; i < 13; i++)
                {
                    string[] cells = lines[i].Split(comma, 2000, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < cells.Length; j++)
                    {
                        Globals.SaveOreCollected[i - 7, j] = Convert.ToBoolean(cells[j]);
                    }
                }
            }
            catch
            {
                CreateNewFile();
            }
        }

        public static void SaveGame()
        {
            string file = "";

            file = Globals.SaveSelectedShip + Environment.NewLine;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    file += Globals.SaveShipsAreasCompleted[i, j].ToString() + ";";
                }

                file += Environment.NewLine;
            }

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    file += Globals.SaveOreCollected[i, j].ToString() + ";";
                }

                file += Environment.NewLine;
            }

            Functions.WriteDecryptedString(file, Globals.SaveFilePath);
        }

        public static void CreateNewFile()
        {
            Functions.WriteDecryptedString(Globals.DefaultSaveFile, Globals.SaveFilePath);
        }

        public static bool ValidateSaveIntegrity()
        {
            bool validated = true;

            if (!System.IO.File.Exists(Globals.SaveFilePath))
            {
                validated = false;
            }
            else
            {
                try
                {
                    string file = Functions.ReadEncryptedFile(Globals.SaveFilePath);

                    string[] newline = { Environment.NewLine };
                    string[] comma = { ";" };

                    string[] lines = file.Split(newline, 2000, StringSplitOptions.RemoveEmptyEntries);

                    if (lines.Length != 13)
                    {
                        validated = false;
                    }
                }
                catch
                {
                    validated = false;
                }
            }

            return validated;
        }

        public static bool RecordFeatures(Enum.RecordType type)
        {
            bool unlocked = false;

            if (type == Enum.RecordType.SelectedShip)
            {
                Globals.SaveSelectedShip = Globals.SelectedShip.Ship.ToString();
            }
            else if (type == Enum.RecordType.UnlockedArea)
            {
                int shipIndex = FunctionsGame.GetShipIndex(Globals.SelectedShip);
                int areaIndex = -1;

                if (Globals.CurrentStage == 15)
                {
                    areaIndex = 0;
                }
                else if (Globals.CurrentStage == 25)
                {
                    areaIndex = 1;
                }
                else if (Globals.CurrentStage == 35)
                {
                    areaIndex = 2;
                }
                else if (Globals.CurrentStage == 45)
                {
                    areaIndex = 3;
                }
                else if (Globals.CurrentStage == 55)
                {
                    areaIndex = 4;
                }
                else if (Globals.CurrentStage == 65)
                {
                    areaIndex = 5;
                }

                if (Globals.CurrentStage != 65 && Globals.SelectedShip.Ship != Enum.Ships.TypeX1)
                {
                    unlocked = !Globals.SaveShipsAreasCompleted[areaIndex, shipIndex];
                }

                Globals.SaveShipsAreasCompleted[areaIndex, shipIndex] = true;
            }
            else if (type == Enum.RecordType.OreCollected)
            {
                int area = Convert.ToInt16(Globals.CurrentStage.ToString().Substring(0, 1));
                int stage = Convert.ToInt16(Globals.CurrentStage.ToString().Substring(1, 1));

                Globals.SaveOreCollected[area - 1, stage - 1] = true;
            }

            FunctionsGame.SaveGame();

            return unlocked;
        }

        public static bool VerifyCollision(SpriteShip sprite, Sprite lz, ref bool landed)
        {
            Globals.CollidedUp = false;
            Globals.CollidedDown = false;
            Globals.CollidedLeft = false;
            Globals.CollidedRight = false;

            if (Globals.CurrentStage != 0)
            {
                Globals.CollidedGround = FunctionsGame.CollidedGround();
            }

            if (Globals.CurrentStage != 0)
            {
                Globals.CollidedLZ = FunctionsGame.CollidedLZ(ref landed);
            }
            //else if (Globals.SelectedStageFreeCollision)
            //{
            //    Globals.CollidedLZ = FunctionsGame.CollidedLZ(ref landed);
            //}


            if (Globals.CollidedGround || Globals.CollidedLZ)
            {
                Globals.Collided = true;

                Globals.SelectedShip.VerticalVelocity = 0;
                Globals.SelectedShip.HorizontalVelocity = 0;

                Globals.SelectedShip.SpriteTop.Visible = false;
                Globals.SelectedShip.SpriteBotton.Visible = false;
                Globals.SelectedShip.SpriteLeft.Visible = false;
                Globals.SelectedShip.SpriteRight.Visible = false;
            }
            else
            {
                Globals.Collided = false;
            }

            return Globals.Collided;
        }

        public static bool CollidedLZ(ref bool landed)
        {
            bool collided = false;
            landed = false;

            if (Functions.DetectCollision(Globals.SelectedShip, Globals.SelectedStage.SpriteLZ, ref Globals.CollidedUp, ref Globals.CollidedDown, ref Globals.CollidedLeft, ref Globals.CollidedRight))
            {
                if (Globals.RelativeVelocity > Globals.SelectedShip.Resistance || Globals.CollidedUp || Globals.CollidedLeft || Globals.CollidedRight)
                {
                    if (Globals.SelectedShip.TotalVelocity < Globals.SelectedShip.Resistance * 2.5)
                    {
                        Globals.SelectedShip.TextureCurrent = Globals.SelectedShip.Textures[2];
                        Globals.SFXCrash.Play();
                    }
                    else
                    {
                        Globals.SelectedShip.TextureCurrent = Globals.SelectedShip.Textures[1];
                        Globals.SFXExplosion.Play();
                    }

                    collided = true;
                }
                else
                {
                    collided = true;
                    landed = true;
                }
            }

            return collided;
        }

        public static bool CollidedGround()
        {
            bool collided = false;

            if (Functions.CollideBorder(Globals.SelectedShip, Enum.Direction.Down, Globals.SelectedStage.SpriteAction.Height))
            {
                if (Globals.SelectedShip.TotalVelocity < Globals.SelectedShip.Resistance * 2.5)
                {
                    Globals.SelectedShip.TextureCurrent = Globals.SelectedShip.Textures[2];
                    Globals.SFXCrash.Play();
                }
                else
                {
                    Globals.SelectedShip.TextureCurrent = Globals.SelectedShip.Textures[1];
                    Globals.SFXExplosion.Play();
                }

                collided = true;
            }

            return collided;
        }

        public static void DecreaseFuel(SpriteShip sprite, Bar FuelBar)
        {
            if (Globals.UpKeyDown || Globals.DownKeyDown || Globals.LeftKeyDown || Globals.RightKeyDown)
            {
                sprite.Fuel -= sprite.FuelConsumptionRate;
            }

            if (Globals.SpaceKeyDown && sprite.UseFuelWhenSpecialKeyDown)
            {
                sprite.Fuel -= sprite.SpecialFuelConsumptionRate;
            }

            if (sprite.Fuel < 0)
            {
                sprite.Fuel = 0;
            }

            if (sprite.Fuel > sprite.MaxFuel)
            {
                sprite.Fuel = sprite.MaxFuel;
            }

            FuelBar.Value = (int)sprite.Fuel;

            if (sprite.Fuel < FuelBar.MaxValue / 5)
            {
                if ((FuelBar.ForeColor == Color.SpringGreen || FuelBar.ForeColor == Color.Purple) && (FuelBar.FlickCount == 2))
                {
                    FuelBar.ForeColor = Color.Red;
                    FuelBar.FlickCount = 0;
                }
                else if (FuelBar.ForeColor == Color.Red && (FuelBar.FlickCount == 2))
                {
                    FuelBar.ForeColor = Color.White;
                    FuelBar.FlickCount = 0;
                }
                else if (FuelBar.ForeColor == Color.White && (FuelBar.FlickCount == 2))
                {
                    FuelBar.ForeColor = Color.Red;
                    FuelBar.FlickCount = 0;
                }
            }
            else if (FuelBar.ForeColor != Color.Purple && (FuelBar.FlickCount == 2))
            {
                FuelBar.ForeColor = Color.SpringGreen;
                FuelBar.FlickCount = 0;
            }

            FuelBar.FlickCount++;
        }

        public static void UpdateNull()
        {
        }

        public static float GenerateRandomWind(int minValue, int maxValue, Stage stage)
        {
            float wind;
            Random r = new Random();
            float f = (float)r.NextDouble();
            wind = r.Next(minValue, maxValue);
            wind += f;

            if (f > 0.5F)
            {
                wind *= -1;
                stage.WindDirection = "W";
            }
            else
            {
                stage.WindDirection = "E";
            }

            return (float)Math.Round(wind, 2, MidpointRounding.AwayFromZero);
        }

        public static void MoveOffMapCursor()
        {
            Globals.SelectedStage.SpriteCursor.X = Globals.SelectedShip.X + Globals.SelectedShip.Width / 2;
            Globals.SelectedStage.FontCursor.Position.X = Globals.SelectedShip.X + Globals.SelectedShip.Width / 2;
            Globals.SelectedStage.FontCursor.Text = Convert.ToString((int)Globals.SelectedShip.Y * -1);
        }

        public static int GetShipIndex(SpriteShip sprite)
        {
            int shipIndex = -1;

            switch (Globals.SelectedShip.Ship)
            {
                case Enum.Ships.Type01: shipIndex = 0;
                    break;
                case Enum.Ships.Type02: shipIndex = 1;
                    break;
                case Enum.Ships.Type03: shipIndex = 2;
                    break;
                case Enum.Ships.Type04: shipIndex = 3;
                    break;
                case Enum.Ships.Type05: shipIndex = 4;
                    break;
                case Enum.Ships.Type06: shipIndex = 5;
                    break;
                case Enum.Ships.Type07: shipIndex = 6;
                    break;
                case Enum.Ships.Type08: shipIndex = 7;
                    break;
                case Enum.Ships.Type09: shipIndex = 8;
                    break;
                case Enum.Ships.TypeX1: shipIndex = 9;
                    break;
            }

            return shipIndex;
        }
    }
}
