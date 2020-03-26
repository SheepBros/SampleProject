using UnityEngine;
using UnityEngine.UI;

namespace SB.UI.Sample
{
    public class SettingsView : View<SettingsViewController>
    {
        [SerializeField]
        private Button _backButton;

        [SerializeField]
        private Button _saveButton;

        private void Awake()
        {
            _backButton.onClick.AddListener(OnBackButtonClicked);
            _saveButton.onClick.AddListener(OnSaveButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            _controller.Back();
        }

        private void OnSaveButtonClicked()
        {
            _controller.Save();
        }
    }
}