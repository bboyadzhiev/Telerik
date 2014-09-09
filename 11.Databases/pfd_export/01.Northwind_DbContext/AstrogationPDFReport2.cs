using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace _01.Northwind_DbContext
{
    public class AstrogationPDFReport2
    {
        private const int borderOffset = 3;

        public static void GenerateReport()
        {
            // Create a MigraDoc document
            Document document = new Document();

            var date = DateTime.Now;
            var dateString = date.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
            var timeString = date.ToString("HH:mm:ss", CultureInfo.InvariantCulture);

            // Get data
            using (var context = new NorthwindEntities())
            {
                var orderDates = context.Orders.Join(
                    context.Order_Details, (order => order.OrderID), (order_detail => order_detail.OrderID),
                    (order, order_detail) => new
                    {
                        OrderID = order.OrderID,
                        OrderDate = order.OrderDate,
                        ProductName = order_detail.Product.ProductName,
                        OrderQuantity = order_detail.Quantity,
                        UnitPrice = order_detail.UnitPrice,
                    });




                DefineStyles(document);

                var section = document.AddSection();
                // Create footer
                Paragraph paragraph = document.LastSection.Headers.Primary.AddParagraph();
                paragraph.AddText("Astrogation Report");
                paragraph.Format.Font.Size = 9;
                paragraph.Format.Alignment = ParagraphAlignment.Center;

                //Paragraph frame = document.LastSection.AddParagraph();

                document.LastSection.AddParagraph("Date: " + dateString + "\nTime: " + timeString);
                // Preparing Report
                // var title = GetTableTitle(3, "Astrogation Report");
                // document.LastSection.Add(title);

                var headers = new List<string>() { "Product name", "Quantity", "Price" };

                var lastRecord = 0;
                var tableTitle = new Table();
                var tableHeaders = new Table();


                foreach (var orderDate in orderDates)
                {
                    if (lastRecord != orderDate.OrderID)
                    {
                        lastRecord = orderDate.OrderID;
                        // Adds space between tables
                        document.LastSection.Add(new Paragraph());
                        // Add Table Title
                        tableTitle = GetTableTitle(3, orderDate.OrderDate.ToString());
                        document.LastSection.Add(tableTitle);
                        // Add Table Headers
                        tableHeaders = GetTableHeader(headers);
                        document.LastSection.Add(tableHeaders);
                    }

                    // Add Tabe Data
                    List<string> rowData = new List<string>() { orderDate.ProductName, orderDate.UnitPrice.ToString(), orderDate.OrderQuantity.ToString() };
                    Table table = new Table();
                    table.Style = "Table";
                    table.Borders.Color = TableBorder;
                    table.Borders.Width = 0.25;
                    table.Borders.Left.Width = 0.5;
                    table.Borders.Right.Width = 0.5;
                    Row tableRow = GetTableRow(3, table);
                    AddRowData(rowData, tableRow, false);

                    document.LastSection.Add(table);
                    lastRecord = orderDate.OrderID;
                }
            }
            try
            {
                Console.WriteLine(dateString);

                document.UseCmykColor = true;

                // Create a renderer for PDF that uses Unicode font encoding
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

                // Set the MigraDoc document
                pdfRenderer.Document = document;

                // Create the PDF document
                pdfRenderer.RenderDocument();

                // Save the PDF document...

                string filename = "AstrogationReport_" + date.ToString("dd_MM_yyyy_HH_mm_ss", CultureInfo.InvariantCulture) + ".pdf";

                pdfRenderer.Save(filename);
                // ...and start a viewer.
                Process.Start(filename);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }

        private static Table GetTableTitle(int colsCount, string tableTitle)
        {
            // Paragraph paragraph = this.document.LastSection.AddParagraph("Table Overview", "Heading1");
            // paragraph.AddBookmark("ReportTitle");

            Table titleRow = new Table();
            titleRow.Borders.Width = 0.75;

            var tableTitleWidth = Unit.FromCentimeter(borderOffset) * colsCount;

            Column column = titleRow.AddColumn(tableTitleWidth);
            column.Format.Alignment = ParagraphAlignment.Center;
            Row row = titleRow.AddRow();
            row.Shading.Color = Colors.PaleGoldenrod;
            Cell cell = row.Cells[0];
            cell.AddParagraph(tableTitle);
            return titleRow;
        }

        private static Table GetTableHeader(List<string> headerData)
        {
            Table table = new Table();
            table.Style = "TableHeader";
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            Row headerRow = GetTableRow(headerData.Count, table);
            headerRow.Format.Alignment = ParagraphAlignment.Center;
            headerRow.Format.Font.Bold = true;
            headerRow.HeadingFormat = true;
            AddRowData(headerData, headerRow, true);

            table.SetEdge(0, 0, headerData.Count, 1, Edge.Box, BorderStyle.Single, 0.75);//, Color.Empty);
            return table;

        }

        private static Row GetTableRow(int headerLength, Table table)
        {
            for (int i = 0; i < headerLength; i++)
            {
                Column column = table.AddColumn(Unit.FromCentimeter(borderOffset));
            }

            Row row = table.AddRow();
            row.HeadingFormat = false;
            row.Format.Font.Bold = false;
            row.Format.Alignment = ParagraphAlignment.Left;
            row.Shading.Color = TableBlue;

            return row;
        }

        private static void AddRowData(List<string> rowData, Row row, bool isHeaderRow)
        {
            for (int i = 0; i < rowData.Count; i++)
            {
                row.Cells[i].AddParagraph(rowData[i]);
                row.Cells[i].Format.Font.Bold = isHeaderRow;
                if (isHeaderRow)
                {
                    row.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                }
                row.Cells[i].Format.Alignment = ParagraphAlignment.Left;
                row.Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }
        }

        private static void DefineStyles(Document document)
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;

            // Create a new style called Reference based on style Normal
            style = document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);

            // Table headers styles
            style = document.Styles.AddStyle("TableHeader", "Normal");
            style.ParagraphFormat.Font.Bold = true;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;
        }

        // Some pre-defined colors
#if true
        // RGB colors
        private static readonly Color TableBorder = new Color(81, 125, 192);
        private static readonly Color TableBlue = new Color(235, 240, 249);
        private static readonly Color TableGray = new Color(242, 242, 242);
#else
    // CMYK colors
    readonly static Color tableBorder = Color.FromCmyk(100, 50, 0, 30);
    readonly static Color tableBlue = Color.FromCmyk(0, 80, 50, 30);
    readonly static Color tableGray = Color.FromCmyk(30, 0, 0, 0, 100);
#endif
    }
}