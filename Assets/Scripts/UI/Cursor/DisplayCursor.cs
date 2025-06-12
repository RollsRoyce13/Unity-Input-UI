using Enums;
using Managers;
using UnityEngine;

namespace UI.Cursor
{
    public class DisplayCursor : MonoBehaviour
    {
        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        private void Start()
        {
            LoadInputInfo();
            SubscribeToEvents();
        }

        private void LoadInputInfo()
        {
            UpdateCursor(PlayerInputManager.Instance.CurrentInputType);
        }

        private void SubscribeToEvents()
        {
            PlayerInputManager.Instance.OnInputTypeChanged += UpdateCursor;
        }

        private void UnsubscribeFromEvents()
        {
            PlayerInputManager.Instance.OnInputTypeChanged -= UpdateCursor;
        }

        private void UpdateCursor(InputType type)
        {
            bool isKeyboardAndMouse = type == InputType.KeyboardAndMouse;
            
            UnityEngine.Cursor.visible = isKeyboardAndMouse;
            UnityEngine.Cursor.lockState = isKeyboardAndMouse
                ? CursorLockMode.None
                : CursorLockMode.Locked;
        }
    }
}