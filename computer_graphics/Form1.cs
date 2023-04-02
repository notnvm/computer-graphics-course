namespace computer_graphics
{
    public partial class Form1 : Form
    {
        Bitmap img;
        bool not_busy = true;

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
            if (not_busy)
            {
                invert_filter inverse = new invert_filter();
                backgroundWorker1.RunWorkerAsync(inverse);
            }
            else MessageBox.Show("Please wait...");
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            not_busy = false;
            Bitmap new_img = ((filters)e.Argument).process_image(img, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                img = new_img;
            not_busy = true;
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
            if (not_busy)
            {
                filters blur = new blur_filter();
                backgroundWorker1.RunWorkerAsync(blur);
            }
            else MessageBox.Show("Please wait...");
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (not_busy)
            {
                filters gaussian = new gaussian_filter();
                backgroundWorker1.RunWorkerAsync(gaussian);
            }
            else MessageBox.Show("Please wait...");
        }

        private void grayScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (not_busy)
            {
                gray_scale_filter gray_scale = new gray_scale_filter();
                backgroundWorker1.RunWorkerAsync(gray_scale);
            }
            else MessageBox.Show("Please wait...");
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (not_busy)
            {
                sepia_filter sepia = new sepia_filter();
                backgroundWorker1.RunWorkerAsync(sepia);
            }
            else MessageBox.Show("Please wait...");
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (not_busy)
            {
                brightness_filter brightness = new brightness_filter();
                backgroundWorker1.RunWorkerAsync(brightness);
            }
            else MessageBox.Show("Please wait...");
        }

        private void perfectReflectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (not_busy)
            {
                perfect_reflector reflec = new perfect_reflector();
                backgroundWorker1.RunWorkerAsync(reflec);
            }
            else MessageBox.Show("Please wait...");
        }

        private void sharpnessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (not_busy)
            {
                sharpness_filter sharp = new sharpness_filter();
                backgroundWorker1.RunWorkerAsync(sharp);
            }
            else MessageBox.Show("Please wait...");
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (not_busy)
            {
                sobel_filter sobel = new sobel_filter();
                backgroundWorker1.RunWorkerAsync(sobel);
            }
            else MessageBox.Show("Please wait...");
        }

        private void linearStretchHiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (not_busy)
            {
                linear_stretch lin = new linear_stretch();
                backgroundWorker1.RunWorkerAsync(lin);
            }
            else MessageBox.Show("Please wait...");
        }

        private void borderSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (not_busy)
            {
                border_selection br_sl = new border_selection();
                backgroundWorker1.RunWorkerAsync(br_sl);
            }
            else MessageBox.Show("Please wait...");
        }

        private void waveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (not_busy)
            {
                wave_filter wave = new wave_filter();
                backgroundWorker1.RunWorkerAsync(wave);
            }
            else MessageBox.Show("Please wait...");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save as...";

                saveFileDialog.OverwritePrompt = true;
                saveFileDialog.CheckPathExists = true;

                saveFileDialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";

                saveFileDialog.ShowHelp = true;
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        img.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Can't save this file");
                    }
                }
            }
        }
    }
}