using BackEnd.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SistemaControl.Models
{
    public class ReporteModel
    {
      
        #region Declaration

        int _totalColumn = 6;
        Document _document;
        Font _fontStyle;

        string _fecha;
       
        PdfPTable _pdfTable = new PdfPTable(6);
        PdfPCell _pdfCell;
        MemoryStream _memoryStream = new MemoryStream();
        List<Documento> _referencias = new List<Documento>();
        List<List<string>> _lista = new List<List<string>>();
        

        #endregion

        public byte[] PrepareReport(List<Documento> referencias,List<List<string>> Lista, string fecha)
        {

            _referencias = referencias;
            _lista = Lista;
            _fecha = fecha;

            #region

            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);

         
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_BOTTOM;

            _fontStyle = FontFactory.GetFont("HELVETICA", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();

  
            _pdfTable.SetWidths(new float[] { 30f, 30f, 15f, 30f, 30f, 15f });

            #endregion

            this.ReportHeader();
            this.ReportBody();
            _pdfTable.HeaderRows = 2;

            
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();

        }

        private void ReportHeader()
        {
            string direccion = HttpContext.Current.Server.MapPath("~/Content/img/");
            Image tif = Image.GetInstance(direccion + "muni.gif");
            tif.ScalePercent(24f);
            _pdfCell = new PdfPCell(tif);
            _pdfCell.Colspan = _totalColumn;
            _pdfCell.Rowspan = 1;
            _pdfCell.Border = 0;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.BackgroundColor = BaseColor.WHITE;
            _pdfCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 20f, 1);
            _pdfCell = new PdfPCell(new Phrase("Municipalidad de Alajuela", _fontStyle));
            _pdfCell.Colspan = _totalColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Border = 0;
            _pdfCell.BackgroundColor = BaseColor.WHITE;
            _pdfCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();


            _fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 20f, 1);
            _pdfCell = new PdfPCell(new Phrase("Procesos de Servicos Juridicos", _fontStyle));
            _pdfCell.Colspan = _totalColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Border = 0;
            _pdfCell.BackgroundColor = BaseColor.WHITE;
            _pdfCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 20f, 1);
            _pdfCell = new PdfPCell(new Phrase("Reporte de Documentos", _fontStyle));
            _pdfCell.Colspan = _totalColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.Border = 0;
            _pdfCell.BackgroundColor = BaseColor.WHITE;
            _pdfCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(_pdfCell);
            _pdfTable.CompleteRow();


            //_fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 15f, 1);
            //_pdfCell = new PdfPCell(new Phrase("Fuente: Sistema Control Juridico", _fontStyle));
            //_pdfCell.Colspan = 6;
            //_pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfCell.Border = 0;
            //_pdfCell.BackgroundColor = BaseColor.WHITE;
            //_pdfCell.Padding = 20f;
            //_pdfCell.ExtraParagraphSpace = 0;
            // _pdfTable.AddCell(_pdfCell);
            //_pdfTable.CompleteRow();


            _fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 15f);
            _pdfCell = new PdfPCell();
            Phrase frase1 = new Phrase("Fuente: Sistema de Control Juridico", _fontStyle);
            Phrase frase2 = new Phrase("Fecha: "+_fecha, _fontStyle);
            _pdfCell.Colspan = _totalColumn;
            _pdfCell.Border = 0;
            _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
           _pdfCell.BorderWidthBottom = 0f;
            _pdfCell.BackgroundColor = BaseColor.WHITE;
            _pdfCell.ExtraParagraphSpace = 0;
            _pdfCell.AddElement(frase1);
            _pdfCell.AddElement(frase2);
            _pdfCell.Padding = 20f;
            _pdfTable.AddCell(_pdfCell);

            _pdfTable.CompleteRow();

        }

        private void ReportBody()
        {

            #region

            // imagen 

            


            _fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 8f, 1);
            _pdfCell = new PdfPCell(new Phrase("Número Oficio", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 8f, Font.BOLDITALIC);
            _pdfCell = new PdfPCell(new Phrase("Número Ingreso", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 8f, Font.BOLDITALIC);
            _pdfCell = new PdfPCell(new Phrase("Fecha", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 8f, Font.BOLDITALIC);
            _pdfCell = new PdfPCell(new Phrase("Tipo Origen", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 8f, Font.BOLDITALIC);
            _pdfCell = new PdfPCell(new Phrase("Origen", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 8f, Font.BOLDITALIC);
            _pdfCell = new PdfPCell(new Phrase("Estado", _fontStyle));
            _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(_pdfCell);

            _pdfTable.CompleteRow();

            #endregion

            #region Table Body

            _fontStyle = FontFactory.GetFont(@"C:\Windows\Fonts\times.ttf", 10f, 0);
            _fontStyle.SetColor(0, 0,0); // color de tabla contenido

            int cont=0;


            foreach (Documento documento in _referencias)
            {

                _pdfCell = new PdfPCell(new Phrase(documento.numeroDocumento.ToString(), _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(documento.numeroIngreso, _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(documento.fecha.ToString("dd/MM/yyyy"), _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(_lista[cont][0], _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(_lista[cont][1], _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(_lista[cont][2], _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(_pdfCell);

                _pdfTable.CompleteRow();
                cont = cont+1;
            }

            #endregion

        }

    }
}