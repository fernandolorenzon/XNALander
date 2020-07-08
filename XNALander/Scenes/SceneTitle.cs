using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNALander.StaticFunctions;
using XNALander.Classes;

namespace XNALander.Scenes
{
    public class SceneTitle : Scene
    {
        private Sprite titleScreen;
        private Sprite cursor;

        private Font title;
        private Font arcade;
        private Font freeGame;
        private Font oreCollecting;
        private Font chooseShip;
        private Font currentShip;
        private Font exit;

        private Enum.Options gameOptions;

        public SceneTitle() : base()
        {
        }

        public override void LoadScene()
        {
            base.LoadScene();

            Globals.SelectedShip.X = this.currentShip.Position.X + 70;
            Globals.SelectedShip.Y = this.currentShip.Position.Y - 5;
            Globals.FontInfo1.Text = "Pressione Enter para selecionar";

            this.gameOptions = Enum.Options.Arcade;
        }

        public override void LoadSpriteList()
        {
            this.titleScreen = new Sprite(800, 450, "Images\\Menu\\LunarLander");
            this.cursor = new Sprite(16, 16, "Images\\Misc\\VMenuCursor");
            this.cursor.Y = 550;
            
            if (Globals.SelectedShip == null)
            {
                Enum.Ships selected = Enum.Ships.Type01;

                if (Globals.SaveSelectedShip == Enum.Ships.Type01.ToString())
                {
                    selected = Enum.Ships.Type01;
                }
                else if (Globals.SaveSelectedShip == Enum.Ships.Type02.ToString())
                {
                    selected = Enum.Ships.Type02;
                }
                else if (Globals.SaveSelectedShip == Enum.Ships.Type03.ToString())
                {
                    selected = Enum.Ships.Type03;
                }
                else if (Globals.SaveSelectedShip == Enum.Ships.Type04.ToString())
                {
                    selected = Enum.Ships.Type04;
                }
                else if (Globals.SaveSelectedShip == Enum.Ships.Type05.ToString())
                {
                    selected = Enum.Ships.Type05;
                }
                else if (Globals.SaveSelectedShip == Enum.Ships.Type06.ToString())
                {
                    selected = Enum.Ships.Type06;
                }
                else if (Globals.SaveSelectedShip == Enum.Ships.Type07.ToString())
                {
                    selected = Enum.Ships.Type07;
                }
                else if (Globals.SaveSelectedShip == Enum.Ships.Type08.ToString())
                {
                    selected = Enum.Ships.Type08;
                }
                else if (Globals.SaveSelectedShip == Enum.Ships.Type09.ToString())
                {
                    selected = Enum.Ships.Type09;
                }
                else if (Globals.SaveSelectedShip == Enum.Ships.TypeX1.ToString())
                {
                    selected = Enum.Ships.TypeX1;
                }

                Globals.SelectedShip = new SpriteShip(selected, 32, 32);
            }

            this.SpriteList = new System.Collections.Generic.List<Sprite>();

            this.SpriteList.Add(this.titleScreen);
            this.SpriteList.Add(this.cursor);
            this.SpriteList.Add(Globals.SelectedShip);
        }

        public override void LoadFontList()
        {
            this.title = new Font("Fonts\\Title", "XNA Lander", new Vector2(270, 22), Color.Lime);
            this.arcade = new Font("Fonts\\MenuOptions", "Arcade", new Vector2(10, 533), Color.Lime);
            this.freeGame = new Font("Fonts\\MenuOptions", "Jogo Livre", new Vector2(75, 533), Color.Lime);
            this.oreCollecting = new Font("Fonts\\MenuOptions", "Coletar Minério", new Vector2(160, 533), Color.Lime);
            this.chooseShip = new Font("Fonts\\MenuOptions", "Escolher Nave", new Vector2(275, 533), Color.Lime);
            this.exit = new Font("Fonts\\MenuOptions", "Sair", new Vector2(380, 533), Color.Lime);
            this.currentShip = new Font("Fonts\\MenuOptions", "Nave Atual", new Vector2(600, 533), Color.Lime);

            this.FontList = new System.Collections.Generic.List<Font>();

            this.FontList.Add(this.title);
            this.FontList.Add(this.arcade);
            this.FontList.Add(this.freeGame);
            this.FontList.Add(this.oreCollecting);
            this.FontList.Add(this.chooseShip);
            this.FontList.Add(this.currentShip);
            this.FontList.Add(this.exit);

            this.FontList.Add(Globals.FontInfo1);
        }

        public override void Update()
        {
            Functions.KeyReading();

            if (Globals.EnterKeyPressed)
            {
                Globals.SFXSelected.Play();
                Functions.CreateDelay(1);

                if (this.gameOptions == Enum.Options.Arcade)
                {
                    Globals.GameType = Enum.GameType.Arcade;
                    Globals.CurrentScene = new SceneChooseArea();
                }
                else if (this.gameOptions == Enum.Options.FreeGame)
                {
                    Globals.GameType = Enum.GameType.Free;
                    Globals.CurrentScene = new SceneChooseStage();
                }
                else if (this.gameOptions == Enum.Options.OreCollecting)
                {
                    Globals.GameType = Enum.GameType.OreColleting;
                    Globals.CurrentScene = new SceneChooseStage();
                }
                else if (this.gameOptions == Enum.Options.ChooseShip)
                {
                    Globals.CurrentScene = new SceneChooseShip();
                }
                else if (this.gameOptions == Enum.Options.Exit)
                {
                    Globals.Game1.Exit();
                }
            }

            if (this.gameOptions == Enum.Options.Arcade)
            {
                this.cursor.X = (int)this.arcade.Position.X + 10;
            }
            else if (this.gameOptions == Enum.Options.FreeGame)
            {
                this.cursor.X = (int)this.freeGame.Position.X + 17;
            }
            else if (this.gameOptions == Enum.Options.OreCollecting)
            {
                this.cursor.X = (int)this.oreCollecting.Position.X + 30;
            }
            else if (this.gameOptions == Enum.Options.ChooseShip)
            {
                this.cursor.X = (int)this.chooseShip.Position.X + 32;
            }
            else if (this.gameOptions == Enum.Options.Exit)
            {
                this.cursor.X = (int)this.exit.Position.X + 1;
            }

            if (Classes.Globals.RightKeyPressed)
            {
                if (this.gameOptions == Enum.Options.Arcade)
                {
                    this.gameOptions = Enum.Options.FreeGame;
                }
                else if (this.gameOptions == Enum.Options.FreeGame)
                {
                    this.gameOptions = Enum.Options.OreCollecting;
                }
                else if (this.gameOptions == Enum.Options.OreCollecting)
                {
                    this.gameOptions = Enum.Options.ChooseShip;
                }
                else if (this.gameOptions == Enum.Options.ChooseShip)
                {
                    this.gameOptions = Enum.Options.Exit;
                }
            }
            else if (Classes.Globals.LeftKeyPressed)
            {
                if (this.gameOptions == Enum.Options.Exit)
                {
                    this.gameOptions = Enum.Options.ChooseShip;
                }
                else if (this.gameOptions == Enum.Options.ChooseShip)
                {
                    this.gameOptions = Enum.Options.OreCollecting;
                }
                else if (this.gameOptions == Enum.Options.OreCollecting)
                {
                    this.gameOptions = Enum.Options.FreeGame;
                }
                else if (this.gameOptions == Enum.Options.FreeGame)
                {
                    this.gameOptions = Enum.Options.Arcade;
                }
            }
        }
    }
}