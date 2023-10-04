using Controladores;
using Model;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");
            if ((bool)Session["permission"] != true) HttpContext.Current.Response.Redirect("Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            user.Dni = TextBox1.Text;
            user.Name = TextBox2.Text;
            user.LastName = TextBox3.Text;
            user.Nickname = TextBox4.Text;   
            user.Password = TextBox5.Text;
            user.Mail = TextBox6.Text;
            user.Phone = TextBox7.Text;
            user.Adress = TextBox8.Text;

            if (AddUser(user))
                GlobalMessage.MessageBox(this, $"Se agrego a {user.Nickname} al sistema");
            else
                GlobalMessage.MessageBox(this, $"No se pudo agregar a {user.Nickname} al sistema");
        }

        public bool AddUser(UserModel user) {
            UserService us = new UserService();
            us.CreateUser(user);
            return true;
        }
    }
}