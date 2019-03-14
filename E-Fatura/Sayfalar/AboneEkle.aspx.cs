using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Fatura.Siniflar;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace E_Fatura.Sayfalar
{
    public partial class AboneEkle : System.Web.UI.Page
    {
        Yonetici yonet = new Yonetici();    // Yönetim Classındaki metotları kullanabilmek için NESNE(MİZ)'i oluşturduk.
        protected void Page_Load(object sender, EventArgs e)
        {
            // Buradaki işlem, bu sayfaya sadece Personel giriş yapıp görebilirliğini sağlamak için kpşul koymak.
            if (!IsPostBack)    // Sayfa yüklendiğinde işlemler yapılacak
            {
                if (Session["Yetki"] != null) //Yetki Session değeri null değilse, doluysa girişi Personel mi yapmış bakıyoruz.
                {
                    if (Session["Yetki"].ToString() != "Personel")  //Eğer Personel giriş yapmadıysa 
                    {
                        Response.Redirect("Anasayfa.aspx");  //Anasayfaya yönlendir. Değilse işlem yapabilir, Abone ekleyebilir, güncelleyip silebilir.
                    }
                }
                else        //Eğer Yetki null ise (boşsa) Anasayfaya git.
                {
                    Response.Redirect("Anasayfa.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*ABONE EKLEME */
            //String t = tarih.SelectedDate.ToString("dd.MM.yyyy"); //Tarih nesnesini istenilen formata çevirdik.
            // Abone Ekleme metodu
            yonet.aboneEkle(tc.Text, adsoyad.Text, dogum.Text, telefon.Text,adres.Text,cinsiyet.Text, aboneTuru.Text);
            Response.Redirect("AboneEkle.aspx");    // Sayfa Yenileme ve işlemleri görebilmek için.
        }

        protected void Button2_Click(object sender, EventArgs e)
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
            yonet.TumAboneler();
            raporum.Add(new Paragraph("ABONE LISTESI"));
            while (yonet.dr.Read())
            {
                raporum.Add(new Paragraph("__________________________________________________"));
                raporum.Add(new Paragraph("Abone Numarasi     : " + yonet.dr["ABONENO"].ToString()));
                raporum.Add(new Paragraph("TC Kimlik Numarasi : " + yonet.dr["TCKIMLIKNO"].ToString()));
                raporum.Add(new Paragraph("Abone Ad Soyad     : " + yonet.dr["ADSOYAD"].ToString()));
                raporum.Add(new Paragraph("Abone Dogum Tarihi : " + yonet.dr["DOGTAR"].ToString()));
                raporum.Add(new Paragraph("Abone Telefon      : " + yonet.dr["TEL"].ToString()));
                raporum.Add(new Paragraph("Abone Adres        : " + yonet.dr["ADRES"].ToString()));
                raporum.Add(new Paragraph("Abone Cinsiyet     : " + yonet.dr["CINSIYET"].ToString()));
                raporum.Add(new Paragraph("Abone Turu         : " + yonet.dr["ABONETURU"].ToString()));
            }
            Response.Write("PDF Dosyanız Oluşmuştur.");

            raporum.Close();

            /*-------------------------------------*/
        }
    }
}