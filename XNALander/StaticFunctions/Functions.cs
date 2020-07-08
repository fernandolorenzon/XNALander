using System;
using XNALander.Classes;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Timers;

namespace XNALander.StaticFunctions
{
    public static class Functions
    {
        //DetectCollision statics
        private static int previousPositionVertex1X;
        private static int previousPositionVertex1Y;
        private static int previousPositionVertex2X;
        private static int previousPositionVertex2Y;
        private static int previousPositionVertex3X;
        private static int previousPositionVertex3Y;
        private static int previousPositionVertex4X;
        private static int previousPositionVertex4Y;

        //ShowMessage
        private static string previousMessage;
        private static Color previousMessageColor;

        public static void ShowMessage(Font font, Color color, string text)
        {
            font.Text = text;
            font.Color = color;
        }

        public static void MoveSprite(Sprite sprite, int x, int y)
        {
            sprite.Rectangle.Location = new Point(x, y);
        }

        public static void MoveSprite(Sprite sprite)
        {
            float previousX = sprite.X;
            float previousY = sprite.Y;

            if (Globals.CollidedDown && sprite.VerticalVelocity > 0)
            {
                sprite.VerticalVelocity = 0;
            }

            if (Globals.CollidedUp && sprite.VerticalVelocity < 0)
            {
                sprite.VerticalVelocity = 0;
            }

            if (Globals.CollidedLeft && sprite.HorizontalVelocity < 0)
            {
                sprite.HorizontalVelocity = 0;
            }

            if (Globals.CollidedRight && sprite.HorizontalVelocity > 0)
            {
                sprite.HorizontalVelocity = 0;
            }

            sprite.X += sprite.HorizontalVelocity;
            sprite.Y += sprite.VerticalVelocity;

            if (sprite.X > previousX)
            {
                if (sprite.Y > previousY)
                {
                    sprite.CurrentMovingDirection = Enum.Direction.DownRight;
                }
                else if (sprite.Y < previousY)
                {
                    sprite.CurrentMovingDirection = Enum.Direction.UpRight;
                }
                else if (sprite.Y == previousY)
                {
                    sprite.CurrentMovingDirection = Enum.Direction.Right;
                }
            }
            else if (sprite.X < previousX)
            {
                if (sprite.Y > previousY)
                {
                    sprite.CurrentMovingDirection = Enum.Direction.DownLeft;
                }
                else if (sprite.Y < previousY)
                {
                    sprite.CurrentMovingDirection = Enum.Direction.UpLeft;
                }
                else if (sprite.Y == previousY)
                {
                    sprite.CurrentMovingDirection = Enum.Direction.Left;
                }
            }
            else
            {
                if (sprite.Y > previousY)
                {
                    sprite.CurrentMovingDirection = Enum.Direction.Down;
                }
                else if (sprite.Y < previousY)
                {
                    sprite.CurrentMovingDirection = Enum.Direction.Up;
                }
                else if (sprite.Y == previousY)
                {
                    sprite.CurrentMovingDirection = Enum.Direction.Still;
                }
            }
        }

        public static float CalculateTotalForce(Sprite sprite)
        {
            float f;

            if (sprite.HorizontalVelocity >= 0)
            {
                f = sprite.HorizontalVelocity;
            }
            else
            {
                f = sprite.HorizontalVelocity * -1;
            }

            if (sprite.VerticalVelocity >= 0)
            {
                f += sprite.VerticalVelocity;
            }
            else
            {
                f += sprite.VerticalVelocity * -1;
            }

            return f;
        }

        public static float CalculateRelativeVelocityToSprite(Sprite sprite, Sprite target)
        {
            float f;

            float h = sprite.HorizontalVelocity - target.HorizontalVelocity;
            float v = sprite.VerticalVelocity - target.VerticalVelocity;

            if (h >= 0)
            {
                f = h;
            }
            else
            {
                f = h * -1;
            }

            if (v >= 0)
            {
                f += v;
            }
            else
            {
                f += v * -1;
            }

            return f;
        }

