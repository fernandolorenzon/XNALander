using Microsoft.Xna.Framework.Audio;

namespace XNALander.Classes
{
    public static class SoundClass
    {
        public static void PlayLooping(SoundEffectInstance SoundFX, bool Enabled)
        {
            if (Enabled)
            {
                SoundFX.Play();
            }
            else
            {
                SoundFX.Stop();
            }
        }

        public static void Stop(SoundEffectInstance SoundFX)
        {
            SoundFX.Stop();
        }
    }
}
