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

namespace görsel_2_proje.takip
{
    public partial class TakipEkle : Form
    {
        public TakipEkle()
        {
            InitializeComponent();
        }
        sqlbaglanti sb = new sqlbaglanti();
        public string TakipNo;
        string id;
        private void uyeMi_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (uyeMi.Checked)
                {
                    SqlConnection baglan = new SqlConnection(sb.Baglanti_Kodu());
                    baglan.Open();
                    SqlCommand MusSql = new SqlCommand("SELECT Musteri_adi,Musteri_soyadi FROM Musteriler", baglan);
                    object Mvarmi = MusSql.ExecuteScalar();
                    if (Mvarmi != null)
                    {
                        SqlDataReader MusOku = MusSql.ExecuteReader();
                        while (MusOku.Read())
                        {
                            musteri.Items.Add(MusOku["Musteri_adi"].ToString() + " " + MusOku["Musteri_soyadi"].ToString());
                        }
                        uyeyse.Enabled = true;
                        uyedegilse.Enabled = false;
                        musteri.SelectedIndex = 0;
                    }
                    else
                    {
                        DialogResult MusEkle = MessageBox.Show("Sistemde müşteri bulunmamaktadır, yeni müşteri eklemek ister misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (MusEkle == DialogResult.Yes)
                        {
                            MusteriEkle me = new MusteriEkle();
                            me.ShowDialog();
                        }
                    }
                    baglan.Close();
                }
                else
                {
                    uyeyse.Enabled = false;
                    uyedegilse.Enabled = true;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TakipEkle_Load(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();
                double sayi = rnd.Next(0, 99999);
                double sayi2 = rnd.Next(0, 99999);
                takipno.Text = "TKP" + sayi.ToString() + sayi2.ToString();
                TakipNo = takipno.Text;
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void musteriarama_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection(sb.Baglanti_Kodu());
            if (musteriarama.Text.Length > 0)
            {
                musteriarama.Text = musteriarama.Text.Replace("'", "’");
                SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                SqlDataReader MusteriOku; object sonuc;
                baglanti.Open();
                SqlCommand MusteriAraSorgu = new SqlCommand("SELECT * FROM Musteriler WHERE Musteri_adi like '%" + musteriarama.Text + "%' or Musteri_soyadi like '%" + musteriarama.Text + "%'", baglanti);
                sonuc = MusteriAraSorgu.ExecuteScalar();
                musteri.Items.Clear();
                if (sonuc != null)
                {
                    MusteriOku = MusteriAraSorgu.ExecuteReader();
                    while (MusteriOku.Read())
                    {
                        musteri.Items.Add(MusteriOku["Musteri_adi"].ToString() + " " + MusteriOku["Musteri_soyadi"].ToString());
                    }
                    musteri.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Aranan isme / soyisme göre müşteri bulunamadı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("İsim veya Soyisim girin ( Hata kodu: M-06 )", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                musteri.Items.Clear();
                baglan.Open();
                SqlCommand MusSql = new SqlCommand("SELECT Musteri_adi,Musteri_soyadi FROM Musteriler", baglan);
                object musSS = MusSql.ExecuteScalar();
                if (musSS != null)
                {
                    SqlDataReader MusOku = MusSql.ExecuteReader();
                    while (MusOku.Read())
                    {
                        musteri.Items.Add(MusOku["Musteri_adi"].ToString() + " " + MusOku["Musteri_soyadi"].ToString());
                    }
                    musteri.SelectedIndex = 0;
                }
                else
                {
                    DialogResult MusEkle = MessageBox.Show("Sistemde müşteri bulunmamaktadır, yeni müşteri eklemek ister misiniz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (MusEkle == DialogResult.Yes)
                    {
                        MusteriEkle me = new MusteriEkle();
                        me.ShowDialog();
                    }
                }
                baglan.Close();

            }
        }

        private void musTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void imei_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void takipno_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void takipno_TextChanged(object sender, EventArgs e)
        {

        }

        private void kopyala_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(takipno.Text);
            MessageBox.Show("Teknik takip kodu kopyalanmıştır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Ekle_Click_1(object sender, EventArgs e)
        {
            try
            {
                if ((marka.Text != "" && model.Text != "") && ((imei.Text != "" && imei.Text.Length > 14) || (serino.Text != "")))
                {
                    marka.Text = marka.Text.Replace("'", "’");
                    model.Text = model.Text.Replace("'", "’");
                    serino.Text = serino.Text.Replace("'", "’");
                    musadi.Text = musadi.Text.Replace("'", "’");
                    SqlConnection baglan = new SqlConnection(sb.Baglanti_Kodu());
                    SqlConnection baglan1 = new SqlConnection(sb.Baglanti_Kodu());
                    SqlConnection baglan2 = new SqlConnection(sb.Baglanti_Kodu());
                    SqlConnection baglan3 = new SqlConnection(sb.Baglanti_Kodu());

                    if (uyeMi.Checked == true)
                    {//üye
                        baglan.Open();
                        SqlCommand TakipSor = new SqlCommand("select * from teknik_takip where takip_imei='" + imei.Text + "' or takip_serino='" + serino.Text + "'", baglan);
                        object TakipVarMi = TakipSor.ExecuteScalar();
                        baglan.Close();
                        if (TakipVarMi == null)
                        {
                            //takibi ekle..
                            baglan.Open();
                            string[] ads = musteri.Text.Split(' ');
                            SqlCommand MusidSql = new SqlCommand("SELECT Musteri_id FROM Musteriler WHERE Musteri_adi='" + ads[0] + "' and Musteri_soyadi='" + ads[1] + "'", baglan);
                            object MusKontrol = MusidSql.ExecuteScalar();
                            if (MusKontrol != null)
                            {
                                SqlDataReader MusidOku = MusidSql.ExecuteReader(); MusidOku.Read();
                                id = MusidOku["Musteri_id"].ToString();
                                string tarih = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                                byte sonuc;
                                sonuc = sb.Ekle("Teknik_Takip", "Takip_no,Musteri_id,Takip_marka,Takip_model,Takip_imei,Takip_serino,Takip_girisTarih,Takip_durum", "'" + TakipNo + "','" + id + "','" + sb.IlkHarfleriBuyut(marka.Text) + "','" + sb.IlkHarfleriBuyut(model.Text) + "','" + imei.Text + "','" + serino.Text + "','" + tarih + "','1'");
                                if (sonuc == 1)
                                {
                                    MessageBox.Show("Takip başarıyla eklenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Random rnd = new Random();
                                    double sayi = rnd.Next(0, 99999);
                                    double sayi2 = rnd.Next(0, 99999);
                                    takipno.Text = "TKP" + sayi.ToString() + sayi2.ToString();
                                    TakipNo = takipno.Text;
                                }
                                else
                                    MessageBox.Show("Takip eklenemedi ( Hata kodu: T-01 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show("Sistemsel bir hata oluştu, lütfen sağlayıcınıza başvurunuz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            baglan.Close();
                        }
                        else
                        {
                            DialogResult Sor = MessageBox.Show("Eklemek istediğiniz cihaz sistemde kayıtlıdır, yeni takip açmak istediğinize emin misiniz?", "Takip Eklensin Mi ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (Sor == DialogResult.Yes)
                            {//ekle
                                baglan.Open();
                                string[] ads = musteri.Text.Split(' ');
                                SqlCommand MusidSql = new SqlCommand("SELECT Musteri_id FROM Musteriler WHERE Musteri_adi='" + ads[0] + "' and Musteri_soyadi='" + ads[1] + "'", baglan);
                                object MusKontrol = MusidSql.ExecuteScalar();
                                if (MusKontrol != null)
                                {
                                    SqlDataReader MusidOku = MusidSql.ExecuteReader(); MusidOku.Read();
                                    id = MusidOku["Musteri_id"].ToString();
                                    string tarih = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                                    byte sonuc;
                                    sonuc = sb.Ekle("Teknik_Takip", "Takip_no,Musteri_id,Takip_marka,Takip_model,Takip_imei,Takip_serino,Takip_girisTarih,Takip_durum", "'" + TakipNo + "','" + id + "','" + sb.IlkHarfleriBuyut(marka.Text) + "','" + sb.IlkHarfleriBuyut(model.Text) + "','" + imei.Text + "','" + serino.Text + "','" + tarih + "','1'");
                                    if (sonuc == 1)
                                    {
                                        MessageBox.Show("Takip başarıyla eklenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Random rnd = new Random();
                                        double sayi = rnd.Next(0, 99999);
                                        double sayi2 = rnd.Next(0, 99999);
                                        takipno.Text = "TKP" + sayi.ToString() + sayi2.ToString();
                                        TakipNo = takipno.Text;
                                    }
                                    else
                                        MessageBox.Show("Takip eklenemedi ( Hata kodu: T-01 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    MessageBox.Show("Sistemsel bir hata oluştu, lütfen sağlayıcınıza başvurunuz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                baglan.Close();
                            }
                            else
                            {//ekleme

                            }
                        }
                    }
                    else
                    {//üye değil

                        if (musadi.Text != "" && musTel.Text != "")
                        {
                            baglan.Open();
                            SqlCommand TakipSor = new SqlCommand("select * from teknik_takip where takip_imei='" + imei.Text + "' or takip_serino='" + serino.Text + "'", baglan);
                            object TakipVarMi = TakipSor.ExecuteScalar();
                            baglan.Close();
                            if (TakipVarMi == null)
                            {//ekle
                                // ekle
                                byte sonuc;
                                string tarih = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();

                                sonuc = sb.Ekle("Teknik_Takip", "Takip_no,Takip_marka,Takip_model,Takip_imei,Takip_serino,Takip_girisTarih,Takip_durum,Takip_kisibilgi,Takip_kisiTel", "'" + TakipNo + "','" + sb.IlkHarfleriBuyut(marka.Text) + "','" + sb.IlkHarfleriBuyut(model.Text) + "','" + imei.Text + "','" + serino.Text + "','" + tarih + "','1','" + sb.IlkHarfleriBuyut(musadi.Text) + "','" + musTel.Text + "'");
                                if (sonuc == 1)
                                {
                                    MessageBox.Show("Takip başarıyla eklenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Random rnd = new Random();
                                    double sayi = rnd.Next(0, 99999);
                                    double sayi2 = rnd.Next(0, 99999);
                                    takipno.Text = "TKP" + sayi.ToString() + sayi2.ToString();
                                    TakipNo = takipno.Text;
                                }
                                else
                                    MessageBox.Show("Takip eklenemedi ( Hata kodu: T-01 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {//sor
                                DialogResult Sor = MessageBox.Show("Eklemek istediğiniz cihaz sistemde kayıtlıdır, yeni takip açmak istediğinize emin misiniz?", "Takip Eklensin Mi ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (Sor == DialogResult.Yes)
                                {//ekle
                                    // ekle
                                    byte sonuc;
                                    string tarih = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();

                                    sonuc = sb.Ekle("Teknik_Takip", "Takip_no,Takip_marka,Takip_model,Takip_imei,Takip_serino,Takip_girisTarih,Takip_durum,Takip_kisibilgi,Takip_kisiTel", "'" + TakipNo + "','" + sb.IlkHarfleriBuyut(marka.Text) + "','" + sb.IlkHarfleriBuyut(model.Text) + "','" + imei.Text + "','" + serino.Text + "','" + tarih + "','1','" + sb.IlkHarfleriBuyut(musadi.Text) + "','" + musTel.Text + "'");
                                    if (sonuc == 1)
                                    {
                                        MessageBox.Show("Takip başarıyla eklenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Random rnd = new Random();
                                        double sayi = rnd.Next(0, 99999);
                                        double sayi2 = rnd.Next(0, 99999);
                                        takipno.Text = "TKP" + sayi.ToString() + sayi2.ToString();
                                        TakipNo = takipno.Text;
                                    }
                                    else
                                        MessageBox.Show("Takip eklenemedi ( Hata kodu: T-01 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {//ekleme

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Müşteri bilgilerini eksiksiz giriniz ( Hata kodu: T-03 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cihaz Bilgilerini eksiksiz giriniz ( Hata kodu: T-02 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void musteri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
