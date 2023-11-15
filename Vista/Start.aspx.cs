using System;
using System.Web;
using System.Web.UI.WebControls;
using Model;
using Servicios;
using LogService = Controladores.Login;

namespace Vista
{
    public partial class Start : System.Web.UI.Page
    {
        UserModel user = new UserModel();
        LogService login = new LogService();
        BitacoraService bitacoraService = new BitacoraService();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["logged_in"] = false;
            //GlobalMessage.MessageBox(this, $"{Session.SessionID}");
            //Label1.Text = Session.SessionID;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            user.Nickname = TextBox1.Text;
            user.Password = CustomPassword.getText();

            if (logIn(user))
            {
                Session["logged_in"] = true;
                HttpContext.Current.Response.Redirect("Default.aspx");
                GlobalMessage.MessageBox(this, $"Login de {user.Nickname} realizado con exito!");
            }
            else
                if (login.isCorruputed == true) {
                foreach (var item in login.corrputionList)
                {
                    GlobalMessage.MessageBox(this, $"DB Corrputa. {item}");
                }

            }
            else
            {
                GlobalMessage.MessageBox(this, $"Login de {user.Nickname} ha fallado!");
            }
        }

        private bool logIn(UserModel user)
        {
            if (login.LogIn(user))
            {           
                bitacoraService.LogData("Login", $"El usuario {user.Name} se logueo.", "Baja");

                return true;
            }
            return false;
        }
    }
}