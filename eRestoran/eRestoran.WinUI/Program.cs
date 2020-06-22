using eRestoran.WinUI.Rezervacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eRestoran.WinUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMenadzerIndex());

            frmLogin login = new frmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                if (login._id == 1)
                    Application.Run(new frmMenadzerIndex());
                if (login._id == 2)
                    Application.Run(new frmAdminIndex());



            }
        }
    }
}
