using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGeneratorProject {
    public partial class ApplicationWindow : Form {
        public Form DisplayedForm;
        private Form startForm;
        private int titleHeight;

        public ApplicationWindow(Form displayedForm) {
            InitializeComponent();
            startForm = displayedForm;
        }

        private void ApplicationWindow_Load(object sender, EventArgs e) { }
        private void ApplicationWindow_Shown(object sender, EventArgs e) { //https://stackoverflow.com/a/219155
            SetActiveForm(startForm);
        }
        public void SetActiveForm(Form displayedForm) {
            if (DisplayedForm != null) { DisplayedForm.Close(); }
            DisplayedForm = displayedForm;
            Rectangle screenRectangle = this.RectangleToScreen(this.ClientRectangle); //https://stackoverflow.com/a/2022684
            titleHeight = screenRectangle.Top - this.Top;
            DisplayedForm.Show(this); //https://stackoverflow.com/a/22263483
            DisplayedForm.Activated += DisplayedForm_Activated;
            DisplayedForm.Move += DisplayedForm_Move;
            DisplayedForm.SizeChanged += DisplayedForm_SizeChanged; ;
            DisplayedForm.Location = new Point(Location.X, Location.Y + titleHeight);
            DisplayedForm.Size = new Size(Size.Width, DisplayedForm.Size.Height - titleHeight);
            DisplayedForm.ShowInTaskbar = false; this.ShowInTaskbar = true;
            DisplayedForm.ControlBox = false; DisplayedForm.Text = "";
            this.Activate();
        }

        private void ApplicationWindow_FormClosing(object sender, FormClosingEventArgs e) {
            DisplayedForm.Close();
        }

        private void ApplicationWindow_Move(object sender, EventArgs e) {
            if (DisplayedForm == null) { return; }
            DisplayedForm.Location = new Point(Location.X, Location.Y+titleHeight);
        }
        private void DisplayedForm_Move(object sender, EventArgs e) {
            this.Location = new Point(DisplayedForm.Location.X, DisplayedForm.Location.Y-titleHeight);
        }

        private void ApplicationWindow_SizeChanged(object sender, EventArgs e) {
            if (DisplayedForm == null) { return; }
            DisplayedForm.Size = new Size(Size.Width, DisplayedForm.Size.Height);
            Size = new Size(Size.Width, 0);
        }
        private void DisplayedForm_SizeChanged(object sender, EventArgs e) {
            this.Size = new Size(DisplayedForm.Size.Width, 0);
        }

        private void ApplicationWindow_Activated(object sender, EventArgs e) {  }
        private void DisplayedForm_Activated(object sender, EventArgs e) {  }

    }
}