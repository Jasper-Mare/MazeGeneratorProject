
namespace MazeGeneratorProject.Forms
{
    partial class BeginningForm
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
            this.bttn_Start = new System.Windows.Forms.Button();
            this.pbxImg = new MazeGeneratorProject.Forms.PixelBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImg)).BeginInit();
            this.SuspendLayout();
            // 
            // bttn_Start
            // 
            this.bttn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttn_Start.Font = new System.Drawing.Font("Times New Roman", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttn_Start.Location = new System.Drawing.Point(12, 605);
            this.bttn_Start.Name = "bttn_Start";
            this.bttn_Start.Size = new System.Drawing.Size(656, 69);
            this.bttn_Start.TabIndex = 0;
            this.bttn_Start.Text = "START";
            this.bttn_Start.UseVisualStyleBackColor = true;
            this.bttn_Start.Click += new System.EventHandler(this.bttn_Start_Click);
            // 
            // pbxImg
            // 
            this.pbxImg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxImg.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            this.pbxImg.Location = new System.Drawing.Point(12, 12);
            this.pbxImg.Name = "pbxImg";
            this.pbxImg.Size = new System.Drawing.Size(656, 587);
            this.pbxImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImg.TabIndex = 1;
            this.pbxImg.TabStop = false;
            // 
            // BeginningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(680, 686);
            this.ControlBox = false;
            this.Controls.Add(this.pbxImg);
            this.Controls.Add(this.bttn_Start);
            this.Name = "BeginningForm";
            this.Text = "BeginningForm";
            this.Load += new System.EventHandler(this.BeginningForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttn_Start;
        private PixelBox pbxImg;
    }
}