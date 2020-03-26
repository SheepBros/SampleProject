using UnityEngine;
using UnityEngine.UI;

namespace SB.UI.Sample
{
    public class MainView : View<MainViewController>, IViewEnterState, IViewExitState
    {
        [SerializeField]
        private Button _settingsButton;

        [SerializeField]
        private Button _userButton;

        private void Awake()
        {
            _settingsButton.onClick.AddListener(OpenSettingsScreen);
            _userButton.onClick.AddListener(OpenUserScreen);
        }

        private void OpenSettingsScreen()
        {
            _controller.RequestScreen(ScreenNodeConstants.Settings);
        }

        private void OpenUserScreen()
        {
            _controller.RequestScreen(ScreenNodeConstants.User);
        }

        void IViewEnterState.EnterState(object args)
        {
        }

        void IViewExitState.ExitState()
        {
        }
    }
}