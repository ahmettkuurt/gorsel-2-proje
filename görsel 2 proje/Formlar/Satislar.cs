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


namespace görsel_2_proje.Formlar
{
    public partial class Satislar : Form
    {
        public Satislar()
        {
            InitializeComponent();
        }
        sqlbaglanti sb=new sqlbaglanti();
        string tarih = "";

        public SqlDataReader Sokuu { get; private set; }

        private void Satislar_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sb.SatisStunOlustur();
            FormLoad();
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            SatisIptali();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SatisId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void ara_Click(object sender, EventArgs e)
        {
            SatisAra();
        }

        public void FormLoad()
        {
            DataRow satir;
            label1.Text = DateTime.Now.Day.ToString() + " / " + DateTime.Now.Month.ToString() + " / " + DateTime.Now.Year.ToString() + " - Günü Satışları";
            tarih = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection b1 = new SqlConnection(sb.Baglanti_Kodu());
            SqlConnection b2 = new SqlConnection(sb.Baglanti_Kodu());

            b1.Open();
            SqlCommand SecilenTarihSatis = new SqlCommand("SELECT * FROM Satis WHERE Satis_tarih='" + tarih + "'", b1);
            object kontrol = SecilenTarihSatis.ExecuteScalar();
            if (kontrol != null)
            {
                sb.dt.Clear();
                dataGridView1.Refresh();
                using ( Sokuu = SecilenTarihSatis.ExecuteReader())
                {
                    while (Sokuu.Read())
                    {
                        satir = sb.dt.NewRow();
                        satir["Satış Id"] = "S " + Sokuu["Satis_id"].ToString();
                        b2.Open();
                        SqlCommand UrunAdi = new SqlCommand("SELECT Urun_adi FROM Urunler WHERE Urun_id='" + Sokuu["Satis_urun"].ToString() + "'", b2);
                        SqlDataReader UrunAdiOku = UrunAdi.ExecuteReader();
                        UrunAdiOku.Read();
                        satir["Satış Ürün"] = UrunAdiOku["Urun_adi"].ToString();
                        b2.Close();
                        if (Sokuu["Satis_musteri"].ToString() == "")
                        {
                            satir["Satış Müşteri"] = "Standart Satış";
                        }
                        else
                        {
                            b2.Open();
                            SqlCommand MusteriAdi = new SqlCommand("SELECT Musteri_adi,Musteri_soyadi FROM Musteriler WHERE Musteri_id='" + Sokuu["Satis_musteri"].ToString() + "'", b2);
                            SqlDataReader MusteriAdiOku = MusteriAdi.ExecuteReader();
                            MusteriAdiOku.Read();
                            satir["Satış Müşteri"] = MusteriAdiOku["Musteri_adi"].ToString() + " " + MusteriAdiOku["Musteri_soyadi"].ToString();
                            b2.Close();
                        }
                        satir["Satış Tarihi"] = Sokuu["Satis_tarih"].ToString();
                        if (Sokuu["Satis_not"].ToString() == "")
                        {
                            satir["Satış Notu"] = "Not Eklenmemiş";
                        }
                        else
                        {
                            satir["Satış Notu"] = Sokuu["Satis_not"].ToString();
                        }
                        sb.dt.Rows.Add(satir);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seçilen tarihte satış yapılmamıştır", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            b1.Close();


        }

        public void SatisAra()
        {
            try
            {
                tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                DataRow satir;
                SqlConnection b1 = new SqlConnection(sb.Baglanti_Kodu());
                SqlConnection b2 = new SqlConnection(sb.Baglanti_Kodu());

                b1.Open();
                SqlCommand SecilenTarihSatis = new SqlCommand("SELECT * FROM Satis WHERE Satis_tarih='" + tarih + "'", b1);
                object kontrol = SecilenTarihSatis.ExecuteScalar();
                if (kontrol != null)
                {
                    sb.dt.Clear();
                    dataGridView1.Refresh();
                    SqlDataReader SatisOku = SecilenTarihSatis.ExecuteReader();
                    label1.Text = dateTimePicker1.Value.ToString("dd / MM / yyyy") + " - Günü Satışları";
                    while (SatisOku.Read())
                    {
                        satir = sb.dt.NewRow();
                        satir["Satış Id"] = "S " + SatisOku["Satis_id"].ToString();
                        b2.Open();
                        SqlCommand UrunAdi = new SqlCommand("SELECT Urun_adi FROM Urunler WHERE Urun_id='" + SatisOku["Satis_urun"].ToString() + "'", b2);
                        SqlDataReader UrunAdiOku = UrunAdi.ExecuteReader();
                        UrunAdiOku.Read();
                        satir["Satış Ürün"] = UrunAdiOku["Urun_adi"].ToString();
                        b2.Close();
                        if (SatisOku["Satis_musteri"].ToString() == "")
                        {
                            satir["Satış Müşteri"] = "Standart Satış";
                        }
                        else
                        {
                            b2.Open();
                            SqlCommand MusteriAdi = new SqlCommand("SELECT Musteri_adi,Musteri_soyadi FROM Musteriler WHERE Musteri_id='" + SatisOku["Satis_musteri"].ToString() + "'", b2);
                            SqlDataReader MusteriAdiOku = MusteriAdi.ExecuteReader();
                            MusteriAdiOku.Read();
                            satir["Satış Müşteri"] = MusteriAdiOku["Musteri_adi"].ToString() + " " + MusteriAdiOku["Musteri_soyadi"].ToString();
                            b2.Close();
                        }
                        satir["Satış Tarihi"] = SatisOku["Satis_tarih"].ToString();
                        if (SatisOku["Satis_not"].ToString() == "")
                        {
                            satir["Satış Notu"] = "Not Eklenmemiş";
                        }
                        else
                        {
                            satir["Satış Notu"] = SatisOku["Satis_not"].ToString();
                        }
                        sb.dt.Rows.Add(satir);
                    }
                }
                else
                {
                    MessageBox.Show("Seçilen tarihte satış yapılmamıştır", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                b1.Close();

                b1.Open();
                SqlCommand ManuelSatis = new SqlCommand("SELECT * FROM ManuelSatis WHERE satis_tarih='" + tarih + "'", b1);
                object sn = ManuelSatis.ExecuteScalar();
                if (sn != null)
                {
                    SqlDataReader okuu = ManuelSatis.ExecuteReader();
                    while (okuu.Read())
                    {
                        satir = sb.dt.NewRow();
                        satir["Satış Id"] = "M " + okuu["satis_id"].ToString();
                        satir["Satış Ürün"] = okuu["satis_urunadi"].ToString();
                        if (okuu["satis_musteri"].ToString() == "")
                        {
                            satir["Satış Müşteri"] = "Standart Satış";
                        }
                        else
                        {
                            b2.Open();
                            SqlCommand MusteriAdi = new SqlCommand("SELECT Musteri_adi,Musteri_soyadi FROM Musteriler WHERE Musteri_id='" + okuu["satis_musteri"].ToString() + "'", b2);
                            SqlDataReader MusteriAdiOku = MusteriAdi.ExecuteReader();
                            MusteriAdiOku.Read();
                            satir["Satış Müşteri"] = MusteriAdiOku["Musteri_adi"].ToString() + " " + MusteriAdiOku["Musteri_soyadi"].ToString();
                            b2.Close();
                        }
                        satir["Satış Tarihi"] = okuu["satis_tarih"].ToString();
                        if (okuu["Satis_not"].ToString() == "")
                        {
                            satir["Satış Notu"] = "Not Eklenmemiş";
                        }
                        else
                        {
                            satir["Satış Notu"] = okuu["satis_not"].ToString();
                        }
                        sb.dt.Rows.Add(satir);
                    }
                }
                b1.Close();
            }
            catch (Exception h1)
            {
                MessageBox.Show(h1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SatisIptali()
        {
            try
            {
                SatisId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                string[] ads = SatisId.Text.Split(' ');
                if (ads[0] == "S")
                {
                    SatisId.Text = ads[1].ToString();
                    SqlConnection b1 = new SqlConnection(sb.Baglanti_Kodu());

                    b1.Open();
                    SqlCommand SatisUrun = new SqlCommand("SELECT Satis_urun FROM Satis WHERE Satis_id='" + SatisId.Text + "'", b1);
                    SqlDataReader Oku = SatisUrun.ExecuteReader();
                    Oku.Read();
                    string urunid = Oku["Satis_urun"].ToString();
                    Oku.Close();
                    b1.Close();

                    DialogResult m = MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " Satışı iptal edilecek. Emin misiniz ? ", "Onaylama", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == m)
                    {
                        sb.Sil("Satis", "Satis_id='" + SatisId.Text + "' and Satis_tarih='" + tarih + "'");
                        b1.Open();
                        SqlCommand RaporSor = new SqlCommand("SELECT * FROM Rapor WHERE rapor_satisId='" + urunid + "' and rapor_tarih='" + tarih + "'", b1);
                        SqlDataReader cek = RaporSor.ExecuteReader();
                        cek.Read(); int say = int.Parse(cek["rapor_sayac"].ToString()); cek.Close();
                        b1.Close();
                        if (say > 1)
                        {
                            byte sonuc = sb.Guncelle("Rapor", "rapor_sayac=rapor_sayac-1", "rapor_satisId='" + urunid + "' and rapor_tarih='" + tarih + "'");
                            if (sonuc == 1)
                            {
                                MessageBox.Show("Satış başarıyla silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GridGuncelle();
                                FormLoad();
                            }
                            else
                            {
                                MessageBox.Show("Satış silinemedi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            byte sonuc = sb.Sil("Rapor", "rapor_satisId='" + urunid + "' and rapor_tarih='" + tarih + "'");
                            if (sonuc == 1)
                            {
                                MessageBox.Show("Satış başarıyla silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                GridGuncelle();
                                FormLoad();
                            }
                            else
                            {
                                MessageBox.Show("Satış silinemedi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    SatisId.Text = ads[1].ToString();
                    DialogResult m = MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " Satışı iptal edilecek. Emin misiniz ? ", "Onaylama", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (DialogResult.Yes == m)
                    {
                        byte sonuc = sb.Sil("ManuelSatis", "satis_id='" + SatisId.Text + "'");
                        if (sonuc == 1)
                        {
                            MessageBox.Show("Satış başarıyla silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Satış silinemedi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GridGuncelle()
        {
            sb.dt.Clear();
            dataGridView1.Refresh();
        }
    }
}
