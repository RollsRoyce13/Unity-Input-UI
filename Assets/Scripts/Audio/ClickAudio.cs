using Consts;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Audio
{
    [RequireComponent(typeof(Button))]
    public class ClickAudio : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
        
            _button.onClick.AddListener(PlayClick);
        }

        private void PlayClick()
        {
            AudioEffectsManager.Instance.PlaySoundByName(Key.CLICK);
        }
    }
}