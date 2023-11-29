using Model;
using Modelos;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

                BitacoraService bitacoraService = new BitacoraService();
                UserModel user = new UserModel();
                bitacoraService.LogData("Login", $"El usuario {user.Name} agrego un curso.", "Media");
                GlobalMessage.MessageBox(this, $"Se agrego el curso");
            }
            catch(Exception ex) 
            { 
                GlobalMessage.MessageBox(this,ex.Message+"SayIt - Error"); 
            }
        }
        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            //No hay que hacer nada aca.
        }
    }
}