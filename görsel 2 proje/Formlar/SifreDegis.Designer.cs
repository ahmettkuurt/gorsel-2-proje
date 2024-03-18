namespace görsel_2_proje.Formlar
{
    partial class SifreDegis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SifreDegis));
            this.eskiSifre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Degistir = new System.Windows.Forms.Button();
            this.yeniSifre2 = new System.Windows.Forms.TextBox();
            this.yeniSifre1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // eskiSifre
            // 
            this.eskiSifre.Location = new System.Drawing.Point(87, 106);
            this.eskiSifre.Name = "eskiSifre";
            this.eskiSifre.PasswordChar = '●';
            this.eskiSifre.Size = new System.Drawing.Size(109, 20);
            this.eskiSifre.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Eski Şifre :";
            // 
            // Degistir
            // 
            this.Degistir.Location = new System.Drawing.Point(217, 130);
            this.Degistir.Name = "Degistir";
            this.Degistir.Size = new System.Drawing.Size(77, 47);
            this.Degistir.TabIndex = 17;
            this.Degistir.Text = "Kaydet";
            this.Degistir.UseVisualStyleBackColor = true;
            this.Degistir.Click += new System.EventHandler(this.Degistir_Click);
            // 
            // yeniSifre2
            // 
            this.yeniSifre2.Location = new System.Drawing.Point(87, 157);
            this.yeniSifre2.Name = "yeniSifre2";
            this.yeniSifre2.PasswordChar = '●';
            this.yeniSifre2.Size = new System.Drawing.Size(109, 20);
            this.yeniSifre2.TabIndex = 15;
            // 
            // yeniSifre1
            // 
            this.yeniSifre1.Location = new System.Drawing.Point(87, 132);
            this.yeniSifre1.Name = "yeniSifre1";
            this.yeniSifre1.PasswordChar = '●';
            this.yeniSifre1.Size = new System.Drawing.Size(109, 20);
            this.yeniSifre1.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tekrar Şifre :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Şifre :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(112, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 30);
            this.label4.TabIndex = 16;
            this.label4.Text = "Not: Şifrenizi unuttuğunuz taktirde\r\nsistem sağlayıcınıza başvurunuz.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(9, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 30);
            this.label3.TabIndex = 14;
            this.label3.Text = "Şifreyi değiştirdikten sonra bir sonraki girişte \r\nbu şifre kullanılacaktır.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(9, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "Programın ilk kullanım şifresi \'123\' dür.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Sisteme giriş yaparken kullandığınız şifreyi değiştirin.";
            // 
            // SifreDegis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 229);
            this.Controls.Add(this.eskiSifre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Degistir);
            this.Controls.Add(this.yeniSifre2);
            this.Controls.Add(this.yeniSifre1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(326, 268);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(326, 268);
            this.Name = "SifreDegis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Şifre Değiştirme";
            this.Load += new System.EventHandler(this.SifreDegis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox eskiSifre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Degistir;
        private System.Windows.Forms.TextBox yeniSifre2;
        private System.Windows.Forms.TextBox yeniSifre1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}