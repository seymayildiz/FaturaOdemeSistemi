using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Fatura.Siniflar;

namespace E_Fatura.Sayfalar
{
    public partial class Ekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        Yonetici yonet = new Yonetici();
        protected void Button1_Click(object sender, EventArgs e)
        {
            /*ABONE EKLEME */
            String t = tarih.SelectedDate.ToString("dd.MM.yyyy"); //Tarih nesnesini istenilen formata çevirdik.
            // Abone Ekleme metodu
            yonet.aboneEkle(tc.Text, adsoyad.Text, t, telefon.Text, adres.Text, cinsiyet.Text, aboneTuru.Text);
            Response.Redirect("AboneEkle.aspx");    // Sayfa Yenileme ve işlemleri görebilmek için.
        }
    }
}