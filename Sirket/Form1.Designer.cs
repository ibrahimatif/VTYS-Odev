namespace Sirket
{
    partial class giris
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(giris));
            this.sifreTB = new System.Windows.Forms.TextBox();
            this.kullaniciAdiTB = new System.Windows.Forms.TextBox();
            this.girisBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sifreTB
            // 
            this.sifreTB.BackColor = System.Drawing.SystemColors.Info;
            this.sifreTB.Location = new System.Drawing.Point(75, 190);
            this.sifreTB.Name = "sifreTB";
            this.sifreTB.Size = new System.Drawing.Size(150, 20);
            this.sifreTB.TabIndex = 0;
            this.sifreTB.UseSystemPasswordChar = true;
            // 
            // kullaniciAdiTB
            // 
            this.kullaniciAdiTB.BackColor = System.Drawing.SystemColors.Info;
            this.kullaniciAdiTB.Location = new System.Drawing.Point(75, 150);
            this.kullaniciAdiTB.Name = "kullaniciAdiTB";
            this.kullaniciAdiTB.Size = new System.Drawing.Size(150, 20);
            this.kullaniciAdiTB.TabIndex = 1;
            // 
            // girisBTN
            // 
            this.girisBTN.Location = new System.Drawing.Point(75, 230);
            this.girisBTN.Name = "girisBTN";
            this.girisBTN.Size = new System.Drawing.Size(150, 23);
            this.girisBTN.TabIndex = 2;
            this.girisBTN.Text = "Giriş";
            this.girisBTN.UseVisualStyleBackColor = true;
            this.girisBTN.Click += new System.EventHandler(this.girisBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre";
            // 
            // giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(284, 411);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.girisBTN);
            this.Controls.Add(this.kullaniciAdiTB);
            this.Controls.Add(this.sifreTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 450);
            this.Name = "giris";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Sirket";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.giris_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sifreTB;
        private System.Windows.Forms.TextBox kullaniciAdiTB;
        private System.Windows.Forms.Button girisBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

