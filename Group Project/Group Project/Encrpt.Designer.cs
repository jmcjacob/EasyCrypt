﻿namespace Group_Project
{
    partial class Encrpt
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
            this.decryptPath = new System.Windows.Forms.ComboBox();
            this.encryptPath = new System.Windows.Forms.TextBox();
            this.decryptFile = new System.Windows.Forms.Button();
            this.encryptFile = new System.Windows.Forms.Button();
            this.findPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LogOut = new System.Windows.Forms.Button();
            this.changeNFC = new System.Windows.Forms.Button();
            this.changePassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // decryptPath
            // 
            this.decryptPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.decryptPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decryptPath.FormattingEnabled = true;
            this.decryptPath.Location = new System.Drawing.Point(15, 70);
            this.decryptPath.Name = "decryptPath";
            this.decryptPath.Size = new System.Drawing.Size(392, 23);
            this.decryptPath.TabIndex = 0;
            // 
            // encryptPath
            // 
            this.encryptPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptPath.Location = new System.Drawing.Point(15, 41);
            this.encryptPath.Name = "encryptPath";
            this.encryptPath.Size = new System.Drawing.Size(361, 21);
            this.encryptPath.TabIndex = 1;
            // 
            // decryptFile
            // 
            this.decryptFile.Location = new System.Drawing.Point(413, 70);
            this.decryptFile.Name = "decryptFile";
            this.decryptFile.Size = new System.Drawing.Size(75, 23);
            this.decryptFile.TabIndex = 2;
            this.decryptFile.Text = "Decrypt File";
            this.decryptFile.UseVisualStyleBackColor = true;
            this.decryptFile.Click += new System.EventHandler(this.decryptFile_Click);
            // 
            // encryptFile
            // 
            this.encryptFile.Location = new System.Drawing.Point(413, 41);
            this.encryptFile.Name = "encryptFile";
            this.encryptFile.Size = new System.Drawing.Size(75, 23);
            this.encryptFile.TabIndex = 3;
            this.encryptFile.Text = "Encrypt File";
            this.encryptFile.UseVisualStyleBackColor = true;
            this.encryptFile.Click += new System.EventHandler(this.encryptFile_Click);
            // 
            // findPath
            // 
            this.findPath.Location = new System.Drawing.Point(382, 41);
            this.findPath.Name = "findPath";
            this.findPath.Size = new System.Drawing.Size(25, 23);
            this.findPath.TabIndex = 4;
            this.findPath.Text = "...";
            this.findPath.UseVisualStyleBackColor = true;
            this.findPath.Click += new System.EventHandler(this.findPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Hello ";
            // 
            // LogOut
            // 
            this.LogOut.Location = new System.Drawing.Point(413, 12);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(75, 23);
            this.LogOut.TabIndex = 6;
            this.LogOut.Text = "Sign Out";
            this.LogOut.UseVisualStyleBackColor = true;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // changeNFC
            // 
            this.changeNFC.Location = new System.Drawing.Point(301, 12);
            this.changeNFC.Name = "changeNFC";
            this.changeNFC.Size = new System.Drawing.Size(106, 23);
            this.changeNFC.TabIndex = 7;
            this.changeNFC.Text = "Change NFC Tag";
            this.changeNFC.UseVisualStyleBackColor = true;
            this.changeNFC.Click += new System.EventHandler(this.changeNFC_Click);
            // 
            // changePassword
            // 
            this.changePassword.Location = new System.Drawing.Point(189, 12);
            this.changePassword.Name = "changePassword";
            this.changePassword.Size = new System.Drawing.Size(106, 23);
            this.changePassword.TabIndex = 8;
            this.changePassword.Text = "Change Password";
            this.changePassword.UseVisualStyleBackColor = true;
            this.changePassword.Click += new System.EventHandler(this.changePassword_Click);
            // 
            // Encrpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 103);
            this.Controls.Add(this.changePassword);
            this.Controls.Add(this.changeNFC);
            this.Controls.Add(this.LogOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.findPath);
            this.Controls.Add(this.encryptFile);
            this.Controls.Add(this.decryptFile);
            this.Controls.Add(this.encryptPath);
            this.Controls.Add(this.decryptPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Encrpt";
            this.Text = "TITLE";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox decryptPath;
        private System.Windows.Forms.TextBox encryptPath;
        private System.Windows.Forms.Button decryptFile;
        private System.Windows.Forms.Button encryptFile;
        private System.Windows.Forms.Button findPath;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LogOut;
        private System.Windows.Forms.Button changeNFC;
        private System.Windows.Forms.Button changePassword;
    }
}