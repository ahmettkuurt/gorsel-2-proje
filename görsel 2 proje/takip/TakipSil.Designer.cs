﻿namespace görsel_2_proje.Formlar
{
    partial class TakipSil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TakipSil));
            this.Hayir = new System.Windows.Forms.Button();
            this.Evet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Hayir
            // 
            this.Hayir.Image = global::görsel_2_proje.Properties.Resources.carpi32;
            this.Hayir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Hayir.Location = new System.Drawing.Point(226, 103);
            this.Hayir.Name = "Hayir";
            this.Hayir.Size = new System.Drawing.Size(81, 38);
            this.Hayir.TabIndex = 22;
            this.Hayir.Text = "Hayır   ";
            this.Hayir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Hayir.UseVisualStyleBackColor = true;
            this.Hayir.Click += new System.EventHandler(this.Hayir_Click);
            // 
            // Evet
            // 
            this.Evet.Image = global::görsel_2_proje.Properties.Resources.tik32;
            this.Evet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Evet.Location = new System.Drawing.Point(139, 103);
            this.Evet.Name = "Evet";
            this.Evet.Size = new System.Drawing.Size(81, 38);
            this.Evet.TabIndex = 21;
            this.Evet.Text = "Evet   ";
            this.Evet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Evet.UseVisualStyleBackColor = true;
            this.Evet.Click += new System.EventHandler(this.Evet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 32);
            this.label1.TabIndex = 20;
            this.label1.Text = "Yukarıda numarası verilmiş teknik takip kaydını silmek istediğinize \r\nemin misini" +
    "z?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Algerian", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(147, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 24);
            this.label8.TabIndex = 19;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Takip Numarası:";
            // 
            // TakipSil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 156);
            this.Controls.Add(this.Hayir);
            this.Controls.Add(this.Evet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 195);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 195);
            this.Name = "TakipSil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Takip Sil";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Hayir;
        private System.Windows.Forms.Button Evet;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}