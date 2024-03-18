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

namespace görsel_2_proje.Formlar
{
    public partial class SifreDegis : Form
    {
        public SifreDegis()
        {
            InitializeComponent();
        }
        sqlbaglanti sb =new sqlbaglanti();
        private void SifreDegis_Load(object sender, EventArgs e)
        {

        }

        private void Degistir_Click(object sender, EventArgs e)
        {
            try
            {
                eskiSifre.Text = eskiSifre.Text.Replace("'", "’");
                yeniSifre1.Text = yeniSifre1.Text.Replace("'", "’");
                yeniSifre2.Text = yeniSifre2.Text.Replace("'", "’");
                SqlConnection baglan = new SqlConnection(sb.Baglanti_Kodu());
                baglan.Open();
                SqlCommand Sifre = new SqlCommand("select sifre from Login", baglan);
                SqlDataReader oku = Sifre.ExecuteReader(); oku.Read();
                string KayitliSifre = oku["sifre"].ToString();
                baglan.Close();
                if (eskiSifre.Text != "" && yeniSifre1.Text != "" && yeniSifre2.Text != "")
                {
                    if (yeniSifre1.Text == yeniSifre2.Text)
                    {
                        if (eskiSifre.Text == KayitliSifre)
                        {
                            baglan.Open();
                            SqlCommand SifreDegis = new SqlCommand("update Login set sifre='" + yeniSifre1.Text + "'", baglan);
                            SifreDegis.ExecuteNonQuery();
                            MessageBox.Show("Sistem şifreniz başarıyla güncellenmiştir", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            baglan.Close();
                        }
                        else
                        {
                            MessageBox.Show("Eski şifre yanlış girildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Girilen yeni şifreler uyuşmuyor.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Eski ve yeni şifreleri girin", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
