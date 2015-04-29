using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erp.Custom.UI.Common
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
            Application.Run(new Main());
        }

        private static void ApplyTheme(Form f)
        {
            f.Font = new Font("Microsoft Sans Serif", 8.25f);
            //f.ForeColor = Color.White;
            f.BackColor = Color.FromArgb(222, 235, 250);
        }

        public static void UseTheme(Form form)
        {
            ApplyTheme(form);
        }
    }
}
