using System;
using System.Collections.Generic;
using XNALander.Classes;
using Microsoft.Xna.Framework;
using XNALander.StaticFunctions;
using Microsoft.Xna.Framework.Graphics;

namespace XNALander.Scenes
{
    public class SceneChooseShip : Scene
    {
        Vector2 currentSelection = new Vector2();

        SpriteShip currentShip;
        private SpriteShip ship1;
        private SpriteShip ship2;
        private SpriteShip ship3;
        private SpriteShip ship4;
        private SpriteShip ship5;
        private SpriteShip ship6;
        private SpriteShip ship7;
        private SpriteShip ship8;
        private SpriteShip ship9;
        private SpriteShip shipX1;
        private Sprite cursor;

        private Font fontID01;
        private Font fontName01;
        private Font fontAccel01;
        private Font fontResistance01;
        private Font fontSpecial01;

        private Font fontID02;
        private Font fontName02;
        private Font fontAccel02;
        private Font fontResistance02;
        private Font fontSpecial02;
        private Font font02Locked;

        private Font fontID03;
        private Font fontName03;
        private Font fontAccel03;
        private Font fontResistance03;
        private Font fontSpecial03;
        private Font font03Locked;

        private Font fontID04;
        private Font fontName04;
        private Font fontAccel04;
        private Font fontResistance04;
        private Font fontSpecial04;
        private Font font04Locked;

        private Font fontID05;
        private Font fontName05;
        private Font fontAccel05;
        private Font fontResistance05;
        private Font fontSpecial05;
        private Font font05Locked;

        private Font fontID06;
        private Font fontName06;
        private Font fontAccel06;
        private Font fontResistance06;
        private Font fontSpecial06;
        private Font font06Locked;

        private Font fontID07;
        private Font fontName07;
        private Font fontAccel07;
        private Font fontResistance07;
        private Font fontSpecial07;
        private Font font07Locked;

        private Font fontID08;
        private Font fontName08;
        private Font fontAccel08;
        private Font fontResistance08;
        private Font fontSpecial08;
        private Font font08Locked;

        private Font fontID09;
        private Font fontName09;
        private Font fontAccel09;
        private Font fontResistance09;
        private Font fontSpecial09;
        private Font font09Locked;

        private Font fontIDX1;
        private Font fontNameX1;
        private Font fontAccelX1;
        private Font fontResistanceX1;
        private Font fontSpecialX1;
        private Font fontX1Locked;

        private Font fontCommand;
        private Font fontCommandUp;
        private Font fontCommandDown;
        private Font fontCommandLeft;
        private Font fontCommandRight;
        private Font fontCommandSpecial;

        private SpriteShip[,] selectionGrid = new SpriteShip[4, 3];

        public SceneChooseShip()
        {

        }

