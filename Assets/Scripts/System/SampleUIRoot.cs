using System.Collections.Generic;
using UnityEngine;
using SimpleDI;

namespace SB.UI.Sample
{
    public class SampleUIRoot : MonoBehaviour
    {
        private IUIDataController _uiDataController;

        private IUIController _uiController;

        private IUIDataIOController _uiDataIOController;

        [Inject]
        public void InitContexts(IUIDataController uiDataController, IUIController uiController,
            IUIDataIOController uiDataIOController)
        {
            _uiDataController = uiDataController;
            _uiController = uiController;
            _uiDataIOController = uiDataIOController;

            MakeSceneList();
        }

        private void Start()
        {
            _uiDataController.Load().Then(() =>
            {
                _uiController.ChangeSceneGraph(SceneConstants.Lobby);
            });
        }

        private void MakeSceneList()
        {
            UISceneList sceneList = new UISceneList();
            sceneList.SceneGraphs = new Dictionary<string, UISceneGraph>();
            CreateLobbySceneGraph(sceneList);
            CreateMainSceneGraph(sceneList);

            _uiDataIOController.Save(sceneList);
        }

        private void CreateLobbySceneGraph(UISceneList sceneList)
        {
            UISceneGraph graph = new UISceneGraph();
            sceneList.SceneGraphs.Add(SceneConstants.Lobby, graph);

            graph.SceneName = SceneConstants.Lobby;
            graph.StartScreenNodeId = ScreenNodeConstants.Lobby;

            UIScreenNode lobbyNode = new UIScreenNode();
            graph.ScreenNodes = new List<UIScreenNode>();
            graph.ScreenNodes.Add(lobbyNode);

            lobbyNode.Name = ScreenNodeConstants.Lobby;
            lobbyNode.Layer = 0;
            lobbyNode.IsStartNode = true;
            lobbyNode.TransitionNodes = new List<string>();
            lobbyNode.ElementIdsList = new List<string> { UIElementConstants.LobbyUI };

            graph.UIElements = new Dictionary<string, UIElement>();
            graph.UIElements.Add(UIElementConstants.LobbyUI, new UIElement()
            {
                Id = UIElementConstants.LobbyUI,
                Asset = new UIAsset("lobby", "LobbyScreen.prefab"),
                Precache = true
            });
        }

        private void CreateMainSceneGraph(UISceneList sceneList)
        {
            UISceneGraph graph = new UISceneGraph();
            sceneList.SceneGraphs.Add(SceneConstants.Main, graph);

            graph.SceneName = SceneConstants.Main;
            graph.StartScreenNodeId = ScreenNodeConstants.Main;

            UIScreenNode mainNode = new UIScreenNode();
            UIScreenNode settingsNode = new UIScreenNode();
            UIScreenNode userNode = new UIScreenNode();
            UIScreenNode popupNode = new UIScreenNode();
            graph.ScreenNodes = new List<UIScreenNode>();
            graph.ScreenNodes.Add(mainNode);
            graph.ScreenNodes.Add(settingsNode);
            graph.ScreenNodes.Add(userNode);
            graph.ScreenNodes.Add(popupNode);

            mainNode.Name = ScreenNodeConstants.Main;
            mainNode.Layer = 0;
            mainNode.IsStartNode = true;
            mainNode.TransitionNodes = new List<string> { ScreenNodeConstants.User, ScreenNodeConstants.Settings };
            mainNode.ElementIdsList = new List<string> { UIElementConstants.MainUI };

            settingsNode.Name = ScreenNodeConstants.Settings;
            settingsNode.Layer = 1;
            settingsNode.IsStartNode = false;
            settingsNode.BackTransitionNode = ScreenNodeConstants.Main;
            settingsNode.TransitionNodes = new List<string> { ScreenNodeConstants.Main, ScreenNodeConstants.User, ScreenNodeConstants.Popup };
            settingsNode.ElementIdsList = new List<string> { UIElementConstants.SettingsUI, UIElementConstants.UserInfoUI };

            userNode.Name = ScreenNodeConstants.User;
            userNode.Layer = 1;
            userNode.IsStartNode = false;
            userNode.BackTransitionNode = ScreenNodeConstants.Main;
            userNode.TransitionNodes = new List<string> { ScreenNodeConstants.Main, ScreenNodeConstants.Settings, ScreenNodeConstants.Popup };
            userNode.ElementIdsList = new List<string> { UIElementConstants.UserUI, UIElementConstants.UserInfoUI };

            popupNode.Name = ScreenNodeConstants.Popup;
            popupNode.Layer = 3;
            popupNode.IsStartNode = false;
            popupNode.TransitionNodes = new List<string> { };
            popupNode.ElementIdsList = new List<string> { UIElementConstants.PopupUI };

            graph.UIElements = new Dictionary<string, UIElement>();
            graph.UIElements.Add(UIElementConstants.PopupUI, new UIElement()
            {
                Id = UIElementConstants.PopupUI,
                Asset = new UIAsset("common", "Popup.prefab"),
                Precache = false
            });
            graph.UIElements.Add(UIElementConstants.MainUI, new UIElement()
            {
                Id = UIElementConstants.MainUI,
                Asset = new UIAsset("main", "MainScreen.prefab"),
                Precache = true
            });
            graph.UIElements.Add(UIElementConstants.UserInfoUI, new UIElement()
            {
                Id = UIElementConstants.UserInfoUI,
                Asset = new UIAsset("main", "UserInfo.prefab"),
                Precache = true
            });
            graph.UIElements.Add(UIElementConstants.SettingsUI, new UIElement()
            {
                Id = UIElementConstants.SettingsUI,
                Asset = new UIAsset("main", "SettingsScreen.prefab"),
                Precache = true
            });
            graph.UIElements.Add(UIElementConstants.UserUI, new UIElement()
            {
                Id = UIElementConstants.UserUI,
                Asset = new UIAsset("main", "UserScreen.prefab"),
                Precache = true
            });
        }
    }
}