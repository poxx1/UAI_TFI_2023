using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

namespace Vista
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
                    "Bitacora"
                };
                AdminList.DataSource = null;
                AdminList.DataSource = adminlist;
                AdminList.DataBind();
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
                    default: HttpContext.Current.Response.Redirect("default.aspx"); break;
                }
            }
        }
    }
}