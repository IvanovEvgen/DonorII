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
    public partial class Form07 : Form
    {
        string IDUsers;
        public Form07(string IDUsers)
        {
            InitializeComponent();
            this.IDUsers = IDUsers;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new Form09(IDUsers);
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new Form5(IDUsers);
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var f = new Form110();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();
        }
    }
}
