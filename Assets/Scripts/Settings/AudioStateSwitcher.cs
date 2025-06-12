using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public abstract class AudioStateSwitcher : MonoBehaviour
    {
        [SerializeField] protected AudioSettingsSO audioSettings;
        
        protected Toggle _toggle;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
        }

        private void Start()
        {
            Load();
            _toggle.onValueChanged.AddListener(SwitchState);
        }
        
        protected abstract void Load();
        
        protected abstract void SwitchState(bool state);
    }
}