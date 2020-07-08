using Microsoft.Xna.Framework.Graphics;
using XNALander.StaticFunctions;

namespace XNALander.Classes
{
    public class SpriteShip : Sprite
    {
        public string Name;
        public string Special;
        public Enum.Ships Ship;
        public float Resistance;
        public float Fuel;
        public float MaxFuel;
        public float CurrentAccelUp;
        public float CurrentAccelDown;
        public float CurrentAccelLeft;
        public float CurrentAccelRight;
        public float SpecialFuelConsumptionRate;
        public bool UseFuelWhenSpecialKeyDown;
        public float FuelConsumptionRate;
        public Sprite SpriteLeft;
        public Sprite SpriteRight;
        public Sprite SpriteTop;
        public Sprite SpriteBotton;

        public SpriteShip(Enum.Ships ship, int DefaultWidth, int DefaultHeight)
            : base(DefaultWidth, DefaultHeight, Color.White)
        {
            this.Name = "";
            this.Special = "";
            this.Ship = ship;
            this.AccelMpS = 0;
            this.Resistance = 0;
            this.FuelConsumptionRate = 0.03F;
            this.Fuel = 0;
            this.MaxFuel = 40;

            this.SpriteLeft = new Sprite(32, 32, "Images\\Boosters\\LeftBoost");
            this.SpriteRight = new Sprite(32, 32, "Images\\Boosters\\RightBoost");
            this.SpriteTop = new Sprite(32, 32, "Images\\Boosters\\TopBoost");
            this.SpriteBotton = new Sprite(32, 32, "Images\\Boosters\\BottonBoost");

            this.SpriteLeft.Visible = false;
            this.SpriteRight.Visible = false;
            this.SpriteTop.Visible = false;
            this.SpriteBotton.Visible = false;

            this.TexturesPaths.Add("Images\\Misc\\Explosion");

            if (ship == Enum.Ships.Type01)
            {
                this.SpecialFuelConsumptionRate = 0.2F; //decrementa a cada Update()
                this.AccelMpS = 13F;
                this.Resistance = 3F;
                this.UseFuelWhenSpecialKeyDown = true;
                this.Name = "Gaia Saucer";
                this.ID = "Type01";
                this.Special = "Estabilizador";
                this.TexturesPaths[0] = "Images\\Landers\\LanderType01";
                this.TexturesPaths.Add("Images\\Landers\\LanderType01Crash");
                Globals.UpdateLander = new XNALander.Game1.UpdateForLander(FunctionsShip.UpdateForLander01);
            }
            else if (ship == Enum.Ships.Type02)
            {
                this.SpecialFuelConsumptionRate = 0.2F; //decrementa a cada Update()
                this.AccelMpS = 11F;
                this.Resistance = 4F;
                this.UseFuelWhenSpecialKeyDown = true;
                this.Name = "Prometeus Voyager";
                this.ID = "Type02";
                this.Special = "Propulsor Auxiliar";
                this.TexturesPaths[0] = "Images\\Landers\\LanderType02";
                this.TexturesPaths.Add("Images\\Landers\\LanderType02Crash");
                this.SpriteBotton.TexturesPaths.Add("Images\\Boosters\\AuxRocketBoost");
                Globals.UpdateLander = new XNALander.Game1.UpdateForLander(FunctionsShip.UpdateForLander02);
            }
            else if (ship == Enum.Ships.Type03)
            {
                this.SpecialFuelConsumptionRate = 0.04F; //decrementa a cada Update()
                this.AccelMpS = 15F;
                this.Resistance = 3.7F;
                this.UseFuelWhenSpecialKeyDown = false;
                this.Name = "Ares Charriot";
                this.ID = "Type03";
                this.Special = "\r\nPropulsores de Precisão";
                this.TexturesPaths[0] = "Images\\Landers\\LanderType03";
                this.TexturesPaths.Add("Images\\Landers\\LanderType03Crash");
                Globals.UpdateLander = new XNALander.Game1.UpdateForLander(FunctionsShip.UpdateForLander03);
            }
            else if (ship == Enum.Ships.Type04)
            {
                this.SpecialFuelConsumptionRate = 0.5F; //decrementa a cada Update()
                this.AccelMpS = 12F;
                this.Resistance = 4.2F;
                this.UseFuelWhenSpecialKeyDown = true;
                this.Name = "Hades Star";
                this.ID = "Type04";
                this.Special = "Freio Eletro-Magnético";
                this.TexturesPaths[0] = "Images\\Landers\\LanderType04";
                this.TexturesPaths.Add("Images\\Landers\\LanderType04Crash");
                Globals.UpdateLander = new XNALander.Game1.UpdateForLander(FunctionsShip.UpdateForLander04);
            }
            else if (ship == Enum.Ships.Type05)
            {
                this.SpecialFuelConsumptionRate = 0.15F; //decrementa a cada Update()
                this.AccelMpS = 17F;
                this.Resistance = 3.2F;
                this.UseFuelWhenSpecialKeyDown = true;
                this.Name = "Hermes Flash Rocket";
                this.ID = "Type05";
                this.Special = "Estabilização Vertical";
                this.TexturesPaths[0] = "Images\\Landers\\LanderType05";
                this.TexturesPaths.Add("Images\\Landers\\LanderType05Crash");
                this.TexturesPaths.Add("Images\\Landers\\LanderType05_Left");
                this.TexturesPaths.Add("Images\\Landers\\LanderType05_Right");
                Globals.UpdateLander = new XNALander.Game1.UpdateForLander(FunctionsShip.UpdateForLander05);
            }
            else if (ship == Enum.Ships.Type06)
            {
                this.SpecialFuelConsumptionRate = 0.4F; //decrementa a cada Update()
                this.AccelMpS = 16F;
                this.Resistance = 4.5F;
                this.UseFuelWhenSpecialKeyDown = true;
                this.Name = "Poseidon Speedster";
                this.ID = "Type06";
                this.Special = "Inversão de Forças";
                this.TexturesPaths[0] = "Images\\Landers\\LanderType06";
                this.TexturesPaths.Add("Images\\Landers\\LanderType06Crash");
                Globals.UpdateLander = new XNALander.Game1.UpdateForLander(FunctionsShip.UpdateForLander06);
            }
            else if (ship == Enum.Ships.Type07)
            {
                this.SpecialFuelConsumptionRate = 0.03F; //decrementa a cada Update()
                this.AccelMpS = 12F;
                this.Resistance = 3.8F;
                this.UseFuelWhenSpecialKeyDown = true;
                this.Name = "Athena Fortress";
                this.ID = "Type07";
                this.Special = "Anti-Gravidade";
                this.TexturesPaths[0] = "Images\\Landers\\LanderType07";
                this.TexturesPaths.Add("Images\\Landers\\LanderType07Crash");
                Globals.UpdateLander = new XNALander.Game1.UpdateForLander(FunctionsShip.UpdateForLander07);
            }
            else if (ship == Enum.Ships.Type08)
            {
                this.AccelMpS = 13F;
                this.Resistance = 3F;
                this.UseFuelWhenSpecialKeyDown = true;
                this.Name = "Soviet LK";
                this.ID = "Type08";
                this.Special = "Pára-Quedas";
                this.TexturesPaths[0] = "Images\\Landers\\LanderType08";
                this.TexturesPaths.Add("Images\\Landers\\LanderType08Crash");
                this.TexturesPaths.Add("Images\\Misc\\Parachute");
                Globals.UpdateLander = new XNALander.Game1.UpdateForLander(FunctionsShip.UpdateForLander08);
            }
            else if (ship == Enum.Ships.Type09)
            {
                this.AccelMpS = 12F;
                this.Resistance = 2.7F;
                this.UseFuelWhenSpecialKeyDown = true;
                this.Name = "Apollo 11 LM \"Eagle\"";
                this.ID = "Type09";
                this.Special = "Pára-Quedas";
                this.TexturesPaths[0] = "Images\\Landers\\LanderType09";
                this.TexturesPaths.Add("Images\\Landers\\LanderType09Crash");
                this.TexturesPaths.Add("Images\\Misc\\Parachute");
                Globals.UpdateLander = new XNALander.Game1.UpdateForLander(FunctionsShip.UpdateForLander09);
            }
            else if (ship == Enum.Ships.TypeX1)
            {
                this.SpecialFuelConsumptionRate = -0.1F; //decrementa a cada Update()
                this.AccelMpS = 14F;
                this.Resistance = 4F;
                this.UseFuelWhenSpecialKeyDown = true;
                this.Name = "Samus' Gunship";
                this.ID = "TypeX1";
                this.Special = "Recarga";
                this.TexturesPaths[0] = "Images\\Landers\\LanderTypeX1";
                this.TexturesPaths.Add("Images\\Landers\\LanderTypeX1Crash");
                Globals.UpdateLander = new XNALander.Game1.UpdateForLander(FunctionsShip.UpdateForLanderX1);
            }

            this.Fuel = this.MaxFuel;
            this.Accel = Functions.ConvertMpSToVelocity(this.AccelMpS, Globals.TimerInterval, Globals.PixelToMeter);
            this.CurrentAccelLeft = this.Accel / 3;
            this.CurrentAccelRight = this.Accel / 3;
            this.CurrentAccelUp = this.Accel / 3;
            this.CurrentAccelDown = this.Accel / 3;
        }
    }
}