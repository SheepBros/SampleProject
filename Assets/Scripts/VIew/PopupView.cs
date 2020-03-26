using UnityEngine;
using UnityEngine.UI;

namespace SB.UI.Sample
{
    public class PopupView : View<PopupViewController>, IViewEnterState
    {
        [SerializeField]
        private Text _title;

        [SerializeField]
        private Text _description;

        [SerializeField]
        private Button _closeButton;

        [SerializeField]
        private Button _backgroundButton;

        protected virtual void Awake()
        {
            _closeButton.onClick.AddListener(Close);
            _backgroundButton.onClick.AddListener(Close);
        }

        protected void Close()
        {
            _controller.Close();
        }

        public virtual void EnterState(object args)
        {
            if (!(args is PopupViewPayload))
            {
                return;
            }

            PopupViewPayload popupView = args as PopupViewPayload;
            _title.text = popupView.Title;
            _description.text = popupView.Description;
        }
    }
}