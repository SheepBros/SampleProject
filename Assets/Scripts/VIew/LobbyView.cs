using UnityEngine;
using UnityEngine.UI;

namespace SB.UI.Sample
{
    public class LobbyView : View<LobbyViewController>
    {
        [SerializeField]
        private Button _enterMainButton;

        private void Start()
        {
            _enterMainButton.onClick.AddListener(EnterMainScene);
        }

        private void EnterMainScene()
        {
            _controller.LoadMainScene();
        }
    }
}