        public static void ApplyFlicker(Sprite sprite, bool enabled, bool defaultVisible)
        {
            if (enabled)
            {
                if (sprite.FlickCount == 0)
                {
                    sprite.Visible = true;
                    sprite.FlickCount = 1;
                }
                else
                {
                    sprite.Visible = false;
                    sprite.FlickCount = 0;
                }
            }
            else
            {
                sprite.Visible = defaultVisible;
            }
        }

        public static void ApplyStretch(Sprite sprite, Enum.Direction direction, float rate, int minimumSize, int maximumSize)
        {
            if (direction == Enum.Direction.Up)
            {
                sprite.Height = (int)(sprite.DefaultHeight * rate);

                if (sprite.Height < minimumSize)
                {
                    sprite.Height = minimumSize;
                }
                else if (sprite.Height > maximumSize)
                {
                    sprite.Height = maximumSize;
                }
            }
            else if (direction == Enum.Direction.Down)
            {
                sprite.Height = (int)(sprite.DefaultHeight * rate);

                if (sprite.Height * rate < minimumSize)
                {
                    sprite.Height = minimumSize;
                }
                else if (sprite.Height * rate > maximumSize)
                {
                    sprite.Height = maximumSize;
                }
            }
            else if (direction == Enum.Direction.Right)
            {
                sprite.Width = (int)(sprite.DefaultWidth * rate);

                if (sprite.Width < minimumSize)
                {
                    sprite.Width = minimumSize;
                }
                else if (sprite.Width > maximumSize)
                {
                    sprite.Width = maximumSize;
                }
            }
            else if (direction == Enum.Direction.Left)
            {
                sprite.Width = (int)(sprite.DefaultWidth * rate);

                if (sprite.Width < minimumSize)
                {
                    sprite.Width = minimumSize;
                }
                else if (sprite.Width > maximumSize)
                {
                    sprite.Width = maximumSize;
                }
            }
        }

        public static void ApplyStretch(Sprite sprite, Enum.Axis axis, int defaultX, int defaultY, float rate, int minimumSize, int maximumSize)
        {
            if (axis == Enum.Axis.Horizontal)
            {

                sprite.Width = (int)(sprite.DefaultWidth * rate);

                if (sprite.Width < minimumSize)
                {
                    sprite.Width = minimumSize;
                }
                else if (sprite.Width > maximumSize)
                {
                    sprite.Width = maximumSize;
                }

                sprite.X = defaultX - ((sprite.Width - sprite.DefaultWidth) / 2) + 1;
            }
            else if (axis == Enum.Axis.Vertical)
            {
                sprite.Height = (int)(sprite.DefaultHeight * rate);

                if (sprite.Height * rate < minimumSize)
                {
                    sprite.Height = minimumSize;
                }
                else if (sprite.Height * rate > maximumSize)
                {
                    sprite.Height = maximumSize;
                }

                sprite.Y = defaultY - (sprite.Height - sprite.DefaultHeight);
            }
        }

        public static void ApplyDrag(float drag, Sprite sprite, Enum.Axis axis)
        {
            if (axis == Enum.Axis.Horizontal || axis == Enum.Axis.All)
            {
                if (sprite.HorizontalVelocity > 0)
                {
                    sprite.HorizontalVelocity -= drag;

                    if (sprite.HorizontalVelocity < 0)
                    {
                        sprite.HorizontalVelocity = 0;
                    }
                }
                else if (sprite.HorizontalVelocity < 0)
                {
                    sprite.HorizontalVelocity += drag;

                    if (sprite.HorizontalVelocity > 0)
                    {
                        sprite.HorizontalVelocity = 0;
                    }
                }
            }

            if (axis == Enum.Axis.Vertical || axis == Enum.Axis.All)
            {
                if (sprite.VerticalVelocity > 0)
                {
                    sprite.VerticalVelocity -= drag;

                    if (sprite.VerticalVelocity < 0)
                    {
                        sprite.VerticalVelocity = 0;
                    }
                }
                else if (sprite.VerticalVelocity < 0)
                {
                    sprite.VerticalVelocity += drag;

                    if (sprite.VerticalVelocity > 0)
                    {
                        sprite.VerticalVelocity = 0;
                    }
                }
            }
        }

