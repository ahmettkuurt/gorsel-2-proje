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

namespace görsel_2_proje.urun
{
    public partial class urunSil : Form
    {
        public urunSil()
        {
            InitializeComponent();
        }
        sqlbaglanti sb=new sqlbaglanti();
        string id;
        private void UrunSil_Load(object sender, EventArgs e)
        {

        }

        private void urunAdi_TextChanged(object sender, EventArgs e, urunSil urunSil)
        {
            try
            {
                if (urunAdi.Text.Length > 0)
                {
                    urunAdi.Text = urunAdi.Text.Replace("'", "’");
                    SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                    SqlDataReader UrunOku; object sonuc;
                    baglanti.Open();
                    SqlCommand UrunAraSorgu = new SqlCommand("SELECT * FROM Urunler WHERE Urun_adi like '%" + urunAdi.Text + "%' or Urun_adi like '%" + sb.IlkHarfleriBuyut(urunAdi.Text) + "%'", baglanti);
                    sonuc = UrunAraSorgu.ExecuteScalar();
                    urunler.Items.Clear();
                    if (sonuc != null)
                    {
                        UrunOku = UrunAraSorgu.ExecuteReader();
                        while (UrunOku.Read())
                        {
                            urunler.Items.Add(UrunOku["Urun_adi"].ToString());
                        }
                        urunler.SelectedIndex = 0;
                        urunler.Enabled = true;
                        urunSil.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Aranan isme / soyisme göre müşteri bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        urunler.Enabled = false;
                        urunSil.Enabled = false;
                    }
                    baglanti.Close();
                }
                else
                {
                    urunler.Enabled = false;
                    urunler.SelectedIndex = -1;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void urunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (urunler.Text.Length > 0)
                {
                    // Üürn bilgileri //
                    string adsoyad = urunler.Text;
                    SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                    SqlDataReader UrunBilgi;
                    SqlCommand MusteriSorgu = new SqlCommand("SELECT * FROM Urunler WHERE Urun_adi='" + urunler.Text + "'", baglanti);
                    baglanti.Open();
                    object s1 = MusteriSorgu.ExecuteScalar();
                    if (s1 != null)
                    {
                        UrunBilgi = MusteriSorgu.ExecuteReader(); UrunBilgi.Read();
                        id = UrunBilgi["Urun_id"].ToString();
                        this.Text = UrunBilgi["Urun_adi"] + " - Müşteri Silinecek";
                        label1.Text = this.Text;

                        // Ürün bilgileri //
                    }
                    else
                    {
                        MessageBox.Show("Sistemsel bir hata oluştu, lütfen sağlayıcınıza başvurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    baglanti.Close();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SilEvet_Click(object sender, EventArgs e)
        {
            try
            {
                byte sonuc;

                SqlConnection baglan = new SqlConnection(sb.Baglanti_Kodu());
                baglan.Open();
                SqlCommand SatisTab = new SqlCommand("SELECT Satis_id FROM Satis WHERE Urun_id='" + id + "'", baglan);
                SqlDataReader SatisIdOku = SatisTab.ExecuteReader();
                while (SatisIdOku.Read())
                {
                    sb.Sil("Satis", "Satis_id='" + SatisIdOku["Satis_id"].ToString() + "'");
                }
                baglan.Close();

                baglan.Open();
                SqlCommand RaporTab = new SqlCommand("SELECT rapor_id FROM Rapor WHERE rapor_satisId='" + id + "'", baglan);
                SqlDataReader RaporIdOku = RaporTab.ExecuteReader();
                while (RaporIdOku.Read())
                {
                    sb.Sil("Rapor", "rapor_id='" + RaporIdOku["rapor_id"].ToString() + "'");
                }
                baglan.Close();

                sonuc = sb.Sil("Urunler", "Urun_id='" + id + "'");
                if (sonuc == 1)
                {
                    MessageBox.Show("Ürün başarıyla silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ürün silinemedi ( Hata kodu: U-09 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SilHayir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Müşteri silme işlemi iptal edilmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}

