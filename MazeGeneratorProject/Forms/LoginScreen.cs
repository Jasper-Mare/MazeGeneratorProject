using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class LoginScreen : Form {
        Regex usernameRegex = new Regex(@"^[a-zA-Z0-9]+$");

        public LoginScreen() {
            InitializeComponent();
            lbl_title.Font = StyleSheet.Headings;
            lbl_usrnm.Font = StyleSheet.Body;
            txtbx_username.Font = StyleSheet.Body;
            bttn_login.Font = StyleSheet.Body;
        }

        private void LoginScreen_Load(object sender,EventArgs e) {

        }

        private void bttn_login_Click(object sender,EventArgs e) {
            if(!usernameRegex.IsMatch(txtbx_username.Text)) { MessageBox.Show("Enter a username consisting of only letters and numbers!"); return; }

            User user;
            if(!User.ReadUserFromFile(txtbx_username.Text,out user)) {
                if(MessageBox.Show("User not found, create a new user account?","New User?",MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    user = new User(txtbx_username.Text);
                    user.SaveToFile();
                    Program.AppWindow.SetActiveForm(new MainMenu(user));
                }
            } else {
                Program.AppWindow.SetActiveForm(new MainMenu(user));
            }
        }

        private void txtbx_username_PreviewKeyDown(object sender,PreviewKeyDownEventArgs e) {
            if(e.KeyCode == Keys.Enter) {
                bttn_login.PerformClick();
            }
        }
    }
}