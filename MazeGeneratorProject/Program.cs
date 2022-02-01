using System;
using System.Windows.Forms;

namespace MazeGeneratorProject {
    public static class Program {
        public static ApplicationWindow AppWindow; //the program owns the appwindow

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            //automatically generated code for running a windows form program
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppWindow = new ApplicationWindow(new Forms.BeginningForm()); //create the appwindow with the first form being the 'BeginningForm'
            //=======================================|| A way for me to skip to a different form during coding
            //User me;
            //User.ReadUserFromFile(0, out me);
            //AppWindow = new ApplicationWindow(new Forms.MazeOptions(me));
            //=======================================||

            Application.Run(AppWindow);
        }
    }
}