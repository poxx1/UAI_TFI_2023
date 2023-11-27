using iTextSharp.text;
using iTextSharp.text.pdf;
using Spire.Pdf.Tables;
using Spire.Pdf.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;

namespace Controladores
{
    public class pdf
    {
        public void create(List<string> lista)
        {
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

            //cell1.BackgroundColor = new iTextSharp.text.BaseColor(240, 1, 1);
            //cell2.BackgroundColor = new iTextSharp.text.BaseColor(240, 1, 1);
            cell1.BorderColor = new iTextSharp.text.BaseColor(200, 200, 240);

            cell1.BackgroundColor = new iTextSharp.text.BaseColor(210, 210, 210);

            cell2 = new PdfPCell(new Phrase("Factura [B] - Consumidor Final - SayIT\n\n", new Font(Font.FontFamily.TIMES_ROMAN, 20)));
            cell2.HorizontalAlignment = Element.ALIGN_CENTER;
            cell2.VerticalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            cell2.Colspan = 2;
            cell2.BorderColor = new iTextSharp.text.BaseColor(240, 1, 1);
            table.AddCell(cell2);
            cell1 = new PdfPCell(new Phrase($"\n Fecha de la factura: {DateTime.Now.ToString("dd/MM/yy hh:mm:ss")} \n", new Font(Font.FontFamily.TIMES_ROMAN, 14)));
            cell1.HorizontalAlignment = Element.ALIGN_LEFT;
            cell1.VerticalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            cell1.Colspan = 2;
            table.AddCell(cell1);

            PdfPCell cell = new PdfPCell(new Phrase("Detalle de los cursos comprados", new Font(Font.FontFamily.HELVETICA, 14)));
            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
            cell1.VerticalAlignment = Element.ALIGN_JUSTIFIED_ALL;
            cell1.Colspan = 2;
            table.AddCell(cell);
            #endregion

            PdfPTable table2 = new PdfPTable(1); //lista.Count() El numero determina las columnas

            table2.DefaultCell.Padding = 3;
            table2.WidthPercentage = 100;
            table2.HorizontalAlignment = Element.ALIGN_LEFT;
            table2.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);

            //Hay que modificar esto para agregar los cursos con nombre, detalle y precio
            foreach (string field in lista)
            {
                table2.AddCell(new Phrase("\n " +field+ "\n ", new Font(Font.FontFamily.TIMES_ROMAN, 14)));
            }

            #region Footer
            PdfPTable footer = new PdfPTable(4);
            footer.DefaultCell.Padding = 3;
            footer.WidthPercentage = 100;
            footer.HorizontalAlignment = Element.ALIGN_LEFT;
            footer.DefaultCell.BackgroundColor = new iTextSharp.text.BaseColor(210, 210, 210);

            footer.AddCell(new Phrase("Cantidad total ", new Font(Font.FontFamily.TIMES_ROMAN, 14)));
            footer.AddCell(new Phrase("3 Cursos ", new Font(Font.FontFamily.TIMES_ROMAN, 14)));
            footer.AddCell(new Phrase("Precio total ", new Font(Font.FontFamily.TIMES_ROMAN, 14)));
            PdfPCell cellFooter = new PdfPCell(new Phrase("ARS$ 24320.00 ", new Font(Font.FontFamily.TIMES_ROMAN, 14)));
            cellFooter.HorizontalAlignment = Element.ALIGN_RIGHT;
            footer.AddCell(cellFooter);
            #endregion

            FileStream fs = new FileStream(@"C:\XML\" + FileName, FileMode.Create);

            PdfWriter.GetInstance(document, fs);
            
            document.Open();

            document.Add(table);
            document.Add(table2);
            document.Add(footer);

            document.Close();
            fs.Close();
        }
    }
}
