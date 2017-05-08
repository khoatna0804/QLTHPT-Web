using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class ImportPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void buttonUpload_Click(object sender, EventArgs e)
    {
        //Upload and save the file
        string csvPath = Server.MapPath("~/App_Data/") + Path.GetFileName(buttonChooseFile.PostedFile.FileName);
        buttonChooseFile.SaveAs(csvPath);

        DataTable dt = new DataTable();
        dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id", typeof(int)),
            new DataColumn("Name", typeof(string)) });


        string csvData = File.ReadAllText(csvPath);
        foreach (string row in csvData.Split('\n'))
        {
            if (!string.IsNullOrEmpty(row))
            {
                dt.Rows.Add();
                int i = 0;
                foreach (string cell in row.Split(','))
                {
                    dt.Rows[dt.Rows.Count - 1][i] = cell;
                    i++;
                }
            }
        }

        string consString = ConfigurationManager.ConnectionStrings["MainDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(consString))
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
            {
                //Set the database table name
                sqlBulkCopy.DestinationTableName = "Truong";
                con.Open();
                sqlBulkCopy.WriteToServer(dt);
                con.Close();
            }
        }
    }

    protected void buttonExportPDF_Click(object sender, EventArgs e)
    {
        Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
        PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("D://Test.pdf", FileMode.Create));
        doc.Open();
        Paragraph paragraph = new Paragraph("Testing pdf file");
        doc.Add(paragraph);
        doc.Close();
    }

    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
}
