using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class BeginningForm : Form {
        public BeginningForm() {
            InitializeComponent();
        }

        private void bttn_Start_Click(object sender, EventArgs e) {
            Program.appWindow.SetActiveForm(new LoginScreen());
        }
    }
}