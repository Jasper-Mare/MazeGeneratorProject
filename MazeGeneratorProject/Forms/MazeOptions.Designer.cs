
namespace MazeGeneratorProject.Forms
{
    partial class MazeOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bttn_back = new System.Windows.Forms.Button();
            this.lbl_Username = new System.Windows.Forms.Label();
            this.pnl_Options = new System.Windows.Forms.Panel();
            this.lbl_diff = new System.Windows.Forms.Label();
            this.openFile_TemplateImage = new System.Windows.Forms.OpenFileDialog();
            this.bar_difficulty = new System.Windows.Forms.PictureBox();
            this.bttn_GenMaze = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bar_difficulty)).BeginInit();
            this.SuspendLayout();
            // 
            // bttn_back
            // 
            this.bttn_back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttn_back.Location = new System.Drawing.Point(12, 398);
            this.bttn_back.Name = "bttn_back";
            this.bttn_back.Size = new System.Drawing.Size(303, 40);
            this.bttn_back.TabIndex = 0;
            this.bttn_back.Text = "Back to Main Menu";
            this.bttn_back.UseVisualStyleBackColor = true;
            this.bttn_back.Click += new System.EventHandler(this.Bttn_back_Click);
            // 
            // lbl_Username
            // 
            this.lbl_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Username.Location = new System.Drawing.Point(12, 9);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(303, 68);
            this.lbl_Username.TabIndex = 2;
            this.lbl_Username.Text = "Hello username";
            this.lbl_Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Options
            // 
            this.pnl_Options.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Options.Location = new System.Drawing.Point(321, 41);
            this.pnl_Options.Name = "pnl_Options";
            this.pnl_Options.Size = new System.Drawing.Size(467, 397);
            this.pnl_Options.TabIndex = 3;
            // 
            // lbl_diff
            // 
            this.lbl_diff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_diff.Location = new System.Drawing.Point(321, 12);
            this.lbl_diff.Name = "lbl_diff";
            this.lbl_diff.Size = new System.Drawing.Size(211, 23);
            this.lbl_diff.TabIndex = 4;
            this.lbl_diff.Text = "Difficulty: ";
            this.lbl_diff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bar_difficulty
            // 
            this.bar_difficulty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bar_difficulty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.bar_difficulty.Location = new System.Drawing.Point(538, 9);
            this.bar_difficulty.Name = "bar_difficulty";
            this.bar_difficulty.Size = new System.Drawing.Size(250, 26);
            this.bar_difficulty.TabIndex = 5;
            this.bar_difficulty.TabStop = false;
            // 
            // bttn_GenMaze
            // 
            this.bttn_GenMaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttn_GenMaze.Location = new System.Drawing.Point(12, 352);
            this.bttn_GenMaze.Name = "bttn_GenMaze";
            this.bttn_GenMaze.Size = new System.Drawing.Size(303, 40);
            this.bttn_GenMaze.TabIndex = 6;
            this.bttn_GenMaze.Text = "Generate Maze";
            this.bttn_GenMaze.UseVisualStyleBackColor = true;
            this.bttn_GenMaze.Click += new System.EventHandler(this.bttn_GenMaze_Click);
            // 
            // GenerateMaze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bttn_GenMaze);
            this.Controls.Add(this.bar_difficulty);
            this.Controls.Add(this.pnl_Options);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.bttn_back);
            this.Controls.Add(this.lbl_diff);
            this.Name = "GenerateMaze";
            this.Text = "GenerateMaze";
            this.Load += new System.EventHandler(this.GenerateMaze_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar_difficulty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttn_back;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Panel pnl_Options;
        private System.Windows.Forms.Label lbl_diff;
        private System.Windows.Forms.OpenFileDialog openFile_TemplateImage;
        private System.Windows.Forms.PictureBox bar_difficulty;
        private System.Windows.Forms.Button bttn_GenMaze;
    }
}