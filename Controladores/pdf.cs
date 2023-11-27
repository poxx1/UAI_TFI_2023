using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelos;
using Org.BouncyCastle.Crypto.Macs;
using Spire.Pdf.Tables;
using Spire.Pdf.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Web.ModelBinding;

namespace Controladores
{
    public class pdf
    {
        public void create(List<CursosModel> lista)
        {
            float total = 0;
            int count = lista.Count();

            #region Detalles pdf
            string fecha = DateTime.Now.ToString("dd-MM-yy_hhmmss");
            string FileName = fecha + "_Factura.pdf";

            PdfPTable table = new PdfPTable(1);
            Document document = new Document(PageSize.A4, 10f, 20f, 20f, 10f);
            table.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(210, 210, 210);

            table.DefaultCell.Padding = 3;
            table.WidthPercentage = 100;
            table.HorizontalAlignment = Element.ALIGN_LEFT;

            PdfPCell cell1 = new PdfPCell();
            PdfPCell cell2 = new PdfPCell();

            cell1.BorderColor = new iTextSharp.text.BaseColor(200, 200, 210);
            cell1.BackgroundColor = new iTextSharp.text.BaseColor(210, 210, 210);

            cell2 = new PdfPCell(new Phrase("\n| SayIT | Factura - [B] - Consumidor Final\n\r", new Font(Font.FontFamily.TIMES_ROMAN, 20, Font.BOLD)));

            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            //cell2.VerticalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            cell2.Colspan = 2;
            cell2.BorderColor = new iTextSharp.text.BaseColor(100, 100, 200);
            cell2.BorderWidth = 2;
            cell2.BackgroundColor = new iTextSharp.text.BaseColor(150, 150, 240);
            table.AddCell(cell2);
            cell1 = new PdfPCell(new Phrase($"Fecha de la factura: {DateTime.Now.ToString("dd/MM/yy hh:mm:ss")} \n", new Font(Font.FontFamily.TIMES_ROMAN, 14)));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            //cell1.VerticalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            cell1.Colspan = 2;
            table.AddCell(cell1);

            //FALTA Agregar detalle del usuario 
            PdfPCell celdaUsuario = new PdfPCell();
            PdfPTable tablaUsuario = new PdfPTable(1);

            tablaUsuario.DefaultCell.Padding = 3;
            tablaUsuario.WidthPercentage = 100;
            tablaUsuario.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaUsuario.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(220, 220, 220);

            //Nombre de usuario - Sugerencia que lo saque
            //tablaUsuario.AddCell(new Phrase("Usuario que realiza la compra: " + SessionModel.GetUser().Nickname, new Font(Font.FontFamily.HELVETICA, 14)));
            //Nombre y apellido
            tablaUsuario.AddCell(new Phrase("Nombre:  "+ SessionModel.GetUser().Name + " | Apellido: " +SessionModel.GetUser().LastName, new Font(Font.FontFamily.HELVETICA, 14)));
            //Correo
            tablaUsuario.AddCell(new Phrase("Direccion de correo electronico: " + SessionModel.GetUser().Mail, new Font(Font.FontFamily.HELVETICA, 14)));
            //Direccion fisica
            tablaUsuario.AddCell(new Phrase("Direccion del consumidor final: " + SessionModel.GetUser().Adress, new Font(Font.FontFamily.HELVETICA, 14)));

            PdfPCell cell = new PdfPCell(new Phrase("\nDetalle de los cursos comprados\n", new Font(Font.FontFamily.HELVETICA, 14, Font.BOLD)));
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.VerticalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            cell.Colspan = 2;
            tablaUsuario.AddCell(cell);
            #endregion

            #region Header de los items
            PdfPTable tableHeader = new PdfPTable(2); //lista.Count() El numero determina las columnas

            tableHeader.AddCell(new Phrase("Nombre", new Font(Font.FontFamily.TIMES_ROMAN, 16)));
            tableHeader.AddCell(new Phrase("Precio", new Font(Font.FontFamily.TIMES_ROMAN, 16)));

            tableHeader.DefaultCell.Padding = 3;
            tableHeader.WidthPercentage = 100;
            tableHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            tableHeader.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(230, 230, 240);
            //tableHeader.AddCell(new Phrase("\n " + "Cantidad" + "\n ", new Font(Font.FontFamily.TIMES_ROMAN, 14))); No puedo comprar el curso mas de una vez

            #endregion

            #region Items
            // FALTA que los items de la tabla sean reales;
            PdfPTable table2 = new PdfPTable(2); //lista.Count() El numero determina las columnas

            table2.DefaultCell.Padding = 3;
            table2.WidthPercentage = 100;
            table2.HorizontalAlignment = Element.ALIGN_LEFT;
            table2.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);

            //Hay que modificar esto para agregar los cursos con nombre, detalle y precio
            foreach (CursosModel field in lista)
            {
                table2.AddCell(new Phrase("\n " + field.Name + "\n ", new Font(Font.FontFamily.TIMES_ROMAN, 10)));
                table2.AddCell(new Phrase("\n ARS$ " + field.Price + "\n ", new Font(Font.FontFamily.TIMES_ROMAN, 10)));
                total += field.Price;
            }

            #endregion

            #region Footer
            PdfPTable footer = new PdfPTable(4);
            footer.DefaultCell.Padding = 3;
            footer.WidthPercentage = 100;
            footer.HorizontalAlignment = Element.ALIGN_LEFT;
            footer.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(210, 210, 210);

            footer.AddCell(new Phrase("Cantidad total ", new Font(Font.FontFamily.TIMES_ROMAN, 14, Font.BOLD)));
            footer.AddCell(new Phrase(count + " cursos ", new Font(Font.FontFamily.TIMES_ROMAN, 14)));
            footer.AddCell(new Phrase("Precio total ", new Font(Font.FontFamily.TIMES_ROMAN, 14, Font.BOLD)));
            PdfPCell cellFooter = new PdfPCell(new Phrase("ARS$" + total + ".00 ", new Font(Font.FontFamily.TIMES_ROMAN, 14)));
            cellFooter.HorizontalAlignment = Element.ALIGN_RIGHT;
            footer.AddCell(cellFooter);
            #endregion

            FileStream fs = new FileStream(@"C:\XML\" + FileName, FileMode.Create);

            PdfWriter.GetInstance(document, fs);
            
            document.Open();

            document.Add(table);
            document.Add(tablaUsuario);
            document.Add(tableHeader);
            document.Add(table2);
            document.Add(footer);

            document.Close();
            fs.Close();

            Gmail gmail = new Gmail();
            GmailModel gmailModel = new GmailModel();

            gmailModel.from = "julianlastra.kz@gmail.com";
            gmailModel.to = "julianlastra.kz@gmail.com";
            gmailModel.subject = "Factura de su compra";
            gmailModel.body = "Estimado usuario,\r\n\r\nSe adjunta la factura de su compra. Cualquier consulta que tenga por favor contacte al soporte especializado.\r\n\r\nMuchas gracias por su compra y por confiar en nosotros.";

            gmail.sendEmail(gmailModel, @"C:\XML\" + FileName);
        }
    }
}
