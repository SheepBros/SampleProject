using UnityEngine;
using SimpleDI;

namespace SB.UI.Sample
{
    public class PersistantInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject _persistentUIRoot;

        public override void InstallBindings()
        {
            GameObject persistentUIRoot = Instantiate(_persistentUIRoot);
            SampleViewHandler viewHandler = persistentUIRoot.GetComponent<SampleViewHandler>();
            UIDataController uiDataController = new UIDataController(viewHandler);
            UIController uiController = new UIController(uiDataController, viewHandler);

            _container.BindAllInterfacesFrom<SampleViewHandler>(viewHandler);
            _container.BindFrom<IUIDataController>(uiDataController);
            _container.BindFrom<IUIController>(uiController);
            _container.BindAllInterfaces<UserDataManager>();
        }
    }
}