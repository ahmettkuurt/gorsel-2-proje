namespace görsel_2_proje.urun
{
    partial class urunEkle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(urunEkle));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AlisFiyat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.barkodlu = new System.Windows.Forms.CheckBox();
            this.Ekle = new System.Windows.Forms.Button();
            this.urunkategoriBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.görsel2projeDataSet1 = new görsel_2_proje.görsel2projeDataSet();
            this.urunkategoriBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.görsel2projeDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.görsel2projeDataSet = new görsel_2_proje.görsel2projeDataSet();
            this.UrunFiyat = new System.Windows.Forms.TextBox();
            this.UrunBarkod = new System.Windows.Forms.TextBox();
            this.UrunAdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.urunkategoriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fKUrunkategoriBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.urunlerTableAdapter = new görsel_2_proje.görsel2projeDataSetTableAdapters.UrunlerTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.urunkategoriBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.görsel2projeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunkategoriBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.görsel2projeDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.görsel2projeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunkategoriBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKUrunkategoriBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AlisFiyat);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.barkodlu);
            this.groupBox1.Controls.Add(this.Ekle);
            this.groupBox1.Controls.Add(this.UrunFiyat);
            this.groupBox1.Controls.Add(this.UrunBarkod);
            this.groupBox1.Controls.Add(this.UrunAdi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 276);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // AlisFiyat
            // 
            this.AlisFiyat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.AlisFiyat.Location = new System.Drawing.Point(95, 103);
            this.AlisFiyat.MaxLength = 10;
            this.AlisFiyat.Name = "AlisFiyat";
            this.AlisFiyat.Size = new System.Drawing.Size(160, 20);
            this.AlisFiyat.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Ürün Satış Fiyatı:";
            // 
            // barkodlu
            // 
            this.barkodlu.AutoSize = true;
            this.barkodlu.Checked = true;
            this.barkodlu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.barkodlu.Location = new System.Drawing.Point(262, 64);
            this.barkodlu.Name = "barkodlu";
            this.barkodlu.Size = new System.Drawing.Size(76, 17);
            this.barkodlu.TabIndex = 3;
            this.barkodlu.Text = "Barkodsuz";
            this.barkodlu.UseVisualStyleBackColor = true;
            this.barkodlu.CheckedChanged += new System.EventHandler(this.barkodlu_CheckedChanged);
            // 
            // Ekle
            // 
            this.Ekle.Image = global::görsel_2_proje.Properties.Resources.tik32;
            this.Ekle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Ekle.Location = new System.Drawing.Point(89, 214);
            this.Ekle.Name = "Ekle";
            this.Ekle.Size = new System.Drawing.Size(94, 40);
            this.Ekle.TabIndex = 7;
            this.Ekle.Text = "      Ekle";
            this.Ekle.UseVisualStyleBackColor = true;
            this.Ekle.Click += new System.EventHandler(this.Ekle_Click_1);
            // 
            // urunkategoriBindingSource1
            // 
            this.urunkategoriBindingSource1.DataMember = "Urun_kategori";
            this.urunkategoriBindingSource1.DataSource = this.görsel2projeDataSet1;
            // 
            // görsel2projeDataSet1
            // 
            this.görsel2projeDataSet1.DataSetName = "görsel2projeDataSet";
            this.görsel2projeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // urunkategoriBindingSource2
            // 
            this.urunkategoriBindingSource2.DataMember = "Urun_kategori";
            this.urunkategoriBindingSource2.DataSource = this.görsel2projeDataSetBindingSource;
            // 
            // görsel2projeDataSetBindingSource
            // 
            this.görsel2projeDataSetBindingSource.DataSource = this.görsel2projeDataSet;
            this.görsel2projeDataSetBindingSource.Position = 0;
            // 
            // görsel2projeDataSet
            // 
            this.görsel2projeDataSet.DataSetName = "görsel2projeDataSet";
            this.görsel2projeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UrunFiyat
            // 
            this.UrunFiyat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.UrunFiyat.Location = new System.Drawing.Point(95, 140);
            this.UrunFiyat.MaxLength = 10;
            this.UrunFiyat.Name = "UrunFiyat";
            this.UrunFiyat.Size = new System.Drawing.Size(160, 20);
            this.UrunFiyat.TabIndex = 5;
            // 
            // UrunBarkod
            // 
            this.UrunBarkod.Enabled = false;
            this.UrunBarkod.Location = new System.Drawing.Point(95, 62);
            this.UrunBarkod.MaxLength = 15;
            this.UrunBarkod.Name = "UrunBarkod";
            this.UrunBarkod.Size = new System.Drawing.Size(160, 20);
            this.UrunBarkod.TabIndex = 2;
            this.UrunBarkod.Text = "Barkod Eklenmedi";
            // 
            // UrunAdi
            // 
            this.UrunAdi.Location = new System.Drawing.Point(95, 23);
            this.UrunAdi.MaxLength = 100;
            this.UrunAdi.Multiline = true;
            this.UrunAdi.Name = "UrunAdi";
            this.UrunAdi.Size = new System.Drawing.Size(160, 20);
            this.UrunAdi.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ürün Alış Fiyatı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ürün Barkod:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ürün Adı:";
            // 
            // urunkategoriBindingSource
            // 
            this.urunkategoriBindingSource.DataMember = "Urun_kategori";
            this.urunkategoriBindingSource.DataSource = this.görsel2projeDataSet;
            // 
            // urun_kategoriTableAdapter
            // 
            // 
            // fKUrunkategoriBindingSource
            // 
            this.fKUrunkategoriBindingSource.DataMember = "FK_Urunler_Urun_kategori";
            this.fKUrunkategoriBindingSource.DataSource = this.urunkategoriBindingSource;
            // 
            // urunlerTableAdapter
            // 
            this.urunlerTableAdapter.ClearBeforeFill = true;
            // 
            // urunEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 284);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(363, 323);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(363, 323);
            this.Name = "urunEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ürün Ekle";
            this.Load += new System.EventHandler(this.urunEkle_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.urunkategoriBindingSource1)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.görsel2projeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunkategoriBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.görsel2projeDataSetBindingSource)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.görsel2projeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.urunkategoriBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fKUrunkategoriBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox AlisFiyat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox barkodlu;
        private System.Windows.Forms.Button Ekle;
        private System.Windows.Forms.TextBox UrunFiyat;
        private System.Windows.Forms.TextBox UrunBarkod;
        private System.Windows.Forms.TextBox UrunAdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource görsel2projeDataSetBindingSource;
        private görsel2projeDataSet görsel2projeDataSet;
        private System.Windows.Forms.BindingSource urunkategoriBindingSource;
        private System.Windows.Forms.BindingSource fKUrunkategoriBindingSource;
        private görsel2projeDataSetTableAdapters.UrunlerTableAdapter urunlerTableAdapter;
        private görsel2projeDataSet görsel2projeDataSet1;
        private System.Windows.Forms.BindingSource urunkategoriBindingSource1;
        private System.Windows.Forms.BindingSource urunkategoriBindingSource2;
    }
}