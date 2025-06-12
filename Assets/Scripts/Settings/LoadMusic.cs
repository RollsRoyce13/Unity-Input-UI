using Utils;

namespace Settings
{
    public class LoadMusic : LoadAudioSettings
    {
        protected override void Load()
        {
            if (audioSettings.IsNull()) return;
            
            SwitchState(audioSettings.IsMusicOn);
        }

        protected override void SubscribeToEvent()
        {
            if (audioSettings.IsNull()) return;
            
            audioSettings.OnMusicChanged += SwitchState;
        }

        protected override void UnsubscribeFromEvent()
        {
            if (audioSettings.IsNull()) return;
            
            audioSettings.OnMusicChanged -= SwitchState;
        }
    }
}