using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class Graphs : Form {
        User user;
        public Graphs(User user) {
            this.user = user;
            InitializeComponent();
        }

        private void graphs_Load(object sender, EventArgs e) {
            lbl_title.Font = StyleSheet.Headings;
            tbctl_Graphs.Font = StyleSheet.Body;
            bttn_back.Font = StyleSheet.Body;

            //set up the tabpage to show the graphs
            for (int i = 0; i < (int)Difficulty.Count; i++) {
                TabPage page = new TabPage();

                PictureBox tmpltPicBox = new PictureBox();
                tmpltPicBox.SizeMode = PictureBoxSizeMode.Zoom; //make the image in the picturebox automatically scale
                tmpltPicBox.Dock = DockStyle.Fill; //make the picturebox fill the tab
                page.Controls.Add(tmpltPicBox); //add the template to the tab's controlls

                page.Text = ((Difficulty)i).ToString();
                tbctl_Graphs.TabPages.Add(page);
            }

            //impersonate the tabpage.selected event
            tbctl_Graphs_Selected(tbctl_Graphs, new TabControlEventArgs(tbctl_Graphs.TabPages[0], 0, TabControlAction.Selected));
        }

        private void tbctl_Graphs_Selected(object sender,TabControlEventArgs e) {
            PictureBox picbox = (PictureBox)e.TabPage.Controls[0]; //get a reference to the picturebox

            const int w = 1600, h = 900; //the size of the image
            if(picbox.Image == null) { picbox.Image = new Bitmap(w,h); } //if there isn't an image create a new one
            Graphics gfx = Graphics.FromImage(picbox.Image); //create a graphics object from the image.
            gfx.Clear(SystemColors.ControlDark);
            gfx.DrawRectangle(new Pen(SystemColors.ControlLight,3),1,1,w-1,h-1);

            Pen linePen = new Pen(Color.OrangeRed, 3);
            int timesDiff = e.TabPageIndex; //the difficulty setting this graph is showing
            if(user.Times[timesDiff] == null || user.Times[timesDiff].Count == 0) {
                gfx.DrawString("You haven't solved any mazes on this difficulty yet.",StyleSheet.Headings,Brushes.Black,new Point(w/6,h/2-15));
            } else {
                List<float> values = user.Times[timesDiff].ToList(); //the list of the times being drawn out

                if(values.Count == 1) { values.Add(values[0]); } //if there is only one, coppy it so a flat line is drawn

                //x and y scaleing factors
                float ySfact = (h-100)/values.Max();
                float xSfact = (w-150)/(values.Count-1);
                //write y axis values
                for(int y = 0; y <= h-100; y += 50) {
                    gfx.DrawString((y/ySfact).ToString("F2"),StyleSheet.Body,Brushes.Black,10,h-y-60);
                    gfx.DrawLine(SystemPens.ControlLight,100,h-y-50,w-50,h-y-50);
                }
                //draw the line of the graph
                int y1 = h-(int)(values[0]*ySfact)-50;
                for(int x = 1; x < values.Count; x++) {
                    int y2 = h-(int)(values[x]*ySfact)-50;
                    gfx.DrawLine(linePen,(x-1)*xSfact+100,y1,x*xSfact+100,y2);
                    y1 = y2;
                }
            }

            //draw the axes
            linePen.Color = Color.Black;
            gfx.DrawLine(linePen,100,50,100,h-50);
            gfx.DrawLine(linePen,100,h-50,w-50,h-50);

        }

        private void bttn_back_Click(object sender, EventArgs e) {
            Program.AppWindow.SetActiveForm(new MainMenu(user)); //change to the main menu
        }
    }
}
