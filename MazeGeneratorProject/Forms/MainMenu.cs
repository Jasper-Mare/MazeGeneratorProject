﻿using System;
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
            lbl_Username.Font = StyleSheet.Headings;
            lbl_Username.Text = "Hello " + user.Name;
            bttn_LogOut.Font = StyleSheet.Body;
            bttn_generate.Font = StyleSheet.Body;
            tbctl_Graphs.Font = StyleSheet.Body;

            for (int i = 0; i < (int)Difficulty.Count; i++) {
                TabPage page = new TabPage();

                PictureBox tmpltPicBox = new PictureBox();
                tmpltPicBox.SizeMode = PictureBoxSizeMode.Zoom;
                tmpltPicBox.Dock = DockStyle.Fill;
                page.Controls.Add(tmpltPicBox);

                page.Text = ((Difficulty)i).ToString();
                tbctl_Graphs.TabPages.Add(page);
            }

            //impersonate the tabpage.selected event
            tbctl_Graphs_Selected(tbctl_Graphs, new TabControlEventArgs(tbctl_Graphs.TabPages[0], 0, TabControlAction.Selected));
        }

        private void tbctl_Graphs_Selected(object sender, TabControlEventArgs e) {
            PictureBox picbox = (PictureBox)e.TabPage.Controls[0];

            const int W = 1600, H = 900;
            if (picbox.Image == null) { picbox.Image = new Bitmap(W, H); }
            Graphics gfx = Graphics.FromImage(picbox.Image);
            gfx.Clear(SystemColors.ControlDark);
            gfx.DrawRectangle(new Pen(SystemColors.ControlLight, 3), 1,1, W-1,H-1);

            Pen linePen = new Pen(Color.OrangeRed, 3);
            int timesDiff = e.TabPageIndex;
            if (user.Times[timesDiff] == null || user.Times[timesDiff].Count == 0) {
                gfx.DrawString("You haven't solved any mazes on this difficulty yet.", StyleSheet.Headings, Brushes.Black, new Point(W/6, H/2-15) );
            } else {
                //x and y scaleing factor
                float Ysfact = (H-100)/user.Times[timesDiff].Max();
                float Xsfact = (W-150)/(user.Times[timesDiff].Count-1);
                //write y axis values
                for (int y = 0; y <= H-100; y += 50) {
                    gfx.DrawString((y/Ysfact).ToString("F2"), StyleSheet.Body, Brushes.Black, 10,H-y-60);
                    gfx.DrawLine(SystemPens.ControlLight, 100,H-y-50, W-50,H-y-50);
                }
                int y1 = H-(int)(user.Times[timesDiff][0]*Ysfact)-50;
                for (int x = 1; x < user.Times[timesDiff].Count; x++) {
                    int y2 = H-(int)(user.Times[timesDiff][x]*Ysfact)-50;
                    gfx.DrawLine(linePen, (x-1)*Xsfact+100,y1, x*Xsfact+100, y2);
                    y1 = y2;
                }
            }

            linePen.Color = Color.Black;
            gfx.DrawLine(linePen, 100, 50  , 100 , H-50);
            gfx.DrawLine(linePen, 100, H-50, W-50, H-50);

        }

        private void bttn_LogOut_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Sign out?", "", MessageBoxButtons.YesNo) == DialogResult.Yes) { 
                Program.appWindow.SetActiveForm(new LoginScreen());
            }        
        }

        private void bttn_generate_Click(object sender, EventArgs e) {
            Program.appWindow.SetActiveForm(new GenerateMaze(user));
        }
    }
}