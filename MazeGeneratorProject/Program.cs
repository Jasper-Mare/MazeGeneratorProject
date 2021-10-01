using System;
using System.Windows.Forms;

namespace MazeGeneratorProject {
    public static class Program {
        public static ApplicationWindow appWindow = new ApplicationWindow(new Forms.BeginningForm());
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(appWindow);
        }
    }
}