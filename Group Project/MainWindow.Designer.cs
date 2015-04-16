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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.nfcScan = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.Button();
            this.AddProfile = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nfcScan
            // 
            this.nfcScan.Image = global::Group_Project.Properties.Resources.NFC;
            this.nfcScan.Location = new System.Drawing.Point(12, 12);
            this.nfcScan.Name = "nfcScan";
            this.nfcScan.Size = new System.Drawing.Size(310, 257);
            this.nfcScan.TabIndex = 0;
            this.nfcScan.UseVisualStyleBackColor = true;
            this.nfcScan.Click += new System.EventHandler(this.nfcScan_Click);
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login.Location = new System.Drawing.Point(12, 277);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(310, 28);
            this.Login.TabIndex = 1;
            this.Login.Text = "Click Here to Login with Credentials!";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // AddProfile
            // 
            this.AddProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProfile.Location = new System.Drawing.Point(12, 311);
            this.AddProfile.Name = "AddProfile";
            this.AddProfile.Size = new System.Drawing.Size(150, 28);
            this.AddProfile.TabIndex = 2;
            this.AddProfile.Text = "Add Profile";
            this.AddProfile.UseVisualStyleBackColor = true;
            this.AddProfile.Click += new System.EventHandler(this.AddProfile_Click);
            // 
            // remove
            // 
            this.remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remove.Location = new System.Drawing.Point(172, 311);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(150, 28);
            this.remove.TabIndex = 3;
            this.remove.Text = "Remove Profile";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 347);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.AddProfile);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.nfcScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "EasyCrypt";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nfcScan;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button AddProfile;
        private System.Windows.Forms.Button remove;
    }
}