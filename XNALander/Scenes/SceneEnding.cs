using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNALander.StaticFunctions;
using XNALander.Classes;

namespace XNALander.Scenes
{
    public class SceneEnding : Scene
    {
        private Font message1;
        private Font message2;

        public SceneEnding()
        {

        }

        public override void LoadScene()
        {
            base.LoadScene();

            Globals.ShipsLeft = 2;
            bool unlocked = FunctionsGame.RecordFeatures(Enum.RecordType.UnlockedArea);

            if (unlocked && Globals.CurrentStage == 55 && Globals.SelectedShip.Ship != Enum.Ships.Type09)
            {
                this.message2.Visible = true;
                Globals.SFXUnlocked.Play();
            }

        }

        public override void LoadSpriteList()
        {

        }

        public override void LoadFontList()
        {
            this.message1 = new Font("Fonts\\StageOptions", "Parabéns! Você concluiu esta área!", new Vector2(300, 250), Color.WhiteSmoke);
            this.message2 = new Font("Fonts\\StageOptions", "Nave Desbloqueada!", new Vector2(350, 300), Color.Lime);

            this.FontList = new System.Collections.Generic.List<Font>();

            this.FontList.Add(this.message1);
            this.FontList.Add(this.message2);

            this.message2.Visible = false;
        }

        public override void Update()
        {
            Functions.KeyReading();


            if (this.message1.SpriteFont != null)
            {
                Functions.CenterFont(this.message1, 800);
            }

            if (this.message2.SpriteFont != null)
            {
                Functions.CenterFont(this.message2, 800);
            }

            if (Globals.EnterKeyPressed)
            {
                Functions.CreateDelay(1);
                Globals.CurrentScene = new SceneTitle();
            }
        }
    }
}