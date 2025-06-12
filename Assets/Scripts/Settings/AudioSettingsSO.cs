using System;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "AudioSettings/AudioSettings")]
    public class AudioSettingsSO : ScriptableObject
    {
        public event Action<bool> OnMusicChanged;
        public event Action<bool> OnSoundChanged;

        private const string MUSIC_PLAYER_PREFS_KEY = "MUSIC_PLAYER_PREFS_KEY";
        private const string SOUND_PLAYER_PREFS_KEY = "SOUND_PLAYER_PREFS_KEY";

        public bool IsMusicOn
        {
            get => PlayerPrefs.GetInt(MUSIC_PLAYER_PREFS_KEY, 1) == 1;
            
            set
            {
                PlayerPrefs.SetInt(MUSIC_PLAYER_PREFS_KEY, value ? 1 : 0);
                PlayerPrefs.Save();
                OnMusicChanged?.Invoke(value);
                Debug.Log($"Is Music On: {value}");
            }
        }

        public bool IsSoundOn
        {
            get => PlayerPrefs.GetInt(SOUND_PLAYER_PREFS_KEY, 1) == 1;
            
            set
            {
                PlayerPrefs.SetInt(SOUND_PLAYER_PREFS_KEY, value ? 1 : 0);
                PlayerPrefs.Save();
                OnSoundChanged?.Invoke(value);
                Debug.Log($"Is Sound On: {value}");
            }
        }

        public void SwitchMusic()
        {
            IsMusicOn = !IsMusicOn;
        }

        public void SwitchSound()
        {
            IsSoundOn = !IsSoundOn;
        }
    }
}