using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class BeginningForm : Form {
        public BeginningForm() {
            InitializeComponent();
            bttn_Start.Font = StyleSheet.Headings;
        }
        private void BeginningForm_Load(object sender, EventArgs e) {
            pbxImg.Image = Image.FromFile(@"Database/maze.png");
        }

        private void bttn_Start_Click(object sender, EventArgs e) {
            Program.AppWindow.SetActiveForm(new LoginScreen()); //change to the login form
        }

    }
}