using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

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

    }
}
