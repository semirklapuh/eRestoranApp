namespace eRestoran.WinUI.Roba
{
    partial class frmIzmjenaStanja
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProizvod = new System.Windows.Forms.TextBox();
            this.txtStanje = new System.Windows.Forms.TextBox();
            this.txtSave = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(55)))));
            this.panel1.Controls.Add(this.lblUI);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 131);
            this.panel1.TabIndex = 0;
            // 
            // lblUI
            // 
            this.lblUI.AutoSize = true;
            this.lblUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUI.ForeColor = System.Drawing.Color.White;
            this.lblUI.Location = new System.Drawing.Point(63, 48);
            this.lblUI.Name = "lblUI";
            this.lblUI.Size = new System.Drawing.Size(204, 33);
            this.lblUI.TabIndex = 1;
            this.lblUI.Text = "Izmjena stanja";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proizvod:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Stanje:";
            // 
            // txtProizvod
            // 
            this.txtProizvod.Location = new System.Drawing.Point(153, 160);
            this.txtProizvod.Name = "txtProizvod";
            this.txtProizvod.ReadOnly = true;
            this.txtProizvod.Size = new System.Drawing.Size(100, 20);
            this.txtProizvod.TabIndex = 3;
            // 
            // txtStanje
            // 
            this.txtStanje.Location = new System.Drawing.Point(153, 204);
            this.txtStanje.Name = "txtStanje";
            this.txtStanje.Size = new System.Drawing.Size(100, 20);
            this.txtStanje.TabIndex = 4;
            // 
            // txtSave
            // 
            this.txtSave.Location = new System.Drawing.Point(111, 273);
            this.txtSave.Name = "txtSave";
            this.txtSave.Size = new System.Drawing.Size(100, 31);
            this.txtSave.TabIndex = 5;
            this.txtSave.Text = "Sačuvaj";
            this.txtSave.UseVisualStyleBackColor = true;
            this.txtSave.Click += new System.EventHandler(this.TxtSave_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmIzmjenaStanja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(330, 342);
            this.Controls.Add(this.txtSave);
            this.Controls.Add(this.txtStanje);
            this.Controls.Add(this.txtProizvod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmIzmjenaStanja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmIzmjenaStanja";
            this.Load += new System.EventHandler(this.FrmIzmjenaStanja_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblUI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProizvod;
        private System.Windows.Forms.TextBox txtStanje;
        private System.Windows.Forms.Button txtSave;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}