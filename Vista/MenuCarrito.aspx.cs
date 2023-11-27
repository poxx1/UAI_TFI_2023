using Modelos;
using Servicios;
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
            //Quitar item
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            // FALTA realizar compra

            // FALTA crear el pdf de la factura

            // FALTA enviar por email el pdf de la compra//Quitar item
        }

    }
}