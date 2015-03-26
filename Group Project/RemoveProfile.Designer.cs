namespace Group_Project
{
    partial class RemoveProfile
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nfcScan = new System.Windows.Forms.Button();
            this.passwordCon = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.profileName = new System.Windows.Forms.TextBox();
            this.removeButton = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(90, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(90, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Confim Password:";
            // 
            // nfcScan
            // 
            this.nfcScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nfcScan.ForeColor = System.Drawing.Color.RoyalBlue;
            this.nfcScan.Location = new System.Drawing.Point(12, 12);
            this.nfcScan.Name = "nfcScan";
            this.nfcScan.Size = new System.Drawing.Size(75, 80);
            this.nfcScan.TabIndex = 3;
            this.nfcScan.Text = "SCAN NFC";
            this.nfcScan.UseVisualStyleBackColor = true;
            this.nfcScan.Click += new System.EventHandler(this.nfcScan_Click);
            // 
            // passwordCon
            // 
            this.passwordCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordCon.Location = new System.Drawing.Point(210, 71);
            this.passwordCon.Name = "passwordCon";
            this.passwordCon.Size = new System.Drawing.Size(118, 21);
            this.passwordCon.TabIndex = 4;
            this.passwordCon.UseSystemPasswordChar = true;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(210, 44);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(118, 20);
            this.password.TabIndex = 5;
            this.password.UseSystemPasswordChar = true;
            // 
            // profileName
            // 
            this.profileName.Location = new System.Drawing.Point(210, 14);
            this.profileName.Name = "profileName";
            this.profileName.Size = new System.Drawing.Size(118, 20);
            this.profileName.TabIndex = 6;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(93, 102);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(235, 23);
            this.removeButton.TabIndex = 7;
            this.removeButton.Text = "Click Here To Remove Profile";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(13, 102);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(74, 23);
            this.Back.TabIndex = 8;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // RemoveProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 137);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.profileName);
            this.Controls.Add(this.password);
            this.Controls.Add(this.passwordCon);
            this.Controls.Add(this.nfcScan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RemoveProfile";
            this.Text = "EasyCrypt - Remove Profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button nfcScan;
        private System.Windows.Forms.TextBox passwordCon;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox profileName;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button Back;
    }
}