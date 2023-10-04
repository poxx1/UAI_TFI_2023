using Model;
using Servicios;

namespace Controladores
{
    public class Login
    {
        SessionService session = new SessionService();
        UserService userService = new UserService();
        public bool LogIn(UserModel user)
        {
            //Security.Encript(user.Nickname); wtf prque lo encriptaba?
            user.Password = Security.HashSha256(user.Password);

            UserModel dbUser = userService.Get(user.Nickname);
            if(dbUser != null)
            {
                if (dbUser.Password == user.Password && dbUser.Tries < 3 && dbUser.Blocked == false)
                {
                    userService.ResetTries(dbUser);
                    session.Login(dbUser);
                    return true;
                }
                else { 
                    userService.AddTries(dbUser);

                    if(dbUser.Tries>=3)
                        userService.BlockUser(dbUser);    
                }
            }
            return false;
        }
        public bool LogOut() {
            session.Logout();
            return true;
        }
    }
}
