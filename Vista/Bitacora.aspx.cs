using Controladores;
using Model;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FastMember;

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

        private void BindGrid(List<LogModel> lista)
        {
            // New table.
            IEnumerable<LogModel> data = lista;
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(data))
            {
                table.Load(reader);
            }

            GridView1.DataSource = table;
            GridView1.DataBind();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string ordernarPor = ListBox1.SelectedItem.Text;
                bool ordenarDescendente = CheckBox1.Checked;

                var lista = bitacoraList();

                switch (ordernarPor)
                {
                    case "Id":
                        if (ordenarDescendente)
                        {
                            BindGrid((List<LogModel>)lista.OrderByDescending(x => x.Id).ToList());
                        }
                        else { BindGrid((List<LogModel>)lista.OrderBy(x => x.Id).ToList()); };
                        break;

                    case "Fecha":
                        if (ordenarDescendente)
                        {
                            BindGrid((List<LogModel>)lista.OrderByDescending(x => x.Fecha).ToList());
                        }
                        else
                        {
                            BindGrid((List<LogModel>)lista.OrderBy(x => x.Fecha).ToList());
                        };
                        break;

                    case "Usuario":
                        if (ordenarDescendente)
                        {
                            BindGrid((List<LogModel>)lista.OrderByDescending(x => x.Usuario).ToList());
                        }
                        else
                        {
                            BindGrid((List<LogModel>)lista.OrderBy(x => x.Usuario).ToList());
                        };
                        break;

                    default: break;
                }
            }
            catch (Exception ex) { };
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //GridView1.DataSource = bitacoraList();
            GridView1.DataBind();
        }
    }
}