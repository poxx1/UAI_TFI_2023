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
    public partial class Site2Master : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region Cargar DropDowns
                List<string> userlist = new List<string>()
                {   "Users",
                    "Add user",
                    "Delete user",
                    "Update user",
                    "List user"
                };
                UserList.DataSource = null;
                UserList.DataSource = userlist;
                UserList.DataBind();

                List<string> permissionlist = new List<string>()
                {
                    "Permissions",
                    "Update Usuario/Patente",
                    "Update Familia/Patente",
                };
                PermissionList.DataSource = null;
                PermissionList.DataSource = permissionlist;
                PermissionList.DataBind();

                List<string> adminlist = new List<string>()
                    {
                        "Services",
                        "Bitacora",
                        "Backup",
                        "XML",
                        "WebServices"
                    };
                AdminList.DataSource = null;
                AdminList.DataSource = adminlist;
                AdminList.DataBind();

                List<string> solicitudeslist = new List<string>()
                    {
                        "Requests",
                        "Interpreter",
                        "Request List",
                        "Request Approval",
                        "New Request"
                    };
                SolicitudesList.DataSource = null;
                SolicitudesList.DataSource = solicitudeslist;
                SolicitudesList.DataBind();

                List<string> comprasList = new List<string>()
                    {
                        "Purchase",
                        "Courses",
                        "Shopping bag",
                        "Add course",
                        "Edit course"
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

                Label1.Text = "2023 - Lastra Julian - Project - Trabajo Final de Ing. | Username: " + user.Nickname + " | User type: " + tipoUsuario;
            }
        }
        protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                switch (UserList.SelectedItem.Text)
                {
                    case "Add user": HttpContext.Current.Response.Redirect("AddUser.aspx"); break;
                    case "Delete user": HttpContext.Current.Response.Redirect("DeleteUser.aspx"); break;
                    case "Update user": HttpContext.Current.Response.Redirect("EditUser.aspx"); break;
                    case "List user": HttpContext.Current.Response.Redirect("ListUser.aspx"); break;
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
                    case "Update Usuario/Patente": HttpContext.Current.Response.Redirect("UsuarioPatente.aspx"); break;
                    case "Update Familia/Patente": HttpContext.Current.Response.Redirect("FamiliaPatente.aspx"); break;
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
                    case "XML": HttpContext.Current.Response.Redirect("salidasXML.aspx"); break;
                    case "WebServices":HttpContext.Current.Response.Redirect("llamarWebService.aspx"); break;
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
                    case "Interpreter": HttpContext.Current.Response.Redirect("Interprete.aspx");break;
                    case "Request List": HttpContext.Current.Response.Redirect("ListSolicitud.aspx"); break;
                    case "Request Approval": HttpContext.Current.Response.Redirect("ListSolicitud.aspx"); break;
                    case "New Request": HttpContext.Current.Response.Redirect("AddSolicitud.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }
        protected void ComprasListIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                switch (ComprasList.SelectedItem.Text)
                {
                    case "Courses": HttpContext.Current.Response.Redirect("MenuItems.aspx"); break;
                    case "Shopping bag": HttpContext.Current.Response.Redirect("MenuCarrito.aspx"); break;
                    case "Add course": HttpContext.Current.Response.Redirect("MenuAgregarItems.aspx"); break;
                    case "Edit course": HttpContext.Current.Response.Redirect("MenuAgregarItems.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }   
    }
}