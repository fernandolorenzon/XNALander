using System;
using System.Collections.Generic;
using XNALander.Classes;
using XNALander.StaticFunctions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNALander.Scenes
{
    public class SceneChooseArea : Scene
    {
        private Sprite area1;
        private Sprite area2;
        private Sprite area3;
        private Sprite area4;
        private Sprite area5;
        private Sprite area6;

        private Sprite area1Clear;
        private Sprite area2Clear;
        private Sprite area3Clear;
        private Sprite area4Clear;
        private Sprite area5Clear;
        private Sprite area6Clear;

        private Sprite cursor;

        private Font font2Locked;
        private Font font3Locked;
        private Font font4Locked;
        private Font font5Locked;
        private Font font6Locked;

        private int cursorYGap = 30;
        private int selectedAreaIndex = 0;
        private Sprite[] areas;

        public SceneChooseArea()
        {
        }

        public override void LoadScene()
        {
            base.LoadScene();

            Globals.ShipsLeft = 2;

            this.areas = new Sprite[6];
            this.areas[0] = this.area1;
            this.areas[1] = this.area2;
            this.areas[2] = this.area3;
            this.areas[3] = this.area4;
            this.areas[4] = this.area5;
            this.areas[5] = this.area6;

            int x = 50;
            int gap = 5;

            this.area1.X = x;
            this.area1.Y = 20;

            this.area2.X = x;
            this.area2.Y = this.area1.Y + this.area1.Height + gap;

            this.area3.X = x;
            this.area3.Y = this.area2.Y + this.area2.Height + gap;

            this.area4.X = x;
            this.area4.Y = this.area3.Y + this.area3.Height + gap;

            this.area5.X = x;
            this.area5.Y = this.area4.Y + this.area4.Height + gap;

            this.area6.X = x;
            this.area6.Y = this.area5.Y + this.area5.Height + gap;

            this.area1Clear.X = this.area1.X + this.area1.Width + 5;
            this.area1Clear.Y = this.area1.Y + 10;

            this.area2Clear.X = this.area2.X + this.area2.Width + 5;
            this.area2Clear.Y = this.area2.Y + 10;

            this.area3Clear.X = this.area3.X + this.area3.Width + 5;
            this.area3Clear.Y = this.area3.Y + 10;

            this.area4Clear.X = this.area4.X + this.area4.Width + 5;
            this.area4Clear.Y = this.area4.Y + 10;

            this.area5Clear.X = this.area5.X + this.area5.Width + 5;
            this.area5Clear.Y = this.area5.Y + 10;

            this.area6Clear.X = this.area6.X + this.area6.Width + 5;
            this.area6Clear.Y = this.area6.Y + 10;

            this.cursor.X = this.area1.X - 40;
            this.cursor.Y = this.area1.Y + this.cursorYGap;

            int gapLocked = 20;

            this.font2Locked.Position.X = this.area2.X;
            this.font2Locked.Position.Y = this.area2.Y + gapLocked;

            this.font3Locked.Position.X = this.area3.X;
            this.font3Locked.Position.Y = this.area3.Y + gapLocked;

            this.font4Locked.Position.X = this.area4.X;
            this.font4Locked.Position.Y = this.area4.Y + gapLocked;

            this.font5Locked.Position.X = this.area5.X;
            this.font5Locked.Position.Y = this.area5.Y + gapLocked;

            this.font6Locked.Position.X = this.area6.X;
            this.font6Locked.Position.Y = this.area6.Y + gapLocked;

            int shipIndex = FunctionsGame.GetShipIndex(Globals.SelectedShip);

            this.area2.Visible = Globals.SaveShipsAreasCompleted[0, shipIndex];
            this.area3.Visible = Globals.SaveShipsAreasCompleted[1, shipIndex];
            this.area4.Visible = Globals.SaveShipsAreasCompleted[2, shipIndex];
            this.area5.Visible = Globals.SaveShipsAreasCompleted[3, shipIndex];

            this.area1Clear.Visible = Globals.SaveShipsAreasCompleted[0, shipIndex];
            this.area2Clear.Visible = Globals.SaveShipsAreasCompleted[1, shipIndex];
            this.area3Clear.Visible = Globals.SaveShipsAreasCompleted[2, shipIndex];
            this.area4Clear.Visible = Globals.SaveShipsAreasCompleted[3, shipIndex];
            this.area5Clear.Visible = Globals.SaveShipsAreasCompleted[4, shipIndex];
            this.area6Clear.Visible = Globals.SaveShipsAreasCompleted[5, shipIndex];

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

            this.area6.Visible = area6Enabled;

            this.font2Locked.Visible = !this.area2.Visible;
            this.font3Locked.Visible = !this.area3.Visible;
            this.font4Locked.Visible = !this.area4.Visible;
            this.font5Locked.Visible = !this.area5.Visible;
            this.font6Locked.Visible = !this.area6.Visible;
        }

        public override void LoadSpriteList()
        {
            this.area1 = new Sprite(700, 90, "Images\\Areas\\Area1_Neiborhood_Typed");
            this.area2 = new Sprite(700, 90, "Images\\Areas\\Area2_JupiterMoons_Typed");
            this.area3 = new Sprite(700, 90, "Images\\Areas\\Area3_OtherMoons_Typed");
            this.area4 = new Sprite(700, 90, "Images\\Areas\\Area4_DwarfPlanets_Typed");
            this.area5 = new Sprite(700, 90, "Images\\Areas\\Area5_Asteroids_Typed");
            this.area6 = new Sprite(700, 90, "Images\\Areas\\Area6_MetroidUniverse_Typed");

            this.area1Clear = new Sprite(32, 32, "Images\\Misc\\Clear");
            this.area2Clear = new Sprite(32, 32, "Images\\Misc\\Clear");
            this.area3Clear = new Sprite(32, 32, "Images\\Misc\\Clear");
            this.area4Clear = new Sprite(32, 32, "Images\\Misc\\Clear");
            this.area5Clear = new Sprite(32, 32, "Images\\Misc\\Clear");
            this.area6Clear = new Sprite(32, 32, "Images\\Misc\\Clear");

            this.cursor = new Sprite(16, 16, "Images\\Misc\\HMenuCursor");

            this.SpriteList = new List<Sprite>();

            this.SpriteList.Add(this.area1);
            this.SpriteList.Add(this.area2);
            this.SpriteList.Add(this.area3);
            this.SpriteList.Add(this.area4);
            this.SpriteList.Add(this.area5);
            this.SpriteList.Add(this.area6);

            this.SpriteList.Add(this.area1Clear);
            this.SpriteList.Add(this.area2Clear);
            this.SpriteList.Add(this.area3Clear);
            this.SpriteList.Add(this.area4Clear);
            this.SpriteList.Add(this.area5Clear);
            this.SpriteList.Add(this.area6Clear);

            this.SpriteList.Add(this.cursor);
        }

        public override void LoadFontList()
        {
            this.font2Locked = new Font("Fonts\\Message", "Bloqueado", new Vector2(0, 0), Color.White);
            this.font3Locked = new Font("Fonts\\Message", "Bloqueado", new Vector2(0, 0), Color.White);
            this.font4Locked = new Font("Fonts\\Message", "Bloqueado", new Vector2(0, 0), Color.White);
            this.font5Locked = new Font("Fonts\\Message", "Bloqueado", new Vector2(0, 0), Color.White);
            this.font6Locked = new Font("Fonts\\Message", "Bloqueado", new Vector2(0, 0), Color.White);

            Globals.FontInfo2 = new Font("Fonts\\Info", "", new Vector2(250, 5), Color.Gold);

            Globals.FontInfo1.Text = "Pressione Enter para selecionar\r\nPressione Esc para voltar";
            
            Globals.FontInfo2.Text = "Complete as 5 áreas para desbloquear uma nova nave";

            this.FontList.Add(this.font2Locked);
            this.FontList.Add(this.font3Locked);
            this.FontList.Add(this.font4Locked);
            this.FontList.Add(this.font5Locked);
            this.FontList.Add(this.font6Locked);
            this.FontList.Add(Globals.FontInfo1);
            this.FontList.Add(Globals.FontInfo2);
        }

        public override void Update()
        {
            Functions.KeyReading();

            if (Globals.DownKeyPressed)
            {
                if (this.selectedAreaIndex < 5)
                {
                    this.selectedAreaIndex++;
                    this.cursor.Y = this.areas[this.selectedAreaIndex].Y + this.cursorYGap;
                }
            }
            else if (Globals.UpKeyPressed)
            {
                if (this.selectedAreaIndex > 0)
                {
                    this.selectedAreaIndex--;
                    this.cursor.Y = this.areas[this.selectedAreaIndex].Y + this.cursorYGap;
                }
            }
            else if (Globals.EnterKeyPressed)
            {
                if (this.SpriteList[this.selectedAreaIndex].Visible)
                {
                    Globals.SFXSelected.Play();
                    Functions.CreateDelay(1);
                    Globals.CurrentStage = Convert.ToInt32((this.selectedAreaIndex + 1).ToString() + "1");
                    Globals.CurrentScene = new SceneAction();
                }
            }
            else if (Globals.EscKeyPressed)
            {
                Globals.CurrentStage = 11;
                Globals.CurrentScene = new SceneTitle();
            }
        }
    }
}