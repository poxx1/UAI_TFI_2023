using Controladores;
using Modelos;
using System;
using System.Collections.Generic;

namespace Vista
{
    public partial class MenuCarrito : System.Web.UI.Page
    {
        List<CursosModel> cursos = new List<CursosModel>();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> lista = (List<string>)Session["carrito"];

            foreach (object item in lista)
            {
                CursosModel curso = (CursosModel)item;
                cursos.Add(curso);
            }

            ListBox1.DataSource = lista;
            ListBox1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try { ListBox1.SelectedValue.Remove(0); }catch(Exception) { }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            // FALTA realizar compra

            // FALTA crear el pdf de la factura
            pdf p = new pdf();
            var l = (List<string>)Session["carrito"];
            l.Add("Curso 1");
            l.Add("Curso 2");
            l.Add("Curso 3");
            p.create(l);

            // FALTA enviar por email el pdf de la compra//Quitar item
            Gmail gmail = new Gmail();
            GmailModel gmailModel = new GmailModel();

            gmailModel.from = "julianlastra.kz@gmail.com";
            gmailModel.to = "julianlastra.kz@gmail.com";
            gmailModel.subject = "Factura de su compra";
            gmailModel.body = "Estimado usuario, <br><br> Se adjunta la factura de su compra.<br><br> Muchas gracias.";            

            gmail.sendEmail(gmailModel);
        }
    }
}