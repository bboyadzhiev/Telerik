using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Northwind_DbContext
{
    class MultiTablePDFReport
    {
        const int borderOffset = 3;
        Document document;
        //IList<DataTable> dataTables;
        IDictionary<string, DataTable> dataTables;
        IList<Table> generatedTables;
        string reportTitle;
        string imagePath;

        /// <summary>
        /// The text frame of the MigraDoc document that contains the address.
        /// </summary>
        TextFrame addressFrame;

        public MultiTablePDFReport(IDictionary<string, DataTable> dataTables, string reportTitle, string imagePath)
        {
            this.generatedTables = new List<Table>();
            this.dataTables = dataTables;
            this.reportTitle = reportTitle;
            this.imagePath = imagePath;
        }

        public Document CreateDocument()
        {
            // Create a new MigraDoc document
            this.document = new Document();
            this.document.Info.Title = "";
            this.document.Info.Subject = "";
            this.document.Info.Author = "Aftab";

            DefineStyles();

            //Atleast one document section is needed
            //var section = CreatePageHeaderSection();
            var section = this.document.AddSection();
            AppendTableTitle(this.dataTables.First().Value.Columns.Count, reportTitle);
            AppendTables(this.dataTables);
            return this.document;
        }


        /// <summary>
        /// Defines the styles used to format the MigraDoc document.
        /// </summary>
        void DefineStyles()
        {
            // Get the predefined style Normal.
            Style style = this.document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Verdana";

            style = this.document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = this.document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called Table based on style Normal
            style = this.document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "Verdana";
            style.Font.Name = "Times New Roman";
            style.Font.Size = 9;

            // Create a new style called Reference based on style Normal
            style = this.document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("16cm", TabAlignment.Right);
        }

        /// <summary>
        /// Creates the static parts of the invoice.
        /// </summary>

        Section CreatePageHeaderSection()
        {
            // Each MigraDoc document needs at least one section.
            Section section = this.document.AddSection();

            // Put a logo in the header
            Image image = section.AddImage(this.imagePath);
          
          
            image.Top = ShapePosition.Top;
            image.Left = ShapePosition.Left;
            image.WrapFormat.Style = WrapStyle.Through;

            // Create footer
            Paragraph paragraph = section.Headers.Primary.AddParagraph();
            paragraph.AddText("PDF Report.");
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            // Create the text frame for the address
            this.addressFrame = section.AddTextFrame();
            this.addressFrame.Height = "3.0cm";
            this.addressFrame.Width = "7.0cm";
            this.addressFrame.Left = ShapePosition.Left;
            this.addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;
            this.addressFrame.Top = "5.0cm";
            this.addressFrame.RelativeVertical = RelativeVertical.Page;

            // Put sender in address frame
            paragraph = this.addressFrame.AddParagraph("Karachi,Pakistan");
            paragraph.Format.Font.Name = "Times New Roman";
            paragraph.Format.Font.Size = 7;
            paragraph.Format.SpaceAfter = 3;

            // Add the print date field
            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "6cm";
            paragraph.Style = "Reference";
            paragraph.AddFormattedText("Patients Detail", TextFormat.Bold);
            paragraph.AddTab();
            paragraph.AddText("Date, ");
            paragraph.AddDateField("dd.MM.yyyy");

            

            return section;
        }

        /// <summary>
        /// Creates the dynamic parts of the invoice.
        /// </summary>
        void FillTableContent(DataTable dataTable, Table generatedTable)
        {
            
            Row row1;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                row1 = generatedTable.AddRow();
                row1.TopPadding = 1.5;

                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    row1.Cells[j].Shading.Color = TableGray;
                    row1.Cells[j].VerticalAlignment = VerticalAlignment.Center;
                    row1.Cells[j].Format.Alignment = ParagraphAlignment.Left;
                    row1.Cells[j].Format.FirstLineIndent = 1;
                    row1.Cells[j].AddParagraph(dataTable.Rows[i][j].ToString());

                    generatedTable.SetEdge(0, generatedTable.Rows.Count - 2, dataTable.Columns.Count, 1, Edge.Box, BorderStyle.Single, 0.75);
                }
            }
        }

        private void AppendTables(IDictionary<string, DataTable> dataTables)
        {

            foreach (var dataTable in dataTables)
            {
                AppendTableTitle(dataTable.Value.Columns.Count, dataTable.Key);
                
                // Create the item table
                var newTable = new Table();

                newTable = this.document.LastSection.AddTable();
                newTable.Style = "Table";
                newTable.Borders.Color = TableBorder;
                newTable.Borders.Width = 0.25;
                newTable.Borders.Left.Width = 0.5;
                newTable.Borders.Right.Width = 0.5;
                newTable.Rows.LeftIndent = 0;

                
                PrepareTableHeader(dataTable.Value, newTable);
                FillTableContent(dataTable.Value, newTable);
                
                this.generatedTables.Add(newTable);
            }
            Console.WriteLine("Tables generated!");
        }

        private void PrepareTableHeader(DataTable dataTable, Table generatedTable)
        {
            // Before you can add a row, you must define the columns
            Column column;
            foreach (DataColumn col in dataTable.Columns)
            {
                column = generatedTable.AddColumn(Unit.FromCentimeter(borderOffset));
                column.Format.Alignment = ParagraphAlignment.Center;
            }
            // Create the header of the table
            Row row = generatedTable.AddRow();
            row.HeadingFormat = true;
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Format.Font.Bold = true;
            row.Shading.Color = TableBlue;

            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                row.Cells[i].AddParagraph(dataTable.Columns[i].ColumnName);
                row.Cells[i].Format.Font.Bold = true;
                row.Cells[i].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[i].VerticalAlignment = VerticalAlignment.Center;
            }
            generatedTable.SetEdge(0, 0, dataTable.Columns.Count, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
        }

        /// <summary>
        /// Appends a title to every DataTable that is being visualized
        /// </summary>
        /// <param name="dataTable">The sourece DataTable object</param>
        /// <param name="tableTitle">The title to be appended</param>
        void AppendTableTitle(DataTable dataTable, string tableTitle)
        {
            Paragraph paragraph = this.document.LastSection.AddParagraph("Table Overview", "Heading1");
            paragraph.AddBookmark("ReportTitle");

            Table titleRow = new Table();
            titleRow.Borders.Width = 0.75;

            var tableTitleWidth = Unit.FromCentimeter(borderOffset) * dataTable.Columns.Count;

            Column column = titleRow.AddColumn(tableTitleWidth);
            column.Format.Alignment = ParagraphAlignment.Center;
            Row row = titleRow.AddRow();
            row.Shading.Color = Colors.PaleGoldenrod;
            Cell cell = row.Cells[0];
            cell.AddParagraph(tableTitle);
            this.document.LastSection.Add(titleRow);
        }

        /// <summary>
        /// Appends a title to every DataTable that is being visualised
        /// </summary>
        /// <param name="colsCount">The columns count to span to</param>
        /// <param name="tableTitle">The title to be appended</param>
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
