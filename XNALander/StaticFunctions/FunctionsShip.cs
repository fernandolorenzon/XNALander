using XNALander.Classes;

namespace XNALander.StaticFunctions
{
    public static class FunctionsShip
    {
        public static void ApplyControls(SpriteShip sprite)
        {
            float accel = 0.02F;

            if (Globals.LeftKeyDown)
            {
                if (sprite.CurrentAccelLeft <= sprite.Accel)
                {
                    sprite.CurrentAccelLeft += accel;
                }
                else
                {
                    sprite.CurrentAccelLeft = sprite.Accel;
                }
            }
            else
            {
                sprite.CurrentAccelLeft = sprite.Accel / 3;
            }

            if (Globals.RightKeyDown)
            {
                if (sprite.CurrentAccelRight <= sprite.Accel)
                {
                    sprite.CurrentAccelRight += accel;
                }
                else
                {
                    sprite.CurrentAccelRight = sprite.Accel;
                }
            }
            else
            {
                sprite.CurrentAccelRight = sprite.Accel / 3;
            }

            if (Globals.UpKeyDown)
            {
                if (sprite.CurrentAccelUp <= sprite.Accel)
                {
                    sprite.CurrentAccelUp += accel;
                }
                else
                {
                    sprite.CurrentAccelUp = sprite.Accel;
                }
            }
            else
            {
                sprite.CurrentAccelUp = sprite.Accel / 3;
            }

            if (Globals.DownKeyDown)
            {
                if (sprite.CurrentAccelDown <= sprite.Accel)
                {
                    sprite.CurrentAccelDown += accel;
                }
                else
                {
                    sprite.CurrentAccelDown = sprite.Accel;
                }
            }
            else
            {
                sprite.CurrentAccelDown = sprite.Accel / 3;
            }

            //if (Globals.LeftKeyDown)
            //{
            //    sprite.HorizontalVelocity -= sprite.Accel;
            //}
            //else if (Globals.RightKeyDown)
            //{
            //    sprite.HorizontalVelocity += sprite.Accel;
            //}
            
            //if (Globals.UpKeyDown)
            //{
            //    sprite.VerticalVelocity -= sprite.Accel;
            //}
            //else if (Globals.DownKeyDown)
            //{
            //    sprite.VerticalVelocity += sprite.Accel;
            //}

            if (Globals.LeftKeyDown)
            {
                sprite.HorizontalVelocity -= sprite.CurrentAccelLeft;
            }
            else if (Globals.RightKeyDown)
            {
                sprite.HorizontalVelocity += sprite.CurrentAccelRight;
            }
            
            if (Globals.UpKeyDown)
            {
                sprite.VerticalVelocity -= sprite.CurrentAccelUp;
            }
            else if (Globals.DownKeyDown)
            {
                sprite.VerticalVelocity += sprite.CurrentAccelDown;
            }
        }

        public static void MoveShipSprites(SpriteShip ship)
        {
            Functions.MoveSprite(ship);
            Functions.MoveSprite(ship.SpriteBotton, (int)ship.X, (int)ship.Y + ship.Height);
            Functions.MoveSprite(ship.SpriteRight, (int)ship.X + ship.Width, (int)ship.Y);
            Functions.MoveSprite(ship.SpriteLeft, (int)ship.X - ship.Width, (int)ship.Y);
            Functions.MoveSprite(ship.SpriteTop, (int)ship.X, (int)ship.Y - ship.Height);
        }

