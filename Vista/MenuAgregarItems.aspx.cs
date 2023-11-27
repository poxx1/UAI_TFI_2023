using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Vista
{
    public partial class MenuAgregarItems : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                CursosModel curso = new CursosModel();
                curso.Name = TextBox1.Text;
                curso.Description = TextBox2.Text;
                curso.Price = float.Parse(TextBox3.Text);

                CursosService cs = new CursosService();
                cs.addCurso(curso);
            }
            catch(Exception ex) { MessageBox.Show(ex.Message,"SayIt - Error",MessageBoxButtons.OK,MessageBoxIcon.Error); }
            //FALTA agregar el message en pantalla de que fue ok
            //FALTA validar que los campos no esten vacios porque la queda
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            //No hay que hacer nada aca.
        }
    }
}