using Controladores;
using Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class ListUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");
            if ((bool)Session["permission"] != true) HttpContext.Current.Response.Redirect("Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataSource = UserList();
            GridView1.DataBind();
        }

        private List<UserModel> UserList() { 
            UserService userService = new UserService();
            return userService.GetAll();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //GridView1.Columns[1].Visible = false;
        }
    }
}