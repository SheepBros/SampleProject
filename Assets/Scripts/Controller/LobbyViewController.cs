using UnityEngine;
using UnityEngine.SceneManagement;
using SimpleDI;

namespace SB.UI.Sample
{
    public class LobbyViewController : IViewController
    {
        private IUIDataController _uiDataController;

        private IUIController _uiController;

        [Inject]
        public void InitContexts(IUIDataController uiDataController, IUIController uiController)
        {
            _uiDataController = uiDataController;
            _uiController = uiController;
        }

        public void LoadMainScene()
        {
            AsyncOperation sceneLoad = SceneManager.LoadSceneAsync(SceneConstants.Main);
            sceneLoad.completed += (async) =>
            {
                _uiController.ChangeSceneGraph(SceneConstants.Main).Then(() =>
                {
                    _uiDataController.ClearPrecachedViews(SceneConstants.Lobby);
                });
            };
        }
    }
}