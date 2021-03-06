﻿namespace Liplis.MainSystem
{
    partial class LiplisIcon
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
            this.btnLog = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.btnChar = new System.Windows.Forms.PictureBox();
            this.btnEnd = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.Color.Transparent;
            this.btnLog.Location = new System.Drawing.Point(95, 54);
            this.btnLog.Margin = new System.Windows.Forms.Padding(0);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(32, 32);
            this.btnLog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLog.TabIndex = 21;
            this.btnLog.TabStop = false;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.Transparent;
            this.btnMenu.Location = new System.Drawing.Point(43, 54);
            this.btnMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(32, 32);
            this.btnMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMenu.TabIndex = 17;
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnChar
            // 
            this.btnChar.BackColor = System.Drawing.Color.Transparent;
            this.btnChar.Location = new System.Drawing.Point(149, 54);
            this.btnChar.Margin = new System.Windows.Forms.Padding(0);
            this.btnChar.Name = "btnChar";
            this.btnChar.Size = new System.Drawing.Size(32, 32);
            this.btnChar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnChar.TabIndex = 15;
            this.btnChar.TabStop = false;
            this.btnChar.Click += new System.EventHandler(this.btnChar_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnEnd.Location = new System.Drawing.Point(204, 54);
            this.btnEnd.Margin = new System.Windows.Forms.Padding(0);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(32, 32);
            this.btnEnd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEnd.TabIndex = 14;
            this.btnEnd.TabStop = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // LiplisIcon
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnLog);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnChar);
            this.Controls.Add(this.btnEnd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LiplisIcon";
            this.Text = "LiplisIcon";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LiplisIcon_FormClosing);
            this.Load += new System.EventHandler(this.LiplisIcon_Load);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.LiplisIcon_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LiplisIcon_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LiplisIcon_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LiplisIcon_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.btnLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnChar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnEnd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.PictureBox btnEnd;
        protected System.Windows.Forms.PictureBox btnChar;
        protected System.Windows.Forms.PictureBox btnMenu;
        protected System.Windows.Forms.PictureBox btnLog;

    }
}