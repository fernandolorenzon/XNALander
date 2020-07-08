using System.Collections.Generic;
using Microsoft.Xna.Framework;
using XNALander.Classes;
using Microsoft.Xna.Framework.Graphics;
using XNALander.StaticFunctions;

namespace XNALander.Scenes
{
    public class SceneChooseStage : Scene
    {
        Vector2 currentSelection = new Vector2();

        private Sprite cursor;

        private Stage location11;
        private Stage location12;
        private Stage location13;
        private Stage location14;
        private Stage location15;

        private Stage location21;
        private Stage location22;
        private Stage location23;
        private Stage location24;
        private Stage location25;

        private Stage location31;
        private Stage location32;
        private Stage location33;
        private Stage location34;
        private Stage location35;

        private Stage location41;
        private Stage location42;
        private Stage location43;
        private Stage location44;
        private Stage location45;

        private Stage location51;
        private Stage location52;
        private Stage location53;
        private Stage location54;
        private Stage location55;

        private Stage location61;
        private Stage location62;
        private Stage location63;
        private Stage location64;
        private Stage location65;

        private Sprite ore11;
        private Sprite ore12;
        private Sprite ore13;
        private Sprite ore14;
        private Sprite ore15;

        private Sprite ore21;
        private Sprite ore22;
        private Sprite ore23;
        private Sprite ore24;
        private Sprite ore25;

        private Sprite ore31;
        private Sprite ore32;
        private Sprite ore33;
        private Sprite ore34;
        private Sprite ore35;

        private Sprite ore41;
        private Sprite ore42;
        private Sprite ore43;
        private Sprite ore44;
        private Sprite ore45;

        private Sprite ore51;
        private Sprite ore52;
        private Sprite ore53;
        private Sprite ore54;
        private Sprite ore55;

        private Sprite ore61;
        private Sprite ore62;
        private Sprite ore63;
        private Sprite ore64;
        private Sprite ore65;

        private Font fontArea1;
        private Font fontArea2;
        private Font fontArea3;
        private Font fontArea4;
        private Font fontArea5;
        private Font fontArea6;

        private Font font11;
        private Font font12;
        private Font font13;
        private Font font14;
        private Font font15;

        private Font font21;
        private Font font22;
        private Font font23;
        private Font font24;
        private Font font25;

        private Font font31;
        private Font font32;
        private Font font33;
        private Font font34;
        private Font font35;

        private Font font41;
        private Font font42;
        private Font font43;
        private Font font44;
        private Font font45;

        private Font font51;
        private Font font52;
        private Font font53;
        private Font font54;
        private Font font55;

        private Font font61;
        private Font font62;
        private Font font63;
        private Font font64;
        private Font font65;

        private Stage[,] selectionGrid = new Stage[6, 5];
        private Sprite[,] selectionGridOre = new Sprite[6, 5];

        public SceneChooseStage()
        {

        }

