namespace eRestoran.WinUI.Nabavke
{
    partial class frmNabavke
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvNabavke = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.NabavkaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumNabavke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zavrsena = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImePrezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Detalji = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtDatum = new System.Windows.Forms.DateTimePicker();
            this.btnNaruci = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNabavke)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvNabavke);
            this.panel1.Location = new System.Drawing.Point(2, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 248);
            this.panel1.TabIndex = 0;
            // 
            // dgvNabavke
            // 
            this.dgvNabavke.AllowUserToAddRows = false;
            this.dgvNabavke.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvNabavke.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNabavke.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvNabavke.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvNabavke.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNabavke.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvNabavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNabavke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NabavkaId,
            this.DatumNabavke,
            this.Zavrsena,
            this.Cijena,
            this.ImePrezime,
            this.Detalji});
            this.dgvNabavke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNabavke.DoubleBuffered = true;
            this.dgvNabavke.EnableHeadersVisualStyles = false;
            this.dgvNabavke.HeaderBgColor = System.Drawing.Color.DimGray;
            this.dgvNabavke.HeaderForeColor = System.Drawing.Color.White;
            this.dgvNabavke.Location = new System.Drawing.Point(0, 0);
            this.dgvNabavke.Name = "dgvNabavke";
            this.dgvNabavke.ReadOnly = true;
            this.dgvNabavke.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNabavke.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvNabavke.RowHeadersVisible = false;
            this.dgvNabavke.Size = new System.Drawing.Size(635, 248);
            this.dgvNabavke.TabIndex = 0;
            this.dgvNabavke.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNabavke_CellContentClick);
            // 
            // NabavkaId
            // 
            this.NabavkaId.DataPropertyName = "NabavkaId";
            this.NabavkaId.HeaderText = "NabavkaId";
            this.NabavkaId.Name = "NabavkaId";
            this.NabavkaId.ReadOnly = true;
            this.NabavkaId.Visible = false;
            // 
            // DatumNabavke
            // 
            this.DatumNabavke.DataPropertyName = "DatumNabavke";
            this.DatumNabavke.HeaderText = "Datum nabavke";
            this.DatumNabavke.Name = "DatumNabavke";
            this.DatumNabavke.ReadOnly = true;
            // 
            // Zavrsena
            // 
            this.Zavrsena.DataPropertyName = "Zavrsena";
            this.Zavrsena.HeaderText = "Zavrsena";
            this.Zavrsena.Name = "Zavrsena";
            this.Zavrsena.ReadOnly = true;
            this.Zavrsena.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Zavrsena.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // ImePrezime
            // 
            this.ImePrezime.DataPropertyName = "ImePrezime";
            this.ImePrezime.HeaderText = "Uposlenik";
            this.ImePrezime.Name = "ImePrezime";
            this.ImePrezime.ReadOnly = true;
            // 
            // Detalji
            // 
            this.Detalji.HeaderText = "";
            this.Detalji.Name = "Detalji";
            this.Detalji.ReadOnly = true;
            this.Detalji.Text = "Detalji";
            this.Detalji.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Datum nabavke:";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(383, 8);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 11;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.CmbStatus_SelectedIndexChanged_1);
            // 
            // txtDatum
            // 
            this.txtDatum.Location = new System.Drawing.Point(137, 9);
            this.txtDatum.Name = "txtDatum";
            this.txtDatum.Size = new System.Drawing.Size(200, 20);
            this.txtDatum.TabIndex = 12;
            this.txtDatum.ValueChanged += new System.EventHandler(this.TxtDatum_ValueChanged);
            // 
            // btnNaruci
            // 
            this.btnNaruci.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnNaruci.BackColor = System.Drawing.Color.DimGray;
            this.btnNaruci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNaruci.BorderRadius = 0;
            this.btnNaruci.ButtonText = "     Naruči robu";
            this.btnNaruci.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNaruci.DisabledColor = System.Drawing.Color.Gray;
            this.btnNaruci.Iconcolor = System.Drawing.Color.Transparent;
            this.btnNaruci.Iconimage = null;
            this.btnNaruci.Iconimage_right = null;
            this.btnNaruci.Iconimage_right_Selected = null;
            this.btnNaruci.Iconimage_Selected = null;
            this.btnNaruci.IconMarginLeft = 0;
            this.btnNaruci.IconMarginRight = 0;
            this.btnNaruci.IconRightVisible = true;
            this.btnNaruci.IconRightZoom = 0D;
            this.btnNaruci.IconVisible = true;
            this.btnNaruci.IconZoom = 90D;
            this.btnNaruci.IsTab = false;
            this.btnNaruci.Location = new System.Drawing.Point(502, 345);
            this.btnNaruci.Name = "btnNaruci";
            this.btnNaruci.Normalcolor = System.Drawing.Color.DimGray;
            this.btnNaruci.OnHovercolor = System.Drawing.Color.DarkGray;
            this.btnNaruci.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNaruci.selected = false;
            this.btnNaruci.Size = new System.Drawing.Size(114, 39);
            this.btnNaruci.TabIndex = 14;
            this.btnNaruci.Text = "     Naruči robu";
            this.btnNaruci.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNaruci.Textcolor = System.Drawing.Color.White;
            this.btnNaruci.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNaruci.Click += new System.EventHandler(this.BtnNaruci_Click);
            // 
            // frmNabavke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(671, 396);
            this.Controls.Add(this.btnNaruci);
            this.Controls.Add(this.txtDatum);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNabavke";
            this.Text = "frmNabavke";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmNabavke_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNabavke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.DateTimePicker txtDatum;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvNabavke;
        private Bunifu.Framework.UI.BunifuFlatButton btnNaruci;
        private System.Windows.Forms.DataGridViewTextBoxColumn NabavkaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumNabavke;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Zavrsena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImePrezime;
        private System.Windows.Forms.DataGridViewButtonColumn Detalji;
    }
}