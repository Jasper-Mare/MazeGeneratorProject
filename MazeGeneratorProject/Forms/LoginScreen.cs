using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class LoginScreen : Form {
        Regex usernameRegex = new Regex(@"^[a-zA-Z0-9]+$"); //a regular expresion that limits the characters used to letters and numbers

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
            if(!usernameRegex.IsMatch(txtbx_username.Text)) { //if the entered name doesn't match the regex give a warning and leave the subroutine.
                MessageBox.Show("Enter a username consisting of only letters and numbers!"); 
                return; 
            } 

            User user;
            if(!User.ReadUserFromFile(txtbx_username.Text,out user)) {
                if(MessageBox.Show("User not found, create a new user account?","New User?",MessageBoxButtons.YesNo) == DialogResult.Yes) { //if the user's account isn't found, they are asked if they want to create one
                    user = new User(txtbx_username.Text);
                    user.SaveToFile(); //new user is saved to the database
                    Program.AppWindow.SetActiveForm(new MainMenu(user)); //send the user to the main menu as the new account
                }
            } else {
                Program.AppWindow.SetActiveForm(new MainMenu(user)); //the account has been found, so the user is sent to the main menu
            }
        }

        private void txtbx_username_PreviewKeyDown(object sender,PreviewKeyDownEventArgs e) {
            if(e.KeyCode == Keys.Enter) { //if enter (return) is pressed it acts the same as clicking the login button
                bttn_login.PerformClick();
            }
        }
    }
}