        public static void ApplyDrag(Sprite sprite, Enum.Axis axis)
        {
            ApplyDrag(sprite.Drag, sprite, axis);
        }

        public static void ApplyDrag(Sprite sprite, Stage stage, Enum.Axis axis)
        {
            ApplyDrag(sprite.Drag + stage.Drag, sprite, axis);
        }

        public static void KeyReading()
        {
            KeyboardState ks = Keyboard.GetState(PlayerIndex.One);

            Globals.EnterKeyDownPrevious = Globals.EnterKeyDown;
            Globals.UpKeyDownPrevious = Globals.UpKeyDown;
            Globals.LeftKeyDownPrevious = Globals.LeftKeyDown;
            Globals.RightKeyDownPrevious = Globals.RightKeyDown;
            Globals.DownKeyDownPrevious = Globals.DownKeyDown;
            Globals.SpaceKeyDownPrevious = Globals.SpaceKeyDown;
            Globals.FireKeyDownPrevious = Globals.FireKeyDown;
            Globals.SpaceKeyDownPrevious = Globals.SpaceKeyDown;
            Globals.JumpStageKeyDownPrevious = Globals.JumpStageKeyDown;
            Globals.EscKeyDownPrevious = Globals.EscKeyDown;

            Globals.EnterKeyDown = ks.IsKeyDown(Keys.Enter);
            Globals.LeftKeyDown = ks.IsKeyDown(Keys.Left);
            Globals.RightKeyDown = ks.IsKeyDown(Keys.Right);
            Globals.UpKeyDown = ks.IsKeyDown(Keys.Up);
            Globals.DownKeyDown = ks.IsKeyDown(Keys.Down);
            Globals.FireKeyDown = ks.IsKeyDown(Keys.LeftControl);
            Globals.SpaceKeyDown = ks.IsKeyDown(Keys.Space);
            Globals.JumpStageKeyDown = ks.IsKeyDown(Keys.Back);
            Globals.EscKeyDown = ks.IsKeyDown(Keys.Escape);

            Globals.EnterKeyPressed = Globals.EnterKeyDown && !Globals.EnterKeyDownPrevious;
            Globals.LeftKeyPressed = Globals.LeftKeyDown && !Globals.LeftKeyDownPrevious;
            Globals.RightKeyPressed = Globals.RightKeyDown && !Globals.RightKeyDownPrevious;
            Globals.UpKeyPressed = Globals.UpKeyDown && !Globals.UpKeyDownPrevious;
            Globals.DownKeyPressed = Globals.DownKeyDown && !Globals.DownKeyDownPrevious;
            Globals.FireKeyPressed = Globals.FireKeyDown && !Globals.FireKeyDownPrevious;
            Globals.SpaceKeyPressed = Globals.EnterKeyDown && !Globals.EnterKeyDownPrevious;
            Globals.JumpStageKeyPressed = Globals.JumpStageKeyDown && !Globals.JumpStageKeyDownPrevious;
            Globals.EscKeyPressed = Globals.EscKeyDown && !Globals.EscKeyDownPrevious;
        }

