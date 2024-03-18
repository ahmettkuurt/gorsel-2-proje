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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        sqlbaglanti sb = new sqlbaglanti();



        private void chcSifre_CheckedChanged(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = chcSifre.Checked ? '\0' : '*';


        }

        private void btnGiris_Click_1(object sender, EventArgs e)
        {
            SqlConnection baglan = new SqlConnection(sb.Baglanti_Kodu());
            SqlCommand kontrol = new SqlCommand("Select * From Login where kullaniciAdi=@p1 and " + "sifre=@p2", baglan);

            kontrol.Parameters.AddWithValue("@p1",txtKadi.Text);
            kontrol.Parameters.AddWithValue("@p2",txtSifre.Text);
            baglan.Open();
            SqlDataReader dr =kontrol.ExecuteReader();
            if (dr.Read())
            {
                int yntc_id = Convert.ToInt32(dr.GetValue(0));
                MessageBox.Show("HOŞ GELDİNİZ", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 home = new Form1();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı !!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void chcSifre_CheckedChanged_1(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = chcSifre.Checked ? '\0' : '*';

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool move;
        int mouse_x;
        int mouse_y;
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }

        private void Login_MouseUp(object sender, MouseEventArgs e)
        {
            move=false;
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);
            }
        }
    }
}
