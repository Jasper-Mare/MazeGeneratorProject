using System;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class BeginningForm : Form {
        public BeginningForm() {
            InitializeComponent();
            bttn_Start.Font = StyleSheet.Headings;
        }

        private void bttn_Start_Click(object sender, EventArgs e) {
            Program.appWindow.SetActiveForm(new LoginScreen());
        }
    }
}