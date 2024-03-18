using System;
using görsel_2_proje.musteri;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace görsel_2_proje.Formlar
{
    public partial class musteriSil : Form
    {
        public musteriSil()
        {
            InitializeComponent();
        }

        public musteriSil(bool enabled)
        {
            this.enabled = enabled;
        }

        sqlbaglanti sb= new sqlbaglanti();
        string id;
        private bool enabled;




        private void MusteriSil2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'görsel2projeDataSet.Musteriler' table. You can move, or remove it, as needed.
            this.musterilerTableAdapter.Fill(this.görsel2projeDataSet.Musteriler);

        }

        private void SilEvet_Click_1(object sender, EventArgs e)
        {
            byte sonuc;

            SqlConnection baglan = new SqlConnection(sb.Baglanti_Kodu());
            SqlConnection baglan1 = new SqlConnection(sb.Baglanti_Kodu());
            SqlConnection baglan2 = new SqlConnection(sb.Baglanti_Kodu());

            // Müşteri sipariş verdiyse bu siparişleri silicez.

            baglan.Open();
            SqlCommand MusUrun = new SqlCommand("SELECT Urun_id FROM Satis WHERE Musteri_id='" + id + "'", baglan);
            string[] urun_id = new string[0];
            SqlDataReader UrunidOku = MusUrun.ExecuteReader(); int i = 0;
            while (UrunidOku.Read())
            {
                Array.Resize(ref urun_id, urun_id.Length + 1);
                urun_id[i] = UrunidOku["Satis_urun"].ToString();
                i++;
            }
            baglan.Close();

            foreach (string uid in urun_id)
            {
                baglan.Open();
                SqlCommand SatisTab = new SqlCommand("SELECT Satis_id FROM Satis WHERE Satis_urun='" + uid + "'", baglan);
                SqlDataReader SatisIdOku = SatisTab.ExecuteReader();
                while (SatisIdOku.Read())
                {
                    sb.Sil("Satis", "Satis_id='" + SatisIdOku["Satis_id"].ToString() + "'");
                }
                baglan.Close();

                baglan.Open();
                SqlCommand RaporTab = new SqlCommand("SELECT rapor_id,rapor_sayac FROM Rapor WHERE rapor_satisId='" + uid + "'", baglan);
                SqlDataReader RaporIdOku = RaporTab.ExecuteReader();
                while (RaporIdOku.Read())
                {
                    if (int.Parse(RaporIdOku["rapor_sayac"].ToString()) > 1)
                    {
                        sb.Guncelle("Rapor", "rapor_sayac=rapor_sayac-1", "rapor_id='" + RaporIdOku["rapor_id"].ToString() + "'");
                    }
                    else
                    {
                        sb.Sil("Rapor", "rapor_id='" + RaporIdOku["rapor_id"].ToString() + "'");
                    }
                }
                baglan.Close();
            }

            // Teknik takipleri sil
            baglan.Open();
            SqlCommand TeknikTab = new SqlCommand("SELECT Takip_id FROM Teknik_Takip WHERE Musteri_id='" + id + "'", baglan);
            SqlDataReader Takipid = TeknikTab.ExecuteReader();
            string[] takip_id = new string[0]; int b = 0;
            while (Takipid.Read())
            {
                Array.Resize(ref takip_id, takip_id.Length + 1);
                takip_id[b] = Takipid["Takip_id"].ToString();
                b++;
            }
            baglan.Close();

            foreach (string tid in takip_id)
            {

                sb.Sil("Teknik_TakipIslemler", "Takip_id='" + tid + "'");
                sb.Sil("Teknik_Takip", "Takip_id='" + tid + "'");

            }



            sonuc = sb.Sil("Musteriler", "Musteri_id='" + id + "'");
            if (sonuc == 1)
            {
                MessageBox.Show("Müşteri başarıyla silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Müşteri silinemedi ( Hata kodu: M-09 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SilHayir_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Müşteri silme işlemi iptal edilmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void Musteri_adi_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Musteri_adi_combo.Text.Length > 0)
            {
                // Müşteri bilgileri //
                string adsoyad = Musteri_adi_combo.Text;
                string[] ads = adsoyad.Split(' ');
                SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                SqlDataReader MusteriBilgi;
                SqlCommand MusteriSorgu = new SqlCommand("SELECT * FROM Musteriler WHERE Musteri_adi='" + ads[0] + "' and Musteri_soyadi='" + ads[1] + "'", baglanti);
                baglanti.Open();
                object mK = MusteriSorgu.ExecuteScalar();
                if (mK != null)
                {
                    MusteriBilgi = MusteriSorgu.ExecuteReader(); MusteriBilgi.Read();
                    id = MusteriBilgi["Musteri_id"].ToString();
                    this.Text = MusteriBilgi["Musteri_adi"] + " " + MusteriBilgi["Musteri_soyadi"] + " - Müşteri Silinecek";
                    label1.Text = this.Text;
                    label1.Show();
                }
                else
                {
                    MessageBox.Show("Sistemsel bir hata oluştu, lütfen sağlayıcınızla iletişime geçiniz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                baglanti.Close();
                // Müşteri bilgileri //
            }
            else
            {
                enabled = false;
                label1.Hide();
            }

        }

        private void AramaMusteriAdi_TextChanged(object sender, EventArgs e)
        {
            if (AramaMusteriAdi.Text.Length > 0)
            {
                AramaMusteriAdi.Text = AramaMusteriAdi.Text.Replace("'", "’");
                string adsoyad2 = sb.IlkHarfleriBuyut(AramaMusteriAdi.Text);
                SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                SqlDataReader MusteriOku; object sonuc;
                baglanti.Open();
                SqlCommand MusteriAraSorgu = new SqlCommand("SELECT * FROM Musteriler WHERE Musteri_adi like '%" + AramaMusteriAdi.Text + "%' or Musteri_soyadi like '%" + AramaMusteriAdi.Text + "%' or Musteri_adi like '%" + adsoyad2 + "%' or Musteri_soyadi like '%" + adsoyad2 + "%'", baglanti);
                sonuc = MusteriAraSorgu.ExecuteScalar();
                Musteri_adi_combo.Items.Clear();
                if (sonuc != null)
                {
                    MusteriOku = MusteriAraSorgu.ExecuteReader();
                    while (MusteriOku.Read())
                    {
                        Musteri_adi_combo.Items.Add(MusteriOku["Musteri_adi"].ToString() + " " + MusteriOku["Musteri_soyadi"].ToString());
                    }
                    Musteri_adi_combo.Enabled = true;
                    Musteri_adi_combo.SelectedIndex = 0;
                    
                    label1.Show();
                }
                else
                {
                    MessageBox.Show("Aranan isme / soyisme göre müşteri bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                baglanti.Close();
            }
            else
            {
                Musteri_adi_combo.Enabled = false;
                Musteri_adi_combo.SelectedIndex = -1;

                label1.Hide();
            }
        }
    }
}
