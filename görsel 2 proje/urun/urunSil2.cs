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
    public partial class urunSil2 : Form
    {
        public urunSil2()
        {
            InitializeComponent();
        }
        sqlbaglanti sb=new sqlbaglanti();
        public string id;
        private void UrunSil2_Load(object sender, EventArgs e)
        {
            try
            {
                // Bağlantı //
                SqlConnection baglanti = new SqlConnection(sb.Baglanti_Kodu());
                // Bağlantı //

                baglanti.Open();
                SqlCommand KategoriAdiSorgu = new SqlCommand("SELECT Urun_adi FROM Urunler WHERE Urun_id='" + id + "'", baglanti);
                SqlDataReader KatAdiOku; KatAdiOku = KategoriAdiSorgu.ExecuteReader(); KatAdiOku.Read();
                this.Text = KatAdiOku["Urun_adi"].ToString() + " - Ürün Silinecek";
                baglanti.Close();
                label1.Text = this.Text;
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
                urunler Uruns = (urunler)Application.OpenForms["Urunler"];
                SqlConnection baglan = new SqlConnection(sb.Baglanti_Kodu());
                baglan.Open();
                SqlCommand SatisTab = new SqlCommand("SELECT Satis_id FROM Satis WHERE Satis_urun='" + id + "'", baglan);
                SqlDataReader SatisIdOku = SatisTab.ExecuteReader();
                while (SatisIdOku.Read())
                {
                    sb.Sil("Satis", "Satis_id='" + SatisIdOku["Satis_id"].ToString() + "'");
                }
                baglan.Close();

                sonuc = sb.Sil("Urunler", "Urun_id='" + id + "'");
                if (sonuc == 1)
                {
                    MessageBox.Show("Ürün başarıyla silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Uruns.GridGuncelle();
                    Uruns.FormLoad();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ürün silinemedi ( Hata kodu: U-04 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
