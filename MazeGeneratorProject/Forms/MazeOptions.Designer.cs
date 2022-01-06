
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.pnl_Options = new System.Windows.Forms.Panel();
            this.lbl_diff = new System.Windows.Forms.Label();
            this.bttn_GenMaze = new System.Windows.Forms.Button();
            this.LayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttn_back
            // 
            this.bttn_back.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bttn_back.Location = new System.Drawing.Point(3, 3);
            this.bttn_back.Name = "bttn_back";
            this.bttn_back.Size = new System.Drawing.Size(382, 43);
            this.bttn_back.TabIndex = 0;
            this.bttn_back.Text = "Back to Main Menu";
            this.bttn_back.UseVisualStyleBackColor = true;
            this.bttn_back.Click += new System.EventHandler(this.Bttn_back_Click);
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_title.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(776, 68);
            this.lbl_title.TabIndex = 2;
            this.lbl_title.Text = "Custom Maze Options";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_Options
            // 
            this.pnl_Options.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_Options.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Options.Location = new System.Drawing.Point(12, 116);
            this.pnl_Options.Name = "pnl_Options";
            this.pnl_Options.Size = new System.Drawing.Size(776, 276);
            this.pnl_Options.TabIndex = 3;
            // 
            // lbl_diff
            // 
            this.lbl_diff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_diff.Location = new System.Drawing.Point(12, 90);
            this.lbl_diff.Name = "lbl_diff";
            this.lbl_diff.Size = new System.Drawing.Size(211, 23);
            this.lbl_diff.TabIndex = 4;
            this.lbl_diff.Text = "This Maze is";
            this.lbl_diff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bttn_GenMaze
            // 
            this.bttn_GenMaze.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bttn_GenMaze.Location = new System.Drawing.Point(391, 3);
            this.bttn_GenMaze.Name = "bttn_GenMaze";
            this.bttn_GenMaze.Size = new System.Drawing.Size(382, 43);
            this.bttn_GenMaze.TabIndex = 6;
            this.bttn_GenMaze.Text = "Generate Maze";
            this.bttn_GenMaze.UseVisualStyleBackColor = true;
            this.bttn_GenMaze.Click += new System.EventHandler(this.bttn_GenMaze_Click);
            // 
            // LayoutPanel
            // 
            this.LayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LayoutPanel.ColumnCount = 2;
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.Controls.Add(this.bttn_back, 0, 0);
            this.LayoutPanel.Controls.Add(this.bttn_GenMaze, 1, 0);
            this.LayoutPanel.Location = new System.Drawing.Point(12, 398);
            this.LayoutPanel.Name = "LayoutPanel";
            this.LayoutPanel.RowCount = 1;
            this.LayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.LayoutPanel.Size = new System.Drawing.Size(776, 49);
            this.LayoutPanel.TabIndex = 7;
            // 
            // MazeOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LayoutPanel);
            this.Controls.Add(this.pnl_Options);
            this.Controls.Add(this.lbl_title);
            this.Controls.Add(this.lbl_diff);
            this.Name = "MazeOptions";
            this.Text = "GenerateMaze";
            this.Load += new System.EventHandler(this.GenerateMaze_Load);
            this.LayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttn_back;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Panel pnl_Options;
        private System.Windows.Forms.Label lbl_diff;
        private System.Windows.Forms.Button bttn_GenMaze;
        private System.Windows.Forms.TableLayoutPanel LayoutPanel;
    }
}