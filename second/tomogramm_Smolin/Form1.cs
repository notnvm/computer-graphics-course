using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tomogramm_Smolin
{
    public partial class Form1 : Form
    {
        GLgraphics glGraphics = new GLgraphics();
        public Form1()
        {
            InitializeComponent();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            glGraphics.update();
            glControl1.SwapBuffers();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            int tex_id = glGraphics.load_texture("../../0.jpg");
            glGraphics.tex_ids.Add(tex_id);
            tex_id = glGraphics.load_texture("../../1.jpg");
            glGraphics.tex_ids.Add(tex_id);
            tex_id = glGraphics.load_texture("../../2.jpg");
            glGraphics.tex_ids.Add(tex_id);
            tex_id = glGraphics.load_texture("../../3.jpg");
            glGraphics.tex_ids.Add(tex_id);
            tex_id = glGraphics.load_texture("../../4.jpg");
            glGraphics.tex_ids.Add(tex_id);
            tex_id = glGraphics.load_texture("../../5.jpg");

            glGraphics.tex_ids.Add(tex_id);
            glGraphics.resize(glControl1.Width, glControl1.Height);
            Application.Idle += application_idle;
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            float width_c = (e.X - glControl1.Width * 0.5f) / (float)glControl1.Width;
            float height_c = (-e.Y + glControl1.Height * 0.5f) / (float)glControl1.Height;
            glGraphics.latitude = height_c * 180;
            glGraphics.longitude = width_c * 360;
        }

        private void application_idle(object sender, EventArgs e)
        {
            while (glControl1.IsIdle)
                glControl1.Refresh();
        }
    }
}
