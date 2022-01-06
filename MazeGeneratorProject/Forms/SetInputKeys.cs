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
    public partial class SetInputKeys : Form {
        public User User { get { return user; } }
        User user;
        int listening = -1;
        Label[] valLabels = new Label[4];

        public SetInputKeys(User user) {
            InitializeComponent();
            this.user = user;
        }

        private void SetInputKeys_Load(object sender,EventArgs e) {
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

            KeyPreview = true;
            KeyUp += KeyUnpressed;

            valLabels[0] = lbl_up_val;
            valLabels[1] = lbl_down_val;
            valLabels[2] = lbl_left_val;
            valLabels[3] = lbl_right_val;

            MessageBox.Show("To change a key click 'reset' then pressed the desired key.");
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
            listening = numb;
            if (0 <= numb && numb <= 3) {
                valLabels[numb].BackColor = Color.Yellow;
            }
        }

        private void KeyUnpressed(object sender,KeyEventArgs e) {
            if (listening == -1) { return; }
            Keys key = e.KeyCode;

            if(0 <= listening && listening <= 3) {
                valLabels[listening].BackColor = SystemColors.Control;
                valLabels[listening].Text = key.ToString();

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

            listening = -1;
        }


        private void bttn_done_Click(object sender,EventArgs e) {
            Close();
        }
    }
}
