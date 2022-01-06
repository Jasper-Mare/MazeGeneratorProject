
namespace MazeGeneratorProject.Forms {
    partial class SetInputKeys {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
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
            this.lbl_up = new System.Windows.Forms.Label();
            this.lbl_left = new System.Windows.Forms.Label();
            this.lbl_down = new System.Windows.Forms.Label();
            this.lbl_down_val = new System.Windows.Forms.Label();
            this.lbl_left_val = new System.Windows.Forms.Label();
            this.lbl_up_val = new System.Windows.Forms.Label();
            this.bttn_set_up = new System.Windows.Forms.Button();
            this.bttn_set_left = new System.Windows.Forms.Button();
            this.bttn_set_down = new System.Windows.Forms.Button();
            this.bttn_done = new System.Windows.Forms.Button();
            this.bttn_set_right = new System.Windows.Forms.Button();
            this.lbl_right_val = new System.Windows.Forms.Label();
            this.lbl_right = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_up
            // 
            this.lbl_up.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_up.Location = new System.Drawing.Point(12, 9);
            this.lbl_up.Name = "lbl_up";
            this.lbl_up.Size = new System.Drawing.Size(175, 83);
            this.lbl_up.TabIndex = 0;
            this.lbl_up.Text = "Up:";
            this.lbl_up.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_left
            // 
            this.lbl_left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_left.Location = new System.Drawing.Point(12, 195);
            this.lbl_left.Name = "lbl_left";
            this.lbl_left.Size = new System.Drawing.Size(175, 83);
            this.lbl_left.TabIndex = 1;
            this.lbl_left.Text = "Left:";
            this.lbl_left.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_down
            // 
            this.lbl_down.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_down.Location = new System.Drawing.Point(12, 102);
            this.lbl_down.Name = "lbl_down";
            this.lbl_down.Size = new System.Drawing.Size(175, 83);
            this.lbl_down.TabIndex = 2;
            this.lbl_down.Text = "Down:";
            this.lbl_down.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_down_val
            // 
            this.lbl_down_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_down_val.Location = new System.Drawing.Point(193, 102);
            this.lbl_down_val.Name = "lbl_down_val";
            this.lbl_down_val.Size = new System.Drawing.Size(175, 83);
            this.lbl_down_val.TabIndex = 5;
            this.lbl_down_val.Text = "val";
            this.lbl_down_val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_left_val
            // 
            this.lbl_left_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_left_val.Location = new System.Drawing.Point(193, 195);
            this.lbl_left_val.Name = "lbl_left_val";
            this.lbl_left_val.Size = new System.Drawing.Size(175, 83);
            this.lbl_left_val.TabIndex = 4;
            this.lbl_left_val.Text = "val";
            this.lbl_left_val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_up_val
            // 
            this.lbl_up_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_up_val.Location = new System.Drawing.Point(193, 9);
            this.lbl_up_val.Name = "lbl_up_val";
            this.lbl_up_val.Size = new System.Drawing.Size(175, 83);
            this.lbl_up_val.TabIndex = 3;
            this.lbl_up_val.Text = "val";
            this.lbl_up_val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bttn_set_up
            // 
            this.bttn_set_up.Location = new System.Drawing.Point(374, 9);
            this.bttn_set_up.Name = "bttn_set_up";
            this.bttn_set_up.Size = new System.Drawing.Size(175, 83);
            this.bttn_set_up.TabIndex = 6;
            this.bttn_set_up.Text = "Reset";
            this.bttn_set_up.UseVisualStyleBackColor = true;
            this.bttn_set_up.Click += new System.EventHandler(this.bttn_set_up_Click);
            // 
            // bttn_set_left
            // 
            this.bttn_set_left.Location = new System.Drawing.Point(374, 195);
            this.bttn_set_left.Name = "bttn_set_left";
            this.bttn_set_left.Size = new System.Drawing.Size(175, 83);
            this.bttn_set_left.TabIndex = 7;
            this.bttn_set_left.Text = "Reset";
            this.bttn_set_left.UseVisualStyleBackColor = true;
            this.bttn_set_left.Click += new System.EventHandler(this.bttn_set_left_Click);
            // 
            // bttn_set_down
            // 
            this.bttn_set_down.Location = new System.Drawing.Point(374, 102);
            this.bttn_set_down.Name = "bttn_set_down";
            this.bttn_set_down.Size = new System.Drawing.Size(175, 83);
            this.bttn_set_down.TabIndex = 8;
            this.bttn_set_down.Text = "Reset";
            this.bttn_set_down.UseVisualStyleBackColor = true;
            this.bttn_set_down.Click += new System.EventHandler(this.bttn_set_down_Click);
            // 
            // bttn_done
            // 
            this.bttn_done.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttn_done.Location = new System.Drawing.Point(12, 393);
            this.bttn_done.Name = "bttn_done";
            this.bttn_done.Size = new System.Drawing.Size(537, 45);
            this.bttn_done.TabIndex = 9;
            this.bttn_done.Text = "Done";
            this.bttn_done.UseVisualStyleBackColor = true;
            this.bttn_done.Click += new System.EventHandler(this.bttn_done_Click);
            // 
            // bttn_set_right
            // 
            this.bttn_set_right.Location = new System.Drawing.Point(374, 284);
            this.bttn_set_right.Name = "bttn_set_right";
            this.bttn_set_right.Size = new System.Drawing.Size(175, 83);
            this.bttn_set_right.TabIndex = 12;
            this.bttn_set_right.Text = "Reset";
            this.bttn_set_right.UseVisualStyleBackColor = true;
            this.bttn_set_right.Click += new System.EventHandler(this.bttn_set_right_Click);
            // 
            // lbl_right_val
            // 
            this.lbl_right_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_right_val.Location = new System.Drawing.Point(193, 284);
            this.lbl_right_val.Name = "lbl_right_val";
            this.lbl_right_val.Size = new System.Drawing.Size(175, 83);
            this.lbl_right_val.TabIndex = 11;
            this.lbl_right_val.Text = "val";
            this.lbl_right_val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_right
            // 
            this.lbl_right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_right.Location = new System.Drawing.Point(12, 284);
            this.lbl_right.Name = "lbl_right";
            this.lbl_right.Size = new System.Drawing.Size(175, 83);
            this.lbl_right.TabIndex = 10;
            this.lbl_right.Text = "Right:";
            this.lbl_right.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetInputKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 450);
            this.Controls.Add(this.bttn_set_right);
            this.Controls.Add(this.lbl_right_val);
            this.Controls.Add(this.lbl_right);
            this.Controls.Add(this.bttn_done);
            this.Controls.Add(this.bttn_set_down);
            this.Controls.Add(this.bttn_set_left);
            this.Controls.Add(this.bttn_set_up);
            this.Controls.Add(this.lbl_down_val);
            this.Controls.Add(this.lbl_left_val);
            this.Controls.Add(this.lbl_up_val);
            this.Controls.Add(this.lbl_down);
            this.Controls.Add(this.lbl_left);
            this.Controls.Add(this.lbl_up);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SetInputKeys";
            this.Text = "SetInputKeys";
            this.Load += new System.EventHandler(this.SetInputKeys_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_up;
        private System.Windows.Forms.Label lbl_left;
        private System.Windows.Forms.Label lbl_down;
        private System.Windows.Forms.Label lbl_down_val;
        private System.Windows.Forms.Label lbl_left_val;
        private System.Windows.Forms.Label lbl_up_val;
        private System.Windows.Forms.Button bttn_set_up;
        private System.Windows.Forms.Button bttn_set_left;
        private System.Windows.Forms.Button bttn_set_down;
        private System.Windows.Forms.Button bttn_done;
        private System.Windows.Forms.Button bttn_set_right;
        private System.Windows.Forms.Label lbl_right_val;
        private System.Windows.Forms.Label lbl_right;
    }
}