        public static void WarpSprite(Sprite sprite, Sprite stage, Enum.Axis axis)
        {
            if (sprite != null && sprite.Rectangle != null)
            {
                if (axis == Enum.Axis.Horizontal || axis == Enum.Axis.All)
                {
                    if (sprite.X > stage.Width)
                    {
                        sprite.X = 0 - sprite.Width + 1;
                    }
                    else if (sprite.X < 0 - sprite.Width)
                    {
                        sprite.X = stage.Width;
                    }
                }

                if (axis == Enum.Axis.Vertical || axis == Enum.Axis.All)
                {
                    if (sprite.Rectangle.Location.Y > stage.Height)
                    {
                        sprite.Y = 0 - sprite.Height + 1;
                    }
                    else if (sprite.Rectangle.Location.Y < 0 - sprite.Height)
                    {
                        sprite.Y = stage.Height;
                    }
                }
            }
        }

        public static bool DetectCollision(Sprite sprite, Sprite target, ref bool collidedUp, ref bool collidedDown, ref bool collidedLeft, ref bool collidedRight)
        {
            bool collided = false;
            collidedUp = false;
            collidedDown = false;
            collidedLeft = false;
            collidedRight = false;

            previousPositionVertex1X = sprite.Vertex1.X;
            previousPositionVertex1Y = sprite.Vertex1.Y;
            previousPositionVertex2X = sprite.Vertex2.X;
            previousPositionVertex2Y = sprite.Vertex2.Y;
            previousPositionVertex3X = sprite.Vertex3.X;
            previousPositionVertex3Y = sprite.Vertex3.Y;
            previousPositionVertex4X = sprite.Vertex4.X;
            previousPositionVertex4Y = sprite.Vertex4.Y;

            //Colisão abaixo do sprite
            if ((sprite.Vertex4.X >= target.Vertex1.X && sprite.Vertex4.X <= target.Vertex2.X) ||
                (sprite.Vertex3.X >= target.Vertex1.X && sprite.Vertex3.X <= target.Vertex2.X))
            {
                if ((sprite.Vertex4.Y >= target.Vertex1.Y && sprite.Vertex4.Y <= target.Vertex4.Y) ||
                    (sprite.Vertex3.Y >= target.Vertex1.Y && sprite.Vertex3.Y <= target.Vertex4.Y))
                {
                    collidedDown = true;
                }
            }
            //Colisão acima do sprite
            if ((sprite.Vertex1.X >= target.Vertex4.X && sprite.Vertex1.X <= target.Vertex3.X) ||
                     (sprite.Vertex2.X >= target.Vertex4.X && sprite.Vertex2.X <= target.Vertex3.X))
            {
                if ((sprite.Vertex1.Y >= target.Vertex1.Y && sprite.Vertex1.Y <= target.Vertex4.Y) ||
                    (sprite.Vertex2.Y >= target.Vertex1.Y && sprite.Vertex2.Y <= target.Vertex4.Y))
                {
                    collidedUp = true;
                }
            }
            //Colisão à esquerda do sprite 
            if ((sprite.Vertex1.Y >= target.Vertex2.Y && sprite.Vertex1.Y <= target.Vertex3.Y) ||
                     (sprite.Vertex4.Y >= target.Vertex2.Y && sprite.Vertex4.Y <= target.Vertex3.Y))
            {
                if ((sprite.Vertex1.X >= target.Vertex1.X && sprite.Vertex1.X <= target.Vertex2.X) ||
                    (sprite.Vertex4.X >= target.Vertex1.X && sprite.Vertex4.X <= target.Vertex2.X))
                {
                    collidedLeft = true;
                }
            }
            //Colisão à direita do sprite
            if ((sprite.Vertex2.Y >= target.Vertex1.Y && sprite.Vertex2.Y <= target.Vertex4.Y) ||
                     (sprite.Vertex3.Y >= target.Vertex1.Y && sprite.Vertex3.Y <= target.Vertex4.Y))
            {
                if ((sprite.Vertex2.X >= target.Vertex1.X && sprite.Vertex2.X <= target.Vertex2.X) ||
                    (sprite.Vertex3.X >= target.Vertex1.X && sprite.Vertex3.X <= target.Vertex2.X))
                {
                    collidedRight = true;
                }
            }

            if (collidedUp || collidedDown || collidedLeft || collidedRight)
            {
                collided = true;
            }

            if (collided)
            {
                //Tira-teima
                //movimento <-
                if (previousPositionVertex1X > sprite.Vertex1.X)
                {
                    collidedRight = false;
                }
                //movimento ->
                else if (previousPositionVertex1X < sprite.Vertex1.X)
                {
                    collidedLeft = false;
                }

                //movimento ^
                if (previousPositionVertex1X > sprite.Vertex1.X)
                {
                    collidedDown = false;
                }
                //movimento v
                else if (previousPositionVertex1X < sprite.Vertex1.X)
                {
                    collidedUp = false;
                }

                if (collidedLeft && collidedUp)
                {
                    if (previousPositionVertex1Y <= target.Vertex3.Y && previousPositionVertex1X >= target.Vertex3.X)
                    {
                        collidedUp = false;
                    }
                    else
                    {
                        collidedLeft = false;
                    }
                }

                if (collidedRight && collidedUp)
                {
                    if (previousPositionVertex2Y <= target.Vertex4.Y && previousPositionVertex2X <= target.Vertex4.X)
                    {
                        collidedUp = false;
                    }
                    else
                    {
                        collidedRight = false;
                    }
                }

                if (collidedLeft && collidedDown)
                {
                    if (previousPositionVertex4Y >= target.Vertex2.Y && previousPositionVertex4X >= target.Vertex2.X)
                    {
                        collidedDown = false;
                    }
                    else
                    {
                        collidedLeft = false;
                    }
                }

                if (collidedRight && collidedDown)
                {
                    if (previousPositionVertex3Y >= target.Vertex1.Y && previousPositionVertex3X <= target.Vertex1.X)
                    {
                        collidedDown = false;
                    }
                    else
                    {
                        collidedRight = false;
                    }
                }

                //Ajuste da posição do sprite com relação ao objeto colidido
                if (collidedUp)
                {
                    sprite.Y = target.Vertex4.Y;
                }
                else if (collidedDown)
                {
                    sprite.Y = target.Vertex1.Y - sprite.Height;
                }
                else if (collidedLeft)
                {
                    sprite.X = target.Vertex2.X;
                }
                else if (collidedRight)
                {
                    sprite.X = target.Vertex1.X - sprite.Width;
                }
            }

            return collided;
        }

