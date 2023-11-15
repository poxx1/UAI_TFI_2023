using Controladores;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class ListSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SolicitudService solicitud = new SolicitudService();

            List<InterpretacionModel> list = new List<InterpretacionModel>(); 
            list = solicitud.listSolicitud();

            DropDownList1.DataSource = list;
            DropDownList1.DataBind();
        }
    }
}