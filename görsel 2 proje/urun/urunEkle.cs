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
    public partial class urunEkle : Form
    {
        public urunEkle()
        {
            InitializeComponent();
        }
        sqlbaglanti sb=new sqlbaglanti();
        private void UrunEkle_Load(object sender, EventArgs e)
        {

        }

        private void barkodlu_CheckedChanged(object sender, EventArgs e)
        {
            if (barkodlu.Checked == true)   //eğer tik işaretli ise barkod yazmamız gerekmi
            {
                UrunBarkod.Text = "";
                UrunBarkod.Enabled = false;
            }
            else
            {
                UrunBarkod.Text = "Barkod EklenmediBarkod Eklenmedi";
                UrunBarkod.Enabled = true;
            }
        }




        private void UrunBarkod_KeyPress(object sender, KeyPressEventArgs e)
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

        private void UrunKategori_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void urunEkle_Load_1(object sender, EventArgs e)
        {
            
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
        }

        private void Ekle_Click_1(object sender, EventArgs e)
        {
            try
            {
                UrunAdi.Text = UrunAdi.Text.Replace("'", "’");
                UrunFiyat.Text = UrunFiyat.Text.Replace(',', '.');
                AlisFiyat.Text = AlisFiyat.Text.Replace(',', '.');
                byte kayit; string ad, barkod, fiyat, afiyat,  tarih;
                if (UrunAdi.Text != "" && UrunFiyat.Text != "" && AlisFiyat.Text != "" )
                {
                    ad = UrunAdi.Text; barkod = UrunBarkod.Text;
                    fiyat = UrunFiyat.Text;
                    afiyat = AlisFiyat.Text;
                    tarih = DateTime.Now.Year.ToString(); tarih += '-' + DateTime.Now.Month.ToString(); tarih += '-' + DateTime.Now.Day.ToString();
                    if (barkod != "Barkod Eklenmedi")
                    {
                        kayit = sb.Ekle("Urunler", "Urun_barkodNo,Urun_adi,Urun_fiyat,Urun_eklenmeTarih,Urun_alisFiyat", "'" + barkod + "','" + sb.IlkHarfleriBuyut(ad) + "','" + fiyat + "','" + tarih + "','" + afiyat + "'");
                        if (kayit == 1)
                        {
                            MessageBox.Show("Ürün başarıyla eklenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UrunFiyat.Text = ""; UrunAdi.Text = ""; UrunBarkod.Text = "Barkod Eklenmedi"; barkodlu.Checked = true; AlisFiyat.Text = "";
                        }
                        else
                            MessageBox.Show("Ürün eklenemedi ( Hata kodu: U-05 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        kayit = sb.Ekle("Urunler", "Urun_barkodNo,Urun_adi,Urun_fiyat,Urun_eklenmeTarih,Urun_alisFiyat", "'0','" + sb.IlkHarfleriBuyut(ad) + "','" + fiyat + "','" + tarih + "','" + afiyat + "'");
                        if (kayit == 1)
                        {
                            MessageBox.Show("Ürün başarıyla eklenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            UrunFiyat.Text = ""; UrunAdi.Text = ""; UrunBarkod.Text = "Barkod Eklenmedi"; barkodlu.Checked = true; AlisFiyat.Text = "";
                        }
                        else
                            MessageBox.Show("Ürün eklenemedi ( Hata kodu: U-05 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Boş alanları doldurun! ( Hata kodu: U-06 )", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
