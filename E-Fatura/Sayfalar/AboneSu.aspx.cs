using E_Fatura.Siniflar;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Fatura.Sayfalar
{
    public partial class AboneSu : System.Web.UI.Page
    {
        Yonetici yonet = new Yonetici();//Yönetici nesnesi oluşturduk.
        protected void Page_Load(object sender, EventArgs e)
        {
            //Eğer Session'da Yetki değeri oluştuysa ve Abone giriş yaptıysa 
            //Sorgulama yapılacak Tool(nesneler) görünmesin diye koşul koyduk.
            if (Session["Yetki"] == "Abone")
            {
                Label1.Visible = false;
                aboneNo.Visible = false;
                Button1.Visible = false;                
            }
            else
            {
                Label1.Visible = true;
                aboneNo.Visible = true;
                Button1.Visible = true;
                
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Abone numarası ile sorgulama yaptık. 
            //Eğer Abone Numarası varsa True değeri döner. sorgula değişkenine true - false değeri atanır.
            Boolean sorgula = yonet.suFaturaSorgula(aboneNo.Text);
            if (sorgula == true)     //True dönerse abone vardır.Eğer abone varsa 
            {
                Session["AboneNu"] = aboneNo.Text;  //Abone girişi için Session'ı doldur.
                // Abone Su Faturası sorguladıysa Session değer oluşturur.
                Session["AboneNo"] = null;  //Bu session Doğalgaz faturası için gereklidir. Bu nedenle içi boştur.
                Response.Redirect("AboneSu.aspx"); //Sayfayı yenilemek için. 
            }
            else    //Eğer abone yoksa Gridview'i boşalt ve uyarı ver.
            {
                GridViewSu.Columns.Clear();
                Response.Write("Hatalı Abone Numarası !");
            }
        }

        protected void GridViewSu_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SuOdemesi")                   // Tıklanılan sütun (Kolon Adı == SuOdemesi ise)
            {
                int index = Convert.ToInt16(e.CommandArgument); // Seçili satır indexini alır..
                TableRow secili = GridViewSu.Rows[index];       // Seçili Satırı değişkene aldık.
                String aboneNo = secili.Cells[1].Text;          // Seçili satırın abone numarasını aldık.
                String faturaNo = secili.Cells[2].Text;         // Seçili satırın fatura numarasını aldık.
                yonet.suFaturaOde(aboneNo, faturaNo);           // Ödeme işlemi metodunu çağırdık...                
                Response.Write("Ödeme Yapıldı...");             // Mesaj verme


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
                raporum.Add(new Paragraph("SU FATURASİ"));
                raporum.Add(new Paragraph("__________________________________________________"));
                raporum.Add(new Paragraph("Abone Numarasi     : " + secili.Cells[0].Text));
                raporum.Add(new Paragraph("Fatura Numarasi    : " + secili.Cells[1].Text));
                raporum.Add(new Paragraph("Fatura Bedeli      : " + secili.Cells[2].Text));
                raporum.Add(new Paragraph("Fatura Tarihi      : " + secili.Cells[3].Text));
                raporum.Add(new Paragraph("Son Ödeme Tarihi   : " + secili.Cells[4].Text));
                raporum.Add(new Paragraph("Odeme Durumu       : " + "Ödenmiştir"));

                Response.Write("PDF Dosyanız Oluşmuştur.");

                raporum.Close();
                Response.Redirect("AboneSu.aspx");              // Yönlendirme...
                /*-------------------------------------*/
            }
        }       
    }
}