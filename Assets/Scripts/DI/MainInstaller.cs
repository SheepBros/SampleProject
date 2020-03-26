using SimpleDI;

namespace SB.UI.Sample
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            _container.BindAs<MainViewController>(bindToParents: true);
            _container.BindAs<UserInfoViewController>(bindToParents: true);
            _container.BindAs<SettingsViewController>(bindToParents: true);
            _container.BindAs<UserViewController>(bindToParents: true);
            _container.BindAs<PopupViewController>(bindToParents: true);
        }
    }
}