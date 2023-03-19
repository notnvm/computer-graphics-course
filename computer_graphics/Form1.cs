namespace computer_graphics
{
    public partial class Form1 : Form
    {
        Bitmap img;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
                img = new Bitmap(dlg.FileName);

            pictureBox1.Image = img;
            pictureBox1.Refresh();

        }

        private void inverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            invert_filter inverse = new invert_filter();
            backgroundWorker1.RunWorkerAsync(inverse);
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap new_img = ((filters)e.Argument).process_image(img, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                img = new_img;
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = img;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void blurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters blur = new blur_filter();
            backgroundWorker1.RunWorkerAsync(blur);
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filters gaussian = new gaussian_filter();
            backgroundWorker1.RunWorkerAsync(gaussian);
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gray_scale_filter gray_scale = new gray_scale_filter();
            backgroundWorker1.RunWorkerAsync(gray_scale);
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sepia_filter sepia = new sepia_filter();
            backgroundWorker1.RunWorkerAsync(sepia);
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brightness_filter brightness = new brightness_filter();
            backgroundWorker1.RunWorkerAsync(brightness);
        }
    }
}