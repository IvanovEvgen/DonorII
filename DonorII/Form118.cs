using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DonorII
{
    public partial class Form118 : Form
    {
        public Form118()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new Form119();
            f.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form120();
            f.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();
            this.Close();
        }
    }
}
