using eRestoran.WinUI.Narudzbe;
using eRestoran.WinUI.Obavijesti;
using eRestoran.WinUI.Rezervacije;
using eRestoran.WinUI.Roba;
using eRestoran.WinUI.Uposlenici;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoran.WinUI
{
    public partial class frmMenadzerIndex : Form
    {


        private int childFormNumber = 0;

        public frmMenadzerIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        //}

        //private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        //}

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }





        private void Label3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Zelite li izaći iz aplikacije?", "Zatvori", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Label4_Click(object sender, EventArgs e)
        {
            
        }

        private void B1_Click(object sender, EventArgs e)
        {
            frmNarudzbe frm = new frmNarudzbe();
            lblHeader.Text = "Narudzbe";
            frm.TopLevel = false;
            pnlSubForm.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();


        }

        private void BunifuFlatButton2_Click(object sender, EventArgs e)
        {


        }

        private void BunifuFlatButton3_Click(object sender, EventArgs e)
        {
            frmObavijesti frm = new frmObavijesti();
            lblHeader.Text = "Obavijesti";
            frm.TopLevel = false;
            pnlSubForm.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void BunifuFlatButton4_Click(object sender, EventArgs e)
        {
            frmRezervacije frm = new frmRezervacije();
            lblHeader.Text = "Rezervacije";
            frm.TopLevel = false;
            pnlSubForm.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void BunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Nabavke.frmNabavke frm = new Nabavke.frmNabavke();
            lblHeader.Text = "Nabavke";
            frm.TopLevel = false;
            pnlSubForm.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Zelite se odjaviti ?", "Odjava", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                Application.Restart();
            }
        }

        private void PnlSubForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmMenadzerIndex_Load(object sender, EventArgs e)
        {
            frmNarudzbe frm = new frmNarudzbe();
            lblHeader.Text = "Narudzbe";
            frm.TopLevel = false;
            pnlSubForm.Controls.Add(frm);
            frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
    }
}
