using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Backup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //No se puede, csm
            //string ruta = Path.GetFullPath(FileUpload1.PostedFile);
            //Label2.Text = ruta;

            var file = FileUpload1;

        }
    }
}