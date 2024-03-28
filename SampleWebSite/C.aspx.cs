using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class C : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void C_img_pdf_click (object sender, EventArgs e)
    {
        Response.ContentType = "Application/pdf";
        Response.AppendHeader("Content-Disposition", "attachment; filename=cprogramming_book.pdf");
        Response.TransmitFile(Server.MapPath("~/PDF_Files/cprogramming_book.pdf"));
        Response.End();
    }
}