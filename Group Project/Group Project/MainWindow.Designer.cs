namespace Group_Project
{
    partial class MainWindow
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
            this.nfcScan = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.AddProfile = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nfcScan
            // 
            this.nfcScan.Image = global::Group_Project.Properties.Resources.NFC;
            this.nfcScan.Location = new System.Drawing.Point(12, 12);
            this.nfcScan.Name = "nfcScan";
            this.nfcScan.Size = new System.Drawing.Size(280, 257);
            this.nfcScan.TabIndex = 0;
            this.nfcScan.UseVisualStyleBackColor = true;
            this.nfcScan.Click += new System.EventHandler(this.nfcScan_Click);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(12, 277);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(280, 23);
            this.Login.TabIndex = 1;
            this.Login.Text = "Click Here to Login with Credentials!";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // AddProfile
            // 
            this.AddProfile.Location = new System.Drawing.Point(12, 306);
            this.AddProfile.Name = "AddProfile";
            this.AddProfile.Size = new System.Drawing.Size(134, 23);
            this.AddProfile.TabIndex = 2;
            this.AddProfile.Text = "Add Profile";
            this.AddProfile.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Remove Profile";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 341);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddProfile);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.nfcScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "TITLE";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nfcScan;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button AddProfile;
        private System.Windows.Forms.Button button1;
    }
}