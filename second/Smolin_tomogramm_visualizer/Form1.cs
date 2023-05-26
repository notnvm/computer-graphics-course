using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smolin_tomogramm_visualizer
{
    public partial class Form1 : Form
    {
        bin_read bin = new bin_read();
        view view_ = new view();
        int current_layer = 0;
        bool loaded = false;
        bool reload = false;
        int frame_count = 0;
        DateTime next_fps_update = DateTime.Now.AddSeconds(1);
        public Form1()
        {
            InitializeComponent();
        }

        public void display_fps()
        {
            if(DateTime.Now >= next_fps_update)
            {
                this.Text = String.Format("CT Visualizer (fps={0})", frame_count);
                next_fps_update = DateTime.Now.AddSeconds(1);
                frame_count = 0;
            }
            frame_count++;
        }
        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string str = dlg.FileName;
                bin.read_bin(str);
                view_.setup_view(glControl1.Width, glControl1.Height);
                loaded = true;
                trackBar1.Maximum = bin.layer_size() - 1;
                glControl1.Invalidate();
            }
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (loaded)
            {
                if (radioButton2.Checked)
                {
                    if (reload)
                    {
                        view_.generate_texture_image(current_layer);
                        view_.load_2D_texture();
                        reload = false;
                    }
                    view_.draw_texture();
                }
                else
                {
                    if (checkBox1.Checked)
                        view_.draw_quads(current_layer, true);
                    else
                        view_.draw_quads(current_layer, false);

                }

                glControl1.SwapBuffers();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            current_layer = trackBar1.Value;
            reload = true;
            glControl1.Refresh();
        }

        void Application_Idle(object sender, EventArgs e)
        {
            while (glControl1.IsIdle)
            {
                display_fps();
                glControl1.Invalidate();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += Application_Idle;
        }
    }
}
