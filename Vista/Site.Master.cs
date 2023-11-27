using Model;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region Cargar DropDowns
                List<string> userlist = new List<string>()
                {   "Menu de usuarios",
                    "Agregar usuario",
                    "Eliminar usuario",
                    "Modificar usuario",
                    "Listar usuarios"
                };
                UserList.DataSource = null;
                UserList.DataSource = userlist;
                UserList.DataBind();

                List<string> permissionlist = new List<string>()
                {
                    "Menu de permisos",
                    "Modificar Usuario/Patente",
                    "Modificar Familia/Patente",
                };
                PermissionList.DataSource = null;
                PermissionList.DataSource = permissionlist;
                PermissionList.DataBind();

                List<string> adminlist = new List<string>()
                    {
                        "Menu de servicios",
                        "Bitacora",
                        "Backup",
                        "Salidas XML"
                    };
                AdminList.DataSource = null;
                AdminList.DataSource = adminlist;
                AdminList.DataBind();

                List<string> solicitudeslist = new List<string>()
                    {
                        "Menu de solicitudes",
                        "Listar solicitudes",
                        "Aprobar solicitudes",
                        "Realizar solicitud"
                    };
                SolicitudesList.DataSource = null;
                SolicitudesList.DataSource = solicitudeslist;
                SolicitudesList.DataBind();

                List<string> comprasList = new List<string>()
                    {
                        "Menu de compras",
                        "Cursos disponibles",
                        "Carrito de compras",
                        "Agregar cursos",
                        "Editar cursos"
                    };
                ComprasList.DataSource = null;
                ComprasList.DataSource = comprasList;
                ComprasList.DataBind();
                #endregion

                UserModel user = new UserModel();
                PermissionsService ps = new PermissionsService();
                
                user = SessionModel.GetInstance.user;
                List<Component> permisos = user.Permissions;
                List<string> strings = new List<string>();

                string tipoUsuario = "";

                foreach(Component permiso in permisos)
                {
                    if(permiso.Nombre == "Admin" || permiso.Nombre =="Cliente" || permiso.Nombre == "Webmaster")
                        tipoUsuario = permiso.Nombre;
                    permiso.Childs.ForEach(x => strings.Add(x.Nombre));
                }

                if (!strings.Contains("Usuarios"))
                    UserList.Enabled = false;
                if (!strings.Contains("Patentes"))
                    PermissionList.Enabled = false;
                if (!strings.Contains("Bitacora"))
                    AdminList.Enabled = false;

                //Label1.Text = "Usuario: " + user.Nickname + " | Rol: " + tipoUsuario;
                Label1.Text = user.Nickname + " | " + tipoUsuario;
            }
        }
        protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                switch (UserList.SelectedItem.Text)
                {
                    case "Agregar usuario": HttpContext.Current.Response.Redirect("AddUser.aspx"); break;
                    case "Eliminar usuario": HttpContext.Current.Response.Redirect("DeleteUser.aspx"); break;
                    case "Modificar usuario": HttpContext.Current.Response.Redirect("EditUser.aspx"); break;
                    case "Listar usuarios": HttpContext.Current.Response.Redirect("ListUser.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }
        protected void PermissionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                switch (PermissionList.SelectedItem.Text)
                {
                    case "Modificar Usuario/Patente": HttpContext.Current.Response.Redirect("UsuarioPatente.aspx"); break;
                    case "Modificar Familia/Patente": HttpContext.Current.Response.Redirect("FamiliaPatente.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }
        protected void AdminList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                switch (AdminList.SelectedItem.Text)
                {
                    case "Bitacora": HttpContext.Current.Response.Redirect("Bitacora.aspx"); break;
                    case "Backup": HttpContext.Current.Response.Redirect("Backup.aspx"); break;
                    case "Salidas XML": HttpContext.Current.Response.Redirect("salidasXML.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }
        protected void SolicitudesListIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                switch (SolicitudesList.SelectedItem.Text)
                {
                    case "Listar solicitudes": HttpContext.Current.Response.Redirect("ListSolicitud.aspx"); break;
                    case "Aprobar solicitudes": HttpContext.Current.Response.Redirect("ListSolicitud.aspx"); break;
                    case "Realizar solicitud": HttpContext.Current.Response.Redirect("AddSolicitud.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }
        protected void Interpretar(object sender, EventArgs e) {
            HttpContext.Current.Response.Redirect("Interprete.aspx");
        }
        protected void ComprasListIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                switch (ComprasList.SelectedItem.Text)
                {
                    case "Cursos disponibles": HttpContext.Current.Response.Redirect("MenuItems.aspx"); break;
                    case "Carrito de compras": HttpContext.Current.Response.Redirect("MenuCarrito.aspx"); break;
                    case "Agregar cursos": HttpContext.Current.Response.Redirect("MenuAgregarItems.aspx"); break;
                    case "Editar cursos": HttpContext.Current.Response.Redirect("MenuAgregarItems.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }   
    }
}