using SimpleDI;

namespace SB.UI.Sample
{
    public class SettingsViewController : IViewController
    {
        private IUIController _uiController;

        [Inject]
        public void InitContexts(IUIController uiController)
        {
            _uiController = uiController;
        }

        public void Back()
        {
            _uiController.RequestBackTransition();
        }

        public void Save()
        {
            // Pretend to save something...

            PopupViewPayload payload = new PopupViewPayload()
            {
                Title = "Result",
                Description = "Saved!"
            };

            _uiController.RequestScreen(ScreenNodeConstants.Popup, payload);
        }
    }
}