 namespace MazeGeneratorProject.Forms {     partial class LoginScreen     {         /// <summary>         /// Required designer variable.         /// </summary>         private System.ComponentModel.IContainer components = null;          /// <summary>         /// Clean up any resources being used.         /// </summary>         /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>         protected override void Dispose(bool disposing)         {             if (disposing && (components != null))             {                 components.Dispose();             }             base.Dispose(disposing);         }          #region Windows Form Designer generated code          /// <summary>         /// Required method for Designer support - do not modify         /// the contents of this method with the code editor.         /// </summary>         private void InitializeComponent()         {             this.lbl_title = new System.Windows.Forms.Label();
            this.txtbx_username = new System.Windows.Forms.TextBox();
            this.lbl_usrnm = new System.Windows.Forms.Label();
            this.bttn_login = new System.Windows.Forms.Button();
            this.lbl_usernameRules = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_title.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_title.Font = new System.Drawing.Font("Times New Roman", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(637, 65);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "Login or Create an Account";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbx_username
            // 
            this.txtbx_username.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbx_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtbx_username.Location = new System.Drawing.Point(12, 112);
            this.txtbx_username.Name = "txtbx_username";
            this.txtbx_username.Size = new System.Drawing.Size(637, 26);
            this.txtbx_username.TabIndex = 1;
            this.txtbx_username.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtbx_username_PreviewKeyDown);
            // 
            // lbl_usrnm
            // 
            this.lbl_usrnm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_usrnm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_usrnm.Location = new System.Drawing.Point(12, 84);
            this.lbl_usrnm.Name = "lbl_usrnm";
            this.lbl_usrnm.Size = new System.Drawing.Size(637, 25);
            this.lbl_usrnm.TabIndex = 2;
            this.lbl_usrnm.Text = "Username:";
            this.lbl_usrnm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bttn_login
            // 
            this.bttn_login.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttn_login.BackColor = System.Drawing.SystemColors.Control;
            this.bttn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bttn_login.Location = new System.Drawing.Point(12, 144);
            this.bttn_login.Name = "bttn_login";
            this.bttn_login.Size = new System.Drawing.Size(637, 29);
            this.bttn_login.TabIndex = 3;
            this.bttn_login.Text = "Log In / Create Account";
            this.bttn_login.UseVisualStyleBackColor = false;
            this.bttn_login.Click += new System.EventHandler(this.bttn_login_Click);
            // 
            // lbl_usernameRules
            // 
            this.lbl_usernameRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_usernameRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbl_usernameRules.Location = new System.Drawing.Point(12, 190);
            this.lbl_usernameRules.Name = "lbl_usernameRules";
            this.lbl_usernameRules.Size = new System.Drawing.Size(637, 58);
            this.lbl_usernameRules.TabIndex = 4;
            this.lbl_usernameRules.Text = "A valid username consists of only:\r\nletters (lower and upper case), and numbers";
            this.lbl_usernameRules.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 270);
            this.Controls.Add(this.lbl_usernameRules);
            this.Controls.Add(this.bttn_login);
            this.Controls.Add(this.lbl_usrnm);
            this.Controls.Add(this.txtbx_username);
            this.Controls.Add(this.lbl_title);
            this.Name = "LoginScreen";
            this.Text = "LoginScreen";
            this.Load += new System.EventHandler(this.LoginScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }          #endregion          private System.Windows.Forms.Label lbl_title;         private System.Windows.Forms.TextBox txtbx_username;         private System.Windows.Forms.Label lbl_usrnm;         private System.Windows.Forms.Button bttn_login;
        private System.Windows.Forms.Label lbl_usernameRules;
    } }