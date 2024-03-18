namespace görsel_2_proje.urun
{
    partial class urunGüncelle2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(urunGüncelle2));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AlisFiyat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.barkodlu = new System.Windows.Forms.CheckBox();
            this.UrunFiyat = new System.Windows.Forms.TextBox();
            this.UrunBarkod = new System.Windows.Forms.TextBox();
            this.UrunAdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Guncelle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AlisFiyat);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.barkodlu);
            this.groupBox1.Controls.Add(this.UrunFiyat);
            this.groupBox1.Controls.Add(this.UrunBarkod);
            this.groupBox1.Controls.Add(this.UrunAdi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Guncelle);
            this.groupBox1.Location = new System.Drawing.Point(5, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 276);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // AlisFiyat
            // 
            this.AlisFiyat.AcceptsReturn = true;
            this.AlisFiyat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.AlisFiyat.Location = new System.Drawing.Point(94, 110);
            this.AlisFiyat.MaxLength = 10;
            this.AlisFiyat.Name = "AlisFiyat";
            this.AlisFiyat.Size = new System.Drawing.Size(160, 20);
            this.AlisFiyat.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Ürün Satış Fiyatı:";
            // 
            // barkodlu
            // 
            this.barkodlu.AutoSize = true;
            this.barkodlu.Checked = true;
            this.barkodlu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.barkodlu.Location = new System.Drawing.Point(261, 71);
            this.barkodlu.Name = "barkodlu";
            this.barkodlu.Size = new System.Drawing.Size(76, 17);
            this.barkodlu.TabIndex = 3;
            this.barkodlu.Text = "Barkodsuz";
            this.barkodlu.UseVisualStyleBackColor = true;
            // 
            // UrunFiyat
            // 
            this.UrunFiyat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.UrunFiyat.Location = new System.Drawing.Point(94, 147);
            this.UrunFiyat.MaxLength = 10;
            this.UrunFiyat.Name = "UrunFiyat";
            this.UrunFiyat.Size = new System.Drawing.Size(160, 20);
            this.UrunFiyat.TabIndex = 5;
            // 
            // UrunBarkod
            // 
            this.UrunBarkod.Enabled = false;
            this.UrunBarkod.Location = new System.Drawing.Point(94, 69);
            this.UrunBarkod.MaxLength = 15;
            this.UrunBarkod.Name = "UrunBarkod";
            this.UrunBarkod.Size = new System.Drawing.Size(160, 20);
            this.UrunBarkod.TabIndex = 2;
            this.UrunBarkod.Text = "Barkod Eklenmedi";
            // 
            // UrunAdi
            // 
            this.UrunAdi.Location = new System.Drawing.Point(94, 30);
            this.UrunAdi.MaxLength = 100;
            this.UrunAdi.Name = "UrunAdi";
            this.UrunAdi.Size = new System.Drawing.Size(160, 20);
            this.UrunAdi.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 39;
            this.label3.Text = "Ürün Alış Fiyatı:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Ürün Barkod:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Ürün Adı:";
            // 
            // Guncelle
            // 
            this.Guncelle.Image = global::görsel_2_proje.Properties.Resources.tik32;
            this.Guncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Guncelle.Location = new System.Drawing.Point(89, 214);
            this.Guncelle.Name = "Guncelle";
            this.Guncelle.Size = new System.Drawing.Size(94, 40);
            this.Guncelle.TabIndex = 7;
            this.Guncelle.Text = "Güncelle ";
            this.Guncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Guncelle.UseVisualStyleBackColor = true;
            this.Guncelle.Click += new System.EventHandler(this.Guncelle_Click);
            // 
            // urunGüncelle2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 293);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(364, 332);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(364, 332);
            this.Name = "urunGüncelle2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ürün Güncelle";
            this.Load += new System.EventHandler(this.urunGüncelle2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox AlisFiyat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox barkodlu;
        private System.Windows.Forms.TextBox UrunFiyat;
        private System.Windows.Forms.TextBox UrunBarkod;
        private System.Windows.Forms.TextBox UrunAdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Guncelle;
    }
}