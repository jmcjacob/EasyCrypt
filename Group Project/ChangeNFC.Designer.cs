﻿namespace Group_Project
{
    partial class ChangeNFC
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
            this.SuspendLayout();
            // 
            // nfcScan
            // 
            this.nfcScan.Image = global::Group_Project.Properties.Resources.NFC_small;
            this.nfcScan.Location = new System.Drawing.Point(12, 13);
            this.nfcScan.Name = "nfcScan";
            this.nfcScan.Size = new System.Drawing.Size(156, 156);
            this.nfcScan.TabIndex = 0;
            this.nfcScan.UseVisualStyleBackColor = true;
            this.nfcScan.Click += new System.EventHandler(this.nfcScan_Click);
            // 
            // ChangeNFC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 181);
            this.Controls.Add(this.nfcScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ChangeNFC";
            this.Text = "EasyCrypt - Update NFC";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nfcScan;
    }
}