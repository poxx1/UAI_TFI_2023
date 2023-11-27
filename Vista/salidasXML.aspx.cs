using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Controladores;
using Modelos;

namespace Vista
{
    public partial class salidasXML : System.Web.UI.Page
    {
        salidaXML salida = new salidaXML();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Totales
            GridView1.DataSource = salida.solicitudesTotales();
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Pendientes
            GridView1.DataSource = salida.solicitudesAprobadas();
            GridView1.DataBind();
            exportarXML(salida.solicitudesAprobadas());
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            //Aprobadas
            GridView1.DataSource = salida.solicitudesPendientes();
            GridView1.DataBind();
            exportarXML(salida.solicitudesPendientes());
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //Totales
            GridView1.DataSource = salida.solicitudesTotales();
            GridView1.DataBind();
            exportarXML(salida.solicitudesTotales());
        }

        private bool exportarXML(List<InterpretacionModel> lista)
        {
            var serializer = new XmlSerializer(lista.GetType());

            string result;
            using (var writer = new System.IO.StringWriter())
            {
                serializer.Serialize(writer, lista);
                result = writer.ToString();
            }

            string check = (DateTime.Now.ToString().Replace(' ','-').Replace('/','-').Replace(':','-'));

            try
            {
                using (var writer = new System.IO.StreamWriter(@"C:\XML\" + check + ".xml"))
                {
                    writer.Write(result);
                    writer.Close();
                }   
            }
            catch (Exception ex) { }

            return true;
        }
    }
}