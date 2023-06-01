namespace Pointeuse
{
    partial class PointagePage
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnQrcode = new System.Windows.Forms.Button();
            this.pbQrcode = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnQrcodeScan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbQrcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQrcode
            // 
            this.btnQrcode.Location = new System.Drawing.Point(177, 461);
            this.btnQrcode.Name = "btnQrcode";
            this.btnQrcode.Size = new System.Drawing.Size(141, 23);
            this.btnQrcode.TabIndex = 0;
            this.btnQrcode.Text = "Generer un code QR";
            this.btnQrcode.UseVisualStyleBackColor = true;
            this.btnQrcode.Click += new System.EventHandler(this.btnQrcode_Click);
            // 
            // pbQrcode
            // 
            this.pbQrcode.Location = new System.Drawing.Point(27, 88);
            this.pbQrcode.Name = "pbQrcode";
            this.pbQrcode.Size = new System.Drawing.Size(462, 367);
            this.pbQrcode.TabIndex = 1;
            this.pbQrcode.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(520, 88);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(612, 367);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // btnQrcodeScan
            // 
            this.btnQrcodeScan.Location = new System.Drawing.Point(761, 461);
            this.btnQrcodeScan.Name = "btnQrcodeScan";
            this.btnQrcodeScan.Size = new System.Drawing.Size(144, 23);
            this.btnQrcodeScan.TabIndex = 3;
            this.btnQrcodeScan.Text = "Scanner un code QR";
            this.btnQrcodeScan.UseVisualStyleBackColor = true;
            this.btnQrcodeScan.Click += new System.EventHandler(this.btnQrcodeScan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(679, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(679, 553);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // PointagePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1387, 704);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnQrcodeScan);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pbQrcode);
            this.Controls.Add(this.btnQrcode);
            this.Name = "PointagePage";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PointagePage_FormClosing_1);
            ((System.ComponentModel.ISupportInitialize)(this.pbQrcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQrcode;
        private System.Windows.Forms.PictureBox pbQrcode;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnQrcodeScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
    }
}

