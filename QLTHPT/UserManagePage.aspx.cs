using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class UserManagePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Report_btn_Click(object sender, EventArgs e)
    {
        //Response.Redirect("Report.aspx");
    }

    protected void buttonExportPDF_Click(object sender, EventArgs e)
    {
        Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
        PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream("D://Test2.pdf", FileMode.Create));
        doc.Open();
        PdfPTable table = new PdfPTable(GrViewUserInfo.Columns.Count);
        for (int i = 0; i < GrViewUserInfo.Columns.Count; i++)
        {
            table.AddCell(new Phrase(GrViewUserInfo.Columns[i].HeaderText));
        }
        table.HeaderRows = 1;
        for(int j=0;j<GrViewUserInfo.Rows.Count-1; j++)
        {
            for(int k=0;k<GrViewUserInfo.Columns.Count-1;k++)
            {
                if(GrViewUserInfo.Rows[j].Cells[k].Text!=null)
                {
                    table.AddCell(new Phrase((GrViewUserInfo.Rows[j].Cells[k].Text.ToString())));
                }
            }
        }
        doc.Add(table);
        doc.Close();
    }
}