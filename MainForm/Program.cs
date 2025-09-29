using System;
using System.Windows.Forms;

namespace GameApp.UI
{
    /// <summary>
    /// Точка входа WinForms-приложения.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Главный метод запуска формы.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
