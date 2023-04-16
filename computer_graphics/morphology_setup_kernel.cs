using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computer_graphics
{
    public partial class morphology_setup_kernel : Form
    {
        public int n;
        public int[,] kernel;
        public morphology_setup_kernel()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            n = System.Convert.ToInt32(textBox1.Text);
            if (n <= 0)
            {
                MessageBox.Show("Error");
                return;
            }
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;
            kernel = new int[n, n];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    kernel[i, j] = Convert.ToInt32(dataGridView1[i, j].Value);
        }
    }
}
