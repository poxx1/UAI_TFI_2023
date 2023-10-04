using System;
using System.Web;
using System.Web.UI;
using Model;
using Modelos;
using Servicios;

using LogService = Controladores.Login;

namespace Vista
{
    public partial class About : Page
    {
        UserModel user = new UserModel();
        LogService login = new LogService();
        BitacoraService bitacoraService = new BitacoraService();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Button2.Visible = false;
            if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");
            TextBox1.Text = SessionModel.GetInstance.user.Nickname;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            logOut();
            Session["logged_in"] = false;
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        private bool logOut() {
            GlobalMessage.MessageBox(this, $"Logout de {SessionModel.GetInstance.user.Nickname} realizado con exito!");

            bitacoraService.LogData("Logout", $"El usuario {user.Nickname} se deslogueo.", "Baja");

            login.LogOut();

            Button2.Visible = false;

            return true;
        }
    }
}