        public static bool DetectCollision(Sprite sprite1, Sprite sprite2)
        {
            bool partial1 = false;
            bool partial2 = false;

            int xDistance = sprite2.Vertex2.X - sprite1.Vertex1.X;
            int yDistance = sprite2.Vertex4.Y - sprite1.Vertex1.Y;

            //Verifica se sprite2 está mais à esquerda que sprite1
            if (sprite2.Vertex1.X < sprite1.Vertex1.X)
            {
                xDistance = sprite1.Vertex2.X - sprite2.Vertex1.X;
            }

            //Verifica se sprite2 está mais ao topo que sprite1
            if (sprite2.Vertex1.Y < sprite1.Vertex1.Y)
            {
                yDistance = sprite1.Vertex4.Y - sprite2.Vertex1.Y;
            }

            int xSize = sprite1.Width + sprite2.Width;
            int ySize = sprite1.Height + sprite2.Height;

            if (xDistance <= xSize)
            {
                partial1 = true;
            }

            if (partial1)
            {
                if (yDistance <= ySize)
                {
                    partial2 = true;
                }
            }

            return partial2;
        }

        public static bool CollideBorder(Sprite sprite, Enum.Direction direction, int collisionPoint)
        {
            bool collided = false;

            if (direction == Enum.Direction.Down)
            {
                if (sprite.Vertex3.Y >= collisionPoint)
                {
                    collided = true;
                }
            }

            return collided;
        }

