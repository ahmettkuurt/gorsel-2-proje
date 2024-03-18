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
using görsel_2_proje.Formlar;


namespace görsel_2_proje.musteri
{
    public partial class Musteri : Form
    {
        public Musteri()
        {
            InitializeComponent();
        }
        MusteriGüncelle mg =new MusteriGüncelle();
        sqlbaglanti sb = new sqlbaglanti();
        public string Musteriid = "";
        private void Musteri_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = sb.SutunOlustur();
            GridListe();
        }

        private void Musteri_adsoyad_TextChanged(object sender, EventArgs e)
        {
            if (Musteri_adsoyad != null)
            {
                Tarih1.Enabled = false; Tarih2.Enabled = false;
                if (Musteri_adsoyad.Text.Length > 0)
                {
                    Tarih1.Enabled = false; Tarih2.Enabled = false;
                }
                else
                {
                    Tarih1.Enabled = true; Tarih2.Enabled = true;
                }
            }
        }

        private void Listele_Click(object sender, EventArgs e)
        {
            
            Musteri_adsoyad.Text = Musteri_adsoyad.Text.Replace("'", "’");
            if (checkBox1.Checked == true)
            {
                // tarihe göre ara
                ButonListe("", Tarih1.Value.ToString("yyyy-MM-dd"), Tarih2.Value.ToString("yyyy-MM-dd"));
            }
            else
            {
                // ada göre ara
                ButonListe(Musteri_adsoyad.Text, "", "");
            }
           
        }

        private void Tarih1_ValueChanged(object sender, EventArgs e)
        {
            if (Tarih1.Text != null)
            {
                if (Tarih1.Text.Length > 0)
                {
                    Musteri_adsoyad.Enabled = false; Musteri_adsoyad.Enabled = false;
                }
                else
                {
                    Musteri_adsoyad.Enabled = true; Musteri_adsoyad.Enabled = true;
                }
            }
        }

