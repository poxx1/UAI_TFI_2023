using Servicios;
using System;

namespace Vista
{
    public partial class MenuCarrito : System.Web.UI.Page
    {
        CursosService cs = new CursosService();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Listar cursos
            ListBox1.DataSource = cs.listCursos();
            ListBox1.DataBind();
        }
    }
}