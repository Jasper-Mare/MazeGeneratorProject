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
            lbl_title.Font = StyleSheet.Headings;
            lbl_usrnm.Font = StyleSheet.Body;
            txtbx_username.Font = StyleSheet.Body;
            bttn_login.Font = StyleSheet.Body;
        }

        private void LoginScreen_Load(object sender, EventArgs e) {
            
        }

        private void bttn_login_Click(object sender, EventArgs e) {
            if (txtbx_username.Text == "") { MessageBox.Show("Enter a username!"); return; }

            User user;
            if (!User.ReadUserFromFile(txtbx_username.Text, out user)) {
                user = new User(txtbx_username.Text);
                user.SaveToFile();
            }
            Program.appWindow.SetActiveForm(new MainMenu(user));
        }

    }
}