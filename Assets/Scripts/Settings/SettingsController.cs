using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Settings
{
    public class SettingsController : MonoBehaviour
    {
        [Header("Lists")]
        [SerializeField] private List<GameObject> panelsList;
        [SerializeField] private List<Button> headerButtonsList;

        private int _currentIndex;

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        private void OnEnable()
        {
            Initialization();
        }

        private void Start()
        {
            SubscribeToEvents();
        }

        public void ActivatePanelByIndex(int index)
        {
            for (var i = 0; i < panelsList.Count; i++)
            {
                panelsList[i].SetActive(i == index);
            }
        }

        private void Initialization()
        {
            _currentIndex = 0;
            
            UpdateButtonByIndex();
        }

        private void SubscribeToEvents()
        {
            PlayerInputManager.Instance.OnRightShoulderClicked += IncreaseIndex;
            PlayerInputManager.Instance.OnLeftShoulderClicked += DecreaseIndex;
        }

        private void UnsubscribeFromEvents()
        {
            PlayerInputManager.Instance.OnRightShoulderClicked -= IncreaseIndex;
            PlayerInputManager.Instance.OnLeftShoulderClicked -= DecreaseIndex;
        }

        private void IncreaseIndex()
        {
            ChangeIndex(1);
            UpdateButtonByIndex();
        }

        private void DecreaseIndex()
        {
            ChangeIndex(-1);
            UpdateButtonByIndex();
        }

        private void ChangeIndex(int direction)
        {
            _currentIndex += direction;
            
            if (_currentIndex >= panelsList.Count)
            {
                _currentIndex = 0;
            }
            else if (_currentIndex < 0)
            {
                _currentIndex = panelsList.Count - 1;
            }
        }
        
        private void UpdateButtonByIndex()
        {
            for (var i = 0; i < headerButtonsList.Count; i++)
            {
                if (i != _currentIndex) continue;
                
                headerButtonsList[i].Select();
                headerButtonsList[i].onClick.Invoke();
            }
        }
    }
}