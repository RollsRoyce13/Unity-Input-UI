using Utils;

namespace Settings
{
    public class SwitchSound : AudioStateSwitcher
    {
        protected override void Load()
        {
            if (audioSettings.IsNull()) return;
            
            _toggle.isOn = audioSettings.IsSoundOn;
        }

        protected override void SwitchState(bool state)
        {
            if (audioSettings.IsNull()) return;
            
            audioSettings.SwitchSound();
        }
    }
}