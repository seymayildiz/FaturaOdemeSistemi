using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Fatura.Siniflar;

namespace E_Fatura.Sayfalar
{
    public partial class PersonelGiris : System.Web.UI.Page
    {
        Yonetici yonet = new Yonetici();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            yonet.yoneticiGirisi(tcText.Text, sifreText.Text); /*Giriş için TC Kimlik No ve Şifre parametre olarak gönderilir */
            if (yonet.kontrol > 0 ) /*Eğer kullanıcı varsa kontrol 0'dan büyük olur. */
            {
                Session["Yetki"] = "Personel";  // Personel giriş yaptığını belirledik.
                Session["AdSoyad"] = yonet.ad;  // Kullanmak için Ad - Soyad değerlerini veritabanından çektik.
                Response.Redirect("AboneEkle.aspx");    // Sayfa yönlendirme
            }
            else    // Eğer giriş yapma başarısızsa.
            {
                Session["Yetki"] = null;
            }
        }
    }
}