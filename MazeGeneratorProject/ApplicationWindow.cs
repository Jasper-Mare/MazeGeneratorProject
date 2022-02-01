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
            startForm = displayedForm; //so the 'SetActivateForm' method doesn't destroy the first form before opening it is stored sepperately
        }

        private void ApplicationWindow_Load(object sender, EventArgs e) { }
        private void ApplicationWindow_Shown(object sender, EventArgs e) { //https://stackoverflow.com/a/219155
            SetActiveForm(startForm); //when this form appears activate the form attached beneath it
        }
        public void SetActiveForm(Form DisplayedForm) {
            if (displayedForm != null) { displayedForm.Close(); displayedForm.Dispose(); } //if the displayed form isn't already empty, destroy it so the previous form doesn't stay around un-connected

            displayedForm = DisplayedForm; //set the active form
            
            //calculate the height of the title bar in pixels on this screen
            Rectangle screenRectangle = this.RectangleToScreen(this.ClientRectangle); //https://stackoverflow.com/a/2022684
            titleHeight = screenRectangle.Top - this.Top;

            //show the form as a client of this form so both appear at the same depth on the screen (a window of another app can't cover one but not the other)
            displayedForm.Show(this); //https://stackoverflow.com/a/22263483

            //link some events of the displayed form into this form
            displayedForm.Move += DisplayedForm_Move;
            displayedForm.SizeChanged += DisplayedForm_SizeChanged;

            displayedForm.Location = new Point(Location.X, Location.Y + titleHeight); //make the displayed form apear below this form
            displayedForm.Size = new Size(Size.Width, displayedForm.Size.Height - titleHeight); //resize the displayed form
            displayedForm.ShowInTaskbar = false; this.ShowInTaskbar = true; //only show this form in the taskbar, not the displayed form
            displayedForm.ControlBox = false; displayedForm.Text = ""; //remove the title bar of the displayed form
            this.Activate(); //give this form focus
        }

        private void ApplicationWindow_FormClosing(object sender, FormClosingEventArgs e) {
            displayedForm.Close(); //if this form closes close the displayed form
        }

        private void ApplicationWindow_Move(object sender, EventArgs e) { //if this form moves move the displayed form with it
            if (displayedForm == null) { return; }
            displayedForm.Location = new Point(Location.X, Location.Y+titleHeight);
        }
        private void DisplayedForm_Move(object sender, EventArgs e) { //if the displayed form moves, move this form
            this.Location = new Point(displayedForm.Location.X, displayedForm.Location.Y-titleHeight);
        }

        private void ApplicationWindow_SizeChanged(object sender, EventArgs e) { //if this form is resized, resize the displayed form and keep this form as only the titlebar
            if (displayedForm == null) { return; }
            displayedForm.Size = new Size(Size.Width, displayedForm.Size.Height);
            this.Size = new Size(Size.Width, 0);
        }
        private void DisplayedForm_SizeChanged(object sender, EventArgs e) { //if the displayed form is resized match this forms width with the displayed form's width
            this.Size = new Size(displayedForm.Size.Width, 0);
        }

    }

}