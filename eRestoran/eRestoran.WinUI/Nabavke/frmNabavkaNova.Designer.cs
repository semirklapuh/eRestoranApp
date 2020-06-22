namespace eRestoran.WinUI.Nabavke
{
    partial class frmNabavkaNova
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblUI = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProizvod = new System.Windows.Forms.ComboBox();
            this.txtKolicina = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNaruci = new Bunifu.Framework.UI.BunifuFlatButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKolicina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(70)))));
            this.panel1.Controls.Add(this.lblUI);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(404, 86);
            this.panel1.TabIndex = 0;
            // 
            // lblUI
            // 
            this.lblUI.AutoSize = true;
            this.lblUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUI.ForeColor = System.Drawing.Color.White;
            this.lblUI.Location = new System.Drawing.Point(166, 29);
            this.lblUI.Name = "lblUI";
            this.lblUI.Size = new System.Drawing.Size(71, 20);
            this.lblUI.TabIndex = 2;
            this.lblUI.Text = "Nabavka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(36, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Proizvod:";
            // 
            // cmbProizvod
            // 
            this.cmbProizvod.FormattingEnabled = true;
            this.cmbProizvod.Location = new System.Drawing.Point(157, 157);
            this.cmbProizvod.Name = "cmbProizvod";
            this.cmbProizvod.Size = new System.Drawing.Size(213, 21);
            this.cmbProizvod.TabIndex = 6;
            // 
            // txtKolicina
            // 
            this.txtKolicina.Location = new System.Drawing.Point(157, 204);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(91, 20);
            this.txtKolicina.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(36, 202);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Količina:";
            // 
            // btnNaruci
            // 
            this.btnNaruci.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnNaruci.BackColor = System.Drawing.Color.DimGray;
            this.btnNaruci.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNaruci.BorderRadius = 0;
            this.btnNaruci.ButtonText = "   Naruči";
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
            this.btnNaruci.Location = new System.Drawing.Point(284, 266);
            this.btnNaruci.Name = "btnNaruci";
            this.btnNaruci.Normalcolor = System.Drawing.Color.DimGray;
            this.btnNaruci.OnHovercolor = System.Drawing.Color.DarkGray;
            this.btnNaruci.OnHoverTextColor = System.Drawing.Color.White;
            this.btnNaruci.selected = false;
            this.btnNaruci.Size = new System.Drawing.Size(86, 31);
            this.btnNaruci.TabIndex = 9;
            this.btnNaruci.Text = "   Naruči";
            this.btnNaruci.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNaruci.Textcolor = System.Drawing.Color.White;
            this.btnNaruci.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNaruci.Click += new System.EventHandler(this.BtnNaruci_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmNabavkaNova
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(404, 342);
            this.Controls.Add(this.btnNaruci);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtKolicina);
            this.Controls.Add(this.cmbProizvod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "frmNabavkaNova";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmNabavkaNova";
            this.Load += new System.EventHandler(this.FrmNabavkaNova_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtKolicina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProizvod;
        private System.Windows.Forms.NumericUpDown txtKolicina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUI;
        private Bunifu.Framework.UI.BunifuFlatButton btnNaruci;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}