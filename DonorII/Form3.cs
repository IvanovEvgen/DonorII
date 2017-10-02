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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Enter your email address";
            textBox1.ForeColor = Color.Gray;
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);

            textBox2.Text = "Enter your password";
            textBox2.ForeColor = Color.Gray;
            textBox2.Font = new Font(textBox2.Font, FontStyle.Italic);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox1.ForeColor = Color.Black;
            textBox1.Font = new Font(textBox2.Font, FontStyle.Regular);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = null;
            textBox2.ForeColor = Color.Black;
            textBox2.Font = new Font(textBox2.Font, FontStyle.Regular);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form1();
            f.ShowDialog();
            this.Close();
        }
    }
}
