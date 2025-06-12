using System.Linq;
using Game.Scripts.Managers;
using UnityEngine;

namespace Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioEffectsManager : Singleton<AudioEffectsManager>
    {
        [SerializeField] private AudioClip[] audioClips;
        
        private AudioSource _audioSource;

        protected override void Awake()
        {
            base.Awake();
            
            _audioSource = GetComponent<AudioSource>();
        }
        
        public void PlaySoundByName(string soundName)
        {
            AudioClip clip = FindAudioClipByName(soundName);
            
            if (clip != null)
            {
                _audioSource.PlayOneShot(clip);
            }
            else
            {
                Debug.LogWarning($"AudioClip {soundName} not found");
            }
        }

        private AudioClip FindAudioClipByName(string soundName)
        {
            return audioClips.FirstOrDefault(x => x.name == soundName);
        }
    }
}
