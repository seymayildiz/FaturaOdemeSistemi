using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient; /*SQL Kütüphaneleri */
using System.Data;

namespace E_Fatura.Siniflar
{
    public class Baglanti
    {
        public SqlCommand cmd; /* SQL sorgu komutları için*/
        public SqlDataAdapter da; /* Veritabanı arasındaki sorguları çalıştırmamızı sağlar*/
        public SqlDataReader dr;/* Sql sorgularını okur*/
        public DataTable dt;/* sorgudan gelen verileri tablo şeklinde tutar. */
        public string sorgu = "";/*Sorgu değişkenimiz */
        /* SqlConnection bağlantıyı sağlayan bilgiler içerir.*/
        public SqlConnection baglan = new SqlConnection("Data Source=SÜLEYMANAYAZ\\SQLEXPRESS;Initial Catalog=FATURAODEME;Integrated Security=True");
        /* Veritabanı bağlantısını açar... */
        public void baglantiAc()
        {
            if (baglan.State == ConnectionState.Closed)
            {
                baglan.Open();
            }
        }
        /* Veritabanı bağlantısını kapatır... */
        public void baglantiKapat()
        {
            if (baglan.State == ConnectionState.Open)
            {
                baglan.Close();
            }
        }
    }
}