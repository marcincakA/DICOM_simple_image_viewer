﻿namespace DICOM
{
    partial class FullSizedPicture
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
            pictureBoxFullImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFullImage).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxFullImage
            // 
            pictureBoxFullImage.Dock = DockStyle.Fill;
            pictureBoxFullImage.Location = new Point(0, 0);
            pictureBoxFullImage.Name = "pictureBoxFullImage";
            pictureBoxFullImage.Size = new Size(800, 450);
            pictureBoxFullImage.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBoxFullImage.TabIndex = 0;
            pictureBoxFullImage.TabStop = false;
            // 
            // FullSizedPicture
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBoxFullImage);
            Name = "FullSizedPicture";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)pictureBoxFullImage).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxFullImage;
    }
}