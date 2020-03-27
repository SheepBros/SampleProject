using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleDI;

namespace SB.UI.Sample
{
    public class LobbyViewController : IViewController
    {
        private IUIController _uiController;

        [Inject]
        public void InitContexts(IUIController uiController)
        {
            _uiController = uiController;
        }

        public void LoadMainScene()
        {
            AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(SceneConstants.Main);
            sceneLoad.completed += (async) =>
            {
                _uiController.ChangeSceneGraph(SceneConstants.Main).Then(() =>
                {
                    _uiController.ClearPrecachedViews(SceneConstants.Lobby);
                });
            };
        }
    }
}