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
using görsel_2_proje.musteri;

namespace görsel_2_proje.musteri
{
    public partial class MusteriGüncelle : Form
    {
        public MusteriGüncelle()
        {
            InitializeComponent();
        }
        sqlbaglanti sb=new sqlbaglanti();
        public string id, Mad = "", Msoyad = "";

        private void MusteriGuncelle2_Load(object sender, EventArgs e)
        {
            
        }

        private void AramaMusteriAdi_TextChanged(object sender, EventArgs e)
        {
            if (AramaMusteriAdi.Text.Length > 0)
            {
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
                    Musteri_adi_combo.SelectedIndex = 0;
                    Musteri_adi_combo.Enabled = true;
                    MusteriBilgiGrup.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Aranan isme / soyisme göre müşteri bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                baglanti.Close();
            }
            else
            {
                Musteri_adi_combo.SelectedIndex = -1;
                Musteri_adi_combo.Enabled = false;
            }
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
                object sn = MusteriSorgu.ExecuteScalar();
                if (sn != null)
                {
                    MusteriBilgi = MusteriSorgu.ExecuteReader(); MusteriBilgi.Read();
                    id = MusteriBilgi["Musteri_id"].ToString();
                    Musteri_adi.Text = MusteriBilgi["Musteri_adi"].ToString(); Musteri_soyadi.Text = MusteriBilgi["Musteri_soyadi"].ToString();
                    this.Text = MusteriBilgi["Musteri_adi"].ToString() + " " + MusteriBilgi["Musteri_soyadi"].ToString() + " - Müşteri Güncelleme";
                    Musteri_telefonu.Text = MusteriBilgi["Musteri_telefon"].ToString(); Musteri_adresi.Text = MusteriBilgi["Musteri_adres"].ToString();
                    Musteri_bakiye.Text = float.Parse(MusteriBilgi["Musteri_bakiye"].ToString()).ToString();
                    if (float.Parse(MusteriBilgi["Musteri_bakiye"].ToString()) < -1) label3.Visible = true;

                    // Genel Ad ve Soyad
                    Mad = MusteriBilgi["Musteri_adi"].ToString();
                    Msoyad = MusteriBilgi["Musteri_soyadi"].ToString();
                    // Genel Ad ve Soyad

                    baglanti.Close();
                    // Müşteri bilgileri //
                }
                else
                {
                    MessageBox.Show("Sistemsel bir hata oluştu, lütfen sağlayıcınıza başvurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglanti.Close();
            }
            else
            {
                MusteriBilgiGrup.Enabled = false;
                Musteri_adi.Text = ""; Musteri_soyadi.Text = ""; Musteri_adresi.Text = ""; Musteri_telefonu.Text = ""; Musteri_bakiye.Text = "0";
            }
        }

        private void ButonAramayaGoreGuncelle_Click(object sender, EventArgs e)
        {
            Musteri_adi.Text = Musteri_adi.Text.Replace("'", "’");
            Musteri_soyadi.Text = Musteri_soyadi.Text.Replace("'", "’");
            Musteri_adresi.Text = Musteri_adresi.Text.Replace("'", "’");
            Musteri_adi.Text = sb.IlkHarfleriBuyut(Musteri_adi.Text);
            Musteri_soyadi.Text = sb.IlkHarfleriBuyut(Musteri_soyadi.Text);
            string ad, soyad, telefon, adres;
            ad = Musteri_adi.Text; soyad = Musteri_soyadi.Text; telefon = Musteri_telefonu.Text;adres = Musteri_adresi.Text;
            if ((ad != "" && ad.Length >= 3) && (soyad != "" && soyad.Length >= 3) && (telefon != "" && telefon.Length >= 10) && (adres != ""))
            {
                SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());


                if (Musteri_bakiye.Text == "") Musteri_bakiye.Text = "0";
                else Musteri_bakiye.Text = Musteri_bakiye.Text.Replace(',', '.');

                if (Musteri_adi.Text == Mad && Musteri_soyadi.Text == Msoyad)
                {
                    // Müşteriyi güncelle //
                    byte sonuc;
                    sonuc = sb.Guncelle("Musteriler", "Musteri_adi='" + ad + "', Musteri_soyadi='" + soyad + "', Musteri_telefon='" + telefon + "', Musteri_adres='" + sb.IlkHarfleriBuyut(adres)+ "', Musteri_bakiye='" + Musteri_bakiye.Text + "'", "Musteri_id='" + id + "'");
                    if (sonuc == 1)
                    {
                        MessageBox.Show("Müşteri başarıyla güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Müşteri güncellenemedi ( Hata kodu: M-07 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Müşteriyi güncelle //
                }
                else
                {
                    // kontrol
                    baglanti.Open();
                    SqlCommand MusteriKontrol = new SqlCommand("SELECT * FROM MUSTERILER WHERE Musteri_adi='" + Musteri_adi.Text + "' and Musteri_soyadi='" + Musteri_soyadi.Text + "'", baglanti);
                    object kontrol = MusteriKontrol.ExecuteScalar();
                    if (kontrol == null)
                    {

                        // Müşteriyi güncelle //
                        byte sonuc;
                        sonuc = sb.Guncelle("Musteriler", "Musteri_adi='" + ad + "', Musteri_soyadi='" + soyad + "', Musteri_telefon='" + telefon + "', Musteri_adres='" + adres + "', Musteri_bakiye='" + Musteri_bakiye.Text + "'", "Musteri_id='" + id + "'");
                        if (sonuc == 1)
                        {
                            MessageBox.Show("Müşteri başarıyla güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Müşteri güncellenemedi ( Hata kodu: M-07 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Müşteriyi güncelle //
                    }
                    else
                    {
                        MessageBox.Show("Güncellemek istediğiniz müşteri sistemde kayıtlıdır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    baglanti.Close();
                }

            }
            else
            {
                MessageBox.Show("Lütfen boş alan bırakmayın ve bilgileri doğru şekilde doldurun", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void katekle_Click(object sender, EventArgs e)
        {

        }

        private void Musteri_kategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Musteri_telefonu_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }



        private void Musteri_bakiye_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44 && e.KeyChar != (char)46 && e.KeyChar != (char)45)
            {
                e.Handled = true;
            }
        }
    }
}
