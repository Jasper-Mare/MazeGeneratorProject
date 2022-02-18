using System;
using System.Windows.Forms;

namespace MazeGeneratorProject.Forms {
    public partial class MainMenu : Form {
        User user;
        public MainMenu(User user) {
            this.user = user;
            InitializeComponent();
        }

        private void MainMenu_Load(object sender,EventArgs e) {
            //apply formatting
            lbl_Title.Font = StyleSheet.Headings;
            bttn_LogOut.Font = StyleSheet.Body;
            bttn_custom.Font = StyleSheet.Body;
            bttn_easy.Font = StyleSheet.Body;
            bttn_medium.Font = StyleSheet.Body;
            bttn_difficult.Font = StyleSheet.Body;
            bttn_setMovement.Font = StyleSheet.Body;
            bttn_graphs.Font = StyleSheet.Body;

            lbl_keyUp.Text = "Up: "+user.KeyUp.ToString();
            lbl_keyDown.Text = "Down: "+user.KeyDown.ToString();
            lbl_keyLeft.Text = "Left: "+user.KeyLeft.ToString();
            lbl_keyRight.Text = "Right: "+user.KeyRight.ToString();
        }

        private void bttn_LogOut_Click(object sender,EventArgs e) {
            if(MessageBox.Show("Sign out?","",MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Program.AppWindow.SetActiveForm(new LoginScreen()); //if the user choses to log out, they are returned to the login screen
            }
        }

        private void bttn_setMovement_Click(object sender,EventArgs e) {
            SetInputKeys setInput = new SetInputKeys(user);
            setInput.ShowDialog(this); //the setInputKey form is opened as a dialog box meaning that the main menu can't be interacted with while the dialog is open
            user = setInput.User; //the user is retreived from the setinput form
            user.SaveToFile(); //the user is saved to the database so the key preferences aren't lost if the program unexpectedly closes
            lbl_keyUp.Text = "Up: " + user.KeyUp.ToString();
            lbl_keyDown.Text = "Down: " + user.KeyDown.ToString();
            lbl_keyLeft.Text = "Left: " + user.KeyLeft.ToString();
            lbl_keyRight.Text = "Right: " + user.KeyRight.ToString();
        }

        private void bttn_graphs_Click(object sender, EventArgs e) {
            Program.AppWindow.SetActiveForm(new Graphs(user)); //switch to the graphs form
        }

        private void bttn_generate_Click(object sender,EventArgs e) {
            Program.AppWindow.SetActiveForm(new MazeOptions(user)); //switch to the generate custom maze form
        }

        private void bttn_easy_Click(object sender, EventArgs e) { //open the maze with an easy difficulty preset 
            GeneratorOptions preset = new GeneratorOptions();
            preset.Diff = Difficulty.Easy;
            preset.Appearance = StyleSheet.MazeStyles[0];
            preset.BiasStrength = 1;
            preset.Size = 30;
            preset.GenerationType = GeneratorOptions._GenerationType.Gamma;
            Program.AppWindow.SetActiveForm(new MazeForm(user, preset));
        }

        private void bttn_medium_Click(object sender, EventArgs e) { //open the maze with a medium difficulty preset 
            GeneratorOptions preset = new GeneratorOptions();
            preset.Diff = Difficulty.Medium;
            preset.Appearance = StyleSheet.MazeStyles[0];
            preset.BiasStrength = 1;
            preset.Size = 50;
            preset.GenerationType = GeneratorOptions._GenerationType.Gamma;
            Program.AppWindow.SetActiveForm(new MazeForm(user, preset));
        }

        private void bttn_difficult_Click(object sender, EventArgs e) { //open the maze with a difficult difficulty preset 
            GeneratorOptions preset = new GeneratorOptions();
            preset.Diff = Difficulty.Hard;
            preset.Appearance = StyleSheet.MazeStyles[0];
            preset.BiasStrength = 1;
            preset.Size = 70;
            preset.GenerationType = GeneratorOptions._GenerationType.Gamma;
            Program.AppWindow.SetActiveForm(new MazeForm(user, preset));
        }
    }
}