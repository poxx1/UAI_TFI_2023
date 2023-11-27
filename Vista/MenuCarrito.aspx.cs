using Controladores;
using Modelos;
using Servicios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Vista
{
    public partial class MenuCarrito : System.Web.UI.Page
    {
        CursosService cs = new CursosService();
        List<CursosModel> cursos = new List<CursosModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["carrito"] != null)
                {
                    List<string> lista = (List<string>)Session["carrito"];

                    foreach (object item in lista)
                    {
                        var cursoActual = listarCursos().Where(x => x.Name.Contains(item.ToString())).ToList().First();
                        cursos.Add(cursoActual);
                    }
                    ListBox1.DataSource = lista;
                    ListBox1.DataBind();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["carrito"] != null)
                {
                    List<string> lista = (List<string>)Session["carrito"];

                    lista.Remove(ListBox1.SelectedValue);

                    foreach (object item in lista)
                    {
                        var cursoActual = listarCursos().Where(x => x.Name.Contains(item.ToString())).ToList().First();
                        cursos.Add(cursoActual);
                    }
                    ListBox1.DataSource = lista;
                    ListBox1.DataBind();
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            pdf p = new pdf();

            List<string> lista = (List<string>)Session["carrito"];
            cursos = new List<CursosModel>();

            foreach (object item in lista)
            {
                var cursoActual = listarCursos().Where(x => x.Name.Contains(item.ToString())).ToList().First();
                cursos.Add(cursoActual);
            }

            p.create(cursos);
            ListBox1.Items.Clear();
            MenuItems.items.Clear();
        }
        private List<CursosModel> listarCursos()
        {
            return cs.listCursos();
        }
    }
}