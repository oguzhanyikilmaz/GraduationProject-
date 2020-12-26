namespace Presentation.Client
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnStart = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pBoxMain = new System.Windows.Forms.PictureBox();
            this.lblAciklama = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.FlatAppearance.BorderSize = 5;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Castellar", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnStart.Location = new System.Drawing.Point(745, 535);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(450, 173);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "ALISVERİSE BASLA";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Castellar", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblWelcome.Location = new System.Drawing.Point(217, 55);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(832, 58);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "HIZLI ÖDEMEYE HOSGELDİNİZ";
            // 
            // pBoxMain
            // 
            this.pBoxMain.Image = ((System.Drawing.Image)(resources.GetObject("pBoxMain.Image")));
            this.pBoxMain.Location = new System.Drawing.Point(54, 161);
            this.pBoxMain.Name = "pBoxMain";
            this.pBoxMain.Size = new System.Drawing.Size(597, 534);
            this.pBoxMain.TabIndex = 3;
            this.pBoxMain.TabStop = false;
            // 
            // lblAciklama
            // 
            this.lblAciklama.Font = new System.Drawing.Font("Castellar", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAciklama.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblAciklama.Location = new System.Drawing.Point(584, 175);
            this.lblAciklama.Name = "lblAciklama";
            this.lblAciklama.Size = new System.Drawing.Size(772, 357);
            this.lblAciklama.TabIndex = 6;
            this.lblAciklama.Text = "Sadece kredi kartı ile sıra beklemeden hızlı alısveris sonlandırmak için alısveri" +
    "si baslatınız.";
            this.lblAciklama.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAciklama.Click += new System.EventHandler(this.lblAciklama_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1248, 762);
            this.Controls.Add(this.lblAciklama);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pBoxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.PictureBox pBoxMain;
        private System.Windows.Forms.Label lblAciklama;
    }
}