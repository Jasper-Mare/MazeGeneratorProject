
namespace MazeGeneratorProject.Forms
{
    partial class Graphs
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
            this.tbctl_Graphs = new System.Windows.Forms.TabControl();
            this.bttn_back = new System.Windows.Forms.Button();
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_attempt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbctl_Graphs
            // 
            this.tbctl_Graphs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbctl_Graphs.Location = new System.Drawing.Point(80, 80);
            this.tbctl_Graphs.Name = "tbctl_Graphs";
            this.tbctl_Graphs.SelectedIndex = 0;
            this.tbctl_Graphs.Size = new System.Drawing.Size(528, 298);
            this.tbctl_Graphs.TabIndex = 3;
            this.tbctl_Graphs.Selected += new System.Windows.Forms.TabControlEventHandler(this.tbctl_Graphs_Selected);
            // 
            // bttn_back
            // 
            this.bttn_back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttn_back.Location = new System.Drawing.Point(12, 404);
            this.bttn_back.Name = "bttn_back";
            this.bttn_back.Size = new System.Drawing.Size(596, 34);
            this.bttn_back.TabIndex = 5;
            this.bttn_back.Text = "Back To Main Menu";
            this.bttn_back.UseVisualStyleBackColor = true;
            this.bttn_back.Click += new System.EventHandler(this.bttn_back_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(596, 68);
            this.lbl_title.TabIndex = 6;
            this.lbl_title.Text = "Graphs of Time Taken";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_time
            // 
            this.lbl_time.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_time.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_time.Location = new System.Drawing.Point(12, 84);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(62, 294);
            this.lbl_time.TabIndex = 7;
            this.lbl_time.Text = "Time Taken to Solve (seconds)";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_attempt
            // 
            this.lbl_attempt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_attempt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_attempt.Location = new System.Drawing.Point(80, 381);
            this.lbl_attempt.Name = "lbl_attempt";
            this.lbl_attempt.Size = new System.Drawing.Size(528, 20);
            this.lbl_attempt.TabIndex = 8;
            this.lbl_attempt.Text = "Attempt Number";
            this.lbl_attempt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Graphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 450);
            this.Controls.Add(this.lbl_attempt);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.bttn_back);
            this.Controls.Add(this.tbctl_Graphs);
            this.Name = "Graphs";
            this.Text = "graphs";
            this.Load += new System.EventHandler(this.graphs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbctl_Graphs;
        private System.Windows.Forms.Button bttn_back;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_attempt;
    }
}