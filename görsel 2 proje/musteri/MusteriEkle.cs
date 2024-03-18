using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace görsel_2_proje.musteri
{
    public partial class MusteriEkle : Form
    {
        public MusteriEkle()
        {
            InitializeComponent();
        }
        sqlbaglanti sb=new sqlbaglanti();

        private void MusteriEkle_Load(object sender, EventArgs e)
        {
            
        }

        private void ButonEkle_Click(object sender, EventArgs e)
        {
            MusAdi.Text = MusAdi.Text.Replace("'", "’");
            MusSoyadi.Text = MusSoyadi.Text.Replace("'", "’");
            MusAdresi.Text = MusAdresi.Text.Replace("'", "’");
            byte kayit;
            MusAdi.Text = sb.IlkHarfleriBuyut(MusAdi.Text);
            MusSoyadi.Text = sb.IlkHarfleriBuyut(MusSoyadi.Text);
            if (MusAdi.Text != "" && MusSoyadi.Text != "" && MusAdresi.Text != "" && MusTelefonu.Text != "")
            {
                string adi, soyadi, adresi, tarih;
                string telefonu;
                adi = MusAdi.Text;
                soyadi = MusSoyadi.Text;
                adresi = MusAdresi.Text;
                telefonu = MusTelefonu.Text;
                tarih = DateTime.Now.Year.ToString(); tarih += '-' + DateTime.Now.Month.ToString(); tarih += '-' + DateTime.Now.Day.ToString();
                // kategori id çekme
                SqlConnection baglan = new SqlConnection(sb.Baglanti_Kodu());
                SqlDataReader oku;
                // kategor id çekme

                baglan.Open();
                SqlCommand MusteriKontrol = new SqlCommand("SELECT * FROM Musteriler WHERE Musteri_adi='" + adi + "' and Musteri_soyadi='" + soyadi + "'", baglan);
                object kontrol = MusteriKontrol.ExecuteScalar();
                if (kontrol == null)
                {
                    kayit = sb.Ekle("Musteriler", "Musteri_adi,Musteri_soyadi,Musteri_adres,Musteri_telefon,Musteri_kayitTarihi,Musteri_bakiye", "'" + adi + "','" + soyadi + "','" + sb.IlkHarfleriBuyut(adresi) + "','" + telefonu + "','" + tarih  + "','0'");
                    if (kayit == 1)
                    {
                        MessageBox.Show("Müşteri başarıyla eklenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MusAdi.Text = ""; MusAdresi.Text = ""; MusSoyadi.Text = ""; MusTelefonu.Text = "";
                    }
                    else
                        MessageBox.Show("Müşteri eklenemedi ( Hata kodu: M-03 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Eklemek istediğiniz müşteri sistemde kayıtlıdır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Boş alanları doldurun! ( Hata kodu: M-04 )", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MusTelefonu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
