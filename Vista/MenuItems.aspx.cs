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
    public partial class MenuItems : System.Web.UI.Page
    {
        CursosService cs = new CursosService();
        List<string> items = new List<string>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //FALTA agregar lista a la session para que se guarde.
            Session["carrito"] = items;

            //Foreach 
            List<string> listCursos = new List<string>();

            foreach (CursosModel curso in listarCursos())
            {
                listCursos.Add(curso.Name + " | Precio: " + curso.Price.ToString());
            }

            //Listar cursos
            ListBox1.DataSource = listCursos;
            ListBox1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Redirect
            HttpContext.Current.Response.Redirect("MenuCarrito.aspx");
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CursosModel cursoActual = new CursosModel();

            cursoActual = listarCursos().Where(x => x.Name == ListBox1.SelectedValue.ToString()).ToList().FirstOrDefault();

            if (cursoActual != null)
            {
                Label3.Text = cursoActual.Price.ToString();
                Label2.Text = cursoActual.Description;
            }
        }
        private List<CursosModel> listarCursos() {
            return cs.listCursos();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            items.Add(ListBox1.SelectedValue.ToString());
            Session["carrito"] = items;
        }
    }
}