        private void Tarih2_ValueChanged(object sender, EventArgs e)
        {
            if (Tarih2.Text != null)
            {
                if (Tarih2.Text.Length > 0)
                {
                    Musteri_adsoyad.Enabled = false; Musteri_adsoyad.Enabled = false;
                }
                else
                {
                    Musteri_adsoyad.Enabled = true; Musteri_adsoyad.Enabled = true;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Tarih1.Enabled = true; Tarih2.Enabled = true; Musteri_adsoyad.Enabled = false;
            }
            else
            {
                Tarih1.Enabled = false; Tarih2.Enabled = false; Musteri_adsoyad.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // seçilen satırdan id'yi al
            DataId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        private void DataId_TextChanged(object sender, EventArgs e)
        {
            Musteriid = DataId.Text;
        }


        public void GridListe()
        {
            Tarih1.Enabled = false; Tarih2.Enabled = false; checkBox1.Checked = false;
            // bağlantı kodumuz //
            SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
            baglanti.Open();
            // bağlantı kodumuz //

            // karaliste //
            SqlDataReader KaraListeOku; object KaraListeSonuc;
            SqlCommand KaraListeSor = new SqlCommand("SELECT Musteri_adi,Musteri_soyadi FROM Musteriler where Musteri_bakiye < 0", baglanti);
            KaraListeSor.Connection = baglanti;
            KaraListeSonuc = KaraListeSor.ExecuteScalar();
            if (KaraListeSonuc != null)
            {
                KaraListeOku = KaraListeSor.ExecuteReader();
                while (KaraListeOku.Read())
                {
                    KaraListe.Items.Add(KaraListeOku["Musteri_adi"] + " " + KaraListeOku["Musteri_soyadi"]);
                }
            }
            else
            {
                KaraListe.Items.Add("Borçlu müşteri bulunmamaktadır.");
            }
            // karaliste //
            baglanti.Close();

            // tarihe göre arama //

            // tarihe göre arama //

            // GridView Stünları oluştur //
            SqlDataReader oku; object sonuc; DataRow satir;
            // GridView Stünları oluştur //

            // Müşteri sql kodu //
            SqlCommand komut_musteri = new SqlCommand("SELECT * FROM Musteriler", baglanti);
            baglanti.Open();

            sonuc = komut_musteri.ExecuteScalar();

            if (sonuc != null)
            {
                oku = komut_musteri.ExecuteReader();
                while (oku.Read())
                {
                    satir = sb.dt.NewRow();
                    satir["Müşteri Id"] = oku["Musteri_id"].ToString();
                    satir["Adı Soyadı"] = oku["Musteri_adi"].ToString() + " " + oku["Musteri_soyadi"].ToString();
                    satir["Telefon"] = oku["Musteri_telefon"].ToString();
                    satir["Bakiye"] = float.Parse(oku["Musteri_bakiye"].ToString()) + " TL";
                    satir["Kayıt Tarihi"] = Convert.ToDateTime(oku["Musteri_kayitTarihi"].ToString());

                    //Veri tablomuza kontrolüne ekle
                    sb.dt.Rows.Add(satir);
                }
            }
            else
            {
                MessageBox.Show("Sistemde müşteri bulunamadı, müşteri ekleyiniz", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                MusteriEkle me = new MusteriEkle();
                me.ShowDialog();
            }

            // bağlantı kapatıldı
            baglanti.Close();
        }

        public void ButonListe(string ad, string t1, string t2)
        {
            Musteri_adsoyad.Text = sb.IlkHarfleriBuyut(ad);
            if (checkBox1.Checked == true)
            {
                string suankitarih = DateTime.Now.ToString("yyyy-MM-dd");
                if ((Tarih1.Value > Tarih2.Value))
                {
                    MessageBox.Show("Tarihler aralığında hata ( Hata kodu: M-01 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    string tarih1, tarih2;
                    //tarih1 = Tarih1.Value.ToString("yyyy-MM-dd");
                    //tarih2 = Tarih2.Value.ToString("yyyy-MM-dd");
                    tarih1 = t1;
                    tarih2 = t2;
                    DateTime tarih = DateTime.Parse(tarih1);
                    // GridView Stünları oluştur //
                    SqlDataReader oku; object sonuc; DataRow satir;
                    // GridView Stünları oluştur //

                    // Müşteri sql kodu //
                    SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                    SqlCommand komut_musteri = new SqlCommand("SELECT * FROM Musteriler WHERE Musteri_kayitTarihi BETWEEN '" + tarih1 + "' and '" + tarih2 + "'", baglanti);
                    baglanti.Open();
                    sonuc = komut_musteri.ExecuteScalar();

                    if (sonuc != null)
                    {
                        sb.dt.Clear();
                        dataGridView1.Refresh();
                        oku = komut_musteri.ExecuteReader();
                        while (oku.Read())
                        {
                            satir = sb.dt.NewRow();
                            satir["Müşteri Id"] = oku["Musteri_id"].ToString();
                            satir["Adı Soyadı"] = oku["Musteri_adi"].ToString() + " " + oku["Musteri_soyadi"].ToString();
                            satir["Telefon"] = oku["Musteri_telefon"].ToString();
                            satir["Bakiye"] = float.Parse(oku["Musteri_bakiye"].ToString()) + " TL";
                            satir["Kayıt Tarihi"] = oku["Musteri_kayitTarihi"].ToString();

                            //Veri tablomuza kontrolüne ekle
                            sb.dt.Rows.Add(satir);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Tarihlere göre aramada müşteri bulunamadı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //GridListe();
                    }

                    // bağlantı kapatıldı
                    baglanti.Close();
                }
            }
            else
            {
                if (Musteri_adsoyad.Text != "")
                {
                    string adsoyad2 = sb.IlkHarfleriBuyut(Musteri_adsoyad.Text);
                    // ad soyada göre arattır
                    SqlDataReader oku; object adsoyad; DataRow satir;
                    SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                    SqlCommand komut_adsoyad = new SqlCommand("SELECT * FROM Musteriler where Musteri_adi like '%" + Musteri_adsoyad.Text + "%' or Musteri_soyadi like '%" + Musteri_adsoyad.Text + "%' or Musteri_adi like '%" + adsoyad2 + "%' or Musteri_soyadi like '%" + adsoyad2 + "%'", baglanti);
                    baglanti.Open();
                    adsoyad = komut_adsoyad.ExecuteScalar();
                    if (adsoyad != null)
                    {
                        sb.dt.Clear();
                        dataGridView1.Refresh();
                        oku = komut_adsoyad.ExecuteReader();
                        while (oku.Read())
                        {
                            satir = sb.dt.NewRow();
                            satir["Müşteri Id"] = oku["Musteri_id"].ToString();
                            satir["Adı Soyadı"] = oku["Musteri_adi"].ToString() + " " + oku["Musteri_soyadi"].ToString();
                            satir["Telefon"] = oku["Musteri_telefon"].ToString();
                            satir["Bakiye"] = float.Parse(oku["Musteri_bakiye"].ToString()) + " TL";
                            satir["Kayıt Tarihi"] = oku["Musteri_kayitTarihi"].ToString();

                            //Veri tablomuza kontrolüne ekle
                            sb.dt.Rows.Add(satir);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Müşteri bulunamadı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Lütfen bir isim / soyisim bilgisini doldurun. ( Hata kodu: M-02 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void GridYenile()
        {
            sb.dt.Clear();
            dataGridView1.Refresh();
        }

        public void BorcListe()
        {
            // bağlantı kodumuz //
            SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
            baglanti.Open();
            // bağlantı kodumuz //

            // karaliste //
            SqlDataReader KaraListeOku; object KaraListeSonuc;
            SqlCommand KaraListeSor = new SqlCommand("SELECT Musteri_adi,Musteri_soyadi FROM Musteriler where Musteri_bakiye < 0", baglanti);
            KaraListeSor.Connection = baglanti;
            KaraListeSonuc = KaraListeSor.ExecuteScalar();
            if (KaraListeSonuc != null)
            {
                KaraListeOku = KaraListeSor.ExecuteReader();
                while (KaraListeOku.Read())
                {
                    KaraListe.Items.Add(KaraListeOku["Musteri_adi"] + " " + KaraListeOku["Musteri_soyadi"]);
                }
            }
            else
            {
                KaraListe.Items.Add("Borçlu müşteri bulunmamaktadır.");
            }
            // karaliste //
            baglanti.Close();
        }

        private void Detay_Click_1(object sender, EventArgs e)
        {
            KaraListe.SelectedIndex = 0;
            string birinci = KaraListe.SelectedItem.ToString();
            if (birinci != "Borçlu müşteri bulunmamaktadır.")
            {
                MusteriGüncelle mg = new MusteriGüncelle();
                // Müşteri bilgileri //
                string adsoyad = KaraListe.SelectedItem.ToString();
                string[] ads = adsoyad.Split(' ');
                SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                SqlDataReader MusteriBilgi;
                SqlCommand MusteriSorgu = new SqlCommand("SELECT * FROM Musteriler WHERE Musteri_adi='" + ads[0] + "' and Musteri_soyadi='" + ads[1] + "'", baglanti);
                baglanti.Open();
                MusteriBilgi = MusteriSorgu.ExecuteReader(); MusteriBilgi.Read();
                mg.id = MusteriBilgi["Musteri_id"].ToString();
                baglanti.Close();
                mg.ShowDialog();
                // Müşteri bilgileri //
            }
            else
            {
                MessageBox.Show("Borçlu müşteri bulunmamaktadır.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
