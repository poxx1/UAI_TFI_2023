using Model;
using Modelos;

namespace Servicios
{
    public class SessionService
    {
        public static readonly int REINTENTOS_MAXIMOS_LOGIN = 3;
        public void Login(UserModel user)
        {
            SessionModel session = SessionModel.GetInstance;
            session.Login(user);
        }
        public void Logout()
        {
            SessionModel.GetInstance.Logout();
        }
    }
}
