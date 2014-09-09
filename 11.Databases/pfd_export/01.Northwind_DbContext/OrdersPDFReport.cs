using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;

namespace _01.Northwind_DbContext
{
    class OrdersPDFReport
    {
        const int borderOffset = 3;
        Document document;
        public OrdersPDFReport()
        {
            this.document = new Document(); 
            using (var context = new NorthwindEntities())
            {
                var orderDates = context.Orders.Join(
                    context.Order_Details, (order => order.OrderID), (order_detail => order_detail.OrderID),
                    (order, order_detail) => new
                    {
                        OrderDate = order.OrderDate,
                        ProductName = order_detail.Product.ProductName,
                        OrderQuantity = order_detail.Quantity,
                        UnitPrice = order_detail.UnitPrice,
                        
                    });


                var lastRecord = orderDates.First();

                foreach (var orderDate in orderDates)
                {
                    if (lastRecord.OrderDate == orderDate.OrderDate)
                    {
                        Table table = new Table();
                        Row tableRow = GetTableRow(3, table);
                        List<string> rowData = new List<string>(){orderDate.ProductName, orderDate.UnitPrice.ToString(), orderDate.OrderQuantity.ToString()};
                        AddRowData(rowData, tableRow);
                    }
                    else
                    {
                        lastRecord = orderDate;
                        // Prepare Header
                        AppendTableTitle(4, orderDate.OrderDate.ToString());
                        Table headerTable = new Table();
                        GetTableHeder(4, headerTable);
                    }
                    
                    
                    
                }
            }
        }

        private void GetTableHeder(int headerLength,Table table)
        {

            Row tableHeader = GetTableRow(headerLength, table);

            AddRowData(new List<string>() { "Product name", "Quantity", "Price" }, tableHeader);

            table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
        }

        private static Row GetTableRow(int headerLength, Table table)
        {
            for (int i = 0; i < headerLength; i++)
            {
                Column column = table.AddColumn(Unit.FromCentimeter(borderOffset));
            }
            Row tableHeader = table.AddRow();
            tableHeader.HeadingFormat = true;
            tableHeader.Format.Alignment = ParagraphAlignment.Center;
            tableHeader.Format.Font.Bold = true;
            tableHeader.Shading.Color = TableBlue;
            return tableHeader;
        }

        void AddRowData(List<string> rowData, Row row)
        {
            for (int i = 0; i < rowData.Count; i++)
            {
                row.Cells[i].AddParagraph(rowData[i]);
                row.Cells[i].Format.Font.Bold = true;
                row.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }
           
        }

        void AppendTableTitle(int colsCount, string tableTitle)
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
            this.document.LastSection.Add(titleRow);
        }

       
        // Some pre-defined colors
#if true
        // RGB colors
        readonly static Color TableBorder = new Color(81, 125, 192);
        readonly static Color TableBlue = new Color(235, 240, 249);
        readonly static Color TableGray = new Color(242, 242, 242);
#else
    // CMYK colors
    readonly static Color tableBorder = Color.FromCmyk(100, 50, 0, 30);
    readonly static Color tableBlue = Color.FromCmyk(0, 80, 50, 30);
    readonly static Color tableGray = Color.FromCmyk(30, 0, 0, 0, 100);
#endif
    }
}
