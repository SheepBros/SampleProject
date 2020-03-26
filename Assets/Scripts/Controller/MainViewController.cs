using SimpleDI;

namespace SB.UI.Sample
{
    public class MainViewController : IViewController
    {
        private IUIController _uiController;

        [Inject]
        public void InitContexts(IUIController uiController)
        {
            _uiController = uiController;
        }

        public void RequestScreen(string name)
        {
            _uiController.RequestScreen(name);
        }
    }
}