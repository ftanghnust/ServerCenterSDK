﻿namespace Frxs.ServiceCenter.DataSync.Message.DataSyncClient
{
    partial class frmDataSync0
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
            this.btnDataSync = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.labelProgress = new System.Windows.Forms.Label();
            this.panelProInfo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnDataSync
            // 
            this.btnDataSync.Location = new System.Drawing.Point(229, 390);
            this.btnDataSync.Name = "btnDataSync";
            this.btnDataSync.Size = new System.Drawing.Size(75, 23);
            this.btnDataSync.TabIndex = 0;
            this.btnDataSync.Text = "同步";
            this.btnDataSync.UseVisualStyleBackColor = true;
            this.btnDataSync.Click += new System.EventHandler(this.btnDataSync_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(-20, 367);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 2);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(315, 390);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // labelProgress
            // 
            this.labelProgress.AutoEllipsis = true;
            this.labelProgress.Location = new System.Drawing.Point(28, 390);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(173, 20);
            this.labelProgress.TabIndex = 4;
            this.labelProgress.Text = "label1";
            // 
            // panelProInfo
            // 
            this.panelProInfo.AutoScroll = true;
            this.panelProInfo.Location = new System.Drawing.Point(9, 12);
            this.panelProInfo.Name = "panelProInfo";
            this.panelProInfo.Size = new System.Drawing.Size(384, 337);
            this.panelProInfo.TabIndex = 5;
            // 
            // frmDataSync0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 436);
            this.Controls.Add(this.panelProInfo);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDataSync);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDataSync0";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmDataSync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmDataSync_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDataSync;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Panel panelProInfo;
    }
}