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
    public partial class AddSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Create solicitud
            InterpretacionModel model = new InterpretacionModel();
            model.Description = TextBox2.Text;
            model.Name = TextBox1.Text;
            model.Fecha = DateTime.Now.ToString();
            model.ID_user = SessionModel.getID();
            model.isApproved = false;

            SolicitudService solicitud = new SolicitudService();
            if (solicitud.createSolicitud(model))
            {
                //Create alert
            }
            else
            { 
                //Create alert
            }
        }
    }
}