        //public static void BounceObject(Sprite sprite, Stage stage, float bouncingSoftness)
        //{
        //    if (sprite.Rectangle.Location.X > stage.SpriteAction.Width - sprite.Width)
        //    {
        //        if (sprite.HorizontalVelocity > 0)
        //        {
        //            if (!sprite.hBouncingZone)
        //            {
        //                sprite.HorizontalVelocity -= bouncingSoftness;

        //                if (sprite.HorizontalVelocity < 0)
        //                {
        //                    sprite.HorizontalVelocity = 0;
        //                }

        //                sprite.HorizontalVelocity *= -1;
        //                sprite.hBouncingZone = true;
        //            }
        //        }

        //        sprite.Rectangle.Location = new Point(stage.SpriteAction.Width - sprite.Width, sprite.Rectangle.Location.Y);
        //    }

        //    else if (sprite.Rectangle.Location.X < 0)
        //    {
        //        if (!sprite.hBouncingZone)
        //        {
        //            if (sprite.HorizontalVelocity < 0)
        //            {
        //                sprite.HorizontalVelocity += bouncingSoftness;

        //                if (sprite.HorizontalVelocity > 0)
        //                {
        //                    sprite.HorizontalVelocity = 0;
        //                }
        //            }

        //            sprite.HorizontalVelocity *= -1;
        //            sprite.hBouncingZone = true;
        //        }

        //        sprite.Rectangle.Location = new Point(0, sprite.Rectangle.Location.Y);
        //    }
        //    else
        //    {
        //        sprite.hBouncingZone = false;
        //    }

        //    if (sprite.Rectangle.Location.Y > stage.SpriteAction.Height - sprite.Height)
        //    {
        //        if (sprite.VerticalVelocity > 0)
        //        {
        //            if (!sprite.vBouncingZone)
        //            {
        //                sprite.VerticalVelocity -= bouncingSoftness;

        //                if (sprite.VerticalVelocity < 0)
        //                {
        //                    sprite.VerticalVelocity = 0;
        //                }

        //                sprite.VerticalVelocity *= -1;
        //                sprite.vBouncingZone = true;
        //            }
        //        }

        //        sprite.Rectangle.Location = new Point(sprite.Rectangle.Location.X, stage.SpriteAction.Height - sprite.Height);
        //    }

        //    else if (sprite.Rectangle.Location.Y < 0)
        //    {
        //        if (!sprite.vBouncingZone)
        //        {
        //            if (sprite.VerticalVelocity < 0)
        //            {
        //                sprite.VerticalVelocity += bouncingSoftness;

        //                if (sprite.VerticalVelocity > 0)
        //                {
        //                    sprite.VerticalVelocity = 0;
        //                }
        //            }

        //            sprite.VerticalVelocity *= -1;
        //            sprite.vBouncingZone = true;
        //        }

        //        sprite.Rectangle.Location = new Point(sprite.Rectangle.Location.X, 0);
        //    }
        //    else
        //    {
        //        sprite.vBouncingZone = false;
        //    }

        //}

        public static void ApplyConstantForce(Sprite sprite, Stage stage)
        {
            sprite.HorizontalVelocity += stage.ConstHForce;
            sprite.VerticalVelocity += stage.ConstVForce;
        }

        public static void ApplyForceLimits(Sprite sprite, Stage stage)
        {
            if (sprite.VerticalVelocityLimit != 0)
            {
                if (sprite.VerticalVelocity > sprite.VerticalVelocityLimit)
                {
                    sprite.VerticalVelocity = sprite.VerticalVelocityLimit;
                }
                else if ((sprite.VerticalVelocity * -1) > sprite.VerticalVelocityLimit)
                {
                    sprite.VerticalVelocity = sprite.VerticalVelocityLimit * -1;
                }
            }

            if (sprite.HorizontalVelocityLimit != 0)
            {
                if (sprite.HorizontalVelocity > sprite.HorizontalVelocityLimit)
                {
                    sprite.HorizontalVelocity = sprite.HorizontalVelocityLimit;
                }
                else if ((sprite.HorizontalVelocity * -1) > sprite.HorizontalVelocityLimit)
                {
                    sprite.HorizontalVelocity = sprite.HorizontalVelocityLimit * -1;
                }
            }
        }

