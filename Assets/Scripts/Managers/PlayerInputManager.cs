using System;
using Enums;
using Game.Scripts.Managers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using Key = Consts.Key;

namespace Managers
{
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerInputManager : Singleton<PlayerInputManager>
    {
        [Header("Events")] 
        [SerializeField] private UnityEvent onCancelClicked;
        [SerializeField] private UnityEvent onSubmitClicked;

        public event Action<InputType> OnInputTypeChanged;
        public event Action OnLeftShoulderClicked;
        public event Action OnRightShoulderClicked;

        public InputType CurrentInputType { get; private set; } = InputType.Unknown;
        
        private PlayerInput _playerInput;

        private bool _isFirstSubmit;

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        protected override void Awake()
        {
            base.Awake();
            
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Start()
        {
            _isFirstSubmit = true;
            
            SubscribeToEvents();
            DetectAndNotifyInputType();
        }

        private void SubscribeToEvents()
        {
            InputUser.onChange += OnInputDeviceChanged;
            _playerInput.actions[Key.CANCEL].performed += OnCancelClicked;
            _playerInput.actions[Key.SUBMIT].performed += OnSubmitClicked;
            _playerInput.actions[Key.SHOULDER_LEFT].performed += LeftShoulderHandler;
            _playerInput.actions[Key.SHOULDER_RIGHT].performed += RightShoulderHandler;
        }

        private void UnsubscribeFromEvents()
        {
            InputUser.onChange -= OnInputDeviceChanged;
            _playerInput.actions[Key.CANCEL].performed -= OnCancelClicked;
            _playerInput.actions[Key.SUBMIT].performed -= OnSubmitClicked;
            _playerInput.actions[Key.SHOULDER_LEFT].performed -= LeftShoulderHandler;
            _playerInput.actions[Key.SHOULDER_RIGHT].performed -= RightShoulderHandler;
        }

        private void OnInputDeviceChanged(InputUser user, InputUserChange change, InputDevice device)
        {
            if (change == InputUserChange.ControlSchemeChanged)
            {
                DetectAndNotifyInputType();
            }
        }
        
        private void OnSubmitClicked(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            if (!_isFirstSubmit) return;
            
            _isFirstSubmit = false;
            Debug.Log("Submit was pressed!");
            AudioEffectsManager.Instance.PlaySoundByName(Key.CLICK);
            onSubmitClicked?.Invoke();
        }

        private void OnCancelClicked(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            Debug.Log("Cancel was pressed!");
            AudioEffectsManager.Instance.PlaySoundByName(Key.CLICK);
            onCancelClicked?.Invoke();
        }
        
        private void LeftShoulderHandler(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            Debug.Log("Left shoulder was pressed!");
            AudioEffectsManager.Instance.PlaySoundByName(Key.CLICK);
            OnLeftShoulderClicked?.Invoke();
        }
        
        private void RightShoulderHandler(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            Debug.Log("Right shoulder was pressed!");
            AudioEffectsManager.Instance.PlaySoundByName(Key.CLICK);
            OnRightShoulderClicked?.Invoke();
        }

        private void DetectAndNotifyInputType()
        {
            InputType newType = GetCurrentInputType();

            if (newType == CurrentInputType) return;
            
            CurrentInputType = newType;
            Debug.Log($"Input changed to: {CurrentInputType}");
            OnInputTypeChanged?.Invoke(CurrentInputType);
        }

        private InputType GetCurrentInputType()
        {
            if (Gamepad.current != null)
            {
                string gamepadName = Gamepad.current.name.ToLower();

                if (gamepadName.Contains(Key.XBOX)) return InputType.Xbox;
                
                if (gamepadName.Contains(Key.DUALSHOCK) || gamepadName.Contains(Key.DUALSENSE))
                    return InputType.PlayStation;

                return InputType.UnknownGamepad;
            }

            if (Keyboard.current != null && Mouse.current != null)
                return InputType.KeyboardAndMouse;

            return InputType.Unknown;
        }
    }
}