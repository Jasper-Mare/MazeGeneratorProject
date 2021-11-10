﻿
namespace MazeGeneratorProject.Forms
{
    partial class MazeForm
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
            this.lbl_Username = new System.Windows.Forms.Label();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.Canvas = new MazeGeneratorProject.Forms.PixelBox();
            this.bttn_Start = new System.Windows.Forms.Button();
            this.pnl_pausedMenu = new System.Windows.Forms.Panel();
            this.lbl_paused = new System.Windows.Forms.Label();
            this.bttn_GiveUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).BeginInit();
            this.pnl_pausedMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Username
            // 
            this.lbl_Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_Username.Location = new System.Drawing.Point(4, 4);
            this.lbl_Username.Name = "lbl_Username";
            this.lbl_Username.Size = new System.Drawing.Size(243, 44);
            this.lbl_Username.TabIndex = 3;
            this.lbl_Username.Text = "Hello username";
            this.lbl_Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_timer
            // 
            this.lbl_timer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_timer.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_timer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_timer.Location = new System.Drawing.Point(0, 0);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(800, 53);
            this.lbl_timer.TabIndex = 4;
            this.lbl_timer.Text = "Time";
            this.lbl_timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Canvas
            // 
            this.Canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Canvas.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Canvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.Canvas.Location = new System.Drawing.Point(12, 61);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(776, 377);
            this.Canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Canvas.TabIndex = 6;
            this.Canvas.TabStop = false;
            // 
            // bttn_Start
            // 
            this.bttn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttn_Start.Font = new System.Drawing.Font("Showcard Gothic", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttn_Start.Location = new System.Drawing.Point(24, 73);
            this.bttn_Start.Name = "bttn_Start";
            this.bttn_Start.Size = new System.Drawing.Size(751, 353);
            this.bttn_Start.TabIndex = 7;
            this.bttn_Start.Text = "Start";
            this.bttn_Start.UseVisualStyleBackColor = true;
            this.bttn_Start.Click += new System.EventHandler(this.bttn_Start_Click);
            // 
            // pnl_pausedMenu
            // 
            this.pnl_pausedMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_pausedMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_pausedMenu.Controls.Add(this.lbl_paused);
            this.pnl_pausedMenu.Controls.Add(this.bttn_GiveUp);
            this.pnl_pausedMenu.Location = new System.Drawing.Point(24, 73);
            this.pnl_pausedMenu.Name = "pnl_pausedMenu";
            this.pnl_pausedMenu.Size = new System.Drawing.Size(751, 353);
            this.pnl_pausedMenu.TabIndex = 8;
            // 
            // lbl_paused
            // 
            this.lbl_paused.AutoSize = true;
            this.lbl_paused.Location = new System.Drawing.Point(-2, 0);
            this.lbl_paused.Name = "lbl_paused";
            this.lbl_paused.Size = new System.Drawing.Size(45, 15);
            this.lbl_paused.TabIndex = 1;
            this.lbl_paused.Text = "Paused";
            // 
            // bttn_GiveUp
            // 
            this.bttn_GiveUp.Location = new System.Drawing.Point(3, 18);
            this.bttn_GiveUp.Name = "bttn_GiveUp";
            this.bttn_GiveUp.Size = new System.Drawing.Size(160, 23);
            this.bttn_GiveUp.TabIndex = 0;
            this.bttn_GiveUp.Text = "Give Up";
            this.bttn_GiveUp.UseVisualStyleBackColor = true;
            this.bttn_GiveUp.Click += new System.EventHandler(this.bttn_GiveUp_Click);
            // 
            // MazeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnl_pausedMenu);
            this.Controls.Add(this.lbl_Username);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.bttn_Start);
            this.Controls.Add(this.Canvas);
            this.Name = "MazeForm";
            this.Text = "MazeForm";
            this.Load += new System.EventHandler(this.MazeForm_Load);
            this.Shown += new System.EventHandler(this.MazeForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Canvas)).EndInit();
            this.pnl_pausedMenu.ResumeLayout(false);
            this.pnl_pausedMenu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_Username;
        private System.Windows.Forms.Label lbl_timer;
        private PixelBox Canvas;
        private System.Windows.Forms.Button bttn_Start;
        private System.Windows.Forms.Panel pnl_pausedMenu;
        private System.Windows.Forms.Label lbl_paused;
        private System.Windows.Forms.Button bttn_GiveUp;
    }
}