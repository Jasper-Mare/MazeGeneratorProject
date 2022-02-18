using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class SetInputKeys : Form {
        public User User { get { return user; } } //a getter, so the user can be got by other classes, but not set
        User user; //the actual local user variable
        int listening = -1; //an int showing which key the form is waiting to be set (-1 means none, 0 up, 1 down, 2 left, 3 right)
        Label[] valLabels = new Label[4];

        public SetInputKeys(User user) {
            InitializeComponent();
            this.user = user;
        }

        private void SetInputKeys_Load(object sender,EventArgs e) {
            //apply formatting
            lbl_up.Font = StyleSheet.Body;
            lbl_down.Font = StyleSheet.Body;
            lbl_left.Font = StyleSheet.Body;
            lbl_right.Font = StyleSheet.Body;

            lbl_up_val.Font = StyleSheet.Body;
            lbl_down_val.Font = StyleSheet.Body;
            lbl_left_val.Font = StyleSheet.Body;
            lbl_right_val.Font = StyleSheet.Body;

            lbl_up_val.Text = user.KeyUp.ToString();
            lbl_down_val.Text = user.KeyDown.ToString();
            lbl_left_val.Text = user.KeyLeft.ToString();
            lbl_right_val.Text = user.KeyRight.ToString();
            
            bttn_set_up.Font = StyleSheet.Body;
            bttn_set_down.Font = StyleSheet.Body;
            bttn_set_left.Font = StyleSheet.Body;
            bttn_set_right.Font = StyleSheet.Body;
            bttn_done.Font = StyleSheet.Body;

            //alow the form to recieve all key presses instead of the component that has focus at the moment the key is pressed
            KeyPreview = true;
            KeyUp += KeyUnpressed;

            //put each of the labels on the form designer in an array for easier access
            valLabels[0] = lbl_up_val;
            valLabels[1] = lbl_down_val;
            valLabels[2] = lbl_left_val;
            valLabels[3] = lbl_right_val;

            MessageBox.Show("To change a key click 'reset' then pressed the desired key."); //give information on how to use the form
        }


        private void bttn_set_up_Click(object sender,EventArgs e) {
            setActive(0);
        }

        private void bttn_set_down_Click(object sender,EventArgs e) {
            setActive(1);
        }

        private void bttn_set_left_Click(object sender,EventArgs e) {
            setActive(2);
        }

        private void bttn_set_right_Click(object sender, EventArgs e) {
            setActive(3);
        }

        void setActive(int numb) {
            if (0 <= numb && numb <= 3) {
                listening = numb;
                valLabels[numb].BackColor = Color.Yellow; //highlight the listening key label
            }
        }

        private void KeyUnpressed(object sender,KeyEventArgs e) {
            if (listening == -1) { return; } //if no key is listening leave this subroutine
            Keys key = e.KeyCode;

            if(0 <= listening && listening <= 3) {
                valLabels[listening].BackColor = SystemColors.Control; //reset the background of the key label
                valLabels[listening].Text = key.ToString(); //write out the key to the label

                //set the key in the user that corresponds to the one being set
                switch (listening) {
                    case 0:
                        user.KeyUp = key;
                    break;
                    case 1:
                        user.KeyDown = key;
                    break;
                    case 2:
                        user.KeyLeft = key;
                    break;
                    case 3:
                        user.KeyRight = key;
                    break;
                }
            }

            listening = -1; //re-set listening
        }

        private void bttn_done_Click(object sender,EventArgs e) {
            Keys[] keys = new Keys[4] { user.KeyUp, user.KeyDown, user.KeyLeft, user.KeyRight };
            if (keys.Distinct().Count() != 4) {
                MessageBox.Show("The same key can't be assigned to multiple actions!");
            } else { 
                Close(); //close the form
            }
        }
    }
}
