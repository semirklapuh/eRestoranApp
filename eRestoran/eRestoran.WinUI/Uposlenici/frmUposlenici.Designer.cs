namespace eRestoran.WinUI.Uposlenici
{
    partial class frmUposlenici
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPret = new System.Windows.Forms.TextBox();
            this.cmbVrsta = new System.Windows.Forms.ComboBox();
            this.dgvUposlenici = new System.Windows.Forms.DataGridView();
            this.UposlenikId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnickoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPretraga = new Bunifu.Framework.UI.BunifuFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUposlenici)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pretraga po imenu";
            // 
            // txtPret
            // 
            this.txtPret.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPret.Location = new System.Drawing.Point(159, 23);
            this.txtPret.Name = "txtPret";
            this.txtPret.Size = new System.Drawing.Size(143, 20);
            this.txtPret.TabIndex = 3;
            this.txtPret.TextChanged += new System.EventHandler(this.TxtPret_TextChanged);
            // 
            // cmbVrsta
            // 
            this.cmbVrsta.FormattingEnabled = true;
            this.cmbVrsta.Location = new System.Drawing.Point(308, 23);
            this.cmbVrsta.Name = "cmbVrsta";
            this.cmbVrsta.Size = new System.Drawing.Size(143, 21);
            this.cmbVrsta.TabIndex = 4;
            this.cmbVrsta.SelectedIndexChanged += new System.EventHandler(this.CmbVrsta_SelectedIndexChanged);
            // 
            // dgvUposlenici
            // 
            this.dgvUposlenici.AllowUserToAddRows = false;
            this.dgvUposlenici.AllowUserToDeleteRows = false;
            this.dgvUposlenici.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUposlenici.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UposlenikId,
            this.Ime,
            this.Prezime,
            this.KorisnickoIme,
            this.Telefon,
            this.Grad,
            this.StatusS,
            this.Detalji});
            this.dgvUposlenici.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUposlenici.Location = new System.Drawing.Point(0, 0);
            this.dgvUposlenici.Name = "dgvUposlenici";
            this.dgvUposlenici.ReadOnly = true;
            this.dgvUposlenici.RowHeadersVisible = false;
            this.dgvUposlenici.Size = new System.Drawing.Size(707, 279);
            this.dgvUposlenici.TabIndex = 0;
            this.dgvUposlenici.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUposlenici_CellContentClick);
            // 
            // UposlenikId
            // 
            this.UposlenikId.DataPropertyName = "KorisnikId";
            this.UposlenikId.HeaderText = "UposlenikId";
            this.UposlenikId.Name = "UposlenikId";
            this.UposlenikId.ReadOnly = true;
            this.UposlenikId.Visible = false;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            this.Ime.ReadOnly = true;
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Prezime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            this.Prezime.ReadOnly = true;
            // 
            // KorisnickoIme
            // 
            this.KorisnickoIme.DataPropertyName = "KorisnickoIme";
            this.KorisnickoIme.HeaderText = "Korisničko ime";
            this.KorisnickoIme.Name = "KorisnickoIme";
            this.KorisnickoIme.ReadOnly = true;
            // 
            // Telefon
            // 
            this.Telefon.DataPropertyName = "Telefon";
            this.Telefon.HeaderText = "Telefon";
            this.Telefon.Name = "Telefon";
            this.Telefon.ReadOnly = true;
            // 
            // Grad
            // 
            this.Grad.DataPropertyName = "Grad";
            this.Grad.HeaderText = "Grad";
            this.Grad.Name = "Grad";
            this.Grad.ReadOnly = true;
            // 
            // StatusS
            // 
            this.StatusS.DataPropertyName = "StatusS";
            this.StatusS.HeaderText = "Aktivnost";
            this.StatusS.Name = "StatusS";
            this.StatusS.ReadOnly = true;
            // 
            // Detalji
            // 
            this.Detalji.HeaderText = "";
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            this.Detalji.Text = "Detalji";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvUposlenici);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(707, 279);
            this.panel1.TabIndex = 6;
            // 
            // btnPretraga
            // 
            this.btnPretraga.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnPretraga.BackColor = System.Drawing.Color.DimGray;
            this.btnPretraga.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPretraga.BorderRadius = 0;
            this.btnPretraga.ButtonText = "Pretraži";
            this.btnPretraga.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPretraga.DisabledColor = System.Drawing.Color.DimGray;
            this.btnPretraga.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.btnPretraga.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPretraga.Iconcolor = System.Drawing.Color.DimGray;
            this.btnPretraga.Iconimage = null;
            this.btnPretraga.Iconimage_right = null;
            this.btnPretraga.Iconimage_right_Selected = null;
            this.btnPretraga.Iconimage_Selected = null;
            this.btnPretraga.IconMarginLeft = 18;
            this.btnPretraga.IconMarginRight = 0;
            this.btnPretraga.IconRightVisible = true;
            this.btnPretraga.IconRightZoom = 0D;
            this.btnPretraga.IconVisible = true;
            this.btnPretraga.IconZoom = 90D;
            this.btnPretraga.IsTab = false;
            this.btnPretraga.Location = new System.Drawing.Point(468, 23);
            this.btnPretraga.Margin = new System.Windows.Forms.Padding(0);
            this.btnPretraga.Name = "btnPretraga";
            this.btnPretraga.Normalcolor = System.Drawing.Color.DimGray;
            this.btnPretraga.OnHovercolor = System.Drawing.Color.DarkGray;
            this.btnPretraga.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPretraga.selected = false;
            this.btnPretraga.Size = new System.Drawing.Size(91, 21);
            this.btnPretraga.TabIndex = 7;
            this.btnPretraga.Text = "Pretraži";
            this.btnPretraga.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPretraga.Textcolor = System.Drawing.Color.White;
            this.btnPretraga.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPretraga.Click += new System.EventHandler(this.BtnPretraga_Click_1);
            // 
            // frmUposlenici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(707, 351);
            this.ControlBox = false;
            this.Controls.Add(this.btnPretraga);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbVrsta);
            this.Controls.Add(this.txtPret);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUposlenici";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Uposlenici";
            this.Load += new System.EventHandler(this.FrmUposlenici_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUposlenici)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPret;
        private System.Windows.Forms.ComboBox cmbVrsta;
        private System.Windows.Forms.DataGridView dgvUposlenici;
        private System.Windows.Forms.DataGridViewTextBoxColumn UposlenikId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnickoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusS;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnPretraga;
    }
}