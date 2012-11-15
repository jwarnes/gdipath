using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Timers;



namespace gdipath
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

            mainForm mainForm = new mainForm();
            mainForm.Show();

            while (mainForm.Created)
            {
                Application.DoEvents();
               
            }
        }

    }
}