        public static void ApplyGravity(Sprite gravityCenter, Sprite affectedtarget)
        {
            float vDistance = (gravityCenter.Y + (gravityCenter.Height / 2)) - (affectedtarget.Y + (affectedtarget.Height / 2));
            float hDistance = (gravityCenter.X + (gravityCenter.Width / 2)) - (affectedtarget.X + (affectedtarget.Width / 2));

            if (vDistance > 0)
            {
                affectedtarget.VerticalVelocity += gravityCenter.GForce;
            }
            else if (vDistance < 0)
            {
                affectedtarget.VerticalVelocity -= gravityCenter.GForce;
            }

            if (hDistance > 0)
            {
                affectedtarget.HorizontalVelocity += gravityCenter.GForce;
            }
            else if (hDistance < 0)
            {
                affectedtarget.HorizontalVelocity -= gravityCenter.GForce;
            }
        }

        public static float ConvertVelocityToMpS(float Force, float TimerInterval, float PixelToMeter)
        {
            float time = TimerInterval / 1000;
            float vel = Force * time * PixelToMeter;

            return (float)Math.Round(vel, 2, MidpointRounding.AwayFromZero);
        }

        public static float ConvertMpSToVelocity(float Force, float TimerInterval, float PixelToMeter)
        {
            float time = TimerInterval / 1000;
            float vel = Force * time / PixelToMeter;

            return (float)Math.Round(vel, 2, MidpointRounding.AwayFromZero);
        }

        public static string Encrypt(string Message)
        {
            string Passphrase = "abc";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }

        public static string Decrypt(string Message)
        {
            string Passphrase = "abc";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }

        public static void CenterFont(Font Font, Sprite Panel)
        {
            Font.Position.X = (Panel.Rectangle.Width / 2) - (Font.SpriteFont.MeasureString(Font.Text).X / 2);
        }

        public static void CenterFont(Font Font, int AbsoluteWidth)
        {
            Font.Position.X = (AbsoluteWidth / 2) - (Font.SpriteFont.MeasureString(Font.Text).X / 2);
        }

        public static void CreateDelay(float Seconds)
        {
            DateTime init = DateTime.Now;

            bool b = true;

            while (b)
            {
                TimeSpan interval = DateTime.Now - init;

                if (interval.TotalSeconds > Seconds)
                {
                    b = false;
                }
            }
        }

        public static void ApplyPause(bool enabled, Font FontMessage)
        {
            if (enabled)
            {
                if (Globals.EnterKeyPressed)
                {
                    if (!Globals.Paused)
                    {
                        Globals.Paused = true;
                        previousMessage = FontMessage.Text;
                        previousMessageColor = FontMessage.Color;

                        Functions.ShowMessage(FontMessage, Color.White, "Pause");
                        Functions.CenterFont(FontMessage, Globals.SelectedStage.SpriteAction);
                    }
                    else
                    {
                        Globals.Paused = false;
                        Functions.ShowMessage(FontMessage, previousMessageColor, previousMessage);
                    }
                }
            }
        }

        public static string ReadEncryptedFile(string path)
        {
            System.IO.StreamReader reader = new System.IO.StreamReader(path);

            string file = reader.ReadToEnd();

            reader.Close();

            return Functions.Decrypt(file);
        }

        public static void WriteDecryptedString(string decryptedContent, string path)
        {
            System.IO.StreamWriter writer = new System.IO.StreamWriter(path, false);

            string encrypted = Functions.Encrypt(decryptedContent);

            writer.Write(encrypted);

            writer.Close();
        }
    }
}