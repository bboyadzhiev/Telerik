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
    public class AstrogationPDFReport
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
                        ProductID = order_detail.ProductID,
                        OrderQuantity = order_detail.Quantity,
                        UnitPrice = order_detail.UnitPrice
                    });
                var discontinued = context.Orders
                        .Join(
                        context.Order_Details,
                        order => order.OrderID, order_detail => order_detail.OrderID,
                        (order, order_detail) => order_detail)
                        .Join(
                        context.Products,
                        order_detail => order_detail.ProductID, product => product.ProductID,
                        (order_detail, product) => new
                        {
                            OrderID = order_detail.OrderID,
                            ProductID = product.ProductID,
                            Discontinued = product.Discontinued
                            
                        })
                        .ToList();
                               

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

                var headers = new List<string>() { "Product name", "Quantity", "Price", "Discontinued" };
                var columnsCount = headers.Count;
                var lastRecordID = 0;
                var tableTitle = new Table();
                var tableHeaders = new Table();
                Table tableData = GetDataTable(columnsCount);
                document.LastSection.Add(tableData);

                foreach (var orderDate in orderDates)
                {
                    if (lastRecordID != orderDate.OrderID)
                    {
                        lastRecordID = orderDate.OrderID;
                        // Adds space between tables
                        document.LastSection.Add(new Paragraph());
                        // Add Table Title
                        tableTitle = GetTableTitle(columnsCount, orderDate.OrderDate.ToString());
                        document.LastSection.Add(tableTitle);
                        // Add Table Headers
                        tableHeaders = GetTableHeader(headers);
                        document.LastSection.Add(tableHeaders);
                        // Add Table Data
                        tableData = GetDataTable(columnsCount);
                        document.LastSection.Add(tableData);
                    }

                    // Add Tabe Data
                    var rowData = new List<string>() 
                    { 
                        orderDate.ProductName, orderDate.UnitPrice.ToString(), orderDate.OrderQuantity.ToString(), discontinued.First(d => d.ProductID == orderDate.ProductID).Discontinued.ToString()
                    };
                    Row tableRow = GetTableRow(columnsCount, tableData);
                    AddRowData(rowData, tableRow, false);
                    lastRecordID = orderDate.OrderID;
                }
            }
            try
            {
                var asrtogationReportName = "AstrogationReport_" + date.ToString("dd_MM_yyyy_HH_mm_ss", CultureInfo.InvariantCulture) + ".pdf";
                Console.WriteLine("New Astrogation report - {0}", asrtogationReportName);

                document.UseCmykColor = true;

                // Create a renderer for PDF that uses Unicode font encoding
                PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

                // Set the MigraDoc document
                pdfRenderer.Document = document;

                // Create the PDF document
                pdfRenderer.RenderDocument();

                // Save the PDF document...
                pdfRenderer.Save(asrtogationReportName);

                // ...and start a viewer.
                Process.Start(asrtogationReportName);
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
            Row headerRow = GetTableHeaderRow(headerData.Count, table);
            headerRow.Format.Alignment = ParagraphAlignment.Center;
            headerRow.Format.Font.Bold = true;
            headerRow.HeadingFormat = true;
            AddRowData(headerData, headerRow, true);

            table.SetEdge(0, 0, headerData.Count, 1, Edge.Box, BorderStyle.Single, 0.75);//, Color.Empty);
            return table;

        }
        private static Table GetDataTable(int colsCount)
        {
            Table table = new Table();
            for (int i = 0; i < colsCount; i++)
            {
                Column column = table.AddColumn(Unit.FromCentimeter(borderOffset));
            }
            table.Style = "Table";
            table.Borders.Color = TableBorder;
            table.Borders.Width = 0.25;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            return table;
        }
        private static Row GetTableHeaderRow(int headerLength, Table table)
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

        private static Row GetTableRow(int headerLength, Table table)
        {
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