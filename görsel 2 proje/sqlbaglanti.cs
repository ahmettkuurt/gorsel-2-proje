using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace görsel_2_proje
{
    internal class sqlbaglanti
    {
        string baglanti_cumlesi ="Data Source=AHMET\\SQLEXPRESS;Initial Catalog=görsel2proje;Integrated Security=True";
        public DataTable dt = new DataTable();
        public string FirmaAdi = "Kurt TECH V1.0";
        public string ProAdi = "Satış ve Teknik Takip Programı";
        public string Versiyon = Application.ProductVersion;


        // Takipler için datagride stün oluşturma
        public object TakipSutunOlustur()
        {
            //Yeni veri tablosu oluştur

            DataColumn sutun;

            sutun = new DataColumn("Takip Id");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Takip No");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Cihaz Marka");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Cihaz Model");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Cihaz İmei");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Cihaz SeriNo");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Müşteri Ad Soyad");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Müşteri Telefon");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Cihaz Giriş Tarihi");
            sutun.DataType = Type.GetType("System.DateTime");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Cihaz Çıkış Tarihi");
            sutun.DataType = Type.GetType("System.DateTime");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Takip Durum");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);
            return dt;
        }

        // Satışlar stün oluştur
        public object SatisStunOlustur()
        {
            //Yeni veri tablosu oluştur

            DataColumn sutun;

            sutun = new DataColumn("Satış Id");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Satış Ürün");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Satış Müşteri");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Satış Tarihi");
            sutun.DataType = Type.GetType("System.DateTime");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Satış Notu");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            return dt;
        }

        // Müşteriler için datagride stün oluşturma
        public object SutunOlustur()
        {
            //Yeni veri tablosu oluştur

            DataColumn sutun;

            sutun = new DataColumn("Müşteri Id");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Adı Soyadı");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Telefon");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Bakiye");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Kayıt Tarihi");
            sutun.DataType = Type.GetType("System.DateTime");
            dt.Columns.Add(sutun);

            return dt;
        }

        // Ürünler için datagride stün oluşturma
        public object UrunSutunOlustur()
        {
            //Yeni veri tablosu oluştur

            DataColumn sutun;

            sutun = new DataColumn("Ürün Id");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Ürün Barkod");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Ürün Adı");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Satış Fiyatı");
            sutun.DataType = Type.GetType("System.String");
            dt.Columns.Add(sutun);

            sutun = new DataColumn("Eklenme Tarihi");
            sutun.DataType = Type.GetType("System.DateTime");
            dt.Columns.Add(sutun);

            return dt;
        }

        // Bağlantı kodu
        public string Baglanti_Kodu()
        {
            return baglanti_cumlesi;
        }
        // Bağlantı açma || kapatma
        public string BaglantiKontrol()
        {
            try
            {
                SqlConnection komut_baglan = new SqlConnection(baglanti_cumlesi);
                komut_baglan.Open();
                komut_baglan.Close();
                return "1";
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        // Veritabanına veri ekleme sorgusu
        public byte Ekle(string tabloadi, string sql1, string sql2)
        {
            try
            {
                int etkilenme = 0;
                SqlConnection baglan = new SqlConnection(baglanti_cumlesi);
                SqlCommand komutinsert = new SqlCommand();


                komutinsert.CommandText = "INSERT INTO " + tabloadi + " (" + sql1 + ") VALUES (" + sql2 + ")";
                komutinsert.Connection = baglan;
                baglan.Open();
                etkilenme = komutinsert.ExecuteNonQuery();
                baglan.Close();
                if (etkilenme > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        // Veritabanından veri silme sorgusu
        public byte Sil(string tabloadi, string sql1)
        {
            try
            {
                int etkilenme = 0;
                SqlConnection baglan = new SqlConnection(baglanti_cumlesi);
                SqlCommand komutdelete = new SqlCommand();


                komutdelete.CommandText = "DELETE FROM " + tabloadi + " WHERE " + sql1 + "";
                komutdelete.Connection = baglan;
                baglan.Open();
                etkilenme = komutdelete.ExecuteNonQuery();
                baglan.Close();
                if (etkilenme > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        // Veritabanında güncelleme yapma sorgusu
        public byte Guncelle(string tabloadi, string sql1, string sql2)
        {
            try
            {
                int etkilenme = 0;
                SqlConnection baglan = new SqlConnection(baglanti_cumlesi);
                SqlCommand komutupdate = new SqlCommand();


                komutupdate.CommandText = "UPDATE " + tabloadi + " SET " + sql1 + " WHERE " + sql2 + "";
                komutupdate.Connection = baglan;
                baglan.Open();
                etkilenme = komutupdate.ExecuteNonQuery();
                baglan.Close();
                if (etkilenme > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        // İlk harfkeri büyütme fonksiyonu
        public string IlkHarfleriBuyut(string metin)
        {
            try
            {
                System.Globalization.CultureInfo cultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture;
                System.Globalization.TextInfo textInfo = cultureInfo.TextInfo;
                return textInfo.ToTitleCase(metin);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
    }
}
