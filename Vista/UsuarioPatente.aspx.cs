using Controladores;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class UsuarioPatente : System.Web.UI.Page
    {
        UserService us = new UserService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");
            if ((bool)Session["permission"] != true) HttpContext.Current.Response.Redirect("Default.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Listar usuarios
            List<UserModel> listaUsuarios = us.GetAll();
            List<string> listaNicks = new List<string>();
            foreach (UserModel usuario in listaUsuarios) {
                listaNicks.Add(usuario.Nickname);
            }
            DropDownList1.DataSource = listaNicks;
            DropDownList1.DataBind();

        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cargar el treeview de permisos
            string userName = DropDownList1.SelectedValue as string;
            var usuarioElegido = us.Get(userName);
            ListBox1.DataSource = usuarioElegido.Permissions;
            ListBox1.DataBind();
        }
    }
}