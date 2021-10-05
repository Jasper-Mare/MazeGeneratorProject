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
    public partial class MainMenu : Form {
        User user;
        public MainMenu(User user) {
            this.user = user;
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e) {
            lbl_Username.Font = StyleSheet.Body;
            lbl_Username.Text = "Hello " + user.Name;

            for (int i = 0; i < (int)Difficulty.Count; i++) {
                TabPage page = new TabPage();

                PictureBox tmpltPicBox = new PictureBox();
                tmpltPicBox.SizeMode = PictureBoxSizeMode.Zoom;
                tmpltPicBox.BackColor = Color.Black;
                tmpltPicBox.Dock = DockStyle.Fill;
                page.Controls.Add(tmpltPicBox);

                page.Text = ((Difficulty)i).ToString();
                tbctl_Graphs.TabPages.Add(page);
            }

        }

        private void tbctl_Graphs_Selected(object sender, TabControlEventArgs e) {
            //e.TabPage.Controls[0].;

            //e.TabPageIndex;
        }
    }
}
