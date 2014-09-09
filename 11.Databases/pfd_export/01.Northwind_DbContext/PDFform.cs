using System;
using System.Globalization;
using System.Xml;
using System.Xml.XPath;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;
using System.Diagnostics;
using System.Data;
/// <summary>
/// Summary description for InvoiceForm
/// </summary>
public class PDFform
{
    public PDFform()
    {
        
    }


    /// <summary>
    /// The MigraDoc document that represents the invoice.
    /// </summary>
    Document document;

    /// <summary>
    /// An XML invoice based on a sample created with Microsoft InfoPath.
    /// </summary>
    DataTable dt;
    string path;
    /// <summary>
    /// The root navigator for the XML document.
    /// </summary>


    /// <summary>
    /// The text frame of the MigraDoc document that contains the address.
    /// </summary>
    TextFrame addressFrame;

    /// <summary>
    /// The table of the MigraDoc document that contains the invoice items.
    /// </summary>
    Table dataSetTable;

    /// <summary>
    /// Initializes a new instance of the class BillFrom and opens the specified XML document.
    /// </summary>
    public PDFform(DataTable dtIn, string pathIn)
    {
        dt = dtIn;
        path = pathIn;
    }

    /// <summary>
    /// Creates the invoice document.
    /// </summary>
    public Document CreateDocument()
    {
        // Create a new MigraDoc document
        this.document = new Document();
        this.document.Info.Title = "";
        this.document.Info.Subject = "";
        this.document.Info.Author = "Aftab";

        DefineStyles();

        CreatePage();

        //FillContent();
        FillTableContent(this.dt, this.dataSetTable);

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
     void AppendTableTitle(DataTable dataTable, string tableTitle)
    {
        Paragraph paragraph = this.document.LastSection.AddParagraph("Table Overview", "Heading1");
        paragraph.AddBookmark("ReportTitle");

        Table titleRow = new Table();
        titleRow.Borders.Width = 0.75;

        var tableTitleWidth = Unit.FromCentimeter(3) * dataTable.Columns.Count;

        Column column = titleRow.AddColumn(tableTitleWidth);
        column.Format.Alignment = ParagraphAlignment.Center;
        Row row = titleRow.AddRow();
        row.Shading.Color = Colors.PaleGoldenrod;
        Cell cell = row.Cells[0];
        cell.AddParagraph(tableTitle);
        this.document.LastSection.Add(titleRow);
    }
    /// <summary>
    /// Creates the static parts of the invoice.
    /// </summary>
   
    void CreatePage()
    {
        // Each MigraDoc document needs at least one section.
        Section section = this.document.AddSection();
     
        // Put a logo in the header
       Image image= section.AddImage(path);

     
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

        AppendTableTitle(this.dt, "BunnyReport 1");

        // Create the item table
        this.dataSetTable = section.AddTable();
        this.dataSetTable.Style = "Table";
        this.dataSetTable.Borders.Color = TableBorder;
        this.dataSetTable.Borders.Width = 0.25;
        this.dataSetTable.Borders.Left.Width = 0.5;
        this.dataSetTable.Borders.Right.Width = 0.5;
        this.dataSetTable.Rows.LeftIndent = 0;

        
//        PrepareTableHeader();
        PrepareTableHeader(this.dt, this.dataSetTable);


    }

    private void PrepareTableHeader(DataTable dataTable, Table table)
    {
        // Before you can add a row, you must define the columns
        Column column;
        foreach (DataColumn col in dataTable.Columns)
        {
            column = table.AddColumn(Unit.FromCentimeter(3));
            column.Format.Alignment = ParagraphAlignment.Center;
        }
        // Create the header of the table
        Row row = table.AddRow();
        row.HeadingFormat = true;
        row.Format.Alignment = ParagraphAlignment.Center;
        row.Format.Font.Bold = true;
        row.Shading.Color = TableBlue;

        for (int i = 0; i < dataTable.Columns.Count; i++)
        {
            row.Cells[i].AddParagraph(dataTable.Columns[i].ColumnName);
            row.Cells[i].Format.Font.Bold = false;
            row.Cells[i].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[i].VerticalAlignment = VerticalAlignment.Bottom;
        }
        this.dataSetTable.SetEdge(0, 0, dataTable.Columns.Count, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
    }

    private void PrepareTableHeader()
    {
        // Before you can add a row, you must define the columns
        Column column;
        foreach (DataColumn col in dt.Columns)
        {

            column = this.dataSetTable.AddColumn(Unit.FromCentimeter(3));
            column.Format.Alignment = ParagraphAlignment.Center;


        }
        // Create the header of the table
        Row row = dataSetTable.AddRow();
        row.HeadingFormat = true;
        row.Format.Alignment = ParagraphAlignment.Center;
        row.Format.Font.Bold = true;
        row.Shading.Color = TableBlue;


        for (int i = 0; i < dt.Columns.Count; i++)
        {

            row.Cells[i].AddParagraph(dt.Columns[i].ColumnName);
            row.Cells[i].Format.Font.Bold = false;
            row.Cells[i].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[i].VerticalAlignment = VerticalAlignment.Bottom;


        }


        this.dataSetTable.SetEdge(0, 0, dt.Columns.Count, 1, Edge.Box, BorderStyle.Single, 0.75, Color.Empty);
    }



    /// <summary>
    /// Creates the dynamic parts of the invoice.
    /// </summary>
    void FillTableContent(DataTable dataTable, Table table)
    {
        Row row1;
        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            row1 = table.AddRow();
            row1.TopPadding = 1.5;

            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                row1.Cells[j].Shading.Color = TableGray;
                row1.Cells[j].VerticalAlignment = VerticalAlignment.Center;
                row1.Cells[j].Format.Alignment = ParagraphAlignment.Left;
                row1.Cells[j].Format.FirstLineIndent = 1;
                row1.Cells[j].AddParagraph(dataTable.Rows[i][j].ToString());

                this.dataSetTable.SetEdge(0, this.dataSetTable.Rows.Count - 2, dataTable.Columns.Count, 1, Edge.Box, BorderStyle.Single, 0.75);
            }
        }
    }