        public static void UpdateForLander01()
        {
            if (Globals.SelectedShip.Fuel > 0)
            {
                if (Globals.SpaceKeyDown)
                {
                    Functions.ApplyDrag(Globals.SelectedShip.Accel * 2, Globals.SelectedShip, Enum.Axis.All);
                }

                SoundClass.PlayLooping(Globals.SFXRocketInstance, Globals.LeftKeyDown || Globals.RightKeyDown || Globals.UpKeyDown || Globals.DownKeyDown || Globals.SpaceKeyDown);

                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, Globals.UpKeyDown || Globals.SpaceKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, Globals.LeftKeyDown || Globals.SpaceKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, Globals.RightKeyDown || Globals.SpaceKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, Globals.DownKeyDown || Globals.SpaceKeyDown, false);
            }
            else
            {
                SoundClass.Stop(Globals.SFXRocketInstance);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, false, false);
            }
        }

        public static void UpdateForLander02()
        {
            if (Globals.SelectedShip.Fuel > 0)
            {

                if (Globals.SpaceKeyDown)
                {
                    Globals.SelectedShip.VerticalVelocity -= (Globals.SelectedShip.Accel * 2);
                }
                SoundClass.PlayLooping(Globals.SFXRocketInstance, Globals.LeftKeyDown || Globals.RightKeyDown || Globals.UpKeyDown || Globals.DownKeyDown || Globals.SpaceKeyDown);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, Globals.UpKeyDown || Globals.SpaceKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, Globals.LeftKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, Globals.RightKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, Globals.DownKeyDown, false);
            }
            else
            {
                SoundClass.Stop(Globals.SFXRocketInstance);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, false, false);
            }

            if (Globals.SpaceKeyDown && !Globals.SpaceKeyDownPrevious)
            {
                Globals.SelectedShip.SpriteBotton.TextureCurrent = Globals.SelectedShip.SpriteBotton.Textures[1];
            }
            else if (!Globals.SpaceKeyDown && Globals.SpaceKeyDownPrevious)
            {
                Globals.SelectedShip.SpriteBotton.TextureCurrent = Globals.SelectedShip.SpriteBotton.Textures[0];
            }
        }

        public static void UpdateForLander03()
        {
            if (Globals.SelectedShip.Fuel > 0)
            {
                if (Globals.SpaceKeyDown)
                {
                    Globals.SelectedShip.Accel = (Functions.ConvertMpSToVelocity(Globals.SelectedShip.AccelMpS, Globals.TimerInterval, Globals.PixelToMeter) / 2);
                }
                else
                {
                    Globals.SelectedShip.Accel = Functions.ConvertMpSToVelocity(Globals.SelectedShip.AccelMpS, Globals.TimerInterval, Globals.PixelToMeter);
                }

                SoundClass.PlayLooping(Globals.SFXRocketInstance, Globals.LeftKeyDown || Globals.RightKeyDown || Globals.UpKeyDown || Globals.DownKeyDown);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, Globals.UpKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, Globals.LeftKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, Globals.RightKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, Globals.DownKeyDown, false);
            }
            else
            {
                SoundClass.Stop(Globals.SFXRocketInstance);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, false, false);
            }
        }

        public static void UpdateForLander04()
        {
            if (Globals.SelectedShip.Fuel > 0)
            {
                if (Globals.SpaceKeyDown)
                {
                    Globals.SelectedShip.VerticalVelocity = 0;
                    Globals.SelectedShip.HorizontalVelocity = 0;
                }

                SoundClass.PlayLooping(Globals.SFXSpecialInstance, Globals.SpaceKeyDown);
                SoundClass.PlayLooping(Globals.SFXFloatInstance, Globals.LeftKeyDown || Globals.RightKeyDown || Globals.UpKeyDown || Globals.DownKeyDown);
            }
            else
            {
                SoundClass.Stop(Globals.SFXFloatInstance);
                SoundClass.Stop(Globals.SFXSpecialInstance);
            }
        }

        public static void UpdateForLander05()
        {
            if (Globals.SelectedShip.Fuel > 0)
            {
                if (Globals.SpaceKeyDown)
                {
                    Functions.ApplyDrag(Globals.SelectedShip.Accel * 2, Globals.SelectedShip, Enum.Axis.Vertical);
                }

                SoundClass.PlayLooping(Globals.SFXRocketInstance, Globals.UpKeyDown || Globals.LeftKeyDown || Globals.RightKeyDown || Globals.DownKeyDown || Globals.SpaceKeyDown);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, Globals.UpKeyDown || Globals.SpaceKeyDown || Globals.LeftKeyDown || Globals.RightKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, Globals.DownKeyDown, false);
            }
            else
            {
                SoundClass.Stop(Globals.SFXRocketInstance);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, false, false);
            }

            if (!Globals.LeftKeyDown && !Globals.RightKeyDown && (Globals.LeftKeyDownPrevious || Globals.RightKeyDownPrevious))
            {
                Globals.SelectedShip.TextureCurrent = Globals.SelectedShip.Textures[0];
            }
            else if (Globals.LeftKeyDown && !Globals.LeftKeyDownPrevious)
            {
                Globals.SelectedShip.TextureCurrent = Globals.SelectedShip.Textures[3];
            }
            else if (Globals.RightKeyDown && !Globals.RightKeyDownPrevious)
            {
                Globals.SelectedShip.TextureCurrent = Globals.SelectedShip.Textures[4];
            }
        }

        public static void UpdateForLander06()
        {
            if (Globals.SelectedShip.Fuel > 0)
            {
                if (Globals.SpaceKeyDown && !Globals.SpaceKeyDownPrevious)
                {
                    Globals.SelectedShip.HorizontalVelocity *= -0.3F;
                    Globals.SelectedShip.VerticalVelocity *= -0.3F;
                }

                SoundClass.PlayLooping(Globals.SFXFloatInstance, Globals.LeftKeyDown || Globals.RightKeyDown || Globals.UpKeyDown || Globals.DownKeyDown);
            }
            else
            {
                SoundClass.Stop(Globals.SFXFloatInstance);
            }
        }

        public static void UpdateForLander07()
        {
            if (Globals.SelectedShip.Fuel > 0)
            {
                if (Globals.SpaceKeyDown)
                {
                    Globals.SelectedShip.VerticalVelocity -= Globals.SelectedStage.ConstVForce;
                }

                SoundClass.PlayLooping(Globals.SFXRocketInstance, Globals.LeftKeyDown || Globals.RightKeyDown || Globals.UpKeyDown || Globals.DownKeyDown);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, Globals.UpKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, Globals.LeftKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, Globals.RightKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, Globals.DownKeyDown, false);
            }
            else
            {
                SoundClass.Stop(Globals.SFXRocketInstance);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, false, false);
            }
        }

        public static void UpdateForLander08()
        {
            if (Globals.SpaceKeyDown)
            {
                Globals.SelectedShip.VerticalVelocity -= Globals.SelectedStage.ConstVForce * 0.90F;
            }

            if (Globals.SelectedShip.Fuel > 0)
            {
                SoundClass.PlayLooping(Globals.SFXRocketInstance, Globals.LeftKeyDown || Globals.RightKeyDown || Globals.UpKeyDown || Globals.DownKeyDown);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, Globals.UpKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, Globals.LeftKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, Globals.RightKeyDown, false);

                if (Globals.SpaceKeyDown)
                {
                    Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, false, true);
                }
                else
                {
                    Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, Globals.DownKeyDown, false);
                }

                if (Globals.SpaceKeyDown && !Globals.SpaceKeyDownPrevious)
                {
                    Globals.SelectedShip.SpriteTop.TextureCurrent = Globals.SelectedShip.Textures[3];
                }
                else if (!Globals.SpaceKeyDown && Globals.SpaceKeyDownPrevious)
                {
                    Globals.SelectedShip.SpriteTop.TextureCurrent = Globals.SelectedShip.SpriteTop.Textures[0];
                }
            }
            else
            {
                SoundClass.Stop(Globals.SFXRocketInstance);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, false, false);
            }
        }

        public static void UpdateForLander09()
        {
            if (Globals.SpaceKeyDown)
            {
                Globals.SelectedShip.VerticalVelocity -= Globals.SelectedStage.ConstVForce * 0.90F;
            }

            if (Globals.SelectedShip.Fuel > 0)
            {
                SoundClass.PlayLooping(Globals.SFXRocketInstance, Globals.LeftKeyDown || Globals.RightKeyDown || Globals.UpKeyDown || Globals.DownKeyDown);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, Globals.UpKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, Globals.LeftKeyDown, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, Globals.RightKeyDown, false);

                if (Globals.SpaceKeyDown)
                {
                    Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, false, true);
                }
                else
                {
                    Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, Globals.DownKeyDown, false);
                }

                if (Globals.SpaceKeyDown && !Globals.SpaceKeyDownPrevious)
                {
                    Globals.SelectedShip.SpriteTop.TextureCurrent = Globals.SelectedShip.Textures[3];
                }
                else if (!Globals.SpaceKeyDown && Globals.SpaceKeyDownPrevious)
                {
                    Globals.SelectedShip.SpriteTop.TextureCurrent = Globals.SelectedShip.SpriteTop.Textures[0];
                }
            }
            else
            {
                SoundClass.Stop(Globals.SFXRocketInstance);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteBotton, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteRight, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteLeft, false, false);
                Functions.ApplyFlicker(Globals.SelectedShip.SpriteTop, false, false);
            }
        }

        public static void UpdateForLanderX1()
        {
            SoundClass.PlayLooping(Globals.SFXSpecialInstance, Globals.SpaceKeyDown);

            if (Globals.SelectedShip.Fuel > 0)
            {
                if (Globals.SpaceKeyDown)
                {
                    //Cancela acelerações atribuidas
                    if (Globals.LeftKeyDown)
                    {
                        Globals.SelectedShip.HorizontalVelocity += Globals.SelectedShip.Accel;
                        Globals.SelectedShip.Fuel += Globals.SelectedShip.FuelConsumptionRate;
                    }
                    else if (Globals.RightKeyDown)
                    {
                        Globals.SelectedShip.HorizontalVelocity -= Globals.SelectedShip.Accel;
                        Globals.SelectedShip.Fuel += Globals.SelectedShip.FuelConsumptionRate;
                    }

                    if (Globals.UpKeyDown)
                    {
                        Globals.SelectedShip.VerticalVelocity += Globals.SelectedShip.Accel;
                        Globals.SelectedShip.Fuel += Globals.SelectedShip.FuelConsumptionRate;
                    }
                    else if (Globals.DownKeyDown)
                    {
                        Globals.SelectedShip.VerticalVelocity -= Globals.SelectedShip.Accel;
                        Globals.SelectedShip.Fuel += Globals.SelectedShip.FuelConsumptionRate;
                    }
                }

                SoundClass.PlayLooping(Globals.SFXFloatInstance, Globals.LeftKeyDown || Globals.RightKeyDown || Globals.UpKeyDown || Globals.DownKeyDown);
            }
            else
            {
                SoundClass.Stop(Globals.SFXFloatInstance);
            }
        }
    }
}
