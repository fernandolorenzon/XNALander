namespace XNALander
{
    public class Enum
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right,
            UpLeft,
            UpRight,
            DownLeft,
            DownRight,
            Still
        }

        public enum Axis
        {
            Vertical,
            Horizontal,
            All
        }

        public enum Ships
        {            
            Type01,
            Type02,
            Type03,
            Type04,
            Type05,
            Type06,
            Type07,
            Type08,
            Type09,
            TypeX1,
        }

        public enum RecordType
        {
            SelectedShip,
            UnlockedArea,
            OreCollected,
        }

        public enum GameType
        {
            Arcade,
            OreColleting,
            Free,
        }

        public enum DrawMode
        {
            Center,
            Stretch            
        }

        public enum Options
        {
            Arcade,
            FreeGame,
            OreCollecting,
            ChooseShip,
            Exit
        }
    }
}
