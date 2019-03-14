using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Fatura.Sayfalar
{
    public partial class Anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Yetki"] != null)   //Eğer giriş yapılıp oturum açıldıysa Gridview görünsün.
            {
                Button1.Visible = false;
                Button2.Visible = false;
                if (Session["Yetki"] == "Abone")
                {
                    GridView1.Visible = true;
                }
            }
            else                            //Eğer oturum açılmadıysa Gridview görünmesin.
            {
                Button1.Visible = true;
                Button2.Visible = true;
                GridView1.Visible = false;
            }
            //  Eğer Personel giriş yaptıysa personelin yapabileceği işlemlere giden buton aktif olsun.
            if (Session["Yetki"] != "Personel")
            {
                Button3.Visible = false;
            }
            else
            {
                Button3.Visible = true;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AboneGiris.aspx");   // Yönlendirme
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonelGirisi.aspx"); // Yönlendirme
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AboneEkle.aspx"); // Yönlendirme
        }
    }
}