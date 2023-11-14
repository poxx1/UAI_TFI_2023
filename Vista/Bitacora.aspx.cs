using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Data;
using FastMember;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Controladores;
using Model;

namespace Vista
{
    public partial class Bitacora : System.Web.UI.Page
    {
        string usuario = "admin";
        string criticidad = "Baja";
        string orden = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((bool)Session["logged_in"] != true) HttpContext.Current.Response.Redirect("Start.aspx");
                if ((bool)Session["permission"] != true) HttpContext.Current.Response.Redirect("Default.aspx");

                GridView1.DataSource = null;
                BindGrid(bitacoraList().OrderByDescending(x => x.Id).ToList());

                //2 usuario //3criticidad
                UserService us = new UserService();
                List<string> liststringsusuarios = new List<string>();
                foreach (UserModel user in us.GetAll())
                {
                    liststringsusuarios.Add(user.Nickname);
                }
                DropDownList1.DataSource = liststringsusuarios;
                DropDownList1.DataBind();

                List<string> liststringslogs = new List<string>();
                liststringslogs.Add("Baja");
                liststringslogs.Add("Media");
                liststringslogs.Add("Alta");

                DropDownList2.DataSource = liststringslogs;
                DropDownList2.DataBind();

                DropDownList3.Items.Add("Id");
                DropDownList3.Items.Add("Fecha");
                DropDownList3.Items.Add("Usuario");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    usuario = DropDownList1.SelectedValue.ToString();
                    List<LogModel> lista = bitacoraList().Where(x => x.Usuario == usuario).ToList();
                    BindGrid(lista.Where(x => x.Priority == criticidad).ToList());

                }
                catch (Exception ex) { }
            }
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
                bool ordenarDescendente = CheckBox1.Checked;

                var lista = bitacoraList();

                switch (orden)
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
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Usuarios
            //if (IsPostBack)
                if (DropDownList1.SelectedValue.ToString() != null)
                    usuario = DropDownList1.SelectedValue.ToString();
    }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Criticidad
            if (DropDownList2.SelectedValue.ToString() != null)
                criticidad = DropDownList2.SelectedValue.ToString();
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ordenar por: Id, Nombre, Criticidad, Fecha.
            if (DropDownList3.SelectedValue.ToString() != null)
                orden = DropDownList3.SelectedValue.ToString();
        }
    }
}