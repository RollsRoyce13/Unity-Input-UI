using Consts;
using Enums;
using Managers;
using TMPro;
using UnityEngine;

namespace UI.Text
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DisplayTextHints : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private bool isSubmitHint;
        
        private TextMeshProUGUI _text;

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            LoadInputInfo();
            SubscribeToEvents();
        }

        private void LoadInputInfo()
        {
            var currentType = PlayerInputManager.Instance.CurrentInputType;
            
            if (isSubmitHint)
            {
                UpdateSubmitText(currentType);
            }
            else
            {
                UpdateBackText(currentType);
            }
        }

        private void SubscribeToEvents()
        {
            if (isSubmitHint)
            {
                PlayerInputManager.Instance.OnInputTypeChanged += UpdateSubmitText;
            }
            else
            {
                PlayerInputManager.Instance.OnInputTypeChanged += UpdateBackText;
            }
        }

        private void UnsubscribeFromEvents()
        {
            if (isSubmitHint)
            {
                PlayerInputManager.Instance.OnInputTypeChanged -= UpdateSubmitText;
            }
            else
            {
                PlayerInputManager.Instance.OnInputTypeChanged -= UpdateBackText;
            }
        }
        
        private void UpdateSubmitText(InputType type)
        {
            switch (type)
            {
                case InputType.Xbox:
                    SetSubmitHintText(Key.XBOX_SUBMIT_HINT);
                    break;
                case InputType.PlayStation:
                    SetSubmitHintText(Key.PLAYSTATION_SUBMIT_HINT);
                    break;
                case InputType.KeyboardAndMouse:
                    SetSubmitHintText(Key.KEYBOARD_SUBMIT_HINT);
                    break;
            }
        }

        private void UpdateBackText(InputType type)
        {
            switch (type)
            {
                case InputType.Xbox:
                    SetBackHintText(Key.XBOX_BACK_HINT);
                    break;
                case InputType.PlayStation:
                    SetBackHintText(Key.PLAYSTATION_BACK_HINT);
                    break;
                case InputType.KeyboardAndMouse:
                    SetBackHintText(Key.KEYBOARD_BACK_HINT);
                    break;
            }
        }
        
        private void SetSubmitHintText(string hint)
        {
            _text.text = $"Press {hint} Button";
        }

        private void SetBackHintText(string hint)
        {
            _text.text = $"Back: {hint}";
        }
    }
}