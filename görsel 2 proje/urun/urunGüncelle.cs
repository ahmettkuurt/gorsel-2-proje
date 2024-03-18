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
    public partial class urunGüncelle : Form
    {
        public urunGüncelle()
        {
            InitializeComponent();
        }
        sqlbaglanti sb = new sqlbaglanti();
        string id;
        private void UrunAdi_TextChanged(object sender, EventArgs e)
        {
            if (UrunAdi.Text.Length > 0)
                UrunBarkodaGoreGrup.Enabled = false;
            else
                UrunBarkodaGoreGrup.Enabled = true;
        }

        private void BarkodNo_TextChanged(object sender, EventArgs e)
        {
            if (BarkodNo.Text.Length > 0)
                UrunAdaGoreGrup.Enabled = false;
            else
                UrunAdaGoreGrup.Enabled = true;
        }

        private void urunGüncelle_Load(object sender, EventArgs e)
        {
            try
            {
                
                // Bağlantı //
                SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                // Bağlantı //

                
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AramaButonAd_Click(object sender, EventArgs e)
        {
            UrunAdi.Text = UrunAdi.Text.Replace("'", "’");
            UrunAraisim();
        }

        private void AramaButonBarkod_Click(object sender, EventArgs e)
        {
            BarkodNo.Text = BarkodNo.Text.Replace("'", "’");
            UrunAraBarkod();
        }

        private void barkodlu_CheckedChanged(object sender, EventArgs e)
        {
            if (barkodlu.Checked == true)
            {
                UrunBarkod.Text = "Barkod Eklenmedi";
                UrunBarkod.Enabled = false;
            }
            else
            {
                UrunBarkod.Text = "";
                UrunBarkod.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Ürün bilgileri //
                string urunadi = comboBox1.Text;
                SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                SqlDataReader UrunBilgi;
                SqlCommand MusteriSorgu = new SqlCommand("SELECT * FROM Urunler WHERE Urun_adi='" + urunadi + "' or Urun_adi='" + sb.IlkHarfleriBuyut(urunadi) + "'", baglanti);
                baglanti.Open();
                UrunBilgi = MusteriSorgu.ExecuteReader(); UrunBilgi.Read();
                id = UrunBilgi["Urun_id"].ToString();
                UrunAd.Text = UrunBilgi["Urun_adi"].ToString();
                this.Text = UrunBilgi["Urun_adi"].ToString() + " - Ürün Güncelleme";
                if (Convert.ToInt64(UrunBilgi["Urun_barkodNo"].ToString()) == 0)
                {
                    barkodlu.Checked = true;
                    UrunBarkod.Text = "Barkod Eklenmedi";
                }
                else
                {
                    barkodlu.Checked = false;
                    UrunBarkod.Text = UrunBilgi["Urun_barkodNo"].ToString();
                }
                UrunFiyat.Text = float.Parse(UrunBilgi["Urun_fiyat"].ToString()).ToString();
                AlisFiyat.Text = float.Parse(UrunBilgi["Urun_alisFiyat"].ToString()).ToString();

                baglanti.Close();
                // Ürün bilgileri //


            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                UrunAd.Text = UrunAd.Text.Replace("'", "’");
                UrunFiyat.Text = UrunFiyat.Text.Replace(',', '.');
                AlisFiyat.Text = AlisFiyat.Text.Replace(',', '.');
                if (UrunAd.Text != "" && UrunAd.Text.Length > 3 && UrunFiyat.Text != "" && AlisFiyat.Text != "")
                {

                 

                    if (barkodlu.Checked == true)
                    {
                        byte sonuc;
                        sonuc = sb.Guncelle("Urunler", "Urun_adi='" + sb.IlkHarfleriBuyut(UrunAd.Text) + "', Urun_fiyat='" + UrunFiyat.Text + "', Urun_alisFiyat='" + AlisFiyat.Text +  "'", "Urun_id='" + id + "'");
                        if (sonuc == 1)
                        {
                            MessageBox.Show("Ürün başarıyla güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (UrunAdi.Text != "")
                            {
                                comboBox1.Items.Clear();
                                UrunAdi.Text = UrunAd.Text;
                                UrunAraisim();
                                comboBox1.Text = UrunAd.Text;
                            }
                            else
                            {
                                comboBox1.Items.Clear();
                                BarkodNo.Text = UrunBarkod.Text;
                                UrunAraBarkod();
                                comboBox1.Text = UrunAd.Text;
                            }
                        }
                        else
                            MessageBox.Show("Ürün güncellenemedi ( Hata kodu: U-07 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (UrunBarkod.Text.Length > 14)
                        {
                            byte sonuc;
                            sonuc = sb.Guncelle("Urunler", "Urun_adi='" + UrunAd.Text + "', Urun_fiyat='" + UrunFiyat.Text + "', Urun_alisFiyat='" + AlisFiyat.Text +  "', Urun_barkodNo='" + UrunBarkod.Text + "'", "Urun_id='" + id + "'");
                            if (sonuc == 1)
                            {
                                MessageBox.Show("Ürün başarıyla güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (UrunAdi.Text != "")
                                {
                                    comboBox1.Items.Clear();
                                    UrunAdi.Text = UrunAd.Text;
                                    UrunAraisim();
                                    comboBox1.Text = UrunAd.Text;
                                }
                                else
                                {
                                    comboBox1.Items.Clear();
                                    BarkodNo.Text = UrunBarkod.Text;
                                    UrunAraBarkod();
                                    comboBox1.Text = UrunAd.Text;
                                }
                            }
                            else
                                MessageBox.Show("Ürün güncellenemedi ( Hata kodu: U-07 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Barkod numarasını 15 hane olarak giriniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Boş alanları doldurunuz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UrunFiyat_TextChanged(object sender, EventArgs e)
        {

        }

        private void UrunFiyat_Validating(object sender, CancelEventArgs e)
        {
        }

        private void BarkodNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }



        private void AlisFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }

        private void UrunFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && e.KeyChar != (char)08 && e.KeyChar != (char)44 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
        }

        private void UrunBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void UrunAraisim()
        {
            try
            {
                if (UrunAdi.Text != "")
                {
                    // ad soyada göre arattır
                    SqlDataReader oku; object urunadi;
                    SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                    SqlConnection baglanti2 = new SqlConnection(sb.Baglanti_Kodu());
                    SqlCommand UrunAdSorgu = new SqlCommand("SELECT * FROM Urunler where Urun_adi like '%" + UrunAdi.Text + "%' or Urun_adi like '%" + sb.IlkHarfleriBuyut(UrunAdi.Text) + "%'", baglanti);
                    baglanti.Open();
                    urunadi = UrunAdSorgu.ExecuteScalar();
                    if (urunadi != null)
                    {
                        comboBox1.Items.Clear();
                        oku = UrunAdSorgu.ExecuteReader();
                        label3.Enabled = true; comboBox1.Enabled = true; UrunGuncelleme.Enabled = true;
                        while (oku.Read())
                        {
                            comboBox1.Items.Add(oku["Urun_adi"].ToString());
                            comboBox1.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ürün bulunamadı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Ürün adını girin. ( Hata kodu: U-01 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UrunAraBarkod()
        {
            try
            {
                // barkoda göre arattır
                if (BarkodNo.Text.Length > 14)
                {
                    SqlDataReader oku; object barkod;
                    SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                    SqlConnection baglanti2 = new SqlConnection(sb.Baglanti_Kodu());
                    SqlCommand UrunBarkodSorgu = new SqlCommand("SELECT * FROM Urunler where Urun_barkodNo='" + BarkodNo.Text + "'", baglanti);
                    baglanti.Open();
                    barkod = UrunBarkodSorgu.ExecuteScalar();
                    if (barkod != null)
                    {
                        comboBox1.Items.Clear(); label3.Enabled = true; comboBox1.Enabled = true; UrunGuncelleme.Enabled = true;
                        oku = UrunBarkodSorgu.ExecuteReader();
                        while (oku.Read())
                        {
                            comboBox1.Items.Add(oku["Urun_adi"].ToString());
                            comboBox1.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ürün bulunamadı. Tam barkod numarasını girin veya okutun", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Barkod numarasını girin. ( Hata kodu: U-02 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
