namespace MazeGeneratorProject {
    partial class ApplicationWindow {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // ApplicationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 0);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(10000, 39);
            this.MinimizeBox = false;
            this.Name = "ApplicationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maze Generator Program";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ApplicationWindow_FormClosing);
            this.Load += new System.EventHandler(this.ApplicationWindow_Load);
            this.Shown += new System.EventHandler(this.ApplicationWindow_Shown);
            this.SizeChanged += new System.EventHandler(this.ApplicationWindow_SizeChanged);
            this.Move += new System.EventHandler(this.ApplicationWindow_Move);
            this.ResumeLayout(false);

        }

        #endregion
    }
}