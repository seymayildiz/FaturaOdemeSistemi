using E_Fatura.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Fatura.Sayfalar
{
    public partial class OdemeYap : System.Web.UI.Page
    {
        Yonetici yonet = new Yonetici();//Yönetici nesnesi oluşturduk.
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "Su") // Su ödemesi yapacaksa
            {
                yonet.suFaturaOde(aboneNo.Text,faturaNo.Text); //Su ödeme metodu
                Response.Write("Ödeme İşlemi Yapılmıştır.");   //Mesaj
            }
            else if (DropDownList1.Text == "Doğalgaz")    // Su ödemesi yapacaksa
            {
                yonet.dogalgazFaturaOde(aboneNo.Text, faturaNo.Text);   //Doğalgaz ödeme metodu
                Response.Write("Ödeme İşlemi Yapılmıştır.");            // MEsaj
            }
            else
            {
                Response.Write("HATA !");    // Herhangi bir hata oluştuğunda
            }
        }
    }
}