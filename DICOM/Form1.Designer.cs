namespace DICOM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            path = new TextBox();
            load = new Button();
            browseButton = new Button();
            trackBar1 = new TrackBar();
            canvas = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(path);
            splitContainer1.Panel1.Controls.Add(load);
            splitContainer1.Panel1.Controls.Add(browseButton);
            splitContainer1.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(trackBar1);
            splitContainer1.Panel2.Controls.Add(canvas);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 0;
            // 
            // path
            // 
            path.Location = new Point(38, 23);
            path.Name = "path";
            path.Size = new Size(191, 27);
            path.TabIndex = 3;
            path.Text = "C:\\Users\\marci\\source\\repos\\DICOM\\DICOM\\series-00000";
            path.TextChanged += path_TextChanged;
            // 
            // load
            // 
            load.Location = new Point(135, 56);
            load.Name = "load";
            load.Size = new Size(94, 29);
            load.TabIndex = 2;
            load.Text = "load";
            load.UseVisualStyleBackColor = true;
            load.Click += load_Click;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(35, 56);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(94, 29);
            browseButton.TabIndex = 1;
            browseButton.Text = "browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // trackBar1
            // 
            trackBar1.AutoSize = false;
            trackBar1.BackColor = SystemColors.Control;
            trackBar1.Location = new Point(462, 23);
            trackBar1.Name = "trackBar1";
            trackBar1.Orientation = Orientation.Vertical;
            trackBar1.RightToLeft = RightToLeft.Yes;
            trackBar1.Size = new Size(56, 415);
            trackBar1.TabIndex = 4;
            // 
            // canvas
            // 
            canvas.Dock = DockStyle.Fill;
            canvas.Location = new Point(0, 0);
            canvas.Name = "canvas";
            canvas.Size = new Size(530, 450);
            canvas.TabIndex = 0;
            canvas.TabStop = false;
            canvas.Click += canvas_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button browseButton;
        private Button load;
        private TextBox path;
        private PictureBox canvas;
        private TrackBar trackBar1;
    }
}
