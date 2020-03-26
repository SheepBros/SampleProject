using UnityEngine;
using UnityEngine.UI;

namespace SB.UI.Sample
{
    public class UserView : View<UserViewController>
    {
        [SerializeField]
        private Button _backButton;

        [SerializeField]
        private Button _checkExpButton;

        private void Awake()
        {
            _backButton.onClick.AddListener(OnBackButtonClicked);
            _checkExpButton.onClick.AddListener(OnOpenExpPopupButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            _controller.Back();
        }

        private void OnOpenExpPopupButtonClicked()
        {
            _controller.OpenExpPopup();
        }
    }
}