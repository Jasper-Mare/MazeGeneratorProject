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
    public partial class LoginScreen : Form {
        public LoginScreen() {
            InitializeComponent();
        }

        private void LoginScreen_Load(object sender, EventArgs e) {
            
        }

        private void bttn_login_Click(object sender, EventArgs e) {
            User user;
            if (!User.ReadUserFromFile(txtbx_username.Text, out user)) {
                MessageBox.Show("User not found");
                return;
            } else {

            }
        }

        private void bttn_createAccount_Click(object sender, EventArgs e) {

        }
    }
}
