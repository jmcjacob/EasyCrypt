namespace Group_Project
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
            this.SuspendLayout();
            // 
            // decryptPath
            // 
            this.decryptPath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.decryptPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decryptPath.FormattingEnabled = true;
            this.decryptPath.Location = new System.Drawing.Point(12, 75);
            this.decryptPath.Name = "decryptPath";
            this.decryptPath.Size = new System.Drawing.Size(286, 23);
            this.decryptPath.TabIndex = 0;
            // 
            // encryptPath
            // 
            this.encryptPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.encryptPath.Location = new System.Drawing.Point(12, 46);
            this.encryptPath.Name = "encryptPath";
            this.encryptPath.Size = new System.Drawing.Size(255, 21);
            this.encryptPath.TabIndex = 1;
            // 
            // decryptFile
            // 
            this.decryptFile.Location = new System.Drawing.Point(304, 75);
            this.decryptFile.Name = "decryptFile";
            this.decryptFile.Size = new System.Drawing.Size(75, 23);
            this.decryptFile.TabIndex = 2;
            this.decryptFile.Text = "Decrypt File";
            this.decryptFile.UseVisualStyleBackColor = true;
            this.decryptFile.Click += new System.EventHandler(this.decryptFile_Click);
            // 
            // encryptFile
            // 
            this.encryptFile.Location = new System.Drawing.Point(304, 46);
            this.encryptFile.Name = "encryptFile";
            this.encryptFile.Size = new System.Drawing.Size(75, 23);
            this.encryptFile.TabIndex = 3;
            this.encryptFile.Text = "Encrypt File";
            this.encryptFile.UseVisualStyleBackColor = true;
            this.encryptFile.Click += new System.EventHandler(this.encryptFile_Click);
            // 
            // findPath
            // 
            this.findPath.Location = new System.Drawing.Point(273, 46);
            this.findPath.Name = "findPath";
            this.findPath.Size = new System.Drawing.Size(25, 23);
            this.findPath.TabIndex = 4;
            this.findPath.Text = "...";
            this.findPath.UseVisualStyleBackColor = true;
            this.findPath.Click += new System.EventHandler(this.findPath_Click);
            // 
            // Encrpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 113);
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
    }
}