using Controladores;
using Model;
using Servicios;
using System;
using System.Web;

namespace Vista
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        UserService us = new UserService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");
            if ((bool)Session["permission"] != true) HttpContext.Current.Response.Redirect("Start.aspx");

            foreach (UserModel user in us.GetAll())
            {
                ListBox1.Items.Add(user.Nickname);
            }
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                string userName = ListBox1.Text;
                if(us.delete(userName))
                    GlobalMessage.MessageBox(this, $"Se elimino a {userName} del sistema");
                else
                    GlobalMessage.MessageBox(this, $"No se pudo eliminar a {userName} del sistema");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}