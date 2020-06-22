namespace eRestoran.WinUI.Nabavke
{
    partial class frmNabavkaDetalji
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDetalji = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.Roba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dostavljeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stanje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnZavrsi = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalji)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDetalji);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(686, 284);
            this.panel1.TabIndex = 0;
            // 
            // dgvDetalji
            // 
            this.dgvDetalji.AllowUserToAddRows = false;
            this.dgvDetalji.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgvDetalji.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalji.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvDetalji.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalji.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalji.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalji.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalji.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Roba,
            this.Dostavljeno,
            this.Stanje,
            this.Sifra});
            this.dgvDetalji.DoubleBuffered = true;
            this.dgvDetalji.EnableHeadersVisualStyles = false;
            this.dgvDetalji.HeaderBgColor = System.Drawing.Color.DimGray;
            this.dgvDetalji.HeaderForeColor = System.Drawing.Color.White;
            this.dgvDetalji.Location = new System.Drawing.Point(0, 0);
            this.dgvDetalji.Name = "dgvDetalji";
            this.dgvDetalji.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvDetalji.RowHeadersVisible = false;
            this.dgvDetalji.Size = new System.Drawing.Size(686, 309);
            this.dgvDetalji.TabIndex = 0;
            this.dgvDetalji.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDetalji_CellContentClick);
            // 
            // Roba
            // 
            this.Roba.DataPropertyName = "Roba";
            this.Roba.HeaderText = "Roba";
            this.Roba.Name = "Roba";
            // 
            // Dostavljeno
            // 
            this.Dostavljeno.DataPropertyName = "Dostavljeno";
            this.Dostavljeno.HeaderText = "Dostavljeno";
            this.Dostavljeno.Name = "Dostavljeno";
            // 
            // Stanje
            // 
            this.Stanje.DataPropertyName = "Stanje";
            this.Stanje.HeaderText = "Trenutno stanje";
            this.Stanje.Name = "Stanje";
            // 
            // Sifra
            // 
            this.Sifra.DataPropertyName = "Sifra";
            this.Sifra.HeaderText = "Sifra";
            this.Sifra.Name = "Sifra";
            // 
            // btnZavrsi
            // 
            this.btnZavrsi.BackColor = System.Drawing.Color.DimGray;
            this.btnZavrsi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZavrsi.ForeColor = System.Drawing.Color.White;
            this.btnZavrsi.Location = new System.Drawing.Point(537, 326);
            this.btnZavrsi.Name = "btnZavrsi";
            this.btnZavrsi.Size = new System.Drawing.Size(109, 38);
            this.btnZavrsi.TabIndex = 11;
            this.btnZavrsi.Text = "Završi narudžbu";
            this.btnZavrsi.UseVisualStyleBackColor = false;
            this.btnZavrsi.Click += new System.EventHandler(this.BtnZavrsi_Click);
            // 
            // frmNabavkaDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(686, 376);
            this.Controls.Add(this.btnZavrsi);
            this.Controls.Add(this.panel1);
            this.Name = "frmNabavkaDetalji";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNabavkaDetalji";
            this.Load += new System.EventHandler(this.FrmNabavkaDetalji_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalji)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dgvDetalji;
        private System.Windows.Forms.DataGridViewTextBoxColumn Roba;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dostavljeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stanje;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifra;
        private System.Windows.Forms.Button btnZavrsi;
    }
}