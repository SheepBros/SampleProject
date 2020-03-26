using SimpleDI;

namespace SB.UI.Sample
{
    public class PopupViewController : IViewController
    {
        private IUIController _uiController;

        [Inject]
        public void InitContexts(IUIController uiController)
        {
            _uiController = uiController;
        }

        public void Close()
        {
            _uiController.RequestPreviousScreen();
        }
    }
}