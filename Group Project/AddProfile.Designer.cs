namespace Group_Project
{
    partial class AddProfile
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
            this.Back = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.profileName = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.passwordCon = new System.Windows.Forms.TextBox();
            this.nfcScan = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(15, 102);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(74, 23);
            this.Back.TabIndex = 17;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(95, 102);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(235, 23);
            this.addButton.TabIndex = 16;
            this.addButton.Text = "Click Here To Add Profile";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // profileName
            // 
            this.profileName.Location = new System.Drawing.Point(212, 14);
            this.profileName.Name = "profileName";
            this.profileName.Size = new System.Drawing.Size(118, 20);
            this.profileName.TabIndex = 15;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(212, 44);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(118, 20);
            this.password.TabIndex = 14;
            this.password.UseSystemPasswordChar = true;
            // 
            // passwordCon
            // 
            this.passwordCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordCon.Location = new System.Drawing.Point(212, 71);
            this.passwordCon.Name = "passwordCon";
            this.passwordCon.Size = new System.Drawing.Size(118, 21);
            this.passwordCon.TabIndex = 13;
            this.passwordCon.UseSystemPasswordChar = true;
            // 
            // nfcScan
            // 
            this.nfcScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nfcScan.ForeColor = System.Drawing.Color.RoyalBlue;
            this.nfcScan.Location = new System.Drawing.Point(14, 12);
            this.nfcScan.Name = "nfcScan";
            this.nfcScan.Size = new System.Drawing.Size(75, 80);
            this.nfcScan.TabIndex = 12;
            this.nfcScan.Text = "SCAN NFC";
            this.nfcScan.UseVisualStyleBackColor = true;
            this.nfcScan.Click += new System.EventHandler(this.nfcScan_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(92, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Confim Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(92, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Profile Name:";
            // 
            // AddProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 137);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.profileName);
            this.Controls.Add(this.password);
            this.Controls.Add(this.passwordCon);
            this.Controls.Add(this.nfcScan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddProfile";
            this.Text = "EasyCrypt - Add Profile";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox profileName;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox passwordCon;
        private System.Windows.Forms.Button nfcScan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}