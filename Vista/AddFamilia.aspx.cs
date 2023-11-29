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
    public partial class AddFamilia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                PermissionsService ps = new PermissionsService();
                Family f = new Family();
                f.Nombre = TextBox1.Text;
                ps.SaveComponent(f, true);
                GlobalMessage.MessageBox(this, "La familia se guardo correctamente");
            }
            catch { GlobalMessage.MessageBox(this, "Error guardando la familia"); }
        }
    }
}