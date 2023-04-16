namespace computer_graphics
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
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfectReflectorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearStretchHiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.glassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borderSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matMorphologyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dIlationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.erosionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.shiftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(883, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.filtersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(95, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dotToolStripMenuItem,
            this.matrixToolStripMenuItem,
            this.matMorphologyToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // dotToolStripMenuItem
            // 
            this.dotToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inverseToolStripMenuItem,
            this.grayScaleToolStripMenuItem,
            this.sepiaToolStripMenuItem,
            this.brightnessToolStripMenuItem,
            this.perfectReflectorToolStripMenuItem,
            this.linearStretchHiToolStripMenuItem,
            this.waveToolStripMenuItem,
            this.glassesToolStripMenuItem,
            this.shiftToolStripMenuItem});
            this.dotToolStripMenuItem.Name = "dotToolStripMenuItem";
            this.dotToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dotToolStripMenuItem.Text = "Dot";
            // 
            // inverseToolStripMenuItem
            // 
            this.inverseToolStripMenuItem.Name = "inverseToolStripMenuItem";
            this.inverseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inverseToolStripMenuItem.Text = "Inverse";
            this.inverseToolStripMenuItem.Click += new System.EventHandler(this.inverseToolStripMenuItem_Click);
            // 
            // grayScaleToolStripMenuItem
            // 
            this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.grayScaleToolStripMenuItem.Text = "Gray scale";
            this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.grayScaleToolStripMenuItem_Click);
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sepiaToolStripMenuItem.Text = "Sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.brightnessToolStripMenuItem.Text = "Brightness";
            this.brightnessToolStripMenuItem.Click += new System.EventHandler(this.brightnessToolStripMenuItem_Click);
            // 
            // perfectReflectorToolStripMenuItem
            // 
            this.perfectReflectorToolStripMenuItem.Name = "perfectReflectorToolStripMenuItem";
            this.perfectReflectorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.perfectReflectorToolStripMenuItem.Text = "Perfect reflector";
            this.perfectReflectorToolStripMenuItem.Click += new System.EventHandler(this.perfectReflectorToolStripMenuItem_Click);
            // 
            // linearStretchHiToolStripMenuItem
            // 
            this.linearStretchHiToolStripMenuItem.Name = "linearStretchHiToolStripMenuItem";
            this.linearStretchHiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.linearStretchHiToolStripMenuItem.Text = "Linear stretching";
            this.linearStretchHiToolStripMenuItem.Click += new System.EventHandler(this.linearStretchHiToolStripMenuItem_Click);
            // 
            // waveToolStripMenuItem
            // 
            this.waveToolStripMenuItem.Name = "waveToolStripMenuItem";
            this.waveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.waveToolStripMenuItem.Text = "Wave";
            this.waveToolStripMenuItem.Click += new System.EventHandler(this.waveToolStripMenuItem_Click);
            // 
            // glassesToolStripMenuItem
            // 
            this.glassesToolStripMenuItem.Name = "glassesToolStripMenuItem";
            this.glassesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.glassesToolStripMenuItem.Text = "Glasses";
            this.glassesToolStripMenuItem.Click += new System.EventHandler(this.glassesToolStripMenuItem_Click);
            // 
            // matrixToolStripMenuItem
            // 
            this.matrixToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurToolStripMenuItem,
            this.gaussianToolStripMenuItem,
            this.sobelToolStripMenuItem,
            this.sharpnessToolStripMenuItem,
            this.borderSelectionToolStripMenuItem});
            this.matrixToolStripMenuItem.Name = "matrixToolStripMenuItem";
            this.matrixToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.matrixToolStripMenuItem.Text = "Matrix";
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.blurToolStripMenuItem.Text = "Blur";
            this.blurToolStripMenuItem.Click += new System.EventHandler(this.blurToolStripMenuItem_Click);
            // 
            // gaussianToolStripMenuItem
            // 
            this.gaussianToolStripMenuItem.Name = "gaussianToolStripMenuItem";
            this.gaussianToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.gaussianToolStripMenuItem.Text = "Gaussian";
            this.gaussianToolStripMenuItem.Click += new System.EventHandler(this.gaussianToolStripMenuItem_Click);
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.sobelToolStripMenuItem.Text = "Sobel ";
            this.sobelToolStripMenuItem.Click += new System.EventHandler(this.sobelToolStripMenuItem_Click);
            // 
            // sharpnessToolStripMenuItem
            // 
            this.sharpnessToolStripMenuItem.Name = "sharpnessToolStripMenuItem";
            this.sharpnessToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.sharpnessToolStripMenuItem.Text = "Sharpness";
            this.sharpnessToolStripMenuItem.Click += new System.EventHandler(this.sharpnessToolStripMenuItem_Click);
            // 
            // borderSelectionToolStripMenuItem
            // 
            this.borderSelectionToolStripMenuItem.Name = "borderSelectionToolStripMenuItem";
            this.borderSelectionToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.borderSelectionToolStripMenuItem.Text = "Border Selection";
            this.borderSelectionToolStripMenuItem.Click += new System.EventHandler(this.borderSelectionToolStripMenuItem_Click);
            // 
            // matMorphologyToolStripMenuItem
            // 
            this.matMorphologyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dIlationToolStripMenuItem,
            this.erosionToolStripMenuItem,
            this.gradientToolStripMenuItem,
            this.medianToolStripMenuItem});
            this.matMorphologyToolStripMenuItem.Name = "matMorphologyToolStripMenuItem";
            this.matMorphologyToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.matMorphologyToolStripMenuItem.Text = "Mat. morphology";
            // 
            // dIlationToolStripMenuItem
            // 
            this.dIlationToolStripMenuItem.Name = "dIlationToolStripMenuItem";
            this.dIlationToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.dIlationToolStripMenuItem.Text = "Dilation";
            this.dIlationToolStripMenuItem.Click += new System.EventHandler(this.dIlationToolStripMenuItem_Click);
            // 
            // erosionToolStripMenuItem
            // 
            this.erosionToolStripMenuItem.Name = "erosionToolStripMenuItem";
            this.erosionToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.erosionToolStripMenuItem.Text = "Erosion";
            this.erosionToolStripMenuItem.Click += new System.EventHandler(this.erosionToolStripMenuItem_Click);
            // 
            // gradientToolStripMenuItem
            // 
            this.gradientToolStripMenuItem.Name = "gradientToolStripMenuItem";
            this.gradientToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.gradientToolStripMenuItem.Text = "Gradient";
            this.gradientToolStripMenuItem.Click += new System.EventHandler(this.gradientToolStripMenuItem_Click);
            // 
            // medianToolStripMenuItem
            // 
            this.medianToolStripMenuItem.Name = "medianToolStripMenuItem";
            this.medianToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.medianToolStripMenuItem.Text = "Median";
            this.medianToolStripMenuItem.Click += new System.EventHandler(this.medianToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(865, 466);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 501);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(865, 35);
            this.progressBar1.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(98, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(196, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Setup Kernel for morphology";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // shiftToolStripMenuItem
            // 
            this.shiftToolStripMenuItem.Name = "shiftToolStripMenuItem";
            this.shiftToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.shiftToolStripMenuItem.Text = "Shift";
            this.shiftToolStripMenuItem.Click += new System.EventHandler(this.shiftToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 548);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ui";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem filtersToolStripMenuItem;
        private ToolStripMenuItem dotToolStripMenuItem;
        private ToolStripMenuItem inverseToolStripMenuItem;
        private ToolStripMenuItem matrixToolStripMenuItem;
        private PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar progressBar1;
        private ToolStripMenuItem blurToolStripMenuItem;
        private ToolStripMenuItem gaussianToolStripMenuItem;
        private ToolStripMenuItem grayScaleToolStripMenuItem;
        private ToolStripMenuItem sepiaToolStripMenuItem;
        private Label label1;
        private TextBox textBox1;
        private ToolStripMenuItem brightnessToolStripMenuItem;
        private ToolStripMenuItem sobelToolStripMenuItem;
        private ToolStripMenuItem perfectReflectorToolStripMenuItem;
        private ToolStripMenuItem sharpnessToolStripMenuItem;
        private ToolStripMenuItem linearStretchHiToolStripMenuItem;
        private ToolStripMenuItem borderSelectionToolStripMenuItem;
        private ToolStripMenuItem waveToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem glassesToolStripMenuItem;
        private ToolStripMenuItem matMorphologyToolStripMenuItem;
        private ToolStripMenuItem dIlationToolStripMenuItem;
        private ToolStripMenuItem erosionToolStripMenuItem;
        private ToolStripMenuItem gradientToolStripMenuItem;
        private ToolStripMenuItem medianToolStripMenuItem;
        private Button button2;
        private ToolStripMenuItem shiftToolStripMenuItem;
    }
}