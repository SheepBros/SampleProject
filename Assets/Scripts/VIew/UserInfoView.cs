using UnityEngine;
using UnityEngine.UI;

namespace SB.UI.Sample
{
    public class UserInfoView : View<UserInfoViewController>, IViewEnterState
    {
        [SerializeField]
        private Text _userNameText;

        [SerializeField]
        private Text _currencyText;

        void IViewEnterState.EnterState(object args)
        {
            _userNameText.text = _controller.GetUserData().Name;
            _currencyText.text = _controller.GetUserData().Currency.ToString();
        }
    }
}