    void FillContent()
    {
        // Fill address in address text frame

   //     Paragraph paragraph = this.addressFrame.AddParagraph();
   //     paragraph.AddText("Dr. Anwar Ali");
   //     paragraph.AddLineBreak();
   //     paragraph.AddText("Health And Social Services ");
   //     paragraph.AddLineBreak();
   //     paragraph.AddText("Karachi");

        Row row1;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
             row1 = this.dataSetTable.AddRow();


            row1.TopPadding = 1.5;


            for (int j = 0; j < dt.Columns.Count; j++)
            {

                row1.Cells[j].Shading.Color = TableGray;
                row1.Cells[j].VerticalAlignment = VerticalAlignment.Center;
               
                row1.Cells[j].Format.Alignment = ParagraphAlignment.Left;
                row1.Cells[j].Format.FirstLineIndent = 1;



                row1.Cells[j].AddParagraph(dt.Rows[i][j].ToString());


                this.dataSetTable.SetEdge(0, this.dataSetTable.Rows.Count - 2, dt.Columns.Count, 1, Edge.Box, BorderStyle.Single, 0.75);
            }
        }

    
        // Add the notes paragraph
    //    paragraph = this.document.LastSection.AddParagraph();
    //    paragraph.Format.SpaceBefore = "1cm";
    //    paragraph.Format.Borders.Width = 0.75;
    //    paragraph.Format.Borders.Distance = 3;
    //    paragraph.Format.Borders.Color = TableBorder;
    //    paragraph.Format.Shading.Color = TableGray;
    //
    //    paragraph.AddText("Note: For any complain please contact us in 24 hours from the issuance of bill");


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