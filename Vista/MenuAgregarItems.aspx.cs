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
    public partial class MenuAgregarItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CursosModel curso = new CursosModel();
            curso.Name = TextBox1.Text;
            curso.Description = TextBox2.Text;
            curso.Price = float.Parse(TextBox3.Text);

            CursosService cs = new CursosService();
            cs.addCurso(curso);
        }
    }
}