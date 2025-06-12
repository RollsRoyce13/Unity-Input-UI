using Utils;

namespace Settings
{
    public class LoadSound : LoadAudioSettings
    {
        protected override void Load()
        {
            if (audioSettings.IsNull()) return;
            
            SwitchState(audioSettings.IsSoundOn);
        }

        protected override void SubscribeToEvent()
        {
            if (audioSettings.IsNull()) return;
            
            audioSettings.OnSoundChanged += SwitchState;
        }

        protected override void UnsubscribeFromEvent()
        {
            if (audioSettings.IsNull()) return;
            
            audioSettings.OnSoundChanged -= SwitchState;
        }
    }
}