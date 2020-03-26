using SimpleDI;

namespace SB.UI.Sample
{
    public class LobbyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            _container.BindAs<LobbyViewController>(bindToParents: true);
        }
    }
}