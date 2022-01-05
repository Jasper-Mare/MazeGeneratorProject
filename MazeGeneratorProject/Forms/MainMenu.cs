using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class MainMenu : Form {
        User user;
        public MainMenu(User user) {
            this.user = user;
            InitializeComponent();
        }

        private void MainMenu_Load(object sender,EventArgs e) {
            lbl_Username.Font = StyleSheet.Headings;
            bttn_LogOut.Font = StyleSheet.Body;
            bttn_generate.Font = StyleSheet.Body;
            bttn_setMovement.Font = StyleSheet.Body;
            tbctl_Graphs.Font = StyleSheet.Body;

            for(int i = 0; i < (int)Difficulty.Count; i++) {
                TabPage page = new TabPage();

                PictureBox tmpltPicBox = new PictureBox();
                tmpltPicBox.SizeMode = PictureBoxSizeMode.Zoom;
                tmpltPicBox.Dock = DockStyle.Fill;
                page.Controls.Add(tmpltPicBox);

                page.Text = ((Difficulty)i).ToString();
                tbctl_Graphs.TabPages.Add(page);
            }

            //impersonate the tabpage.selected event
            tbctl_Graphs_Selected(tbctl_Graphs,new TabControlEventArgs(tbctl_Graphs.TabPages[0],0,TabControlAction.Selected));
        }

        private void tbctl_Graphs_Selected(object sender,TabControlEventArgs e) {
            PictureBox picbox = (PictureBox)e.TabPage.Controls[0];

            const int w = 1600, h = 900;
            if(picbox.Image == null) { picbox.Image = new Bitmap(w,h); }
            Graphics gfx = Graphics.FromImage(picbox.Image);
            gfx.Clear(SystemColors.ControlDark);
            gfx.DrawRectangle(new Pen(SystemColors.ControlLight,3),1,1,w-1,h-1);

            Pen linePen = new Pen(Color.OrangeRed, 3);
            int timesDiff = e.TabPageIndex;
            if(user.Times[timesDiff] == null || user.Times[timesDiff].Count == 0) {
                gfx.DrawString("You haven't solved any mazes on this difficulty yet.",StyleSheet.Headings,Brushes.Black,new Point(w/6,h/2-15));
            } else {
                List<float> values = user.Times[timesDiff].ToList();

                if(values.Count == 1) { values.Add(values[0]); }

                //x and y scaleing factor
                float ySfact = (h-100)/values.Max();
                float xSfact = (w-150)/(values.Count-1);
                //write y axis values
                for(int y = 0; y <= h-100; y += 50) {
                    gfx.DrawString((y/ySfact).ToString("F2"),StyleSheet.Body,Brushes.Black,10,h-y-60);
                    gfx.DrawLine(SystemPens.ControlLight,100,h-y-50,w-50,h-y-50);
                }
                int y1 = h-(int)(values[0]*ySfact)-50;
                for(int x = 1; x < values.Count; x++) {
                    int y2 = h-(int)(values[x]*ySfact)-50;
                    gfx.DrawLine(linePen,(x-1)*xSfact+100,y1,x*xSfact+100,y2);
                    y1 = y2;
                }
            }

            linePen.Color = Color.Black;
            gfx.DrawLine(linePen,100,50,100,h-50);
            gfx.DrawLine(linePen,100,h-50,w-50,h-50);

        }

        private void bttn_LogOut_Click(object sender,EventArgs e) {
            if(MessageBox.Show("Sign out?","",MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Program.AppWindow.SetActiveForm(new LoginScreen());
            }
        }

        private void bttn_generate_Click(object sender,EventArgs e) {
            Program.AppWindow.SetActiveForm(new MazeOptions(user));
        }

        private void bttn_setMovement_Click(object sender,EventArgs e) {
            SetInputKeys setInput = new SetInputKeys(user);
            setInput.ShowDialog(this);
            user = setInput.User;
            user.SaveToFile();
        }
    }
}