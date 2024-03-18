namespace görsel_2_proje.urun
{
    partial class urunler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(urunler));
            this.UrunArama = new System.Windows.Forms.GroupBox();
            this.UrunBarkodaGoreGrup = new System.Windows.Forms.GroupBox();
            this.AramaButonBarkod = new System.Windows.Forms.Button();
            this.BarkodNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UrunAdaGoreGrup = new System.Windows.Forms.GroupBox();
            this.AramaButonAd = new System.Windows.Forms.Button();
            this.UrunAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButonSil = new System.Windows.Forms.Button();
            this.ButonGuncelle = new System.Windows.Forms.Button();
            this.Urunid = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.görsel2projeDataSet = new görsel_2_proje.görsel2projeDataSet();
            this.urunlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.urunlerTableAdapter = new görsel_2_proje.görsel2projeDataSetTableAdapters.UrunlerTableAdapter();
            this.UrunArama.SuspendLayout();
            this.UrunBarkodaGoreGrup.SuspendLayout();
            this.UrunAdaGoreGrup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.görsel2projeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunlerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // UrunArama
            // 
            this.UrunArama.Controls.Add(this.UrunBarkodaGoreGrup);
            this.UrunArama.Controls.Add(this.UrunAdaGoreGrup);
            this.UrunArama.Location = new System.Drawing.Point(83, 5);
            this.UrunArama.Name = "UrunArama";
            this.UrunArama.Size = new System.Drawing.Size(544, 166);
            this.UrunArama.TabIndex = 5;
            this.UrunArama.TabStop = false;
            this.UrunArama.Text = "Ürün Arama";
            // 
            // UrunBarkodaGoreGrup
            // 
            this.UrunBarkodaGoreGrup.Controls.Add(this.AramaButonBarkod);
            this.UrunBarkodaGoreGrup.Controls.Add(this.BarkodNo);
            this.UrunBarkodaGoreGrup.Controls.Add(this.label2);
            this.UrunBarkodaGoreGrup.Location = new System.Drawing.Point(279, 19);
            this.UrunBarkodaGoreGrup.Name = "UrunBarkodaGoreGrup";
            this.UrunBarkodaGoreGrup.Size = new System.Drawing.Size(259, 142);
            this.UrunBarkodaGoreGrup.TabIndex = 1;
            this.UrunBarkodaGoreGrup.TabStop = false;
            this.UrunBarkodaGoreGrup.Text = "Barkod Numarasına Göre Arama";
            // 
            // AramaButonBarkod
            // 
            this.AramaButonBarkod.Image = global::görsel_2_proje.Properties.Resources.ara;
            this.AramaButonBarkod.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AramaButonBarkod.Location = new System.Drawing.Point(75, 85);
            this.AramaButonBarkod.Name = "AramaButonBarkod";
            this.AramaButonBarkod.Size = new System.Drawing.Size(91, 40);
            this.AramaButonBarkod.TabIndex = 3;
            this.AramaButonBarkod.Text = "     Arama";
            this.AramaButonBarkod.UseVisualStyleBackColor = true;
            this.AramaButonBarkod.Click += new System.EventHandler(this.AramaButonBarkod_Click);
            // 
            // BarkodNo
            // 
            this.BarkodNo.Location = new System.Drawing.Point(75, 51);
            this.BarkodNo.MaxLength = 15;
            this.BarkodNo.Name = "BarkodNo";
            this.BarkodNo.Size = new System.Drawing.Size(178, 20);
            this.BarkodNo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Barkod No:";
            // 
            // UrunAdaGoreGrup
            // 
            this.UrunAdaGoreGrup.Controls.Add(this.AramaButonAd);
            this.UrunAdaGoreGrup.Controls.Add(this.UrunAdi);
            this.UrunAdaGoreGrup.Controls.Add(this.label1);
            this.UrunAdaGoreGrup.Location = new System.Drawing.Point(14, 19);
            this.UrunAdaGoreGrup.Name = "UrunAdaGoreGrup";
            this.UrunAdaGoreGrup.Size = new System.Drawing.Size(259, 142);
            this.UrunAdaGoreGrup.TabIndex = 0;
            this.UrunAdaGoreGrup.TabStop = false;
            this.UrunAdaGoreGrup.Text = "Ürün Adına Göre Arama";
            // 
            // AramaButonAd
            // 
            this.AramaButonAd.AccessibleName = "a";
            this.AramaButonAd.Image = global::görsel_2_proje.Properties.Resources.ara;
            this.AramaButonAd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AramaButonAd.Location = new System.Drawing.Point(67, 85);
            this.AramaButonAd.Name = "AramaButonAd";
            this.AramaButonAd.Size = new System.Drawing.Size(91, 40);
            this.AramaButonAd.TabIndex = 2;
            this.AramaButonAd.Text = "     Arama";
            this.AramaButonAd.UseVisualStyleBackColor = true;
            this.AramaButonAd.Click += new System.EventHandler(this.AramaButonAd_Click);
            // 
            // UrunAdi
            // 
            this.UrunAdi.AccessibleName = "a";
            this.UrunAdi.Location = new System.Drawing.Point(67, 55);
            this.UrunAdi.MaxLength = 100;
            this.UrunAdi.Name = "UrunAdi";
            this.UrunAdi.Size = new System.Drawing.Size(178, 20);
            this.UrunAdi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün Adı:";
            // 
            // ButonSil
            // 
            this.ButonSil.Image = global::görsel_2_proje.Properties.Resources.carpi32;
            this.ButonSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButonSil.Location = new System.Drawing.Point(678, 293);
            this.ButonSil.Name = "ButonSil";
            this.ButonSil.Size = new System.Drawing.Size(93, 38);
            this.ButonSil.TabIndex = 9;
            this.ButonSil.Text = "    Sil";
            this.ButonSil.UseVisualStyleBackColor = true;
            this.ButonSil.Click += new System.EventHandler(this.ButonSil_Click);
            // 
            // ButonGuncelle
            // 
            this.ButonGuncelle.Image = global::görsel_2_proje.Properties.Resources.tik32;
            this.ButonGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButonGuncelle.Location = new System.Drawing.Point(677, 249);
            this.ButonGuncelle.Name = "ButonGuncelle";
            this.ButonGuncelle.Size = new System.Drawing.Size(94, 38);
            this.ButonGuncelle.TabIndex = 8;
            this.ButonGuncelle.Text = "Güncelle  ";
            this.ButonGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButonGuncelle.UseVisualStyleBackColor = true;
            this.ButonGuncelle.Click += new System.EventHandler(this.ButonGuncelle_Click);
            // 
            // Urunid
            // 
            this.Urunid.Location = new System.Drawing.Point(690, 213);
            this.Urunid.Name = "Urunid";
            this.Urunid.Size = new System.Drawing.Size(36, 20);
            this.Urunid.TabIndex = 7;
            this.Urunid.Visible = false;
            this.Urunid.TextChanged += new System.EventHandler(this.Urunid_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(660, 230);
            this.dataGridView1.TabIndex = 6;
            // 
            // görsel2projeDataSet
            // 
            this.görsel2projeDataSet.DataSetName = "görsel2projeDataSet";
            this.görsel2projeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // urunlerBindingSource
            // 
            this.urunlerBindingSource.DataMember = "Urunler";
            this.urunlerBindingSource.DataSource = this.görsel2projeDataSet;
            // 
            // urunlerTableAdapter
            // 
            this.urunlerTableAdapter.ClearBeforeFill = true;
            // 
            // urunler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 419);
            this.Controls.Add(this.UrunArama);
            this.Controls.Add(this.ButonSil);
            this.Controls.Add(this.ButonGuncelle);
            this.Controls.Add(this.Urunid);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(792, 458);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(792, 458);
            this.Name = "urunler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürünler";
            this.Load += new System.EventHandler(this.urunler_Load);
            this.UrunArama.ResumeLayout(false);
            this.UrunBarkodaGoreGrup.ResumeLayout(false);
            this.UrunBarkodaGoreGrup.PerformLayout();
            this.UrunAdaGoreGrup.ResumeLayout(false);
            this.UrunAdaGoreGrup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.görsel2projeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunlerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox UrunArama;
        private System.Windows.Forms.GroupBox UrunBarkodaGoreGrup;
        private System.Windows.Forms.Button AramaButonBarkod;
        public System.Windows.Forms.TextBox BarkodNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox UrunAdaGoreGrup;
        private System.Windows.Forms.Button AramaButonAd;
        public System.Windows.Forms.TextBox UrunAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButonSil;
        private System.Windows.Forms.Button ButonGuncelle;
        private System.Windows.Forms.TextBox Urunid;
        public System.Windows.Forms.DataGridView dataGridView1;
        private görsel2projeDataSet görsel2projeDataSet;
        private System.Windows.Forms.BindingSource urunlerBindingSource;
        private görsel2projeDataSetTableAdapters.UrunlerTableAdapter urunlerTableAdapter;
    }
}