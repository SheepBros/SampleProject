using SimpleDI;

namespace SB.UI.Sample
{
    public class UserInfoViewController : IViewController
    {
        private IUserDataManager _userDataManager;

        [Inject]
        public void InitContexts(IUserDataManager userDataManager)
        {
            _userDataManager = userDataManager;
        }

        public UserData GetUserData()
        {
            return _userDataManager.GetUserData();
        }
    }
}