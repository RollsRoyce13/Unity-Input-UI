using UnityEngine;

namespace Settings
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class LoadAudioSettings : MonoBehaviour
    {
        [SerializeField] protected AudioSettingsSO audioSettings;
        
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        
        private void OnDestroy()
        {
            UnsubscribeFromEvent();
        }

        private void Start()
        {
            Load();
            SubscribeToEvent();
        }
        
        protected abstract void Load();

        protected abstract void SubscribeToEvent();

        protected abstract void UnsubscribeFromEvent();

        protected void SwitchState(bool state)
        {
            _audioSource.mute = !state;
        }
    }
}