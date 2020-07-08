using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using XNALander.Scenes;

namespace XNALander.Classes
{
    class Globals
    {
        //Game
        public static Game1 Game1;
        public static SpriteShip SelectedShip;
        public static Stage SelectedStage;
        public static Random Random = new Random();
        public static Scene CurrentScene;
        public static Enum.GameType GameType;

        public static bool FirstLoad = true;
        public static bool PausedMain = false;
        public static bool Paused = false;
        public static bool EndedIntro = false;

        public static float TimerInterval = 20F;//in milliseconds
        public static float PixelToMeter = 1.2F;//how many meters a pixel have

        public static int CurrentStage;

        public static bool MustLoadContent = false;
        
        public static bool OreCollected = false;
        
        //public static bool SelectedStageFreeCollision;
        //public static bool StageFreeCollision;
        //public static bool StageFreeGravity;
        //public static float LZGForce;

        //Sounds
        public static Song Song;
        public static SoundEffect SFXRocket;
        public static SoundEffect SFXFloat;
        public static SoundEffect SFXSpecial;
        public static SoundEffect SFXSelected;
        public static SoundEffect SFXExplosion;
        public static SoundEffect SFXCrash;
        public static SoundEffect SFXCollected;
        public static SoundEffect SFXUnlocked;
        public static SoundEffect SFXLanding;

        public static SoundEffectInstance SFXRocketInstance;
        public static SoundEffectInstance SFXFloatInstance;
        public static SoundEffectInstance SFXSpecialInstance;

        //Stages
        public static float RelativeVelocity;
        public static bool Landed = false;
        public static bool Collided = false;
        public static bool CollidedGround = false;
        public static bool CollidedLZ = false;
        public static bool CollidedUp = false;
        public static bool CollidedDown = false;
        public static bool CollidedLeft = false;
        public static bool CollidedRight = false;
        public static int SpeedBarMultiplier = 100;
        public static int ShipsLeft = 2;
        public static Font FontInfo1;
        public static Font FontInfo2;

        //Keys
        public static int KeyPressDelay = 0;

        public static bool SpaceKeyDown;
        public static bool SpaceKeyDownPrevious;
        public static bool SpaceKeyPressed;

        public static bool LeftKeyDown;
        public static bool LeftKeyDownPrevious;
        public static bool LeftKeyPressed;

        public static bool RightKeyDown;
        public static bool RightKeyDownPrevious;
        public static bool RightKeyPressed;

        public static bool UpKeyDown;
        public static bool UpKeyDownPrevious;
        public static bool UpKeyPressed;

        public static bool DownKeyDown;
        public static bool DownKeyDownPrevious;
        public static bool DownKeyPressed;

        public static bool FireKeyDown;
        public static bool FireKeyDownPrevious;
        public static bool FireKeyPressed;

        public static bool EnterKeyDown;
        public static bool EnterKeyDownPrevious;
        public static bool EnterKeyPressed;

        public static bool JumpStageKeyDown;
        public static bool JumpStageKeyDownPrevious;
        public static bool JumpStageKeyPressed;

        public static bool EscKeyDown;
        public static bool EscKeyDownPrevious;
        public static bool EscKeyPressed;

        //Delegates
        public static XNALander.Game1.UpdateForLander UpdateLander;
        public static XNALander.Game1.UpdateForArea UpdateArea;
        public static XNALander.Game1.UpdateForOre UpdateOre;
        public static XNALander.Game1.UpdateForIntro UpdateIntro;

        //Save
        public static string SaveSelectedShip;
        public const string SaveFilePath = "Save.dat";
        public static bool[,] SaveShipsAreasCompleted = new bool[6,10];
        public static bool[,] SaveOreCollected = new bool[6, 5];

        public static string DefaultSaveFile =
"Type01;" + Environment.NewLine + 
"False;False;False;False;False;False;False;False;False;False;" + Environment.NewLine +
"False;False;False;False;False;False;False;False;False;False;" + Environment.NewLine +
"False;False;False;False;False;False;False;False;False;False;" + Environment.NewLine +
"False;False;False;False;False;False;False;False;False;False;" + Environment.NewLine +
"False;False;False;False;False;False;False;False;False;False;" + Environment.NewLine +
"False;False;False;False;False;False;False;False;False;False;" + Environment.NewLine +
"False;False;False;False;False;" + Environment.NewLine +
"False;False;False;False;False;" + Environment.NewLine +
"False;False;False;False;False;" + Environment.NewLine +
"False;False;False;False;False;" + Environment.NewLine +
"False;False;False;False;False;" + Environment.NewLine + 
"False;False;False;False;False;";
    }
}