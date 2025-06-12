using System;
using Enums;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

namespace Managers
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager Instance { get; private set; }
        
        [Header("Events")] [SerializeField] private UnityEvent onCancelClicked;

        public event Action<InputType> OnInputTypeChanged;

        private const string CANCEL = "Cancel";
        private const string XBOX = "xbox";
        private const string DUALSHOCK = "dualshock";
        private const string DUALSENSE = "dualsense";

        private PlayerInput _playerInput;
        private InputType _currentInputType = InputType.Unknown;

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        private void Awake()
        {
            if (Instance && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }
            
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Start()
        {
            SubscribeToEvents();
            DetectAndNotifyInputType();
        }

        private void SubscribeToEvents()
        {
            InputUser.onChange += OnInputDeviceChanged;
            _playerInput.actions[CANCEL].performed += OnCancel;
        }

        private void UnsubscribeFromEvents()
        {
            InputUser.onChange -= OnInputDeviceChanged;
            _playerInput.actions[CANCEL].performed -= OnCancel;
        }

        private void OnInputDeviceChanged(InputUser user, InputUserChange change, InputDevice device)
        {
            if (change == InputUserChange.ControlSchemeChanged)
            {
                DetectAndNotifyInputType();
            }
        }

        private void OnCancel(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            Debug.Log("Cancel was pressed!");
            onCancelClicked?.Invoke();
        }

        private void DetectAndNotifyInputType()
        {
            InputType newType = GetCurrentInputType();

            if (newType == _currentInputType) return;
            
            _currentInputType = newType;
            Debug.Log($"Input changed to: {_currentInputType}");
            OnInputTypeChanged?.Invoke(_currentInputType);
        }

        private InputType GetCurrentInputType()
        {
            if (Gamepad.current != null)
            {
                string gamepadName = Gamepad.current.name.ToLower();

                if (gamepadName.Contains(XBOX)) return InputType.Xbox;
                
                if (gamepadName.Contains(DUALSHOCK) || gamepadName.Contains(DUALSENSE))
                    return InputType.PlayStation;

                return InputType.UnknownGamepad;
            }

            if (Keyboard.current != null && Mouse.current != null)
                return InputType.KeyboardAndMouse;

            return InputType.Unknown;
        }
    }
}