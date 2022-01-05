using System;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGeneratorProject {
    public partial class ApplicationWindow : Form {
        private Form displayedForm;
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
        public void SetActiveForm(Form DisplayedForm) {
            if (displayedForm != null) { displayedForm.Close(); displayedForm.Dispose(); }
            displayedForm = DisplayedForm;
            Rectangle screenRectangle = this.RectangleToScreen(this.ClientRectangle); //https://stackoverflow.com/a/2022684
            titleHeight = screenRectangle.Top - this.Top;
            displayedForm.Show(this); //https://stackoverflow.com/a/22263483
            displayedForm.Activated += DisplayedForm_Activated;
            displayedForm.Move += DisplayedForm_Move;
            displayedForm.SizeChanged += DisplayedForm_SizeChanged; ;
            displayedForm.Location = new Point(Location.X, Location.Y + titleHeight);
            displayedForm.Size = new Size(Size.Width, displayedForm.Size.Height - titleHeight);
            displayedForm.ShowInTaskbar = false; this.ShowInTaskbar = true;
            displayedForm.ControlBox = false; displayedForm.Text = "";
            this.Activate();
        }

        private void ApplicationWindow_FormClosing(object sender, FormClosingEventArgs e) {
            displayedForm.Close();
        }

        private void ApplicationWindow_Move(object sender, EventArgs e) {
            if (displayedForm == null) { return; }
            displayedForm.Location = new Point(Location.X, Location.Y+titleHeight);
        }
        private void DisplayedForm_Move(object sender, EventArgs e) {
            this.Location = new Point(displayedForm.Location.X, displayedForm.Location.Y-titleHeight);
        }

        private void ApplicationWindow_SizeChanged(object sender, EventArgs e) {
            if (displayedForm == null) { return; }
            displayedForm.Size = new Size(Size.Width, displayedForm.Size.Height);
            Size = new Size(Size.Width, 0);
        }
        private void DisplayedForm_SizeChanged(object sender, EventArgs e) {
            this.Size = new Size(displayedForm.Size.Width, 0);
        }

        private void ApplicationWindow_Activated(object sender, EventArgs e) {  }
        private void DisplayedForm_Activated(object sender, EventArgs e) {  }
    }

}