        public override void LoadScene()
        {
            base.LoadScene();

            this.currentSelection = new Vector2(0, 0);

            this.selectionGrid[0, 0] = this.location11;
            this.selectionGrid[0, 1] = this.location12;
            this.selectionGrid[0, 2] = this.location13;
            this.selectionGrid[0, 3] = this.location14;
            this.selectionGrid[0, 4] = this.location15;

            this.selectionGrid[1, 0] = this.location21;
            this.selectionGrid[1, 1] = this.location22;
            this.selectionGrid[1, 2] = this.location23;
            this.selectionGrid[1, 3] = this.location24;
            this.selectionGrid[1, 4] = this.location25;

            this.selectionGrid[2, 0] = this.location31;
            this.selectionGrid[2, 1] = this.location32;
            this.selectionGrid[2, 2] = this.location33;
            this.selectionGrid[2, 3] = this.location34;
            this.selectionGrid[2, 4] = this.location35;

            this.selectionGrid[3, 0] = this.location41;
            this.selectionGrid[3, 1] = this.location42;
            this.selectionGrid[3, 2] = this.location43;
            this.selectionGrid[3, 3] = this.location44;
            this.selectionGrid[3, 4] = this.location45;

            this.selectionGrid[4, 0] = this.location51;
            this.selectionGrid[4, 1] = this.location52;
            this.selectionGrid[4, 2] = this.location53;
            this.selectionGrid[4, 3] = this.location54;
            this.selectionGrid[4, 4] = this.location55;

            this.selectionGrid[5, 0] = this.location61;
            this.selectionGrid[5, 1] = this.location62;
            this.selectionGrid[5, 2] = this.location63;
            this.selectionGrid[5, 3] = this.location64;
            this.selectionGrid[5, 4] = this.location65;

            this.selectionGridOre[0, 0] = this.ore11;
            this.selectionGridOre[0, 1] = this.ore12;
            this.selectionGridOre[0, 2] = this.ore13;
            this.selectionGridOre[0, 3] = this.ore14;
            this.selectionGridOre[0, 4] = this.ore15;

            this.selectionGridOre[1, 0] = this.ore21;
            this.selectionGridOre[1, 1] = this.ore22;
            this.selectionGridOre[1, 2] = this.ore23;
            this.selectionGridOre[1, 3] = this.ore24;
            this.selectionGridOre[1, 4] = this.ore25;

            this.selectionGridOre[2, 0] = this.ore31;
            this.selectionGridOre[2, 1] = this.ore32;
            this.selectionGridOre[2, 2] = this.ore33;
            this.selectionGridOre[2, 3] = this.ore34;
            this.selectionGridOre[2, 4] = this.ore35;

            this.selectionGridOre[3, 0] = this.ore41;
            this.selectionGridOre[3, 1] = this.ore42;
            this.selectionGridOre[3, 2] = this.ore43;
            this.selectionGridOre[3, 3] = this.ore44;
            this.selectionGridOre[3, 4] = this.ore45;

            this.selectionGridOre[4, 0] = this.ore51;
            this.selectionGridOre[4, 1] = this.ore52;
            this.selectionGridOre[4, 2] = this.ore53;
            this.selectionGridOre[4, 3] = this.ore54;
            this.selectionGridOre[4, 4] = this.ore55;

            this.selectionGridOre[5, 0] = this.ore61;
            this.selectionGridOre[5, 1] = this.ore62;
            this.selectionGridOre[5, 2] = this.ore63;
            this.selectionGridOre[5, 3] = this.ore64;
            this.selectionGridOre[5, 4] = this.ore65;

            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (this.selectionGrid[x, y] != null)
                    {
                        Sprite s = this.selectionGrid[x, y].SpriteLocation;

                        if (y == 0)
                        {
                            s.Y = 80;
                        }
                        else
                        {
                            s.Y = this.selectionGrid[x, y - 1].SpriteLocation.Y + 100;
                        }

                        if (x == 0)
                        {
                            s.X = 30;
                        }
                        else
                        {
                            s.X = this.selectionGrid[x - 1, y].SpriteLocation.X + 130;
                        }
                    }
                }
            }

            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    this.selectionGridOre[x, y].Visible = Globals.SaveOreCollected[x, y];
                    this.selectionGridOre[x, y].X = this.selectionGrid[x, y].SpriteLocation.X;
                    this.selectionGridOre[x, y].Y = this.selectionGrid[x, y].SpriteLocation.Y + this.selectionGrid[x, y].SpriteLocation.Height - 16;
                }
            }

            this.LoadSpriteFonts(this.location11, this.font11);
            this.LoadSpriteFonts(this.location12, this.font12);
            this.LoadSpriteFonts(this.location13, this.font13);
            this.LoadSpriteFonts(this.location14, this.font14);
            this.LoadSpriteFonts(this.location15, this.font15);

            this.LoadSpriteFonts(this.location11, this.font11);
            this.LoadSpriteFonts(this.location12, this.font12);
            this.LoadSpriteFonts(this.location13, this.font13);
            this.LoadSpriteFonts(this.location14, this.font14);
            this.LoadSpriteFonts(this.location15, this.font15);

            this.LoadSpriteFonts(this.location21, this.font21);
            this.LoadSpriteFonts(this.location22, this.font22);
            this.LoadSpriteFonts(this.location23, this.font23);
            this.LoadSpriteFonts(this.location24, this.font24);
            this.LoadSpriteFonts(this.location25, this.font25);

            this.LoadSpriteFonts(this.location31, this.font31);
            this.LoadSpriteFonts(this.location32, this.font32);
            this.LoadSpriteFonts(this.location33, this.font33);
            this.LoadSpriteFonts(this.location34, this.font34);
            this.LoadSpriteFonts(this.location35, this.font35);

            this.LoadSpriteFonts(this.location41, this.font41);
            this.LoadSpriteFonts(this.location42, this.font42);
            this.LoadSpriteFonts(this.location43, this.font43);
            this.LoadSpriteFonts(this.location44, this.font44);
            this.LoadSpriteFonts(this.location45, this.font45);

            this.LoadSpriteFonts(this.location51, this.font51);
            this.LoadSpriteFonts(this.location52, this.font52);
            this.LoadSpriteFonts(this.location53, this.font53);
            this.LoadSpriteFonts(this.location54, this.font54);
            this.LoadSpriteFonts(this.location55, this.font55);

            this.LoadSpriteFonts(this.location61, this.font61);
            this.LoadSpriteFonts(this.location62, this.font62);
            this.LoadSpriteFonts(this.location63, this.font63);
            this.LoadSpriteFonts(this.location64, this.font64);
            this.LoadSpriteFonts(this.location65, this.font65);

            int gap = 45;

            this.fontArea1.Position.X = this.location11.SpriteLocation.X;
            this.fontArea1.Position.Y = this.location11.SpriteLocation.Y - gap;

            this.fontArea2.Position.X = this.location21.SpriteLocation.X;
            this.fontArea2.Position.Y = this.location21.SpriteLocation.Y - gap;

            this.fontArea3.Position.X = this.location31.SpriteLocation.X;
            this.fontArea3.Position.Y = this.location31.SpriteLocation.Y - gap;

            this.fontArea4.Position.X = this.location41.SpriteLocation.X;
            this.fontArea4.Position.Y = this.location41.SpriteLocation.Y - gap;

            this.fontArea5.Position.X = this.location51.SpriteLocation.X;
            this.fontArea5.Position.Y = this.location51.SpriteLocation.Y - gap;

            this.fontArea6.Position.X = this.location61.SpriteLocation.X;
            this.fontArea6.Position.Y = this.location61.SpriteLocation.Y - gap;

            int shipIndex = FunctionsGame.GetShipIndex(Globals.SelectedShip);

            this.location21.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[0, shipIndex];
            this.location22.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[0, shipIndex];
            this.location23.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[0, shipIndex];
            this.location24.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[0, shipIndex];
            this.location25.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[0, shipIndex];

            this.location31.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[1, shipIndex];
            this.location32.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[1, shipIndex];
            this.location33.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[1, shipIndex];
            this.location34.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[1, shipIndex];
            this.location35.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[1, shipIndex];

            this.location41.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[2, shipIndex];
            this.location42.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[2, shipIndex];
            this.location43.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[2, shipIndex];
            this.location44.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[2, shipIndex];
            this.location45.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[2, shipIndex];

            this.location51.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[3, shipIndex];
            this.location52.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[3, shipIndex];
            this.location53.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[3, shipIndex];
            this.location54.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[3, shipIndex];
            this.location55.SpriteLocation.Visible = Globals.SaveShipsAreasCompleted[3, shipIndex];

            bool area6Enabled = true;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!Globals.SaveOreCollected[i, j])
                    {
                        area6Enabled = false;
                    }
                }
            }

            this.location61.SpriteLocation.Visible = area6Enabled;
            this.location62.SpriteLocation.Visible = area6Enabled;
            this.location63.SpriteLocation.Visible = area6Enabled;
            this.location64.SpriteLocation.Visible = area6Enabled;
            this.location65.SpriteLocation.Visible = area6Enabled;

            this.font21.Visible = this.location21.SpriteLocation.Visible;
            this.font22.Visible = this.location22.SpriteLocation.Visible;
            this.font23.Visible = this.location23.SpriteLocation.Visible;
            this.font24.Visible = this.location24.SpriteLocation.Visible;
            this.font25.Visible = this.location25.SpriteLocation.Visible;

            this.font31.Visible = this.location31.SpriteLocation.Visible;
            this.font32.Visible = this.location32.SpriteLocation.Visible;
            this.font33.Visible = this.location33.SpriteLocation.Visible;
            this.font34.Visible = this.location34.SpriteLocation.Visible;
            this.font35.Visible = this.location35.SpriteLocation.Visible;

            this.font41.Visible = this.location41.SpriteLocation.Visible;
            this.font42.Visible = this.location42.SpriteLocation.Visible;
            this.font43.Visible = this.location43.SpriteLocation.Visible;
            this.font44.Visible = this.location44.SpriteLocation.Visible;
            this.font45.Visible = this.location45.SpriteLocation.Visible;

            this.font51.Visible = this.location51.SpriteLocation.Visible;
            this.font52.Visible = this.location52.SpriteLocation.Visible;
            this.font53.Visible = this.location53.SpriteLocation.Visible;
            this.font54.Visible = this.location54.SpriteLocation.Visible;
            this.font55.Visible = this.location55.SpriteLocation.Visible;

            this.font61.Visible = this.location61.SpriteLocation.Visible;
            this.font62.Visible = this.location62.SpriteLocation.Visible;
            this.font63.Visible = this.location63.SpriteLocation.Visible;
            this.font64.Visible = this.location64.SpriteLocation.Visible;
            this.font65.Visible = this.location65.SpriteLocation.Visible;

            if (!this.font21.Visible)
            {
                this.fontArea2.Text = "Bloqueado";
                this.fontArea2.Color = Color.White;
            }

            if (!this.font31.Visible)
            {
                this.fontArea3.Text = "Bloqueado";
                this.fontArea3.Color = Color.White;
            }

            if (!this.font41.Visible)
            {
                this.fontArea4.Text = "Bloqueado";
                this.fontArea4.Color = Color.White;
            }

            if (!this.font51.Visible)
            {
                this.fontArea5.Text = "Bloqueado";
                this.fontArea5.Color = Color.White;
            }

            if (!this.font61.Visible)
            {
                this.fontArea6.Text = "Bloqueado";
                this.fontArea6.Color = Color.White;
            }

            Globals.SelectedStage = this.selectionGrid[0, 0];
        }

        public override void LoadSpriteList()
        {
            this.location11 = new Stage(11);
            this.location12 = new Stage(12);
            this.location13 = new Stage(13);
            this.location14 = new Stage(14);
            this.location15 = new Stage(15);

            this.location21 = new Stage(21);
            this.location22 = new Stage(22);
            this.location23 = new Stage(23);
            this.location24 = new Stage(24);
            this.location25 = new Stage(25);

            this.location31 = new Stage(31);
            this.location32 = new Stage(32);
            this.location33 = new Stage(33);
            this.location34 = new Stage(34);
            this.location35 = new Stage(35);

            this.location41 = new Stage(41);
            this.location42 = new Stage(42);
            this.location43 = new Stage(43);
            this.location44 = new Stage(44);
            this.location45 = new Stage(45);

            this.location51 = new Stage(51);
            this.location52 = new Stage(52);
            this.location53 = new Stage(53);
            this.location54 = new Stage(54);
            this.location55 = new Stage(55);

            this.location61 = new Stage(61);
            this.location62 = new Stage(62);
            this.location63 = new Stage(63);
            this.location64 = new Stage(64);
            this.location65 = new Stage(65);

            this.ore11 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore12 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore13 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore14 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore15 = new Sprite(16, 16, "Images\\Misc\\OreCollected");

            this.ore21 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore22 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore23 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore24 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore25 = new Sprite(16, 16, "Images\\Misc\\OreCollected");

            this.ore31 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore32 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore33 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore34 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore35 = new Sprite(16, 16, "Images\\Misc\\OreCollected");

            this.ore41 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore42 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore43 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore44 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore45 = new Sprite(16, 16, "Images\\Misc\\OreCollected");

            this.ore51 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore52 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore53 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore54 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore55 = new Sprite(16, 16, "Images\\Misc\\OreCollected");

            this.ore61 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore62 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore63 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore64 = new Sprite(16, 16, "Images\\Misc\\OreCollected");
            this.ore65 = new Sprite(16, 16, "Images\\Misc\\OreCollected");

            this.cursor = new Sprite(16, 16, "Images\\Misc\\HMenuCursor");

            this.SpriteList = new List<Sprite>();

            this.SpriteList.Add(this.location11.SpriteLocation);
            this.SpriteList.Add(this.location12.SpriteLocation);
            this.SpriteList.Add(this.location13.SpriteLocation);
            this.SpriteList.Add(this.location14.SpriteLocation);
            this.SpriteList.Add(this.location15.SpriteLocation);

            this.SpriteList.Add(this.location21.SpriteLocation);
            this.SpriteList.Add(this.location22.SpriteLocation);
            this.SpriteList.Add(this.location23.SpriteLocation);
            this.SpriteList.Add(this.location24.SpriteLocation);
            this.SpriteList.Add(this.location25.SpriteLocation);

            this.SpriteList.Add(this.location31.SpriteLocation);
            this.SpriteList.Add(this.location32.SpriteLocation);
            this.SpriteList.Add(this.location33.SpriteLocation);
            this.SpriteList.Add(this.location34.SpriteLocation);
            this.SpriteList.Add(this.location35.SpriteLocation);

            this.SpriteList.Add(this.location41.SpriteLocation);
            this.SpriteList.Add(this.location42.SpriteLocation);
            this.SpriteList.Add(this.location43.SpriteLocation);
            this.SpriteList.Add(this.location44.SpriteLocation);
            this.SpriteList.Add(this.location45.SpriteLocation);

            this.SpriteList.Add(this.location51.SpriteLocation);
            this.SpriteList.Add(this.location52.SpriteLocation);
            this.SpriteList.Add(this.location53.SpriteLocation);
            this.SpriteList.Add(this.location54.SpriteLocation);
            this.SpriteList.Add(this.location55.SpriteLocation);

            this.SpriteList.Add(this.location61.SpriteLocation);
            this.SpriteList.Add(this.location62.SpriteLocation);
            this.SpriteList.Add(this.location63.SpriteLocation);
            this.SpriteList.Add(this.location64.SpriteLocation);
            this.SpriteList.Add(this.location65.SpriteLocation);

            this.SpriteList.Add(this.ore11);
            this.SpriteList.Add(this.ore12);
            this.SpriteList.Add(this.ore13);
            this.SpriteList.Add(this.ore14);
            this.SpriteList.Add(this.ore15);

            this.SpriteList.Add(this.ore21);
            this.SpriteList.Add(this.ore22);
            this.SpriteList.Add(this.ore23);
            this.SpriteList.Add(this.ore24);
            this.SpriteList.Add(this.ore25);

            this.SpriteList.Add(this.ore31);
            this.SpriteList.Add(this.ore32);
            this.SpriteList.Add(this.ore33);
            this.SpriteList.Add(this.ore34);
            this.SpriteList.Add(this.ore35);

            this.SpriteList.Add(this.ore41);
            this.SpriteList.Add(this.ore42);
            this.SpriteList.Add(this.ore43);
            this.SpriteList.Add(this.ore44);
            this.SpriteList.Add(this.ore45);

            this.SpriteList.Add(this.ore51);
            this.SpriteList.Add(this.ore52);
            this.SpriteList.Add(this.ore53);
            this.SpriteList.Add(this.ore54);
            this.SpriteList.Add(this.ore55);

            this.SpriteList.Add(this.ore61);
            this.SpriteList.Add(this.ore62);
            this.SpriteList.Add(this.ore63);
            this.SpriteList.Add(this.ore64);
            this.SpriteList.Add(this.ore65);

            this.SpriteList.Add(this.cursor);
        }

        public override void LoadFontList()
        {
            this.fontArea1 = new Font("Fonts\\StageOptions", "Área 1", new Vector2(0, 0), Color.Lime);
            this.fontArea2 = new Font("Fonts\\StageOptions", "Área 2", new Vector2(0, 0), Color.Lime);
            this.fontArea3 = new Font("Fonts\\StageOptions", "Área 3", new Vector2(0, 0), Color.Lime);
            this.fontArea4 = new Font("Fonts\\StageOptions", "Área 4", new Vector2(0, 0), Color.Lime);
            this.fontArea5 = new Font("Fonts\\StageOptions", "Área 5", new Vector2(0, 0), Color.Lime);
            this.fontArea6 = new Font("Fonts\\StageOptions", "Área 6", new Vector2(0, 0), Color.Lime);

            this.font11 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font12 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font13 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font14 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font15 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);

            this.font21 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font22 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font23 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font24 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font25 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);

            this.font31 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font32 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font33 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font34 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font35 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);

            this.font41 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font42 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font43 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font44 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font45 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);

            this.font51 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font52 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font53 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font54 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font55 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);

            this.font61 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font62 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font63 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font64 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);
            this.font65 = new Font("Fonts\\MenuOptions", "1", new Vector2(0, 0), Color.Lime);

            Globals.FontInfo1.Text = "Pressione Enter para selecionar\r\nPressione Esc para voltar";

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                Globals.FontInfo2 = new Font("Fonts\\Info", "", new Vector2(240, 5), Color.Gold);
                Globals.FontInfo2.Text = "Colete todos os minérios para desbloquear a última área e nave";
            }

            this.FontList = new List<Font>();

            this.FontList.Add(this.fontArea1);
            this.FontList.Add(this.fontArea2);
            this.FontList.Add(this.fontArea3);
            this.FontList.Add(this.fontArea4);
            this.FontList.Add(this.fontArea5);
            this.FontList.Add(this.fontArea6);

            this.FontList.Add(this.font11);
            this.FontList.Add(this.font12);
            this.FontList.Add(this.font13);
            this.FontList.Add(this.font14);
            this.FontList.Add(this.font15);

            this.FontList.Add(this.font21);
            this.FontList.Add(this.font22);
            this.FontList.Add(this.font23);
            this.FontList.Add(this.font24);
            this.FontList.Add(this.font25);

            this.FontList.Add(this.font31);
            this.FontList.Add(this.font32);
            this.FontList.Add(this.font33);
            this.FontList.Add(this.font34);
            this.FontList.Add(this.font35);

            this.FontList.Add(this.font41);
            this.FontList.Add(this.font42);
            this.FontList.Add(this.font43);
            this.FontList.Add(this.font44);
            this.FontList.Add(this.font45);

            this.FontList.Add(this.font51);
            this.FontList.Add(this.font52);
            this.FontList.Add(this.font53);
            this.FontList.Add(this.font54);
            this.FontList.Add(this.font55);

            this.FontList.Add(this.font61);
            this.FontList.Add(this.font62);
            this.FontList.Add(this.font63);
            this.FontList.Add(this.font64);
            this.FontList.Add(this.font65);

            this.FontList.Add(Globals.FontInfo1);

            if (Globals.GameType == Enum.GameType.OreColleting)
            {
                this.FontList.Add(Globals.FontInfo2);
            }
        }

        public override void Update()
        {
            Functions.KeyReading();

            if (Globals.EnterKeyPressed)
            {
                if (Globals.SelectedStage.SpriteLocation.Visible)
                {
                    Globals.SFXSelected.Play();
                    Globals.CurrentStage = Globals.SelectedStage.StageNumber;
                    Globals.CurrentScene = new SceneAction();
                }
            }

            else if (Globals.EscKeyPressed)
            {
                Globals.CurrentScene = new SceneTitle();
            }
            else if (Globals.RightKeyPressed)
            {
                this.currentSelection.X++;
            }
            else if (Globals.LeftKeyPressed)
            {
                this.currentSelection.X--;
            }
            else if (Globals.UpKeyPressed)
            {
                this.currentSelection.Y--;
            }
            else if (Globals.DownKeyPressed)
            {
                this.currentSelection.Y++;
            }

            if (this.currentSelection.X > 5)
            {
                this.currentSelection.X = 5;
            }

            if (this.currentSelection.Y > 4)
            {
                this.currentSelection.Y = 4;
            }

            if (this.currentSelection.X < 0)
            {
                this.currentSelection.X = 0;
            }

            if (this.currentSelection.Y < 0)
            {
                this.currentSelection.Y = 0;
            }

            Globals.SelectedStage = this.selectionGrid[(int)this.currentSelection.X, (int)this.currentSelection.Y];

            this.cursor.Y = Globals.SelectedStage.SpriteLocation.Y + 10;
            this.cursor.X = Globals.SelectedStage.SpriteLocation.X - 20;
        }

        private void LoadSpriteFonts(Stage stage, Font fontStage)
        {
            fontStage.Position.X = stage.SpriteLocation.X;
            fontStage.Position.Y = stage.SpriteLocation.Y + 60;

            fontStage.Text = stage.Location;
        }
    }
}
