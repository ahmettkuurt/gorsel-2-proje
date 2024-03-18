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
    public partial class urunGüncelle2 : Form
    {
        public urunGüncelle2()
        {
            InitializeComponent();
        }
        sqlbaglanti sb = new sqlbaglanti();
        public string id;

        private void urunGüncelle2_Load(object sender, EventArgs e)
        {
            try
            {
                
                // Bağlantı //
                SqlConnection baglan = new SqlConnection(sb.Baglanti_Kodu());
                // Bağlantı //

                

                SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu()); SqlConnection baglanti2 = new SqlConnection(sb.Baglanti_Kodu());
                baglanti.Open();
                SqlCommand UrunBilgi = new SqlCommand("SELECT * FROM Urunler WHERE Urun_id='" + id + "'", baglanti);

                SqlDataReader oku;
                oku = UrunBilgi.ExecuteReader(); oku.Read();
                this.Text = oku["Urun_adi"].ToString() + " - Ürün Güncelleme";
                UrunAdi.Text = oku["Urun_adi"].ToString();
                double barkodNum = double.Parse(oku["Urun_barkodNo"].ToString());
                if (barkodNum == 0)
                {
                    UrunBarkod.Text = "Barkod Eklenmedi";
                    UrunBarkod.Enabled = false;
                    barkodlu.Checked = true;
                }
                else
                {
                    UrunBarkod.Enabled = true;
                    barkodlu.Checked = false;
                    UrunBarkod.Text = oku["Urun_barkodNo"].ToString();
                }
                UrunFiyat.Text = float.Parse(oku["Urun_fiyat"].ToString()).ToString();
                AlisFiyat.Text = float.Parse(oku["Urun_alisFiyat"].ToString()).ToString();

                

                groupBox1.Text = oku["Urun_adi"].ToString();
                baglanti.Close();
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
                urunler Uruns = (urunler)Application.OpenForms["Urunler"];
                UrunAdi.Text = UrunAdi.Text.Replace("'", "’");
                UrunFiyat.Text = UrunFiyat.Text.Replace(',', '.');
                AlisFiyat.Text = AlisFiyat.Text.Replace(',', '.');
                string ad, barkod, fiyat;
                ad = UrunAdi.Text; barkod = UrunBarkod.Text; fiyat = UrunFiyat.Text;
                if ((ad != "" && ad.Length > 3) && fiyat != ""  && AlisFiyat.Text != "")
                {
                    

                    if (barkodlu.Checked == true)
                    {
                        // Ürünü güncelle //
                        byte sonuc;
                        sonuc = sb.Guncelle("Urunler", "Urun_barkodNo='0',Urun_adi='" + sb.IlkHarfleriBuyut(ad) + "',Urun_fiyat='" + fiyat + "',Urun_alisFiyat='" + AlisFiyat.Text + "'", "Urun_id='" + id + "'");
                        if (sonuc == 1)
                        {
                            MessageBox.Show("Ürün başarıyla güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (Uruns.UrunAdi.Text != "")
                            {
                                Uruns.GridGuncelle();
                                Uruns.UrunAra();
                            }
                            else if (Uruns.BarkodNo.Text != "")
                            {
                                Uruns.GridGuncelle();
                                Uruns.UrunAraBarkod();
                            }
                            else
                            {
                                Uruns.GridGuncelle();
                                Uruns.FormLoad();
                            }
                        }
                        else
                            MessageBox.Show("Ürün güncellenemedi ( Hata kodu: M-03 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // Ürünü güncelle //
                    }
                    else
                    {
                        barkod = UrunBarkod.Text;
                        if (barkod.Length > 14)
                        {
                            // Ürünü güncelle //
                            byte sonuc;
                            sonuc = sb.Guncelle("Urunler", "Urun_barkodNo='" + barkod + "',Urun_adi='" + ad + "',Urun_fiyat='" + fiyat + "',Urun_alisFiyat='" + AlisFiyat.Text +"'", "Urun_id='" + id + "'");
                            if (sonuc == 1)
                            {
                                MessageBox.Show("Ürün başarıyla güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (Uruns.UrunAdi.Text != "")
                                {
                                    Uruns.GridGuncelle();
                                    Uruns.UrunAra();
                                }
                                else if (Uruns.BarkodNo.Text != "")
                                {
                                    Uruns.GridGuncelle();
                                    Uruns.UrunAraBarkod();
                                }
                                else
                                {
                                    Uruns.GridGuncelle();
                                    Uruns.FormLoad();
                                }
                            }
                            else
                                MessageBox.Show("Ürün güncellenemedi ( Hata kodu: M-03 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            // Ürünü güncelle //
                        }
                        else
                        {
                            MessageBox.Show("Barkod numarasını 15 hane olarak giriş yapınız", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }

                }
                else
                {
                    // BOŞ ALANLAR
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

