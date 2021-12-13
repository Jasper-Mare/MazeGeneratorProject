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
        Label[] valLabels = new Label[3];

        public SetInputKeys(User user) {
            InitializeComponent();
            this.user = user;
        }

        private void SetInputKeys_Load(object sender,EventArgs e) {
            lbl_ccw.Font = StyleSheet.Body;
            lbl_cw.Font = StyleSheet.Body;
            lbl_select.Font = StyleSheet.Body;

            lbl_ccw_val.Font = StyleSheet.Body;
            lbl_cw_val.Font = StyleSheet.Body;
            lbl_select_val.Font = StyleSheet.Body;

            lbl_ccw_val.Text = user.KeyCCW.ToString();
            lbl_cw_val.Text = user.KeyCW.ToString();
            lbl_select_val.Text = user.KeySelect.ToString();
            
            bttn_set_ccw.Font = StyleSheet.Body;
            bttn_set_cw.Font = StyleSheet.Body;
            bttn_set_select.Font = StyleSheet.Body;
            bttn_done.Font = StyleSheet.Body;

            KeyPreview = true;
            KeyUp += KeyUnpressed;

            valLabels[0] = lbl_ccw_val;
            valLabels[1] = lbl_cw_val;
            valLabels[2] = lbl_select_val;
        }


        private void bttn_set_ccw_Click(object sender,EventArgs e) {
            setActive(0);
        }

        private void bttn_set_cw_Click(object sender,EventArgs e) {
            setActive(1);
        }

        private void bttn_set_select_Click(object sender,EventArgs e) {
            setActive(2);
        }

        void setActive(int numb) {
            listening = numb;
            if (0 <= numb && numb <= 2) {
                valLabels[numb].BackColor = Color.Yellow;
            }
        }

        private void KeyUnpressed(object sender,KeyEventArgs e) {
            if (listening == -1) { return; }
            Keys key = e.KeyCode;

            if(0 <= listening && listening <= 2) {
                valLabels[listening].BackColor = SystemColors.Control;
                valLabels[listening].Text = key.ToString();

                switch (listening) {
                    case 0:
                        user.KeyCCW = key;
                    break;
                    case 1:
                        user.KeyCW = key;
                    break;
                    case 2:
                        user.KeySelect = key;
                    break;
                }
            }

            listening = -1;
        }


        private void bttn_done_Click(object sender,EventArgs e) {
            Close();
        }

        private void lbl_select_Click(object sender,EventArgs e) {

        }

        private void lbl_select_val_Click(object sender,EventArgs e) {

        }
    }
}
