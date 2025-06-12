using Enums;
using Managers;
using TMPro;
using UnityEngine;

namespace UI.Text
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class DisplayTextHints : MonoBehaviour
    {
        [Header("Texts")]
        [SerializeField] private string xboxHint;
        [SerializeField] private string playstationHint;
        [SerializeField] private string keyboardAndMouseHint;

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
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            PlayerInputManager.Instance.OnInputTypeChanged += UpdateText;
        }

        private void UnsubscribeFromEvents()
        {
            PlayerInputManager.Instance.OnInputTypeChanged -= UpdateText;
        }

        private void UpdateText(InputType type)
        {
            // switch (type)
            // {
            //     case InputType.Xbox:
            //         iconImage.sprite = xboxIcon;
            //         break;
            //     case InputType.PlayStation:
            //         iconImage.sprite = psIcon;
            //         break;
            //     case InputType.KeyboardAndMouse:
            //         iconImage.sprite = kbIcon;
            //         break;
            // }
        }
    }
}