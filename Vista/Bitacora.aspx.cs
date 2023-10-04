using Controladores;
using Model;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Bitacora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");
            if ((bool)Session["permission"] != true) HttpContext.Current.Response.Redirect("Default.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataSource = bitacoraList();
            GridView1.DataBind();
        }

        private List<LogModel> bitacoraList()
        {
            BitacoraService bitacora = new BitacoraService();
            return bitacora.ListLogs();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string ordernarPor = ListBox1.SelectedItem.Text;
            bool ordenarDescendente = CheckBox1.Checked;

            var lista = bitacoraList();

            switch (ordernarPor) { 
                case "Id":  if (ordenarDescendente) GridView1.DataSource = lista.OrderByDescending(x => x.Id);
                    else GridView1.DataSource = lista.OrderBy(x => x.Id); ;
                    break;

                case "Fecha": if (ordenarDescendente) GridView1.DataSource = lista.OrderByDescending(x => x.Fecha);
                    else GridView1.DataSource = lista.OrderBy(x => x.Fecha); ;
                    break;

                case "Usuario": if (ordenarDescendente) GridView1.DataSource = lista.OrderByDescending(x => x.Usuario);
                    else GridView1.DataSource = lista.OrderBy(x => x.Usuario); ;
                    break;

                default: break;
            }

            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = bitacoraList();
            GridView1.DataBind();
        }
    }
}