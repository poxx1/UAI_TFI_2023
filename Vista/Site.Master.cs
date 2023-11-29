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
            if (!Page.IsPostBack && (int)Session["language"] == 1)
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
                    "Agregar familia"
                };
                PermissionList.DataSource = null;
                PermissionList.DataSource = permissionlist;
                PermissionList.DataBind();

                List<string> adminlist = new List<string>()
                    {
                        "Menu de servicios",
                        "Bitacora",
                        "Backup",
                        "Salidas XML",
                        "Informes WS"
                    };
                AdminList.DataSource = null;
                AdminList.DataSource = adminlist;
                AdminList.DataBind();

                List<string> solicitudeslist = new List<string>()
                    {
                        "Menu de solicitudes",
                        "Interprete",
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

                if ((bool)Session["recalcular"] != true)
                {
                    user = SessionModel.GetInstance.user;
                    List<Component> permisos = user.Permissions;
                    List<string> strings = new List<string>();

                    string tipoUsuario = "";

                    foreach (Component permiso in permisos)
                    {
                        if (permiso.Nombre == "Admin" || permiso.Nombre == "Cliente" || permiso.Nombre == "Webmaster")
                            tipoUsuario = permiso.Nombre;
                        permiso.Childs.ForEach(x => strings.Add(x.Nombre));
                    }

                    if (!strings.Contains("Usuarios"))
                        UserList.Enabled = false;
                    if (!strings.Contains("Patentes"))
                        PermissionList.Enabled = false;
                    if (!strings.Contains("Bitacora"))
                        AdminList.Enabled = false;

                    Label1.Text = "2023 - Lastra Julian - Proyecto - Trabajo Final de Ing. | Nombre de usuario: " + user.Nickname + " | Tipo de usuario: " + tipoUsuario;
                }
            }

            #region Ingles
            if(!Page.IsPostBack && (int)Session["language"] == 2)
            {
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

                if ((bool)Session["recalcular"] != true)
                {
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
        }
        protected void UserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack && (int)Session["language"]==1)
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
            else
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
            if (Page.IsPostBack && (int)Session["language"] == 1)
            {
                switch (PermissionList.SelectedItem.Text)
                {
                    case "Modificar Usuario/Patente": HttpContext.Current.Response.Redirect("UsuarioPatente.aspx"); break;
                    case "Modificar Familia/Patente": HttpContext.Current.Response.Redirect("FamiliaPatente.aspx"); break;
                    case "Agregar familia": HttpContext.Current.Response.Redirect("AddFamilia.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
            else
            {
                switch (PermissionList.SelectedItem.Text)
                {
                    case "Update Usuario/Patente": HttpContext.Current.Response.Redirect("UsuarioPatente.aspx"); break;
                    case "Update Familia/Patente": HttpContext.Current.Response.Redirect("FamiliaPatente.aspx"); break;
                    case "Agregar familia": HttpContext.Current.Response.Redirect("AddFamilia.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }
        protected void AdminList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack && (int)Session["language"] == 1)
            {
                switch (AdminList.SelectedItem.Text)
                {
                    case "Bitacora": HttpContext.Current.Response.Redirect("Bitacora.aspx"); break;
                    case "Backup": HttpContext.Current.Response.Redirect("Backup.aspx"); break;
                    case "Salidas XML": HttpContext.Current.Response.Redirect("salidasXML.aspx"); break;
                    case "Informes WS":HttpContext.Current.Response.Redirect("llamarWebService.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
            else
            {
                switch (AdminList.SelectedItem.Text)
                {
                    case "Bitacora": HttpContext.Current.Response.Redirect("Bitacora.aspx"); break;
                    case "Backup": HttpContext.Current.Response.Redirect("Backup.aspx"); break;
                    case "XML": HttpContext.Current.Response.Redirect("salidasXML.aspx"); break;
                    case "WebServices": HttpContext.Current.Response.Redirect("llamarWebService.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }
        protected void SolicitudesListIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack && (int)Session["language"] == 1)
            {
                switch (SolicitudesList.SelectedItem.Text)
                {
                    case "Interprete": HttpContext.Current.Response.Redirect("Interprete.aspx");break;
                    case "Listar solicitudes": HttpContext.Current.Response.Redirect("ListSolicitud.aspx"); break;
                    case "Aprobar solicitudes": HttpContext.Current.Response.Redirect("ListSolicitud.aspx"); break;
                    case "Realizar solicitud": HttpContext.Current.Response.Redirect("AddSolicitud.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
            else
            {
                switch (SolicitudesList.SelectedItem.Text)
                {
                    case "Interpreter": HttpContext.Current.Response.Redirect("Interprete.aspx"); break;
                    case "Request List": HttpContext.Current.Response.Redirect("ListSolicitud.aspx"); break;
                    case "Request Approval": HttpContext.Current.Response.Redirect("ListSolicitud.aspx"); break;
                    case "New Request": HttpContext.Current.Response.Redirect("AddSolicitud.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }
        protected void ComprasListIndexChanged(object sender, EventArgs e)
        {
            if (Page.IsPostBack && (int)Session["language"] == 1)
            {
                switch (ComprasList.SelectedItem.Text)
                {
                    case "Cursos disponibles": HttpContext.Current.Response.Redirect("MenuItems.aspx"); break;
                    case "Carrito de compras": HttpContext.Current.Response.Redirect("MenuCarrito.aspx"); break;
                    case "Agregar cursos": HttpContext.Current.Response.Redirect("MenuAgregarItems.aspx"); break;
                    case "Editar cursos": HttpContext.Current.Response.Redirect("EditarCursos.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
            else
            {
                switch (ComprasList.SelectedItem.Text)
                {
                    case "Courses": HttpContext.Current.Response.Redirect("MenuItems.aspx"); break;
                    case "Shopping bag": HttpContext.Current.Response.Redirect("MenuCarrito.aspx"); break;
                    case "Add course": HttpContext.Current.Response.Redirect("MenuAgregarItems.aspx"); break;
                    case "Edit course": HttpContext.Current.Response.Redirect("EditarCursos.aspx"); break;
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }   
        protected void Idioma(object sender, EventArgs e)
        {
            if ((int)Session["language"] == 1)
            { Session["language"] = 2;
                // cambio a ingles 
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

                //GlobalMessage.MessageBox(this, "Se cambio el idioma de la pagina");
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
                
            }
            else if ((int)Session["language"] == 2)
            { Session["language"] = 1;

                //Cambio a espaniol

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
                    "Agregar familia"
                };
                PermissionList.DataSource = null;
                PermissionList.DataSource = permissionlist;
                PermissionList.DataBind();

                List<string> adminlist = new List<string>()
                    {
                        "Menu de servicios",
                        "Bitacora",
                        "Backup",
                        "Salidas XML",
                        "Informes WS"
                    };
                AdminList.DataSource = null;
                AdminList.DataSource = adminlist;
                AdminList.DataBind();

                List<string> solicitudeslist = new List<string>()
                    {
                        "Menu de solicitudes",
                        "Interprete",
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
                Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
        }
    }
}