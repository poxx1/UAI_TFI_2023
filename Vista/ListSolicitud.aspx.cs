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
        SolicitudService solicitud = new SolicitudService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<InterpretacionModel> list = new List<InterpretacionModel>();
                list = solicitud.listSolicitud();
                List<string> lista = new List<string>();

                foreach (var item in list)
                {
                    lista.Add(item.Name.ToString());
                }

                DropDownList1.DataSource = lista;
                DropDownList1.DataBind();
            }
        }

        protected void Approve(object sender, EventArgs e)
        {
            string sol = DropDownList1.SelectedValue.ToString();
            InterpretacionModel sM = new InterpretacionModel();
            sM = solicitud.listSolicitud().Where(x => x.Name == sol).ToList().FirstOrDefault();
            solicitud.Approve(sM);
        }
    }
}