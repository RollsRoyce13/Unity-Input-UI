using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace UI.Screens
{
    public class ScreensController : MonoBehaviour
    {
        [Header("Screens")]
        [SerializeField] private List<Screen> screens;
        [SerializeField] private Screen mainMenuScreen;

        public void OpenScreen(Screen currentScreen)
        {
            if (screens.IsEmpty()) return;
            
            foreach (var screen in screens)
            {
                screen.gameObject.SetActive(screen == currentScreen);
            }
        }

        public void OpenMainMenu()
        {
            if (mainMenuScreen.IsNull()) return;

            OpenScreen(mainMenuScreen);
        }
        
        public void OpenAdditionalScreen(Screen screen)
        {
            screen.gameObject.SetActive(true);
        }
        
        public void CloseAdditionalScreen(Screen screen)
        {
            screen.gameObject.SetActive(false);
        }
    }
}