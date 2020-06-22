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
    public partial class frmAdminIndex : Form
    {
        private int childFormNumber = 0;
        private frmUposlenici _uposlenici;
        private frmRoba _roba;
        public frmAdminIndex()
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

        private void FrmAdminIndex_Load(object sender, EventArgs e)
        {
            Alociraj();
        }

        private void Alociraj()
        {
            frmUposlenici uposlenici = new frmUposlenici();
            frmRoba roba = new frmRoba();

            _roba = roba;
            _uposlenici = uposlenici;
        }

        private void ListaUposlenikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUposlenici uposlenici = new frmUposlenici();
            uposlenici.MdiParent = this;
            uposlenici.Show();
        }

        private void NoviUposlenikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUposleniciDetalji frm = new frmUposleniciDetalji(null, _uposlenici);
            frm.Show();
        }

        private void ListaRobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRoba roba = new frmRoba();
            roba.MdiParent = this;
            roba.Dock = DockStyle.Fill;
            roba.Show();
        }

        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void NoviProizvodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRobaDetalji frm = new frmRobaDetalji(null,_roba);
            frm.Show();
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Zelite se odjaviti ?", "Odjava", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
                Application.Restart();
            }
        }
    }
}