        public override void LoadScene()
        {
            base.LoadScene();

            this.ship1.Visible = true;
            this.fontID01.Visible = true;
            this.fontName01.Visible = true;
            this.fontAccel01.Visible = true;
            this.fontResistance01.Visible = true;
            this.fontSpecial01.Visible = true;

            this.ship2.Visible = Globals.SaveShipsAreasCompleted[4, 0];
            this.fontID02.Visible = Globals.SaveShipsAreasCompleted[4, 0];
            this.fontName02.Visible = Globals.SaveShipsAreasCompleted[4, 0];
            this.fontAccel02.Visible = Globals.SaveShipsAreasCompleted[4, 0];
            this.fontResistance02.Visible = Globals.SaveShipsAreasCompleted[4, 0];
            this.fontSpecial02.Visible = Globals.SaveShipsAreasCompleted[4, 0];
            this.font02Locked.Visible = !this.ship2.Visible;

            this.ship3.Visible = Globals.SaveShipsAreasCompleted[4, 1];
            this.fontID03.Visible = Globals.SaveShipsAreasCompleted[4, 1];
            this.fontName03.Visible = Globals.SaveShipsAreasCompleted[4, 1];
            this.fontAccel03.Visible = Globals.SaveShipsAreasCompleted[4, 1];
            this.fontResistance03.Visible = Globals.SaveShipsAreasCompleted[4, 1];
            this.fontSpecial03.Visible = Globals.SaveShipsAreasCompleted[4, 1];
            this.font03Locked.Visible = !this.ship3.Visible;

            this.ship4.Visible = Globals.SaveShipsAreasCompleted[4, 2];
            this.fontID04.Visible = Globals.SaveShipsAreasCompleted[4, 2];
            this.fontName04.Visible = Globals.SaveShipsAreasCompleted[4, 2];
            this.fontAccel04.Visible = Globals.SaveShipsAreasCompleted[4, 2];
            this.fontResistance04.Visible = Globals.SaveShipsAreasCompleted[4, 2];
            this.fontSpecial04.Visible = Globals.SaveShipsAreasCompleted[4, 2];
            this.font04Locked.Visible = !this.ship4.Visible;

            this.ship5.Visible = Globals.SaveShipsAreasCompleted[4, 3];
            this.fontID05.Visible = Globals.SaveShipsAreasCompleted[4, 3];
            this.fontName05.Visible = Globals.SaveShipsAreasCompleted[4, 3];
            this.fontAccel05.Visible = Globals.SaveShipsAreasCompleted[4, 3];
            this.fontResistance05.Visible = Globals.SaveShipsAreasCompleted[4, 3];
            this.fontSpecial05.Visible = Globals.SaveShipsAreasCompleted[4, 3];
            this.font05Locked.Visible = !this.ship5.Visible;

            this.ship6.Visible = Globals.SaveShipsAreasCompleted[4, 4];
            this.fontID06.Visible = Globals.SaveShipsAreasCompleted[4, 4];
            this.fontName06.Visible = Globals.SaveShipsAreasCompleted[4, 4];
            this.fontAccel06.Visible = Globals.SaveShipsAreasCompleted[4, 4];
            this.fontResistance06.Visible = Globals.SaveShipsAreasCompleted[4, 4];
            this.fontSpecial06.Visible = Globals.SaveShipsAreasCompleted[4, 4];
            this.font06Locked.Visible = !this.ship6.Visible;

            this.ship7.Visible = Globals.SaveShipsAreasCompleted[4, 5];
            this.fontID07.Visible = Globals.SaveShipsAreasCompleted[4, 5];
            this.fontName07.Visible = Globals.SaveShipsAreasCompleted[4, 5];
            this.fontAccel07.Visible = Globals.SaveShipsAreasCompleted[4, 5];
            this.fontResistance07.Visible = Globals.SaveShipsAreasCompleted[4, 5];
            this.fontSpecial07.Visible = Globals.SaveShipsAreasCompleted[4, 5];
            this.font07Locked.Visible = !this.ship7.Visible;

            this.ship8.Visible = Globals.SaveShipsAreasCompleted[4, 6];
            this.fontID08.Visible = Globals.SaveShipsAreasCompleted[4, 6];
            this.fontName08.Visible = Globals.SaveShipsAreasCompleted[4, 6];
            this.fontAccel08.Visible = Globals.SaveShipsAreasCompleted[4, 6];
            this.fontResistance08.Visible = Globals.SaveShipsAreasCompleted[4, 6];
            this.fontSpecial08.Visible = Globals.SaveShipsAreasCompleted[4, 6];
            this.font08Locked.Visible = !this.ship8.Visible;

            this.ship9.Visible = Globals.SaveShipsAreasCompleted[4, 7];
            this.fontID09.Visible = Globals.SaveShipsAreasCompleted[4, 7];
            this.fontName09.Visible = Globals.SaveShipsAreasCompleted[4, 7];
            this.fontAccel09.Visible = Globals.SaveShipsAreasCompleted[4, 7];
            this.fontResistance09.Visible = Globals.SaveShipsAreasCompleted[4, 7];
            this.fontSpecial09.Visible = Globals.SaveShipsAreasCompleted[4, 7];
            this.font09Locked.Visible = !this.ship9.Visible;

            this.shipX1.Visible = true;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!Globals.SaveOreCollected[i, j])
                    {
                        this.shipX1.Visible = false;
                    }
                }
            }


            this.fontIDX1.Visible = this.shipX1.Visible;
            this.fontNameX1.Visible = this.shipX1.Visible;
            this.fontAccelX1.Visible = this.shipX1.Visible;
            this.fontResistanceX1.Visible = this.shipX1.Visible;
            this.fontSpecialX1.Visible = this.shipX1.Visible;
            this.fontX1Locked.Visible = !this.shipX1.Visible;

            this.currentSelection = new Vector2(0, 0);

            this.selectionGrid[0, 0] = this.ship1;
            this.selectionGrid[1, 0] = this.ship2;
            this.selectionGrid[2, 0] = this.ship3;
            this.selectionGrid[3, 0] = this.ship4;
            this.selectionGrid[0, 1] = this.ship5;
            this.selectionGrid[1, 1] = this.ship6;
            this.selectionGrid[2, 1] = this.ship7;
            this.selectionGrid[0, 2] = this.ship8;
            this.selectionGrid[1, 2] = this.ship9;
            this.selectionGrid[2, 2] = this.shipX1;

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (this.selectionGrid[x, y] != null)
                    {
                        SpriteShip s = this.selectionGrid[x, y];

                        if (y == 0)
                        {
                            s.Y = 30;
                        }
                        else
                        {
                            s.Y = this.selectionGrid[x, y - 1].Y + 170;
                        }

                        if (x == 0)
                        {
                            s.X = 30;
                        }
                        else
                        {
                            s.X = this.selectionGrid[x - 1, y].X + 190;
                        }
                    }
                }
            }

            this.LoadSpriteFonts(this.ship1, this.fontID01, this.fontName01, this.fontAccel01, this.fontResistance01, this.fontSpecial01);
            this.LoadSpriteFonts(this.ship2, this.fontID02, this.fontName02, this.fontAccel02, this.fontResistance02, this.fontSpecial02);
            this.LoadSpriteFonts(this.ship3, this.fontID03, this.fontName03, this.fontAccel03, this.fontResistance03, this.fontSpecial03);
            this.LoadSpriteFonts(this.ship4, this.fontID04, this.fontName04, this.fontAccel04, this.fontResistance04, this.fontSpecial04);
            this.LoadSpriteFonts(this.ship5, this.fontID05, this.fontName05, this.fontAccel05, this.fontResistance05, this.fontSpecial05);
            this.LoadSpriteFonts(this.ship6, this.fontID06, this.fontName06, this.fontAccel06, this.fontResistance06, this.fontSpecial06);
            this.LoadSpriteFonts(this.ship7, this.fontID07, this.fontName07, this.fontAccel07, this.fontResistance07, this.fontSpecial07);
            this.LoadSpriteFonts(this.ship8, this.fontID08, this.fontName08, this.fontAccel08, this.fontResistance08, this.fontSpecial08);
            this.LoadSpriteFonts(this.ship9, this.fontID09, this.fontName09, this.fontAccel09, this.fontResistance09, this.fontSpecial09);
            this.LoadSpriteFonts(this.shipX1, this.fontIDX1, this.fontNameX1, this.fontAccelX1, this.fontResistanceX1, this.fontSpecialX1);

            this.font02Locked.Position.X = this.ship2.X;
            this.font02Locked.Position.Y = this.ship2.Y;

            this.font03Locked.Position.X = this.ship3.X;
            this.font03Locked.Position.Y = this.ship3.Y;

            this.font04Locked.Position.X = this.ship4.X;
            this.font04Locked.Position.Y = this.ship4.Y;

            this.font05Locked.Position.X = this.ship5.X;
            this.font05Locked.Position.Y = this.ship5.Y;

            this.font06Locked.Position.X = this.ship6.X;
            this.font06Locked.Position.Y = this.ship6.Y;

            this.font07Locked.Position.X = this.ship7.X;
            this.font07Locked.Position.Y = this.ship7.Y;

            this.font08Locked.Position.X = this.ship8.X;
            this.font08Locked.Position.Y = this.ship8.Y;

            this.font09Locked.Position.X = this.ship9.X;
            this.font09Locked.Position.Y = this.ship9.Y;

            this.fontX1Locked.Position.X = this.shipX1.X;
            this.fontX1Locked.Position.Y = this.shipX1.Y;

            this.fontCommand.Position.X = this.ship4.X;
            this.fontCommand.Position.Y = this.ship4.Y + 230;

            this.fontCommandUp.Position.X = this.ship4.X;
            this.fontCommandUp.Position.Y = this.ship4.Y + 250;

            this.fontCommandDown.Position.X = this.ship4.X;
            this.fontCommandDown.Position.Y = this.ship4.Y + 265;

            this.fontCommandLeft.Position.X = this.ship4.X;
            this.fontCommandLeft.Position.Y = this.ship4.Y + 280;

            this.fontCommandRight.Position.X = this.ship4.X;
            this.fontCommandRight.Position.Y = this.ship4.Y + 295;

            this.fontCommandSpecial.Position.X = this.ship4.X;
            this.fontCommandSpecial.Position.Y = this.ship4.Y + 310;
        }

        public override void LoadSpriteList()
        {
            this.ship1 = new SpriteShip(Enum.Ships.Type01, 32, 32);
            this.ship2 = new SpriteShip(Enum.Ships.Type02, 32, 32);
            this.ship3 = new SpriteShip(Enum.Ships.Type03, 32, 32);
            this.ship4 = new SpriteShip(Enum.Ships.Type04, 32, 32);
            this.ship5 = new SpriteShip(Enum.Ships.Type05, 32, 32);
            this.ship6 = new SpriteShip(Enum.Ships.Type06, 32, 32);
            this.ship7 = new SpriteShip(Enum.Ships.Type07, 32, 32);
            this.ship8 = new SpriteShip(Enum.Ships.Type08, 32, 32);
            this.ship9 = new SpriteShip(Enum.Ships.Type09, 32, 32);
            this.shipX1 = new SpriteShip(Enum.Ships.TypeX1, 32, 32);
            this.cursor = new Sprite(16, 16, "Images\\Misc\\HMenuCursor");

            this.SpriteList = new List<Sprite>();

            this.SpriteList.Add(this.ship1);
            this.SpriteList.Add(this.ship2);
            this.SpriteList.Add(this.ship3);
            this.SpriteList.Add(this.ship4);
            this.SpriteList.Add(this.ship5);
            this.SpriteList.Add(this.ship6);
            this.SpriteList.Add(this.ship7);
            this.SpriteList.Add(this.ship8);
            this.SpriteList.Add(this.ship9);
            this.SpriteList.Add(this.shipX1);
            this.SpriteList.Add(this.cursor);
        }

        public override void LoadFontList()
        {
            this.fontID01 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontName01 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Gold);
            this.fontAccel01 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontResistance01 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontSpecial01 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);

            this.fontID02 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontName02 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Gold);
            this.fontAccel02 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontResistance02 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontSpecial02 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);

            this.fontID03 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontName03 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Gold);
            this.fontAccel03 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontResistance03 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontSpecial03 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);

            this.fontID04 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontName04 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Gold);
            this.fontAccel04 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontResistance04 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontSpecial04 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);

            this.fontID05 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontName05 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Gold);
            this.fontAccel05 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontResistance05 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontSpecial05 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);

            this.fontID06 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontName06 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Gold);
            this.fontAccel06 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontResistance06 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontSpecial06 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);

            this.fontID07 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontName07 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Gold);
            this.fontAccel07 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontResistance07 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontSpecial07 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);

            this.fontID08 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontName08 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Gold);
            this.fontAccel08 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontResistance08 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontSpecial08 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);

            this.fontID09 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontName09 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Gold);
            this.fontAccel09 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontResistance09 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontSpecial09 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);

            this.fontIDX1 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontNameX1 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Gold);
            this.fontAccelX1 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontResistanceX1 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);
            this.fontSpecialX1 = new Font("Fonts\\MenuOptions", "", new Vector2(0, 0), Color.Lime);

            this.font02Locked = new Font("Fonts\\StageOptions", "Bloqueado", new Vector2(this.ship2.X, this.ship2.Y), Color.White);
            this.font03Locked = new Font("Fonts\\StageOptions", "Bloqueado", new Vector2(this.ship3.X, this.ship3.Y), Color.White);
            this.font04Locked = new Font("Fonts\\StageOptions", "Bloqueado", new Vector2(this.ship4.X, this.ship4.Y), Color.White);
            this.font05Locked = new Font("Fonts\\StageOptions", "Bloqueado", new Vector2(this.ship5.X, this.ship5.Y), Color.White);
            this.font06Locked = new Font("Fonts\\StageOptions", "Bloqueado", new Vector2(this.ship6.X, this.ship6.Y), Color.White);
            this.font07Locked = new Font("Fonts\\StageOptions", "Bloqueado", new Vector2(this.ship7.X, this.ship7.Y), Color.White);
            this.font08Locked = new Font("Fonts\\StageOptions", "Bloqueado", new Vector2(this.ship8.X, this.ship8.Y), Color.White);
            this.font09Locked = new Font("Fonts\\StageOptions", "Bloqueado", new Vector2(this.ship9.X, this.ship9.Y), Color.White);
            this.fontX1Locked = new Font("Fonts\\StageOptions", "Bloqueado", new Vector2(this.shipX1.X, this.shipX1.Y), Color.White);

            this.fontCommand = new Font("Fonts\\StageOptions", "Comandos:", new Vector2(this.ship4.X, this.ship4.Y + 30), Color.White);
            this.fontCommandUp = new Font("Fonts\\MenuOptions", "Up: Move para cima", new Vector2(this.ship4.X, this.ship4.Y + 30), Color.White);
            this.fontCommandDown = new Font("Fonts\\MenuOptions", "Down: Move para baixo", new Vector2(this.ship4.X, this.ship4.Y + 4), Color.White);
            this.fontCommandLeft = new Font("Fonts\\MenuOptions", "Left: Move para a esquerda", new Vector2(this.ship4.X, this.ship4.Y + 50), Color.White);
            this.fontCommandRight = new Font("Fonts\\MenuOptions", "Right: Move para a direita", new Vector2(this.ship4.X, this.ship4.Y + 60), Color.White);
            this.fontCommandSpecial = new Font("Fonts\\MenuOptions", "Barra Espaço: Especial", new Vector2(this.ship4.X, this.ship4.Y + 70), Color.White);

            Globals.FontInfo1.Text = "Pressione Enter para selecionar\r\nPressione Esc para voltar";

            this.FontList.Add(this.fontID01);
            this.FontList.Add(this.fontName01);
            this.FontList.Add(this.fontAccel01);
            this.FontList.Add(this.fontResistance01);
            this.FontList.Add(this.fontSpecial01);

            this.FontList.Add(this.fontID02);
            this.FontList.Add(this.fontName02);
            this.FontList.Add(this.fontAccel02);
            this.FontList.Add(this.fontResistance02);
            this.FontList.Add(this.fontSpecial02);

            this.FontList.Add(this.fontID03);
            this.FontList.Add(this.fontName03);
            this.FontList.Add(this.fontAccel03);
            this.FontList.Add(this.fontResistance03);
            this.FontList.Add(this.fontSpecial03);

            this.FontList.Add(this.fontID04);
            this.FontList.Add(this.fontName04);
            this.FontList.Add(this.fontAccel04);
            this.FontList.Add(this.fontResistance04);
            this.FontList.Add(this.fontSpecial04);

            this.FontList.Add(this.fontID05);
            this.FontList.Add(this.fontName05);
            this.FontList.Add(this.fontAccel05);
            this.FontList.Add(this.fontResistance05);
            this.FontList.Add(this.fontSpecial05);

            this.FontList.Add(this.fontID06);
            this.FontList.Add(this.fontName06);
            this.FontList.Add(this.fontAccel06);
            this.FontList.Add(this.fontResistance06);
            this.FontList.Add(this.fontSpecial06);

            this.FontList.Add(this.fontID07);
            this.FontList.Add(this.fontName07);
            this.FontList.Add(this.fontAccel07);
            this.FontList.Add(this.fontResistance07);
            this.FontList.Add(this.fontSpecial07);

            this.FontList.Add(this.fontID08);
            this.FontList.Add(this.fontName08);
            this.FontList.Add(this.fontAccel08);
            this.FontList.Add(this.fontResistance08);
            this.FontList.Add(this.fontSpecial08);

            this.FontList.Add(this.fontID09);
            this.FontList.Add(this.fontName09);
            this.FontList.Add(this.fontAccel09);
            this.FontList.Add(this.fontResistance09);
            this.FontList.Add(this.fontSpecial09);

            this.FontList.Add(this.fontIDX1);
            this.FontList.Add(this.fontNameX1);
            this.FontList.Add(this.fontAccelX1);
            this.FontList.Add(this.fontResistanceX1);
            this.FontList.Add(this.fontSpecialX1);

            this.FontList.Add(this.font02Locked);
            this.FontList.Add(this.font03Locked);
            this.FontList.Add(this.font04Locked);
            this.FontList.Add(this.font05Locked);
            this.FontList.Add(this.font06Locked);
            this.FontList.Add(this.font07Locked);
            this.FontList.Add(this.font08Locked);
            this.FontList.Add(this.font09Locked);
            this.FontList.Add(this.fontX1Locked);

            this.FontList.Add(this.fontCommand);
            this.FontList.Add(this.fontCommandUp);
            this.FontList.Add(this.fontCommandDown);
            this.FontList.Add(this.fontCommandLeft);
            this.FontList.Add(this.fontCommandRight);
            this.FontList.Add(this.fontCommandSpecial);

            this.FontList.Add(Globals.FontInfo1);
        }

        public override void Update()
        {
            Functions.KeyReading();

            if (Globals.RightKeyPressed)
            {
                this.currentSelection.X++;

                if (this.currentSelection.X == 3)
                {
                    if (this.currentSelection.Y == 1 || this.currentSelection.Y == 2)
                    {
                        this.currentSelection.X--;
                    }
                }
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

                if (this.currentSelection.X == 3)
                {
                    if (this.currentSelection.Y == 1 || this.currentSelection.Y == 2)
                    {
                        this.currentSelection.Y--;
                    }
                }
            }
            else if (Globals.EnterKeyPressed)
            {
                if (this.currentShip.Visible)
                {
                    Globals.SFXSelected.Play();
                    Functions.CreateDelay(1);
                    Globals.SelectedShip = this.currentShip;
                    this.LoadShipUpdate();
                    Globals.SaveSelectedShip = Globals.SelectedShip.Ship.ToString();
                    FunctionsGame.SaveGame();
                    Globals.CurrentScene = new SceneTitle();
                }
            }
            else if (Globals.EscKeyPressed)
            {
                Globals.CurrentScene = new SceneTitle();
            }

            if (this.currentSelection.X == 4)
            {
                this.currentSelection.X = 3;
            }

            if (this.currentSelection.Y == 3)
            {
                this.currentSelection.Y = 2;
            }

            if (this.currentSelection.X < 0)
            {
                this.currentSelection.X = 0;
            }

            if (this.currentSelection.Y < 0)
            {
                this.currentSelection.Y = 0;
            }

            this.currentShip = this.selectionGrid[(int)this.currentSelection.X, (int)this.currentSelection.Y];

            this.cursor.Y = this.currentShip.Y + 10;
            this.cursor.X = this.currentShip.X - 20;
        }

        private void LoadSpriteFonts(SpriteShip ship, Font fontID, Font fontName, Font fontAccel, Font fontResistance, Font fontSpecial)
        {
            fontID.Position.X = ship.X;
            fontID.Position.Y = ship.Y + 42;

            fontName.Position.X = ship.X;
            fontName.Position.Y = ship.Y + 57;

            fontAccel.Position.X = ship.X;
            fontAccel.Position.Y = ship.Y + 72;

            fontResistance.Position.X = ship.X;
            fontResistance.Position.Y = ship.Y + 82;

            fontSpecial.Position.X = ship.X;
            fontSpecial.Position.Y = ship.Y + 92;

            fontAccel.Text = "Acel: {0}m/s²";
            fontResistance.Text = "Resistência: {0}";
            fontSpecial.Text = "Especial: {0}";

            fontID.Text = ship.ID;
            fontName.Text = ship.Name;
            fontAccel.Text = string.Format(fontAccel.Text, ship.AccelMpS);
            fontResistance.Text = string.Format(fontResistance.Text, Convert.ToDouble(ship.Resistance).ToString("0.00"));
            fontSpecial.Text = string.Format(fontSpecial.Text, ship.Special);
        }

        private void LoadShipUpdate()
        {
            if (Globals.SelectedShip.Ship == Enum.Ships.Type01)
            {
                Globals.UpdateLander = FunctionsShip.UpdateForLander01;
            }
            else if (Globals.SelectedShip.Ship == Enum.Ships.Type02)
            {
                Globals.UpdateLander = FunctionsShip.UpdateForLander02;
            }
            else if (Globals.SelectedShip.Ship == Enum.Ships.Type03)
            {
                Globals.UpdateLander = FunctionsShip.UpdateForLander03;
            }
            else if (Globals.SelectedShip.Ship == Enum.Ships.Type04)
            {
                Globals.UpdateLander = FunctionsShip.UpdateForLander04;
            }
            else if (Globals.SelectedShip.Ship == Enum.Ships.Type05)
            {
                Globals.UpdateLander = FunctionsShip.UpdateForLander05;
            }
            else if (Globals.SelectedShip.Ship == Enum.Ships.Type06)
            {
                Globals.UpdateLander = FunctionsShip.UpdateForLander06;
            }
            else if (Globals.SelectedShip.Ship == Enum.Ships.Type07)
            {
                Globals.UpdateLander = FunctionsShip.UpdateForLander07;
            }
            else if (Globals.SelectedShip.Ship == Enum.Ships.Type08)
            {
                Globals.UpdateLander = FunctionsShip.UpdateForLander08;
            }
            else if (Globals.SelectedShip.Ship == Enum.Ships.Type09)
            {
                Globals.UpdateLander = FunctionsShip.UpdateForLander09;
            }
            else if (Globals.SelectedShip.Ship == Enum.Ships.TypeX1)
            {
                Globals.UpdateLander = FunctionsShip.UpdateForLanderX1;
            }
        }
    }
}
