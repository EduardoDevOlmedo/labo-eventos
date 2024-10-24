﻿using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Data; 
using System.Diagnostics;

class GenerarPDF
{
    
    private string title;
    private DataTable dataTable; 

    
    public GenerarPDF(string title, DataTable dataTable)
    {
        this.title = title; 
        this.dataTable = dataTable; 
    }

    
    public void CrearPDF()
    {
        
        PdfDocument document = new PdfDocument();
        document.Info.Title = title; // Asigna el título al documento PDF.

        
        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page); // Permite dibujar en la página.

       
        XFont font = new XFont("Verdana", 12, XFontStyleEx.Regular);

        double cellWidth = 100; 
        double cellHeight = 30; 

        double xPos = 50; 
        double yPos = 100; 

        // Dibuja el título centrado en la parte superior de la página.
        gfx.DrawString(title, new XFont("Verdana", 16, XFontStyleEx.Bold), XBrushes.Black, new XRect(10, 50, page.Width, 50), XStringFormats.Center);

        // Dibuja el encabezado de la tabla.
        for (int i = 0; i < dataTable.Columns.Count; i++)
        {
            
            gfx.DrawRectangle(XPens.Black, xPos + i * cellWidth, yPos, cellWidth, cellHeight);
            // Escribe el nombre de la columna en la celda del encabezado.
            gfx.DrawString(dataTable.Columns[i].ColumnName, font, XBrushes.Black,
                           new XRect(xPos + i * cellWidth, yPos, cellWidth, cellHeight),
                           XStringFormats.Center);
        }

        // Dibuja las filas de la tabla.
        for (int row = 0; row < dataTable.Rows.Count; row++)
        {
            for (int col = 0; col < dataTable.Columns.Count; col++)
            {
                
                gfx.DrawRectangle(XPens.Black, xPos + col * cellWidth, yPos + (row + 1) * cellHeight, cellWidth, cellHeight);
                // Escribe el valor de la celda en el rectángulo correspondiente.
                gfx.DrawString(dataTable.Rows[row][col].ToString(), font, XBrushes.Black,
                               new XRect(xPos + col * cellWidth, yPos + (row + 1) * cellHeight, cellWidth, cellHeight),
                               XStringFormats.Center);
            }
        }

        // Muestra la cantidad de elementos a la fecha actual.
        DateTime dateTime = DateTime.UtcNow.Date;
        gfx.DrawString($"Se cuentan con {dataTable.Rows.Count} elementos a día de {dateTime.ToString("dd/MM/yyyy")}", 
                        new XFont("Verdana", 16, XFontStyleEx.Bold), XBrushes.Black, 
                        new XRect(10, 250, page.Width, 50), XStringFormats.Center);

        // Cuenta los elementos "activos" en la tabla si existe la columna "activo".
        int countActivos = dataTable.AsEnumerable()
             .Count(row => (dataTable.Columns.Contains("activo") && row.Field<bool>("activo") == true));

        // Cuenta los elementos "atendidos" en la tabla si existe la columna "atendida".
        int countAtendidos = dataTable.AsEnumerable()
             .Count(row => (dataTable.Columns.Contains("atendida") && row.Field<bool>("atendida") == true));

        // Si hay elementos "atendidos", muestra el conteo en el PDF.
        if (countAtendidos > 0)
        {
            gfx.DrawString(normalizeText(countAtendidos, "atendido/atendidos"), 
                           new XFont("Verdana", 16, XFontStyleEx.Bold), XBrushes.Black, 
                           new XRect(10, 300, page.Width, 50), XStringFormats.Center);
        }

        // Si hay elementos "activos", muestra el conteo en el PDF.
        if (countActivos != 0)
        {
            gfx.DrawString(normalizeText(countActivos, "activo/activos"), 
                           new XFont("Verdana", 16, XFontStyleEx.Bold), XBrushes.Black, 
                           new XRect(10, 300, page.Width, 50), XStringFormats.Center);
        }

        // Guarda el documento PDF en un archivo.
        string fileName = $"{title}.pdf";
        document.Save(fileName);

        // Abre el archivo PDF generado con la aplicación predeterminada.
        Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
    }

    
    public void generarPDFEventos()
    {
        
        PdfDocument document = new PdfDocument();
        document.Info.Title = "Resumen de Eventos";

        PdfPage page = document.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);

        XFont font = new XFont("Verdana", 12, XFontStyleEx.Regular);

        double xPos = 50;
        double yPos = 100;

        // Dibuja el título en la parte superior de la página.
        gfx.DrawString(title, new XFont("Verdana", 16, XFontStyleEx.Bold), XBrushes.Black, 
                       new XRect(10, 50, page.Width, 50), XStringFormats.Center);

        // Obtiene la tabla de datos para los eventos.
        DataTable eventTable = dataTable;

        
        int countEliminar = eventTable.AsEnumerable()
            .Count(row => row.Field<string>("tipoEvento") == "Eliminar");

        int countActualizar = eventTable.AsEnumerable()
            .Count(row => row.Field<string>("tipoEvento") == "Actualizar");

        int countAgregar = eventTable.AsEnumerable()
            .Count(row => row.Field<string>("tipoEvento") == "Agregar");

        yPos += 20;

        
        gfx.DrawString(normalizeText(countEliminar, "eliminado/eliminados"), font, XBrushes.Black, 
                       new XRect(xPos, yPos, page.Width - xPos, 50), XStringFormats.TopLeft);

        yPos += 30;
        
        gfx.DrawString(normalizeText(countActualizar, "actualizado/actualizados"), font, XBrushes.Black, 
                       new XRect(xPos, yPos, page.Width - xPos, 50), XStringFormats.TopLeft);

        yPos += 30; 
       
        gfx.DrawString(normalizeText(countAgregar, "agregado/agregados"), font, XBrushes.Black, 
                       new XRect(xPos, yPos, page.Width - xPos, 50), XStringFormats.TopLeft);

       
        string fileName = "ResumenEventos.pdf";
        document.Save(fileName);

        // Abre el archivo PDF generado con la aplicación predeterminada.
        Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
    }

    // Método para normalizar el texto según la cantidad de elementos.
    private string normalizeText(int amount, string complement)
    {
        if (amount > 1) return $"Se cuentan con {amount} elementos {complement}";
        return $"Se cuenta con {amount} elemento {complement}";
    }
}
