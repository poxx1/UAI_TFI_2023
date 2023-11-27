using Model;

namespace Modelos
{
    public class SessionModel
    {
        static SessionModel _session;
        public UserModel user;
        public bool IsLoggedIn()
        {
            return user != null;
        }
        public void Logout()
        {
            _session.user = null;
        }
        public void Login(UserModel user)
        {
            _session.user = user;
        }
        public static SessionModel GetInstance
        {
            get
            {
                if (_session == null) _session = new SessionModel();
                return _session;
            }
        }
        public static int getID()
        {
            return _session.user.Id;
        }

        public static UserModel GetUser() { return _session.user; }
    }
}
