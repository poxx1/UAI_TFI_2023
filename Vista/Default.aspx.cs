using Model;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace Vista
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");

            UserModel user = new UserModel();
            PermissionsService ps = new PermissionsService();

            user = SessionModel.GetInstance.user;
            List<Component> permisos = user.Permissions;
            List<string> strings = new List<string>();

            string tipoUsuario = "";

            foreach (Component permiso in permisos)
            {
                if (permiso.Nombre == "Admin" || permiso.Nombre == "Cliente" || permiso.Nombre == "Webmaster")
                    tipoUsuario = permiso.Nombre;
                if (tipoUsuario == "Admin" || tipoUsuario == "Webmaster") { Session["permission"] = true; }
                else {Session["permission"] = false; }
            }
        }
    }
}