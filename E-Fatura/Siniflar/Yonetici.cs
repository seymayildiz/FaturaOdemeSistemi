using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Web.UI.WebControls;
using System.Drawing;

namespace E_Fatura.Siniflar
{
    public class Yonetici:Baglanti /* Bağlantı Class'ını kalıtım aldık. */
    {
        public byte kontrol = 0; //Kullanıcı kontrolü için gerekli
        public String tc,ad; //Kullanıcı bilgilerini almak için kullanılacak
        public DataSet ds;

        /*********************Personel Girişi Metodu**************************/
        public void yoneticiGirisi(String tc,String sifre)
        {
            baglantiAc();
           
            cmd = new SqlCommand("SELECT * FROM PERSONEL WHERE TCKIMLIKNO = @tc AND SIFRE = @sifre",baglan);/**Sorgumuzu yazdık */
            /* Parametreleri gönderiyoruz ... */
            cmd.Parameters.AddWithValue("@tc", tc);  // TC parametresi parametresi sorguya gönderilir...   
            cmd.Parameters.AddWithValue("@sifre", sifre);   // Şifre parametresi sorguya gönderilir...
            dr = cmd.ExecuteReader(); // Okuyucuya çalıştırılan sorgudan gelen veriler gönderilir...
            while (dr.Read()) // Verilerin tümünün okunması
            {
                kontrol++;  //Eğer kullanıcı varsa kontrol artacaktır
                tc = dr["TCKIMLIKNO"].ToString();  //TC Kimlik Numarasını hafızaya aldık...
                ad = dr["ADSOYAD"].ToString();
            } 
        }
        /*********************Abone Girişi Metodu**************************/
        public void aboneGirisi(String aboneNo, String tc)
        {
            baglantiAc();

            cmd = new SqlCommand("SELECT * FROM ABONE WHERE TCKIMLIKNO = @tc AND ABONENO = @aboneNo", baglan);/**Sorgumuzu yazdık */
            /* Parametreleri gönderiyoruz ... */
            cmd.Parameters.AddWithValue("@tc", tc);  // TC parametresi parametresi sorguya gönderilir...   
            cmd.Parameters.AddWithValue("@aboneNo", aboneNo);   // Abone No parametresi sorguya gönderilir...
            dr = cmd.ExecuteReader(); // Okuyucuya çalıştırılan sorgudan gelen veriler gönderilir...
            while (dr.Read()) // Verilerin tümünün okunması
            {
                kontrol++;  //Eğer kullanıcı varsa kontrol artacaktır
                tc = dr["TCKIMLIKNO"].ToString();  //TC Kimlik Numarasını hafızaya aldık...
                ad = dr["ADSOYAD"].ToString();
            }
        }
        /**********************Abone Ekleme Metodu****************************************/
        public void aboneEkle(String tc,String adsoyad,String tarih,String tel,String adres,String cinsiyet,String aboneturu)
        {
            baglantiAc();
            cmd = new SqlCommand("PROC_ABONE_EKLE @tc=@tc, @adsoyad = @adsoyad, @dogtarih=@tarih,@tel=@tel,	@adres=@adres,@cinsiyet=@cinsiyet, @aboneturu=@aboneturu",baglan);
            cmd.Parameters.AddWithValue("@tc", tc);
            cmd.Parameters.AddWithValue("@adsoyad", adsoyad);
            cmd.Parameters.AddWithValue("@tarih", tarih);
            cmd.Parameters.AddWithValue("@tel", tel);
            cmd.Parameters.AddWithValue("@adres", adres);
            cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
            cmd.Parameters.AddWithValue("@aboneturu", aboneturu);
            cmd.ExecuteNonQuery();
            baglantiKapat();
        }
        /**********************Abone Doğalgaz Fatura Bilgisi Arama Metodu*********************/
        public Boolean dogalgazFaturaSorgula(String aboneNo)
        {
            baglantiAc();

            cmd = new SqlCommand("SELECT * FROM DOGALGAZ_FATURA_BILGILERI WHERE ABONENO = @aboneNo", baglan);/**Sorgumuzu yazdık */
            /* Parametreleri gönderiyoruz ... */
            cmd.Parameters.AddWithValue("@aboneNo", aboneNo);  // TC parametresi parametresi sorguya gönderilir...
            int kayitSayisi = Convert.ToInt32(cmd.ExecuteScalar());
            baglantiKapat();
            if (kayitSayisi <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /**********************Abone Su Fatura Bilgisi Arama Metodu*********************/
        public Boolean suFaturaSorgula(String aboneNo)
        {
            baglantiAc();

            cmd = new SqlCommand("SELECT * FROM SU_FATURA_BILGILERI WHERE ABONENO = @aboneNo", baglan);/**Sorgumuzu yazdık */
            /* Parametreleri gönderiyoruz ... */
            cmd.Parameters.AddWithValue("@aboneNo", aboneNo);  // TC parametresi parametresi sorguya gönderilir...
            int kayitSayisi = Convert.ToInt32(cmd.ExecuteScalar());
            baglantiKapat();
            if (kayitSayisi <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /**********************Abone Su Faturası Öde Metodu*********************/
        public void suFaturaOde(String aboneNo,String faturaNo)
        {
            baglantiAc();

            cmd = new SqlCommand("UPDATE SU_FATURA_BILGILERI SET ODEMEDURUMU=@ODEMEDURUMU WHERE ABONENO = @aboneNo AND FATURANO=@faturaNo", baglan);/**Sorgumuzu yazdık */
            /* Parametreleri gönderiyoruz ... */
            cmd.Parameters.AddWithValue("@aboneNo", aboneNo);
            cmd.Parameters.AddWithValue("@faturaNo", faturaNo);
            cmd.Parameters.AddWithValue("@ODEMEDURUMU", "Ödendi");
            cmd.ExecuteNonQuery();
            baglantiKapat();          
        }
        /**********************Abone Doğalgaz Faturası Öde Metodu*********************/
        public void dogalgazFaturaOde(String aboneNo,String faturaNo)
        {
            baglantiAc();

            cmd = new SqlCommand("UPDATE DOGALGAZ_FATURA_BILGILERI SET ODEMEDURUMU=@ODEMEDURUMU WHERE ABONENO = @aboneNo AND FATURANO=@faturaNo", baglan);/**Sorgumuzu yazdık */
            /* Parametreleri gönderiyoruz ... */
            cmd.Parameters.AddWithValue("@aboneNo", aboneNo);
            cmd.Parameters.AddWithValue("@faturaNo", faturaNo);
            cmd.Parameters.AddWithValue("@ODEMEDURUMU", "Ödendi");
            cmd.ExecuteNonQuery();
            baglantiKapat();          
        }
        /*********************Aboneler Metodu**************************/
        public void TumAboneler()
        {
            baglantiAc();

            cmd = new SqlCommand("SELECT * FROM ABONE", baglan);/**Sorgumuzu yazdık */
            dr = cmd.ExecuteReader(); // Okuyucuya çalıştırılan sorgudan gelen veriler gönderilir...
            
        }
    }
}