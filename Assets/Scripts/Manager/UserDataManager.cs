using SimpleDI;

namespace SB.UI.Sample
{
    public class UserDataManager : IUserDataManager, IInitializable
    {
        private UserData _userData;

        public void Initialize()
        {
            _userData = new UserData()
            {
                Name = "TestUser",
                Exp = 50,
                Currency = 100
            };
        }

        public UserData GetUserData()
        {
            return _userData;
        }
    }
}