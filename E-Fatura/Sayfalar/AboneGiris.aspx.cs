using E_Fatura.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Fatura.Sayfalar
{
    public partial class AboneGiris : System.Web.UI.Page
    {
        Yonetici yonet = new Yonetici();    // Yönetim Classındaki metotları kullanabilmek için NESNE(MİZ)'i oluşturduk.
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void aboneGirisYap_Click(object sender, EventArgs e)
        {
            yonet.aboneGirisi(aboneNo.Text, tcKimlik.Text); /*Giriş için TC Kimlik No ve Abone Numarası parametre olarak gönderilir */
            if (yonet.kontrol > 0) /*Eğer kullanıcı varsa kontrol 0'dan büyük olur. */
            {
                // Session Global bir değişkendir. 
                //Diğer sayfalarda da kullanılabilir ve değeri biz istemedikçe silinmez.
                Session["Yetki"] = "Abone";             //Session Yetki değerini Abone olarak belirledik.
                Session["AdSoyad"] = yonet.ad;          //Session Ad - Soyad değerini girdiğimiz ad-soyad olarak belirledik.
                Session["AboneNo"] = aboneNo.Text;      //Session Abone Numarasını değerini girdiğimiz abone numarası olarak belirledik.
                Session["AboneNu"] = aboneNo.Text;      //Session Abone Numarasını değerini girdiğimiz abone numarası olarak belirledik.
                Response.Redirect("Anasayfa.aspx");     //Sayfa Yönlendirme için
            }
            else
            {
                Session["Yetki"] = null;    // Giriş yapılan bilgiler eğer veritabanında mevcut değilse giriş yapmaz.
            }
        }
    }
}