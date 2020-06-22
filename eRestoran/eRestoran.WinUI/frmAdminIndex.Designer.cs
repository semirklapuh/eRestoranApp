namespace eRestoran.WinUI
{
    partial class frmAdminIndex
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.uposleniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaUposlenikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviUposlenikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.robaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaRobeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviProizvodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uposleniciToolStripMenuItem,
            this.robaToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(788, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip_ItemClicked);
            // 
            // uposleniciToolStripMenuItem
            // 
            this.uposleniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaUposlenikaToolStripMenuItem,
            this.noviUposlenikToolStripMenuItem});
            this.uposleniciToolStripMenuItem.Name = "uposleniciToolStripMenuItem";
            this.uposleniciToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.uposleniciToolStripMenuItem.Text = "Uposlenici";
            // 
            // listaUposlenikaToolStripMenuItem
            // 
            this.listaUposlenikaToolStripMenuItem.Name = "listaUposlenikaToolStripMenuItem";
            this.listaUposlenikaToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.listaUposlenikaToolStripMenuItem.Text = "Lista uposlenika";
            this.listaUposlenikaToolStripMenuItem.Click += new System.EventHandler(this.ListaUposlenikaToolStripMenuItem_Click);
            // 
            // noviUposlenikToolStripMenuItem
            // 
            this.noviUposlenikToolStripMenuItem.Name = "noviUposlenikToolStripMenuItem";
            this.noviUposlenikToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.noviUposlenikToolStripMenuItem.Text = "Novi uposlenik";
            this.noviUposlenikToolStripMenuItem.Click += new System.EventHandler(this.NoviUposlenikToolStripMenuItem_Click);
            // 
            // robaToolStripMenuItem
            // 
            this.robaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaRobeToolStripMenuItem,
            this.noviProizvodToolStripMenuItem});
            this.robaToolStripMenuItem.Name = "robaToolStripMenuItem";
            this.robaToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.robaToolStripMenuItem.Text = "Roba";
            // 
            // listaRobeToolStripMenuItem
            // 
            this.listaRobeToolStripMenuItem.Name = "listaRobeToolStripMenuItem";
            this.listaRobeToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.listaRobeToolStripMenuItem.Text = "Lista proizvoda";
            this.listaRobeToolStripMenuItem.Click += new System.EventHandler(this.ListaRobeToolStripMenuItem_Click);
            // 
            // noviProizvodToolStripMenuItem
            // 
            this.noviProizvodToolStripMenuItem.Name = "noviProizvodToolStripMenuItem";
            this.noviProizvodToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.noviProizvodToolStripMenuItem.Text = "Novi proizvod";
            this.noviProizvodToolStripMenuItem.Click += new System.EventHandler(this.NoviProizvodToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 470);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(788, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.logOutToolStripMenuItem.Text = "Log out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.LogOutToolStripMenuItem_Click);
            // 
            // frmAdminIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 492);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmAdminIndex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAdminIndex";
            this.Load += new System.EventHandler(this.FrmAdminIndex_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem uposleniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaUposlenikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviUposlenikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem robaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaRobeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviProizvodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
    }
}



