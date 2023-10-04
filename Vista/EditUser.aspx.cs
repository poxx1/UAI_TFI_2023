using Controladores;
using Model;
using Servicios;
using System;
using System.Web;

namespace Vista
{
    public partial class EditUser : System.Web.UI.Page
    {
        UserService us = new UserService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");

            foreach (UserModel user in us.GetAll())
            {
                ListBox1.Items.Add(user.Nickname);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = ListBox1.Text;

            UserModel usuario = us.Get(userName);
            usuario.Dni = TextBox1.Text;
            usuario.Name = TextBox2.Text;
            usuario.LastName = TextBox3.Text;
            usuario.Nickname = TextBox4.Text;
            usuario.Mail = TextBox6.Text;
            usuario.Phone = TextBox7.Text;
            usuario.Adress = TextBox8.Text;

            if (TextBox5.Text.Length > 0) { usuario.Password = Security.HashSha256(TextBox5.Text); }
            //Aca me falta encriptar al enviar el cambio
            if (us.UpdateUser(usuario))
                GlobalMessage.MessageBox(this, $"Se edito a {userName}");
            else
                GlobalMessage.MessageBox(this, $"No se pudo editar a {userName}");
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userName = ListBox1.Text;
            UserModel usuario = us.Get(userName);
            TextBox1.Text = usuario.Dni;
            TextBox2.Text = usuario.Name;
            TextBox3.Text = usuario.LastName;
            TextBox4.Text = usuario.Nickname;
            TextBox5.Text = "";
            TextBox6.Text = usuario.Mail;
            TextBox7.Text = usuario.Phone;
            TextBox8.Text = usuario.Adress;
        }
    }
}