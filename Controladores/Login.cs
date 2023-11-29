using Business;
using Model;
using Servicios;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace Controladores
{
    public class Login
    {
        SessionService session = new SessionService();
        UserService userService = new UserService();
        IntegrityService integrityService = new IntegrityService();

        public List<string> corrputionList = new List<string>();
        public bool isCorruputed = false;
        public bool LogIn(UserModel user,Page page )
        {
            user.Password = Security.HashSha256(user.Password);

            UserModel dbUser = userService.Get(user.Nickname);
            if(dbUser != null)
            {
                if (dbUser.Password == user.Password && dbUser.Tries < 3 && dbUser.Blocked == false && integrityService.check().Count == 0)
                {
                    userService.ResetTries(dbUser);
                    session.Login(dbUser);
                    page.Session["recalcular"] = false;
                    return true;
                }
                else { 

                    if (integrityService.check().Count != 0)
                    {
                        //Show message
                        isCorruputed =true;
                        corrputionList = integrityService.check();
                        page.Session["recalcular"] = true;
                        HttpContext.Current.Response.Redirect("Corrupcion.aspx");
                        //GlobalMessage.MessageBox(this, $"Login de {user.Nickname} realizado con exito!");
                    }

                    userService.AddTries(dbUser);

                    if(dbUser.Tries>=3)
                        userService.BlockUser(dbUser);    
                }
            }
            page.Session["recalcular"] = false;
            return false;
        }
        public bool LogOut() {
            session.Logout();
            return true;
        }
    }
}
