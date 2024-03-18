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
using görsel_2_proje.takip;

namespace görsel_2_proje.Formlar
{
    public partial class TakipSil : Form
    {
        public TakipSil()
        {
            InitializeComponent();
        }
        sqlbaglanti sb = new sqlbaglanti();
        Takipler Tkp = (Takipler)Application.OpenForms["Takipler"];
        private void Evet_Click(object sender, EventArgs e)
        {
            string id = "";
            SqlConnection b1 = new SqlConnection(sb.Baglanti_Kodu());
            b1.Open();
            SqlCommand TakipDetay = new SqlCommand("SELECT Takip_id FROM Teknik_Takip WHERE Takip_no='" + label8.Text + "'", b1);
            object s = TakipDetay.ExecuteScalar();
            if (s != null)
            {
                SqlDataReader idOku = TakipDetay.ExecuteReader(); idOku.Read();
                id = idOku["Takip_id"].ToString(); idOku.Close();
            }
            else
            {
                MessageBox.Show("Sistemsel bir hata oluştu, lütfen sağlayacınıza başvurunuz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            b1.Close();

            if (id != "")
            {
                b1.Open();
                SqlCommand Detaylar = new SqlCommand("SELECT * FROM TeknikTakipIslemler WHERE Takip_id='" + id + "'", b1);
                object s1 = TakipDetay.ExecuteScalar();
                if (s1 != null)
                {
                    SqlDataReader IdOku = Detaylar.ExecuteReader();
                    while (IdOku.Read())
                    {
                        sb.Sil("TeknikTakipIslemler", "Takip_id='" + IdOku["Takip_id"].ToString() + "'");
                    }

                    byte sonuc;
                    sonuc = sb.Sil("Teknik_Takip", "Takip_no='" + label8.Text + "'");
                    if (sonuc == 1)
                    {
                        MessageBox.Show("Teknik Takip başarıyla silinmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Tkp.GridGuncelle();
                        Tkp.FormLoad();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Teknik Takip silinemedi ( Hata kodu: T-13 )", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Sistemsel bir hata oluştu, lütfen sağlayacınıza başvurunuz.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                b1.Close();
            }

        }

        private void Hayir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Teknik takip silme işlemi iptal edilmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
