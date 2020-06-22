namespace eRestoran.WinUI.Obavijesti
{
    partial class frmObavijestDetalji
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmObavijestDetalji));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbUposlenik = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Sačuvaj = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDatum = new System.Windows.Forms.DateTimePicker();
            this.txtSadrzaj = new WindowsFormsControlLibrary1.BunifuCustomTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.lblUI = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbUposlenik);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Sačuvaj);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtDatum);
            this.panel1.Controls.Add(this.txtSadrzaj);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtNaziv);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 354);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // cmbUposlenik
            // 
            this.cmbUposlenik.FormattingEnabled = true;
            this.cmbUposlenik.Location = new System.Drawing.Point(153, 137);
            this.cmbUposlenik.Name = "cmbUposlenik";
            this.cmbUposlenik.Size = new System.Drawing.Size(213, 21);
            this.cmbUposlenik.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(34, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Uposlenik:";
            // 
            // Sačuvaj
            // 
            this.Sačuvaj.ActiveBorderThickness = 1;
            this.Sačuvaj.ActiveCornerRadius = 20;
            this.Sačuvaj.ActiveFillColor = System.Drawing.Color.LimeGreen;
            this.Sačuvaj.ActiveForecolor = System.Drawing.Color.White;
            this.Sačuvaj.ActiveLineColor = System.Drawing.Color.Black;
            this.Sačuvaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.Sačuvaj.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Sačuvaj.BackgroundImage")));
            this.Sačuvaj.ButtonText = "Sačuvaj";
            this.Sačuvaj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Sačuvaj.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sačuvaj.ForeColor = System.Drawing.Color.Snow;
            this.Sačuvaj.IdleBorderThickness = 1;
            this.Sačuvaj.IdleCornerRadius = 20;
            this.Sačuvaj.IdleFillColor = System.Drawing.Color.White;
            this.Sačuvaj.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.Sačuvaj.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.Sačuvaj.Location = new System.Drawing.Point(185, 275);
            this.Sačuvaj.Margin = new System.Windows.Forms.Padding(5);
            this.Sačuvaj.Name = "Sačuvaj";
            this.Sačuvaj.Size = new System.Drawing.Size(181, 41);
            this.Sačuvaj.TabIndex = 8;
            this.Sačuvaj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Sačuvaj.Click += new System.EventHandler(this.BunifuThinButton21_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(34, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sadržaj:";
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(153, 92);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.Size = new System.Drawing.Size(213, 20);
            this.txtDatum.TabIndex = 6;
            // 
            // txtSadrzaj
            // 
            this.txtSadrzaj.BorderColor = System.Drawing.Color.SeaGreen;
            this.txtSadrzaj.Location = new System.Drawing.Point(153, 190);
            this.txtSadrzaj.Multiline = true;
            this.txtSadrzaj.Name = "txtSadrzaj";
            this.txtSadrzaj.Size = new System.Drawing.Size(213, 60);
            this.txtSadrzaj.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(34, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Datum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(34, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Naziv:";
            // 
            // txtNaziv
            // 
            this.txtNaziv.Location = new System.Drawing.Point(153, 40);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(213, 20);
            this.txtNaziv.TabIndex = 0;
            // 
            // lblUI
            // 
            this.lblUI.AutoSize = true;
            this.lblUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUI.ForeColor = System.Drawing.Color.White;
            this.lblUI.Location = new System.Drawing.Point(149, 53);
            this.lblUI.Name = "lblUI";
            this.lblUI.Size = new System.Drawing.Size(74, 20);
            this.lblUI.TabIndex = 1;
            this.lblUI.Text = "Obavijest";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmObavijestDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(418, 450);
            this.Controls.Add(this.lblUI);
            this.Controls.Add(this.panel1);
            this.Name = "frmObavijestDetalji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmObavijestDetalji";
            this.Load += new System.EventHandler(this.FrmObavijestDetalji_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label lblUI;
        private System.Windows.Forms.ComboBox cmbUposlenik;
        private System.Windows.Forms.Label label5;
        private Bunifu.Framework.UI.BunifuThinButton2 Sačuvaj;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker txtDatum;
        private WindowsFormsControlLibrary1.BunifuCustomTextbox txtSadrzaj;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}