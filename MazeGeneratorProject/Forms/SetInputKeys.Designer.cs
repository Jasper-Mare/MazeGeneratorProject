
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
            this.lbl_ccw = new System.Windows.Forms.Label();
            this.lbl_cw = new System.Windows.Forms.Label();
            this.lbl_select = new System.Windows.Forms.Label();
            this.lbl_select_val = new System.Windows.Forms.Label();
            this.lbl_cw_val = new System.Windows.Forms.Label();
            this.lbl_ccw_val = new System.Windows.Forms.Label();
            this.bttn_set_ccw = new System.Windows.Forms.Button();
            this.bttn_set_cw = new System.Windows.Forms.Button();
            this.bttn_set_select = new System.Windows.Forms.Button();
            this.bttn_done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_ccw
            // 
            this.lbl_ccw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ccw.Location = new System.Drawing.Point(12, 9);
            this.lbl_ccw.Name = "lbl_ccw";
            this.lbl_ccw.Size = new System.Drawing.Size(175, 83);
            this.lbl_ccw.TabIndex = 0;
            this.lbl_ccw.Text = "Turn counter clockwise:";
            this.lbl_ccw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_cw
            // 
            this.lbl_cw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_cw.Location = new System.Drawing.Point(374, 9);
            this.lbl_cw.Name = "lbl_cw";
            this.lbl_cw.Size = new System.Drawing.Size(175, 83);
            this.lbl_cw.TabIndex = 1;
            this.lbl_cw.Text = "Turn clockwise:";
            this.lbl_cw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_select
            // 
            this.lbl_select.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_select.Location = new System.Drawing.Point(193, 9);
            this.lbl_select.Name = "lbl_select";
            this.lbl_select.Size = new System.Drawing.Size(175, 83);
            this.lbl_select.TabIndex = 2;
            this.lbl_select.Text = "Select direction:";
            this.lbl_select.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_select.Click += new System.EventHandler(this.lbl_select_Click);
            // 
            // lbl_select_val
            // 
            this.lbl_select_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_select_val.Location = new System.Drawing.Point(193, 97);
            this.lbl_select_val.Name = "lbl_select_val";
            this.lbl_select_val.Size = new System.Drawing.Size(175, 83);
            this.lbl_select_val.TabIndex = 5;
            this.lbl_select_val.Text = "val";
            this.lbl_select_val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_select_val.Click += new System.EventHandler(this.lbl_select_val_Click);
            // 
            // lbl_cw_val
            // 
            this.lbl_cw_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_cw_val.Location = new System.Drawing.Point(374, 97);
            this.lbl_cw_val.Name = "lbl_cw_val";
            this.lbl_cw_val.Size = new System.Drawing.Size(175, 83);
            this.lbl_cw_val.TabIndex = 4;
            this.lbl_cw_val.Text = "val";
            this.lbl_cw_val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ccw_val
            // 
            this.lbl_ccw_val.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_ccw_val.Location = new System.Drawing.Point(12, 97);
            this.lbl_ccw_val.Name = "lbl_ccw_val";
            this.lbl_ccw_val.Size = new System.Drawing.Size(175, 83);
            this.lbl_ccw_val.TabIndex = 3;
            this.lbl_ccw_val.Text = "val";
            this.lbl_ccw_val.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bttn_set_ccw
            // 
            this.bttn_set_ccw.Location = new System.Drawing.Point(12, 185);
            this.bttn_set_ccw.Name = "bttn_set_ccw";
            this.bttn_set_ccw.Size = new System.Drawing.Size(175, 83);
            this.bttn_set_ccw.TabIndex = 6;
            this.bttn_set_ccw.Text = "Set";
            this.bttn_set_ccw.UseVisualStyleBackColor = true;
            this.bttn_set_ccw.Click += new System.EventHandler(this.bttn_set_ccw_Click);
            // 
            // bttn_set_cw
            // 
            this.bttn_set_cw.Location = new System.Drawing.Point(374, 185);
            this.bttn_set_cw.Name = "bttn_set_cw";
            this.bttn_set_cw.Size = new System.Drawing.Size(175, 83);
            this.bttn_set_cw.TabIndex = 7;
            this.bttn_set_cw.Text = "Set";
            this.bttn_set_cw.UseVisualStyleBackColor = true;
            this.bttn_set_cw.Click += new System.EventHandler(this.bttn_set_cw_Click);
            // 
            // bttn_set_select
            // 
            this.bttn_set_select.Location = new System.Drawing.Point(193, 185);
            this.bttn_set_select.Name = "bttn_set_select";
            this.bttn_set_select.Size = new System.Drawing.Size(175, 83);
            this.bttn_set_select.TabIndex = 8;
            this.bttn_set_select.Text = "Set";
            this.bttn_set_select.UseVisualStyleBackColor = true;
            this.bttn_set_select.Click += new System.EventHandler(this.bttn_set_select_Click);
            // 
            // bttn_done
            // 
            this.bttn_done.Location = new System.Drawing.Point(12, 393);
            this.bttn_done.Name = "bttn_done";
            this.bttn_done.Size = new System.Drawing.Size(537, 45);
            this.bttn_done.TabIndex = 9;
            this.bttn_done.Text = "Done";
            this.bttn_done.UseVisualStyleBackColor = true;
            this.bttn_done.Click += new System.EventHandler(this.bttn_done_Click);
            // 
            // SetInputKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 450);
            this.Controls.Add(this.bttn_done);
            this.Controls.Add(this.bttn_set_select);
            this.Controls.Add(this.bttn_set_cw);
            this.Controls.Add(this.bttn_set_ccw);
            this.Controls.Add(this.lbl_select_val);
            this.Controls.Add(this.lbl_cw_val);
            this.Controls.Add(this.lbl_ccw_val);
            this.Controls.Add(this.lbl_select);
            this.Controls.Add(this.lbl_cw);
            this.Controls.Add(this.lbl_ccw);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SetInputKeys";
            this.Text = "SetInputKeys";
            this.Load += new System.EventHandler(this.SetInputKeys_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_ccw;
        private System.Windows.Forms.Label lbl_cw;
        private System.Windows.Forms.Label lbl_select;
        private System.Windows.Forms.Label lbl_select_val;
        private System.Windows.Forms.Label lbl_cw_val;
        private System.Windows.Forms.Label lbl_ccw_val;
        private System.Windows.Forms.Button bttn_set_ccw;
        private System.Windows.Forms.Button bttn_set_cw;
        private System.Windows.Forms.Button bttn_set_select;
        private System.Windows.Forms.Button bttn_done;
    }
}