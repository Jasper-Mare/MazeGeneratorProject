using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class MazeOptions : Form {
        User user;
        Difficulty diff;

        //===options=controls===//
        int controllWidths = 150;
        int controllGaps = 20;
        ComboBox drpdwn_GenType;
        ComboBox drpdwn_Style;
        CheckBox chbx_Minotaur;
        CheckBox chbx_MovingWalls;
        CheckBox chbx_ReducedVisability;
        CheckBox chbx_Keys;
        TrackBar trkbr_bias;
        TrackBar trkbr_size;

        Label lbl_size;
        Label lbl_TitleGenType;
        Label lbl_TitleStyle;
        Label lbl_TitleBias;

        Timer tmr_calculateDifficulty;
        //======================//

        public MazeOptions(User user) {
            InitializeComponent();
            this.user = user;
        }

        private void GenerateMaze_Load(object sender, EventArgs e) {
            lbl_title.Font = StyleSheet.Headings;
            bttn_back.Font = StyleSheet.Body;
            bttn_GenMaze.Font = StyleSheet.Body;

            //set up the options panel
            //pannel scrollbars
            pnl_Options.AutoScroll = true;

            //Size
            trkbr_size = new TrackBar();
            trkbr_size.Minimum = 1;
            trkbr_size.Maximum = 10;
            trkbr_size.Value = 1;
            trkbr_size.Location = new Point(5, 5);
            trkbr_size.Size = new Size(controllWidths, trkbr_size.Height);
            trkbr_size.TickFrequency = 1;
            pnl_Options.Controls.Add(trkbr_size);

            //size label
            lbl_size = new Label();
            lbl_size.Location = new Point(5 + controllWidths + controllGaps, trkbr_size.Location.Y); //controlls are located relative to the one above or beside them
            lbl_size.Size = new Size(pnl_Options.Width - (20 + controllWidths + controllGaps), trkbr_size.Height-10);
            lbl_size.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            lbl_size.TextAlign = ContentAlignment.MiddleLeft;
            lbl_size.AutoEllipsis = true;
            lbl_size.Text = "Size (10 to 100)";
            pnl_Options.Controls.Add(lbl_size);

            //generation type
            drpdwn_GenType = new ComboBox();
            drpdwn_GenType.DropDownStyle = ComboBoxStyle.DropDownList;
            drpdwn_GenType.Items.Add("Gamma (squares)");
            drpdwn_GenType.Items.Add("Delta (triangles)");
            drpdwn_GenType.MouseWheel += Drpdwn_MouseWheel;
            drpdwn_GenType.Size = new Size(controllWidths, drpdwn_GenType.Height);
            drpdwn_GenType.Location = new Point(5, trkbr_size.Location.Y+trkbr_size.Height+controllGaps-25);
            pnl_Options.Controls.Add(drpdwn_GenType);
            drpdwn_GenType.BringToFront();

            //generation type label
            lbl_TitleGenType = new Label();
            lbl_TitleGenType.Location = new Point(5+controllWidths+controllGaps, drpdwn_GenType.Location.Y);
            lbl_TitleGenType.Size = new Size(pnl_Options.Width-(20+controllWidths+controllGaps), drpdwn_GenType.Height);
            lbl_TitleGenType.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            lbl_TitleGenType.TextAlign = ContentAlignment.MiddleLeft;
            lbl_TitleGenType.AutoEllipsis = true;
            lbl_TitleGenType.Text = "Generation Type";
            pnl_Options.Controls.Add(lbl_TitleGenType);

            //maze appearence
            drpdwn_Style = new ComboBox();
            drpdwn_Style.DropDownStyle = ComboBoxStyle.DropDownList;
            drpdwn_Style.Size = new Size(controllWidths, drpdwn_Style.Size.Height);
            drpdwn_Style.ItemHeight *= 2;
            foreach (Style s in StyleSheet.MazeStyles) { drpdwn_Style.Items.Add(s); }
            drpdwn_Style.SelectedIndex = 0;
            drpdwn_Style.DrawMode = DrawMode.OwnerDrawVariable; //enable a custom drawing method for the dropdown
            drpdwn_Style.DrawItem += Drpdwn_Style_DrawItem;
            //https://stackoverflow.com/a/1883072
            drpdwn_Style.MouseWheel += Drpdwn_MouseWheel;
            drpdwn_Style.Location = new Point(5, drpdwn_GenType.Location.Y+ drpdwn_GenType.Size.Height+controllGaps);
            pnl_Options.Controls.Add(drpdwn_Style);

            //appearence label
            lbl_TitleStyle = new Label();
            lbl_TitleStyle.Location = new Point(5+controllWidths+controllGaps, drpdwn_Style.Location.Y);
            lbl_TitleStyle.Size = new Size(pnl_Options.Width-(20+controllWidths+controllGaps), drpdwn_Style.Height);
            lbl_TitleStyle.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            lbl_TitleStyle.TextAlign = ContentAlignment.MiddleLeft;
            lbl_TitleStyle.AutoEllipsis = true;
            lbl_TitleStyle.Text = "Appearence";
            pnl_Options.Controls.Add(lbl_TitleStyle);

            //minotaur
            chbx_Minotaur = new CheckBox();
            chbx_Minotaur.Text = "Minotaur?";
            chbx_Minotaur.Location = new Point(5, drpdwn_Style.Location.Y+drpdwn_Style.Size.Height+controllGaps-5);
            chbx_Minotaur.AutoSize = false;
            chbx_Minotaur.Size = new Size(controllWidths, chbx_Minotaur.Size.Height);
            pnl_Options.Controls.Add(chbx_Minotaur);

            //moving walls
            chbx_MovingWalls = new CheckBox();
            chbx_MovingWalls.Text = "Moving walls?";
            chbx_MovingWalls.Location = new Point(5, chbx_Minotaur.Location.Y+chbx_Minotaur.Size.Height+controllGaps-10);
            chbx_MovingWalls.AutoSize = false;
            chbx_MovingWalls.Size = new Size(controllWidths, chbx_MovingWalls.Size.Height);
            pnl_Options.Controls.Add(chbx_MovingWalls);

            //reduced visability
            chbx_ReducedVisability = new CheckBox();
            chbx_ReducedVisability.Text = "Reduced visability?";
            chbx_ReducedVisability.Location = new Point(5, chbx_MovingWalls.Location.Y+chbx_MovingWalls.Size.Height+controllGaps-10);
            chbx_ReducedVisability.AutoSize = false;
            chbx_ReducedVisability.Size = new Size(controllWidths, chbx_ReducedVisability.Size.Height);
            pnl_Options.Controls.Add(chbx_ReducedVisability);

            //keys
            chbx_Keys = new CheckBox();
            chbx_Keys.Text = "Keys?";
            chbx_Keys.Location = new Point(5, chbx_ReducedVisability.Location.Y+chbx_ReducedVisability.Size.Height+controllGaps-10);
            chbx_Keys.AutoSize = false;
            chbx_Keys.Size = new Size(controllWidths, chbx_Keys.Size.Height);
            pnl_Options.Controls.Add(chbx_Keys);

            //bias
            trkbr_bias = new TrackBar();
            trkbr_bias.Minimum = -6;
            trkbr_bias.Maximum = 6;
            trkbr_bias.Value = 0;
            trkbr_bias.Location = new Point(5, chbx_Keys.Location.Y+chbx_Keys.Size.Height+controllGaps-5);
            trkbr_bias.Size = new Size(controllWidths, trkbr_bias.Size.Height);
            trkbr_bias.TickFrequency = 2;
            pnl_Options.Controls.Add(trkbr_bias);

            //bias label
            lbl_TitleBias = new Label();
            lbl_TitleBias.Location = new Point(5+controllWidths+controllGaps, trkbr_bias.Location.Y);
            lbl_TitleBias.Size = new Size(pnl_Options.Width-(20+controllWidths+controllGaps), trkbr_bias.Height-15);
            lbl_TitleBias.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            lbl_TitleBias.TextAlign = ContentAlignment.MiddleLeft;
            lbl_TitleBias.AutoEllipsis = true;
            lbl_TitleBias.Text = "Bias strength (1/8x to 8x)";
            pnl_Options.Controls.Add(lbl_TitleBias);

            //timer calculate difficulty (a timer set up to trigger a subroutine that calculates the difficulty score every 100ms)
            tmr_calculateDifficulty = new Timer();
            tmr_calculateDifficulty.Interval = 100;
            tmr_calculateDifficulty.Tick += Tmr_calculateDifficulty_Tick;
            tmr_calculateDifficulty.Enabled = true;

            drpdwn_GenType.SelectedIndex = 0;
        }

        private void Tmr_calculateDifficulty_Tick(object sender, EventArgs e) {
            tmr_calculateDifficulty.Enabled = false;
            CalculateDifficulty();
            tmr_calculateDifficulty.Enabled = true;
        }
        private void Drpdwn_MouseWheel(object sender, MouseEventArgs e) { //if the dropdown is scrolled on when it is not open, it should not change the setting of the dropdown
            if (!((ComboBox)sender).DroppedDown) {
                ((HandledMouseEventArgs)e).Handled = true;
            }
        }
        private void Drpdwn_Style_DrawItem(object sender, DrawItemEventArgs e) { //a custom method for the dropdown to draw it's contents
            //https://www.c-sharpcorner.com/UploadFile/renuka11/using-a-combobox-to-select-colors/
            //draw colours
            Graphics gfx = e.Graphics; //construct a graphics object
            Rectangle rect = e.Bounds;
            if (e.Index >= 0) {
                Style selected = (Style)(((ComboBox)sender).Items[e.Index]);
                Brush wallBrush = selected.WallBrush;
                Brush passageBrush = selected.PassageBrush;
                //fill the area half with the passage brush, half with the wall brush
                gfx.FillRectangle(SystemBrushes.ControlDark, rect);
                gfx.FillRectangle(wallBrush, rect.X+1, rect.Y+1, rect.Width/2, rect.Height-2);
                gfx.FillRectangle(passageBrush, rect.X+rect.Width/2, rect.Y+1, rect.Width/2-1, rect.Height-2);
            }
        }
        private void Bttn_back_Click(object sender, EventArgs e) {
            Program.AppWindow.SetActiveForm(new MainMenu(user)); //return the user to the main menu
        }

        private void CalculateDifficulty() {
            int difficultyPoints = 0;
            
            if (chbx_Minotaur.Checked) { difficultyPoints += 1; }
            if (chbx_MovingWalls.Checked) { difficultyPoints += 1; }
            if (chbx_ReducedVisability.Checked) { difficultyPoints += 1; }
            if (chbx_Keys.Checked) { difficultyPoints += 1; }

            if (trkbr_size.Value < 4) { //small maze
                difficultyPoints += 2;
            } else if (trkbr_size.Value < 7) { //medium maze
                difficultyPoints += 5;
            } else {
                difficultyPoints += 7; //big maze
            }

            lbl_diff.Text = "This maze is ";
            //max difficulty points are 11
            if (difficultyPoints >= 7) { lbl_diff.Text += Difficulty.Hard.ToString(); diff = Difficulty.Hard; }
            else if (difficultyPoints >= 3) { lbl_diff.Text += Difficulty.Medium.ToString(); diff = Difficulty.Medium; }
            else { lbl_diff.Text += Difficulty.Easy.ToString(); diff = Difficulty.Easy; }

        }

        private void bttn_GenMaze_Click(object sender, EventArgs e) { //send the options and user to the maze form, where the maze will be generated
            GeneratorOptions options = new GeneratorOptions();
            options.Appearance = (Style)drpdwn_Style.SelectedItem;
            options.GenerationType = (GeneratorOptions._GenerationType)drpdwn_GenType.SelectedIndex;
            
            options.Keys = chbx_Keys.Checked;
            options.Minotaur = chbx_Minotaur.Checked;
            options.MovingWalls = chbx_MovingWalls.Checked;
            options.ReducedVisibility = chbx_ReducedVisability.Checked;

            options.BiasStrength = MathF.Pow(2, trkbr_bias.Value/2f);
            options.Size = 10*trkbr_size.Value;
            options.Diff = diff;

            Program.AppWindow.SetActiveForm(new MazeForm(user, options));
        }
    }
}