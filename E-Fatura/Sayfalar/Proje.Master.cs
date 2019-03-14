using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Fatura.Sayfalar
{
    public partial class Proje : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Eğer yetkisiz giriş yapıldıysa çıkış butonu görünmesin.
            if (Session["Yetki"] != null)
            {
                cikis.Visible = true;
            }
            else    // Eğer oturum açıldıysa oturumu kapatmak için çıkış butonu görünsün.
            {
                cikis.Visible = false;
            }
        }
        protected void cikis_Click(object sender, EventArgs e)
        {
            // Sessionları silip sıfırlıyoruz. Sonra çıkış yaptığından dolayı anasayfaya yönendiriyoruz.
            Session.Abandon();
            Session.Clear();
            Response.Redirect("Anasayfa.aspx");
            Visible = false; // Çıkış butonu görünmesin diye görünümünü kapattık.
        }
    }
}