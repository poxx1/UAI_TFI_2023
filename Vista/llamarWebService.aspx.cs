using Controladores;
using System;

namespace Vista
{
    public partial class llamarWebService : System.Web.UI.Page
    {
        salidaXML ws = new salidaXML();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //solicitudesAprobadas
            Label2.Text = "Cantidad: " + ws.llamarWebService("solicitudesAprobadas").ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //solicitudesPendientes
            Label3.Text = "Cantidad: " + ws.llamarWebService("solicitudesPendientes").ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //solicitudesTotales
            Label4.Text = "Cantidad: " + ws.llamarWebService("solicitudesTotales").ToString();
        }
    }
}