using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using E_Fatura.Siniflar;
namespace E_Fatura.Sayfalar
{
    public partial class TumAboneler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Yonetici rapor = new Yonetici();
        protected void Button1_Click(object sender, EventArgs e)
        {
            /*-------------------------------------*/

            iTextSharp.text.Document raporum = new iTextSharp.text.Document();
            iTextSharp.text.pdf.BaseFont STF_Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "CP1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font fontNormal = new iTextSharp.text.Font(STF_Helvetica_Turkish, 12, iTextSharp.text.Font.NORMAL); 
            // PDF oluşturması ve konumun belirlenmesi
            Random r = new Random();

            PdfWriter.GetInstance(raporum, new FileStream("C:\\Users\\süleyman\\Desktop\\E-Fatura" + r.Next() + ".pdf", FileMode.Create));

            //PDF yi yazan özelliğine eklenecek

            raporum.AddAuthor("Tüm Abone Listesi"); // PDF Oluşturma Tarihi Ekle

            raporum.AddCreationDate(); // PDF Oluşturma Tarihi

            // PDF oluşturan kişi özelliğine yazılacak

            raporum.AddCreator("Aboneler");

            if (raporum.IsOpen() == false)
            {
                raporum.Open();
            }
            rapor.TumAboneler();
            raporum.Add(new Paragraph("ABONE LISTESI"));
            while (rapor.dr.Read())
            {
                 raporum.Add(new Paragraph("__________________________________________________"));
                 raporum.Add(new Paragraph("Abone Numarasi     : "+rapor.dr["ABONENO"].ToString()));
                 raporum.Add(new Paragraph("TC Kimlik Numarasi : " + rapor.dr["TCKIMLIKNO"].ToString()));
                 raporum.Add(new Paragraph("Abone Ad Soyad     : " + rapor.dr["ADSOYAD"].ToString()));
                 raporum.Add(new Paragraph("Abone Dogum Tarihi : " + rapor.dr["DOGTAR"].ToString()));
                 raporum.Add(new Paragraph("Abone Telefon      : " + rapor.dr["TEL"].ToString()));
                 raporum.Add(new Paragraph("Abone Adres        : " + rapor.dr["ADRES"].ToString()));
                 raporum.Add(new Paragraph("Abone Cinsiyet     : " + rapor.dr["CINSIYET"].ToString()));
                 raporum.Add(new Paragraph("Abone Turu         : " + rapor.dr["ABONETURU"].ToString()));
            }
            Response.Write("PDF Dosyanız Oluşmuştur.");

            raporum.Close();

            /*-------------------------------------*/
        }
    }
}