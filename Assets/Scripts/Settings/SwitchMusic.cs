using Utils;

namespace Settings
{
    public class SwitchMusic : AudioStateSwitcher
    {
        protected override void Load()
        {
            if (audioSettings.IsNull()) return;
            
            _toggle.isOn = audioSettings.IsMusicOn;
        }

        protected override void SwitchState(bool state)
        {
            if (audioSettings.IsNull()) return;
            
            audioSettings.SwitchMusic();
        }
    }
}