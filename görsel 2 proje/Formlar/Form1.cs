using görsel_2_proje.Formlar;
using görsel_2_proje.urun;
using görsel_2_proje.takip;
using görsel_2_proje.musteri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace görsel_2_proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void satışlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Satislar satislar = new Satislar();
            satislar.Show();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }



        private void ürünGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urunGüncelle ug= new urunGüncelle();
            ug.Show();
        }

        private void müşterileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.Show();
        }

        private void ürünToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void yeniSatışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniSatis ys = new YeniSatis();
            ys.Show();
            
        }

        private void satışToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void takiplerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Takipler t = new Takipler();
            t.Show();
        }

        private void iletişimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            İletisim i = new İletisim();
            i.Show();
        }

        private void ürünKategorileriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

      

        private void ürünlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urunler u=new urunler();
            u.Show();
        }

        private void ürünEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urunEkle ue=new urunEkle();
            ue.Show();
        }

        private void ürünSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            urunSil us = new urunSil();
            us.Show();
        }







        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriEkle me = new MusteriEkle();
            me.Show();
        }

        private void müşteriGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusteriGüncelle mg = new MusteriGüncelle();
            mg.Show();
        }

        private void müşteriSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musteriSil ms = new musteriSil();   
            ms.Show();
        }

        private void yeniEkleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TakipEkle te = new TakipEkle(); 
            te.Show();
        }

        private void takipDurumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakipGüncelle tg = new TakipGüncelle();
            tg.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SifreDegis sd =new SifreDegis();
            sd.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
