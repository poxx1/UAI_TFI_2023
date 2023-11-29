using Controladores;
using Model;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class UsuarioPatente : System.Web.UI.Page
    {
        UserService us = new UserService();
        PermissionsService ps = new PermissionsService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");
            if ((bool)Session["permission"] != true) HttpContext.Current.Response.Redirect("Default.aspx");
            if (!IsPostBack)
            {
                //Listar usuarios
                List<UserModel> listaUsuarios = us.GetAll();
                List<string> listaNicks = new List<string>();
                foreach (UserModel usuario in listaUsuarios)
                {
                    listaNicks.Add(usuario.Nickname);
                }
                DropDownList1.DataSource = listaNicks;
                DropDownList1.DataBind();

                //Esto lista los permisos, no anda.
                List<Patent> permisos = new List<Patent>();
                permisos = ps.GetAllPatentes();
                List<string> listaPermisos = new List<string>();
                  
                foreach (Patent component in permisos)
                {
                    listaPermisos.Add(component.Nombre);
                }
                DropDownList2.DataSource = listaPermisos;
                DropDownList2.DataBind();
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            string usuario = DropDownList1.SelectedValue.ToString();

            //Este boton es para listar los permisos en el listbox1 del usuario que elegi en el dropdown 1.
            string userName = DropDownList1.SelectedValue as string;
            var usuarioElegido = us.Get(userName);
            ListBox1.DataSource = usuarioElegido.Permissions;
            ListBox1.DataBind();
            //FALTA hacer el update de usuario_permiso
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //FALTA listar permisos del usuario
            string usuario = DropDownList1.SelectedValue.ToString();
            string permiso = DropDownList2.SelectedValue.ToString();
            //Este boton es para agregarle un permiso al usuario. El dropdown 2 tiene los permisos

            //Hacer el foreach de siempre con el where > user
            UserModel user = new UserModel();
            List<UserModel> users = new List<UserModel>();
            users = us.GetAll();

            user = users.Where(x => x.Nickname == usuario).ToList().FirstOrDefault();

            //Hacer el foreach de siempre con el where > permisos
            Patent p = new Patent();
            List<Patent> patents= new List<Patent>();
            patents = ps.GetAllPatentes();

            p = patents.Where(x => x.Nombre == permiso).ToList().FirstOrDefault();
            ps.FillUserComponents(user);
            user.Permissions.Add(p);
            us.SavePermissions(user);
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cargar el treeview de permisos
            string userName = DropDownList1.SelectedValue as string;
            var usuarioElegido = us.Get(userName);
            ListBox1.DataSource = usuarioElegido.Permissions;
            ListBox1.DataBind();

            //List<Patent> permisos = new List<Patent>();
            //permisos = ps.GetAllPatentes();
            //List<string> listaPermisos = new List<string>();

            //foreach (Patent component in permisos)
            //{
            //    listaPermisos.Add(component.Nombre);
            //}
            //DropDownList2.DataSource = listaPermisos;
            //DropDownList2.DataBind();

        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}