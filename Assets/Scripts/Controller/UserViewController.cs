using SimpleDI;

namespace SB.UI.Sample
{
    public class UserViewController : IViewController
    {
        private IUIController _uiController;

        private IUserDataManager _userDataManager;

        [Inject]
        public void InitContexts(IUIController uiController, IUserDataManager userDataManager)
        {
            _uiController = uiController;
            _userDataManager = userDataManager;
        }

        public void Back()
        {
            _uiController.RequestBackTransition();
        }

        public void OpenExpPopup()
        {
            PopupViewPayload payload = new PopupViewPayload()
            {
                Title = "Current Exp",
                Description = $"Exp: {_userDataManager.GetUserData().Exp}"
            };

            _uiController.RequestScreen(ScreenNodeConstants.Popup, payload);
        }
    }
}