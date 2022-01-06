
namespace MazeGeneratorProject.Forms
{
    partial class MainMenu
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
            this.bttn_LogOut = new System.Windows.Forms.Button();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.bttn_custom = new System.Windows.Forms.Button();
            this.bttn_setMovement = new System.Windows.Forms.Button();
            this.lbl_keyLeft = new System.Windows.Forms.Label();
            this.lbl_keyRight = new System.Windows.Forms.Label();
            this.lbl_keyDown = new System.Windows.Forms.Label();
            this.lbl_keyUp = new System.Windows.Forms.Label();
            this.bttn_graphs = new System.Windows.Forms.Button();
            this.grpbx_keys = new System.Windows.Forms.GroupBox();
            this.bttn_easy = new System.Windows.Forms.Button();
            this.bttn_medium = new System.Windows.Forms.Button();
            this.bttn_difficult = new System.Windows.Forms.Button();
            this.grpbx_keys.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttn_LogOut
            // 
            this.bttn_LogOut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bttn_LogOut.Location = new System.Drawing.Point(12, 482);
            this.bttn_LogOut.Name = "bttn_LogOut";
            this.bttn_LogOut.Size = new System.Drawing.Size(303, 34);
            this.bttn_LogOut.TabIndex = 0;
            this.bttn_LogOut.Text = "Sign Out";
            this.bttn_LogOut.UseVisualStyleBackColor = true;
            this.bttn_LogOut.Click += new System.EventHandler(this.bttn_LogOut_Click);
            // 
            // lbl_Title
            // 
            this.lbl_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Title.Location = new System.Drawing.Point(12, 14);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(303, 68);
            this.lbl_Title.TabIndex = 1;
            this.lbl_Title.Text = "Main Menu";
            this.lbl_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bttn_custom
            // 
            this.bttn_custom.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bttn_custom.Location = new System.Drawing.Point(12, 419);
            this.bttn_custom.Name = "bttn_custom";
            this.bttn_custom.Size = new System.Drawing.Size(303, 34);
            this.bttn_custom.TabIndex = 3;
            this.bttn_custom.Text = "Generate a Custom Maze";
            this.bttn_custom.UseVisualStyleBackColor = true;
            this.bttn_custom.Click += new System.EventHandler(this.bttn_generate_Click);
            // 
            // bttn_setMovement
            // 
            this.bttn_setMovement.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bttn_setMovement.Location = new System.Drawing.Point(12, 199);
            this.bttn_setMovement.Name = "bttn_setMovement";
            this.bttn_setMovement.Size = new System.Drawing.Size(303, 34);
            this.bttn_setMovement.TabIndex = 4;
            this.bttn_setMovement.Text = "Change Movement Keys";
            this.bttn_setMovement.UseVisualStyleBackColor = true;
            this.bttn_setMovement.Click += new System.EventHandler(this.bttn_setMovement_Click);
            // 
            // lbl_keyLeft
            // 
            this.lbl_keyLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_keyLeft.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_keyLeft.Location = new System.Drawing.Point(154, 19);
            this.lbl_keyLeft.Name = "lbl_keyLeft";
            this.lbl_keyLeft.Size = new System.Drawing.Size(143, 38);
            this.lbl_keyLeft.TabIndex = 5;
            this.lbl_keyLeft.Text = "Left:";
            this.lbl_keyLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_keyRight
            // 
            this.lbl_keyRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_keyRight.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_keyRight.Location = new System.Drawing.Point(154, 59);
            this.lbl_keyRight.Name = "lbl_keyRight";
            this.lbl_keyRight.Size = new System.Drawing.Size(143, 38);
            this.lbl_keyRight.TabIndex = 6;
            this.lbl_keyRight.Text = "Right:";
            this.lbl_keyRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_keyDown
            // 
            this.lbl_keyDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_keyDown.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_keyDown.Location = new System.Drawing.Point(6, 59);
            this.lbl_keyDown.Name = "lbl_keyDown";
            this.lbl_keyDown.Size = new System.Drawing.Size(142, 38);
            this.lbl_keyDown.TabIndex = 8;
            this.lbl_keyDown.Text = "Down:";
            this.lbl_keyDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_keyUp
            // 
            this.lbl_keyUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_keyUp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_keyUp.Location = new System.Drawing.Point(6, 19);
            this.lbl_keyUp.Name = "lbl_keyUp";
            this.lbl_keyUp.Size = new System.Drawing.Size(142, 38);
            this.lbl_keyUp.TabIndex = 7;
            this.lbl_keyUp.Text = "Up:";
            this.lbl_keyUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bttn_graphs
            // 
            this.bttn_graphs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bttn_graphs.Location = new System.Drawing.Point(12, 239);
            this.bttn_graphs.Name = "bttn_graphs";
            this.bttn_graphs.Size = new System.Drawing.Size(303, 34);
            this.bttn_graphs.TabIndex = 9;
            this.bttn_graphs.Text = "Show Graphs";
            this.bttn_graphs.UseVisualStyleBackColor = true;
            this.bttn_graphs.Click += new System.EventHandler(this.bttn_graphs_Click);
            // 
            // grpbx_keys
            // 
            this.grpbx_keys.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grpbx_keys.Controls.Add(this.lbl_keyUp);
            this.grpbx_keys.Controls.Add(this.lbl_keyLeft);
            this.grpbx_keys.Controls.Add(this.lbl_keyDown);
            this.grpbx_keys.Controls.Add(this.lbl_keyRight);
            this.grpbx_keys.Location = new System.Drawing.Point(12, 85);
            this.grpbx_keys.Name = "grpbx_keys";
            this.grpbx_keys.Size = new System.Drawing.Size(303, 108);
            this.grpbx_keys.TabIndex = 10;
            this.grpbx_keys.TabStop = false;
            this.grpbx_keys.Text = "Movement Keys";
            // 
            // bttn_easy
            // 
            this.bttn_easy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bttn_easy.Location = new System.Drawing.Point(12, 299);
            this.bttn_easy.Name = "bttn_easy";
            this.bttn_easy.Size = new System.Drawing.Size(303, 34);
            this.bttn_easy.TabIndex = 11;
            this.bttn_easy.Text = "Generate an Easy Maze";
            this.bttn_easy.UseVisualStyleBackColor = true;
            this.bttn_easy.Click += new System.EventHandler(this.bttn_easy_Click);
            // 
            // bttn_medium
            // 
            this.bttn_medium.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bttn_medium.Location = new System.Drawing.Point(12, 339);
            this.bttn_medium.Name = "bttn_medium";
            this.bttn_medium.Size = new System.Drawing.Size(303, 34);
            this.bttn_medium.TabIndex = 12;
            this.bttn_medium.Text = "Generate a Medium Maze";
            this.bttn_medium.UseVisualStyleBackColor = true;
            this.bttn_medium.Click += new System.EventHandler(this.bttn_medium_Click);
            // 
            // bttn_difficult
            // 
            this.bttn_difficult.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.bttn_difficult.Location = new System.Drawing.Point(12, 379);
            this.bttn_difficult.Name = "bttn_difficult";
            this.bttn_difficult.Size = new System.Drawing.Size(303, 34);
            this.bttn_difficult.TabIndex = 13;
            this.bttn_difficult.Text = "Generate a Difficult Maze";
            this.bttn_difficult.UseVisualStyleBackColor = true;
            this.bttn_difficult.Click += new System.EventHandler(this.bttn_difficult_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 581);
            this.Controls.Add(this.bttn_difficult);
            this.Controls.Add(this.bttn_medium);
            this.Controls.Add(this.bttn_easy);
            this.Controls.Add(this.grpbx_keys);
            this.Controls.Add(this.bttn_graphs);
            this.Controls.Add(this.bttn_setMovement);
            this.Controls.Add(this.bttn_custom);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.bttn_LogOut);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.grpbx_keys.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttn_LogOut;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.Button bttn_custom;
        private System.Windows.Forms.Button bttn_setMovement;
        private System.Windows.Forms.Label lbl_keyLeft;
        private System.Windows.Forms.Label lbl_keyRight;
        private System.Windows.Forms.Label lbl_keyDown;
        private System.Windows.Forms.Label lbl_keyUp;
        private System.Windows.Forms.Button bttn_graphs;
        private System.Windows.Forms.GroupBox grpbx_keys;
        private System.Windows.Forms.Button bttn_easy;
        private System.Windows.Forms.Button bttn_medium;
        private System.Windows.Forms.Button bttn_difficult;
    }
}