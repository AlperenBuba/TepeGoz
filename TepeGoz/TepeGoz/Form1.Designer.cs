namespace TepeGoz
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.hesapAdiTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bulBtn = new System.Windows.Forms.Button();
            this.sonuclarLB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bagisBtn = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // hesapAdiTxt
            // 
            this.hesapAdiTxt.Location = new System.Drawing.Point(85, 10);
            this.hesapAdiTxt.Name = "hesapAdiTxt";
            this.hesapAdiTxt.Size = new System.Drawing.Size(446, 20);
            this.hesapAdiTxt.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username:";
            // 
            // bulBtn
            // 
            this.bulBtn.Location = new System.Drawing.Point(537, 8);
            this.bulBtn.Name = "bulBtn";
            this.bulBtn.Size = new System.Drawing.Size(75, 23);
            this.bulBtn.TabIndex = 2;
            this.bulBtn.Text = "Find";
            this.bulBtn.UseVisualStyleBackColor = true;
            this.bulBtn.Click += new System.EventHandler(this.bulBtn_Click);
            // 
            // sonuclarLB
            // 
            this.sonuclarLB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.sonuclarLB.ForeColor = System.Drawing.Color.LimeGreen;
            this.sonuclarLB.FormattingEnabled = true;
            this.sonuclarLB.Location = new System.Drawing.Point(15, 45);
            this.sonuclarLB.Name = "sonuclarLB";
            this.sonuclarLB.Size = new System.Drawing.Size(597, 342);
            this.sonuclarLB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(350, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Alperen Buba v1";
            // 
            // bagisBtn
            // 
            this.bagisBtn.BackColor = System.Drawing.Color.Lime;
            this.bagisBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bagisBtn.Location = new System.Drawing.Point(269, 401);
            this.bagisBtn.Name = "bagisBtn";
            this.bagisBtn.Size = new System.Drawing.Size(75, 23);
            this.bagisBtn.TabIndex = 5;
            this.bagisBtn.Text = "Support";
            this.bagisBtn.UseVisualStyleBackColor = false;
            this.bagisBtn.Click += new System.EventHandler(this.bagisBtn_Click_1);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 401);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(248, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::TepeGoz.Properties.Resources.tepegöz;
            this.pictureBox1.Location = new System.Drawing.Point(552, 388);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bagisBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sonuclarLB);
            this.Controls.Add(this.bulBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hesapAdiTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TepeGoz | OSINT";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hesapAdiTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bulBtn;
        private System.Windows.Forms.ListBox sonuclarLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bagisBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

