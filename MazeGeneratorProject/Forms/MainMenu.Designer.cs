
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
            this.lbl_Username = new System.Windows.Forms.Label();
            this.tbctl_Graphs = new System.Windows.Forms.TabControl();
            this.bttn_generate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttn_LogOut
            // 
            this.bttn_LogOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttn_LogOut.Location = new System.Drawing.Point(12, 403);
            this.bttn_LogOut.Name = "bttn_LogOut";
            this.bttn_LogOut.Size = new System.Drawing.Size(303, 34);
            this.bttn_LogOut.TabIndex = 0;
            this.bttn_LogOut.Text = "Sign Out";
            this.bttn_LogOut.UseVisualStyleBackColor = true;
            this.bttn_LogOut.Click += new System.EventHandler(this.bttn_LogOut_Click);
            // 
            // lbl_Username
            // 
            this.lbl_Username.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Username.Location = new System.Drawing.Point(12, 14);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(303, 68);
            this.lbl_Username.TabIndex = 1;
            this.lbl_Username.Text = "Hello username";
            this.lbl_Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbctl_Graphs
            // 
            this.tbctl_Graphs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbctl_Graphs.Location = new System.Drawing.Point(321, 12);
            this.tbctl_Graphs.Name = "tbctl_Graphs";
            this.tbctl_Graphs.SelectedIndex = 0;
            this.tbctl_Graphs.Size = new System.Drawing.Size(467, 426);
            this.tbctl_Graphs.TabIndex = 2;
            this.tbctl_Graphs.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbctl_Graphs_Selected);
            // 
            // bttn_generate
            // 
            this.bttn_generate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttn_generate.Location = new System.Drawing.Point(12, 363);
            this.bttn_generate.Name = "bttn_generate";
            this.bttn_generate.Size = new System.Drawing.Size(303, 34);
            this.bttn_generate.TabIndex = 3;
            this.bttn_generate.Text = "Generate a Maze";
            this.bttn_generate.UseVisualStyleBackColor = true;
            this.bttn_generate.Click += new System.EventHandler(this.bttn_generate_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bttn_generate);
            this.Controls.Add(this.tbctl_Graphs);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.bttn_LogOut);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttn_LogOut;
        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.TabControl tbctl_Graphs;
        private System.Windows.Forms.Button bttn_generate;
    }
}